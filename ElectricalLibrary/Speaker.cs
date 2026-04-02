using System;
using System.Text.Json;
using CAD;

namespace Electrical
{
    public class Speaker : ElectricalElement
    {
        //  *****************************************************************************************
        //  ENUMERATIONS
        //
        //  ************************************************************
        #region
        public enum SpeakerTypeEnum
        {
            Dynamic = 0,
            Electrostatic,
            Planar,
            Piezoelectric,
            Ribbon,
            Horn,
            Coaxial,
            Other
        }

        public enum DriverSizeEnum
        {
            Tweeter = 0,
            MidRange,
            Woofer,
            Subwoofer,
            FullRange,
            Other
        }

        public enum EnclosureTypeEnum
        {
            SealedBox = 0,
            BassReflex,
            BandPass,
            OpenBaffle,
            HornLoaded,
            InfiniteWall,
            None,
            Other
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  SPEAKER CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public Speaker()
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
        public CAD_Dimension OverallDiameter { get; set; }
        public CAD_Dimension MountingDiameter { get; set; }
        public CAD_Dimension Depth { get; set; }
        public List<CAD_Dimension> MyDimensions { get; set; } = new();
        //
        //  Physical Properties
        public CAD_Parameter Weight { get; set; }
        public SpeakerTypeEnum SpeakerType { get; set; }
        public DriverSizeEnum DriverSize { get; set; }
        public EnclosureTypeEnum EnclosureType { get; set; }
        //
        //  Electrical
        public CAD_Parameter NominalImpedance { get; set; }         //  Ohms
        public CAD_Parameter DCResistance { get; set; }             //  Ohms (Re)
        public CAD_Parameter RatedPower { get; set; }               //  Watts (RMS)
        public CAD_Parameter PeakPower { get; set; }                //  Watts
        public CAD_Parameter InductanceVoiceCoil { get; set; }      //  mH (Le)
        //
        //  Acoustic
        public CAD_Parameter Sensitivity { get; set; }              //  dB (1W/1m)
        public CAD_Parameter FrequencyMin { get; set; }             //  Hz
        public CAD_Parameter FrequencyMax { get; set; }             //  Hz
        public CAD_Parameter ResonantFrequency { get; set; }        //  Hz (Fs)
        public CAD_Parameter MaxSPL { get; set; }                   //  dB
        //
        //  Thiele-Small Parameters
        public CAD_Parameter Qts { get; set; }                      //  total Q factor
        public CAD_Parameter Qes { get; set; }                      //  electrical Q factor
        public CAD_Parameter Qms { get; set; }                      //  mechanical Q factor
        public CAD_Parameter Vas { get; set; }                      //  litres (equivalent volume)
        public CAD_Parameter Xmax { get; set; }                     //  mm (max excursion)
        public CAD_Parameter Sd { get; set; }                       //  cm² (effective cone area)
        public CAD_Parameter BL { get; set; }                       //  T·m (force factor)
        //
        //  Operating Conditions
        public CAD_Parameter MinOperatingTemp { get; set; }         //  deg Celsius
        public CAD_Parameter MaxOperatingTemp { get; set; }         //  deg Celsius
        //
        //  Owned & Owning Objects
        public List<CAD_Hole> MountingHoles { get; set; } = new();

        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  METHODS
        //
        //  ************************************************************
        #region
        //
        //  Calculate max RMS voltage from rated power: V = √(P × Z)
        public Double CalculateMaxVoltage()
        {
            if (RatedPower == null || !RatedPower.TryGetDouble(out double power))
                return 0d;
            if (NominalImpedance == null || !NominalImpedance.TryGetDouble(out double impedance) || impedance <= 0)
                return 0d;

            return Math.Sqrt(power * impedance);
        }
        //
        //  Calculate max RMS current from rated power: I = √(P / Z)
        public Double CalculateMaxCurrent()
        {
            if (RatedPower == null || !RatedPower.TryGetDouble(out double power))
                return 0d;
            if (NominalImpedance == null || !NominalImpedance.TryGetDouble(out double impedance) || impedance <= 0)
                return 0d;

            return Math.Sqrt(power / impedance);
        }
        //
        //  Calculate power delivered at a given voltage: P = V² / Z
        public Double CalculatePowerAtVoltage(Double rmsVoltage)
        {
            if (NominalImpedance == null || !NominalImpedance.TryGetDouble(out double impedance) || impedance <= 0)
                return 0d;

            return rmsVoltage * rmsVoltage / impedance;
        }
        //
        //  Estimate SPL at a given power: SPL = Sensitivity + 10 × log10(P)
        public Double EstimateSPL(Double powerWatts)
        {
            if (Sensitivity == null || !Sensitivity.TryGetDouble(out double sens) || powerWatts <= 0)
                return 0d;

            return sens + 10d * Math.Log10(powerWatts);
        }
        //
        //  Check if frequency is within operating bandwidth
        public Boolean IsWithinFrequencyRange(Double frequencyHz)
        {
            if (FrequencyMin == null || !FrequencyMin.TryGetDouble(out double fMin))
                return true;
            if (FrequencyMax == null || !FrequencyMax.TryGetDouble(out double fMax))
                return true;

            return frequencyHz >= fMin && frequencyHz <= fMax;
        }
        //
        //  Check if input power is within rated power
        public Boolean IsWithinPowerRating(Double powerWatts)
        {
            if (RatedPower == null || !RatedPower.TryGetDouble(out double limit))
                return true;

            return powerWatts <= limit;
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
        public static Speaker? FromJson(string json)
        {
            return JsonSerializer.Deserialize<Speaker>(json);
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
