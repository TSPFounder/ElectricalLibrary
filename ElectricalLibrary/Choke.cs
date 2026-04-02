using System;
using System.Text.Json;
using CAD;

namespace Electrical
{
    public class Choke : ElectricalElement
    {
        //  *****************************************************************************************
        //  ENUMERATIONS
        //
        //  ************************************************************
        #region
        public enum ChokeTypeEnum
        {
            CommonMode = 0,
            DifferentialMode,
            PowerLine,
            RF,
            FerriteBead,
            Other
        }

        public enum CoreTypeEnum
        {
            Ferrite = 0,
            PowderedIron,
            Toroidal,
            Laminated,
            Nanocrystalline,
            AirCore,
            Other
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  CHOKE CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public Choke()
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
        public List<CAD_Dimension> MyDimensions { get; set; } = new();
        //
        //  Physical Properties
        public CAD_Parameter Weight { get; set; }
        public ChokeTypeEnum ChokeType { get; set; }
        public CoreTypeEnum CoreType { get; set; }
        public int NumWindings { get; set; }
        //
        //  Performance
        public CAD_Parameter NominalInductance { get; set; }        //  Henries
        public CAD_Parameter DCResistance { get; set; }             //  Ohms (DCR)
        public CAD_Parameter MaxDCCurrent { get; set; }             //  Amps (saturation)
        public CAD_Parameter MaxACCurrent { get; set; }             //  Amps (RMS)
        public CAD_Parameter RatedVoltage { get; set; }             //  Volts
        public CAD_Parameter SelfResonantFrequency { get; set; }    //  Hz
        public CAD_Parameter ImpedanceAt100kHz { get; set; }        //  Ohms
        public CAD_Parameter InsertionLoss { get; set; }            //  dB
        public CAD_Parameter Tolerance { get; set; }                //  %
        public CAD_Parameter MinOperatingTemp { get; set; }         //  deg Celsius
        public CAD_Parameter MaxOperatingTemp { get; set; }         //  deg Celsius
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
        //  Calculate Inductive Reactance: XL = 2πfL
        public Double CalculateReactance(Double frequencyHz)
        {
            if (NominalInductance == null || !NominalInductance.TryGetDouble(out double inductance))
                return 0d;

            return 2d * Math.PI * frequencyHz * inductance;
        }
        //
        //  Calculate Impedance: Z = √(R² + XL²)
        public Double CalculateImpedance(Double frequencyHz)
        {
            double xl = CalculateReactance(frequencyHz);

            if (DCResistance == null || !DCResistance.TryGetDouble(out double dcr))
                return xl;

            return Math.Sqrt(dcr * dcr + xl * xl);
        }
        //
        //  Check if DC current is within saturation rating
        public Boolean IsWithinCurrentRating(Double current)
        {
            if (MaxDCCurrent == null || !MaxDCCurrent.TryGetDouble(out double limit))
                return true;

            return current <= limit;
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
        public static Choke? FromJson(string json)
        {
            return JsonSerializer.Deserialize<Choke>(json);
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
