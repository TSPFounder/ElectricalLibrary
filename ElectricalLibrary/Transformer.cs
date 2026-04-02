using System;
using System.Text.Json;
using CAD;

namespace Electrical
{
    public class Transformer : ElectricalElement
    {
        //  *****************************************************************************************
        //  ENUMERATIONS
        //
        //  ************************************************************
        #region
        public enum TransformerTypeEnum
        {
            StepUp = 0,
            StepDown,
            Isolation,
            Autotransformer,
            CurrentTransformer,
            Flyback,
            PulseTransformer,
            Other
        }

        public enum CoreTypeEnum
        {
            Laminated = 0,
            Toroidal,
            Ferrite,
            AirCore,
            PowderedIron,
            Amorphous,
            Nanocrystalline,
            Other
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  TRANSFORMER CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public Transformer()
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
        public CoreTypeEnum CoreType { get; set; }
        public TransformerTypeEnum TransformerType { get; set; }
        //
        //  Winding Data
        public int PrimaryTurns { get; set; }
        public int SecondaryTurns { get; set; }
        public CAD_Parameter PrimaryInductance { get; set; }        //  Henries
        public CAD_Parameter PrimaryResistance { get; set; }        //  Ohms (DCR)
        public CAD_Parameter SecondaryResistance { get; set; }      //  Ohms (DCR)
        //
        //  Performance
        public CAD_Parameter InputVoltage { get; set; }             //  Volts (primary)
        public CAD_Parameter OutputVoltage { get; set; }            //  Volts (secondary)
        public CAD_Parameter VARating { get; set; }                 //  VA
        public CAD_Parameter MaxPrimaryCurrent { get; set; }        //  Amps
        public CAD_Parameter MaxSecondaryCurrent { get; set; }      //  Amps
        public CAD_Parameter OperatingFrequency { get; set; }       //  Hz
        public CAD_Parameter Efficiency { get; set; }               //  %
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
        //  Calculate Turns Ratio: a = Np / Ns
        public Double CalculateTurnsRatio()
        {
            if (SecondaryTurns <= 0)
                return 0d;

            return (double)PrimaryTurns / SecondaryTurns;
        }
        //
        //  Calculate Output Voltage: Vs = Vp × (Ns / Np)
        public Double CalculateOutputVoltage(Double inputVoltage)
        {
            if (PrimaryTurns <= 0)
                return 0d;

            return inputVoltage * ((double)SecondaryTurns / PrimaryTurns);
        }
        //
        //  Calculate Output Current: Is = Ip × (Np / Ns)
        public Double CalculateOutputCurrent(Double inputCurrent)
        {
            if (SecondaryTurns <= 0)
                return 0d;

            return inputCurrent * ((double)PrimaryTurns / SecondaryTurns);
        }
        //
        //  Calculate Apparent Power: S = V × I (VA)
        public Double CalculateApparentPower(Double voltage, Double current)
        {
            return voltage * current;
        }
        //
        //  Check if Step-Up (Ns > Np)
        public Boolean IsStepUp()
        {
            return SecondaryTurns > PrimaryTurns;
        }
        //
        //  Check if Step-Down (Ns < Np)
        public Boolean IsStepDown()
        {
            return SecondaryTurns < PrimaryTurns && PrimaryTurns > 0;
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
        //  Check if load current is within secondary rating
        public Boolean IsWithinCurrentRating(Double loadCurrent)
        {
            if (MaxSecondaryCurrent == null || !MaxSecondaryCurrent.TryGetDouble(out double limit))
                return true;

            return loadCurrent <= limit;
        }
        //
        //  To JSON
        public string ToJson()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
        //
        //  From JSON
        public static Transformer? FromJson(string json)
        {
            return JsonSerializer.Deserialize<Transformer>(json);
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
