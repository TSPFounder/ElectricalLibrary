using System;
using System.Text.Json;
using CAD;

namespace Electrical
{
    public class Potentiometer : ElectricalElement
    {
        //  *****************************************************************************************
        //  ENUMERATIONS
        //
        //  ************************************************************
        #region
        public enum PotentiometerTypeEnum
        {
            Rotary = 0,
            Slider,
            Trimmer,
            MultiTurn,
            DigitalPot,
            Other
        }

        public enum TaperTypeEnum
        {
            Linear = 0,
            Logarithmic,
            AntiLogarithmic,
            Other
        }

        public enum ElementTypeEnum
        {
            CarbonFilm = 0,
            CermetFilm,
            Wirewound,
            ConductivePlastic,
            Other
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  POTENTIOMETER CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public Potentiometer()
        {
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  PROPERTIES
        //
        //  ************************************************************
        #region
        //
        //  Identification
        public String Make { get; set; } = string.Empty;
        public String Model { get; set; } = string.Empty;
        public String Version { get; set; } = string.Empty;
        //
        //  Dimensions
        public CAD_Dimension Length { get; set; }
        public CAD_Dimension Width { get; set; }
        public CAD_Dimension Height { get; set; }
        public CAD_Dimension ShaftDiameter { get; set; }
        public CAD_Dimension ShaftLength { get; set; }
        public List<CAD_Dimension> MyDimensions { get; set; } = new();
        //
        //  Physical Properties
        public CAD_Parameter Weight { get; set; }
        public PotentiometerTypeEnum PotentiometerType { get; set; }
        public TaperTypeEnum TaperType { get; set; }
        public ElementTypeEnum ElementType { get; set; }
        public int NumTurns { get; set; } = 1;
        //
        //  Performance
        public CAD_Parameter TotalResistance { get; set; }          //  Ohms
        public CAD_Parameter Tolerance { get; set; }                //  %
        public CAD_Parameter PowerRating { get; set; }              //  Watts
        public CAD_Parameter MaxVoltage { get; set; }               //  Volts
        public CAD_Parameter TemperatureCoefficient { get; set; }   //  ppm/°C
        public CAD_Parameter ContactResistance { get; set; }        //  Ohms (wiper)
        public CAD_Parameter RotationalLife { get; set; }           //  cycles
        public CAD_Parameter MinOperatingTemp { get; set; }         //  deg Celsius
        public CAD_Parameter MaxOperatingTemp { get; set; }         //  deg Celsius
        //
        //  State
        public Double WiperPosition { get; set; }                   //  0.0 to 1.0
        //
        //  Owned & Owning Objects

        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  METHODS
        //
        //  ************************************************************
        #region
        //
        //  Calculate resistance between wiper and terminal 1: R1 = Rtotal × position
        public Double CalculateResistanceAtWiper()
        {
            if (TotalResistance == null || !TotalResistance.TryGetDouble(out double total))
                return 0d;

            return total * Math.Clamp(WiperPosition, 0d, 1d);
        }
        //
        //  Calculate resistance between wiper and terminal 2: R2 = Rtotal × (1 - position)
        public Double CalculateComplementResistance()
        {
            if (TotalResistance == null || !TotalResistance.TryGetDouble(out double total))
                return 0d;

            return total * (1d - Math.Clamp(WiperPosition, 0d, 1d));
        }
        //
        //  Calculate output voltage (voltage divider): Vout = Vin × position
        public Double CalculateOutputVoltage(Double inputVoltage)
        {
            return inputVoltage * Math.Clamp(WiperPosition, 0d, 1d);
        }
        //
        //  Calculate power dissipation at wiper: P = V² / Rtotal
        public Double CalculatePowerDissipation(Double appliedVoltage)
        {
            if (TotalResistance == null || !TotalResistance.TryGetDouble(out double total) || total <= 0)
                return 0d;

            return appliedVoltage * appliedVoltage / total;
        }
        //
        //  Check if power dissipation is within rating
        public Boolean IsWithinPowerRating(Double appliedVoltage)
        {
            if (PowerRating == null || !PowerRating.TryGetDouble(out double limit))
                return true;

            return CalculatePowerDissipation(appliedVoltage) <= limit;
        }
        //
        //  Check if within operating temperature range
        public Boolean IsWithinOperatingTemp(Double temperature)
        {
            if (MinOperatingTemp == null || !MinOperatingTemp.TryGetDouble(out double minTemp))
                return true;
            if (MaxOperatingTemp == null || !MaxOperatingTemp.TryGetDouble(out double maxTemp))
                return true;

            return temperature >= minTemp && temperature <= maxTemp;
        }
        //
        //  To JSON
        public string ToJson()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
        //
        //  From JSON
        public static Potentiometer? FromJson(string json)
        {
            return JsonSerializer.Deserialize<Potentiometer>(json);
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  EVENTS
        //
        //  ************************************************************
        #region

        #endregion
        //  *****************************************************************************************
    }
}
