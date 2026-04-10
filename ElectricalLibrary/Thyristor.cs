using System;
using System.Text.Json;
using CAD;

namespace Electrical
{
    public class Thyristor : ElectricalElement
    {
        //  *****************************************************************************************
        //  ENUMERATIONS
        //
        //  ************************************************************
        #region
        public enum ThyristorTypeEnum
        {
            SCR = 0,
            TRIAC,
            DIAC,
            GTO,
            MCT,
            IGCT,
            SCS,
            Other
        }

        public enum TriggerModeEnum
        {
            GateTrigger = 0,
            VoltageTrigger,
            LightTrigger,
            Other
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  THYRISTOR CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public Thyristor()
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
        //  Physical Properties
        public CAD_Parameter Weight { get; set; }
        public ThyristorTypeEnum ThyristorType { get; set; }
        public TriggerModeEnum TriggerMode { get; set; }
        //
        //  Voltage Ratings
        public CAD_Parameter MaxForwardVoltage { get; set; }        //  Volts (VDRM, repetitive peak off-state)
        public CAD_Parameter MaxReverseVoltage { get; set; }        //  Volts (VRRM, repetitive peak reverse)
        public CAD_Parameter ForwardVoltageDrop { get; set; }       //  Volts (VT, on-state)
        public CAD_Parameter BreakoverVoltage { get; set; }         //  Volts (VBO)
        //
        //  Current Ratings
        public CAD_Parameter MaxOnStateCurrent { get; set; }        //  Amps (IT(RMS), continuous)
        public CAD_Parameter MaxSurgeCurrent { get; set; }          //  Amps (ITSM, non-repetitive peak)
        public CAD_Parameter MaxAverageCurrent { get; set; }        //  Amps (IT(AV))
        public CAD_Parameter HoldingCurrent { get; set; }           //  Amps (IH, min to stay latched)
        public CAD_Parameter LatchingCurrent { get; set; }          //  Amps (IL, min to turn on)
        //
        //  Gate
        public CAD_Parameter GateTriggerVoltage { get; set; }       //  Volts (VGT)
        public CAD_Parameter GateTriggerCurrent { get; set; }       //  Amps (IGT)
        public CAD_Parameter MaxGatePower { get; set; }             //  Watts (PGM)
        //
        //  Timing
        public CAD_Parameter TurnOnTime { get; set; }               //  μs (tgt)
        public CAD_Parameter TurnOffTime { get; set; }              //  μs (tq, circuit-commutated)
        public CAD_Parameter I2t { get; set; }                      //  A²s (fusing)
        //
        //  Power
        public CAD_Parameter MaxPowerDissipation { get; set; }      //  Watts
        public CAD_Parameter MaxJunctionTemp { get; set; }          //  deg Celsius (Tj)
        public CAD_Parameter ThermalResistance { get; set; }        //  °C/W (Rth junction-to-case)
        //
        //  Operating Conditions
        public CAD_Parameter MinOperatingTemp { get; set; }         //  deg Celsius
        public CAD_Parameter MaxOperatingTemp { get; set; }         //  deg Celsius
        //
        //  State
        public Boolean IsConducting { get; set; }
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
        //  Calculate on-state power dissipation: P = VT × IT
        public Double CalculatePowerDissipation(Double onStateCurrent)
        {
            if (ForwardVoltageDrop == null || !ForwardVoltageDrop.TryGetDouble(out double vt))
                return 0d;

            return vt * onStateCurrent;
        }
        //
        //  Calculate junction temperature: Tj = Ta + (P × Rth)
        public Double CalculateJunctionTemp(Double ambientTemp, Double powerDissipation)
        {
            if (ThermalResistance == null || !ThermalResistance.TryGetDouble(out double rth))
                return ambientTemp;

            return ambientTemp + powerDissipation * rth;
        }
        //
        //  Check if gate trigger will fire the thyristor
        public Boolean WillTrigger(Double gateVoltage, Double gateCurrent)
        {
            if (GateTriggerVoltage == null || !GateTriggerVoltage.TryGetDouble(out double vgt))
                return false;
            if (GateTriggerCurrent == null || !GateTriggerCurrent.TryGetDouble(out double igt))
                return false;

            return gateVoltage >= vgt && gateCurrent >= igt;
        }
        //
        //  Check if load current is above holding current (stays latched)
        public Boolean WillRemainLatched(Double loadCurrent)
        {
            if (HoldingCurrent == null || !HoldingCurrent.TryGetDouble(out double ih))
                return false;

            return loadCurrent >= ih;
        }
        //
        //  Check if current is above latching current (turns on fully)
        public Boolean WillLatch(Double anodeCurrent)
        {
            if (LatchingCurrent == null || !LatchingCurrent.TryGetDouble(out double il))
                return false;

            return anodeCurrent >= il;
        }
        //
        //  Check if on-state current is within rating
        public Boolean IsWithinCurrentRating(Double rmsCurrent)
        {
            if (MaxOnStateCurrent == null || !MaxOnStateCurrent.TryGetDouble(out double limit))
                return true;

            return rmsCurrent <= limit;
        }
        //
        //  Check if forward voltage is within blocking rating
        public Boolean IsWithinVoltageRating(Double forwardVoltage)
        {
            if (MaxForwardVoltage == null || !MaxForwardVoltage.TryGetDouble(out double limit))
                return true;

            return forwardVoltage <= limit;
        }
        //
        //  Calculate I²t for a given surge: I²t = I² × t
        public Double CalculateI2t(Double surgeCurrent, Double durationSeconds)
        {
            return surgeCurrent * surgeCurrent * durationSeconds;
        }
        //
        //  Check if surge is within I²t fusing rating
        public Boolean IsWithinI2tRating(Double surgeCurrent, Double durationSeconds)
        {
            if (I2t == null || !I2t.TryGetDouble(out double limit))
                return true;

            return CalculateI2t(surgeCurrent, durationSeconds) <= limit;
        }
        //
        //  Calculate average conduction loss for half-wave (single SCR): P = VT × IT(AV)
        //  For a resistive load with firing angle α: IT(AV) = (Ipeak / 2π) × (1 + cos(α))
        public Double CalculateAverageCurrent(Double peakCurrent, Double firingAngleDegrees)
        {
            double alphaRad = firingAngleDegrees * Math.PI / 180d;
            return (peakCurrent / (2d * Math.PI)) * (1d + Math.Cos(alphaRad));
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
        public static Thyristor? FromJson(string json)
        {
            return JsonSerializer.Deserialize<Thyristor>(json);
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
