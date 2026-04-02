using System;
using System.Text.Json;
using CAD;

namespace Electrical
{
    public class Solenoid : ElectricalElement
    {
        //  *****************************************************************************************
        //  ENUMERATIONS
        //
        //  ************************************************************
        #region
        public enum SolenoidTypeEnum
        {
            LinearPush = 0,
            LinearPull,
            Rotary,
            Tubular,
            OpenFrame,
            Latching,
            Proportional,
            Other
        }

        public enum DutyCycleEnum
        {
            Continuous = 0,
            Intermittent,
            ShortDuration,
            Other
        }

        public enum MountTypeEnum
        {
            BoltOn = 0,
            Flange,
            ThreadedBody,
            PanelMount,
            PCBMount,
            Other
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  SOLENOID CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public Solenoid()
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
        public CAD_Dimension PlungerDiameter { get; set; }
        public List<CAD_Dimension> MyDimensions { get; set; } = new();
        //
        //  Physical Properties
        public CAD_Parameter Weight { get; set; }
        public SolenoidTypeEnum SolenoidType { get; set; }
        public DutyCycleEnum DutyCycle { get; set; }
        public MountTypeEnum MountType { get; set; }
        //
        //  Coil
        public CAD_Parameter CoilVoltage { get; set; }              //  Volts (nominal)
        public CAD_Parameter CoilResistance { get; set; }           //  Ohms
        public CAD_Parameter CoilCurrent { get; set; }              //  Amps (nominal)
        public CAD_Parameter CoilInductance { get; set; }           //  mH
        public CAD_Parameter CoilPower { get; set; }                //  Watts
        public int NumTurns { get; set; }
        //
        //  Mechanical
        public CAD_Parameter StrokeLength { get; set; }             //  mm
        public CAD_Parameter ForceAtStroke { get; set; }            //  Newtons (at rated stroke)
        public CAD_Parameter HoldingForce { get; set; }             //  Newtons (at zero gap)
        public CAD_Parameter ReturnForce { get; set; }              //  Newtons (spring return)
        public CAD_Parameter ResponseTime { get; set; }             //  ms (energize to full stroke)
        public CAD_Parameter ReleaseTime { get; set; }              //  ms
        public CAD_Parameter MechanicalLife { get; set; }           //  cycles
        //
        //  Operating Conditions
        public CAD_Parameter MaxDutyCyclePercent { get; set; }      //  #
        public CAD_Parameter MinOperatingTemp { get; set; }         //  deg Celsius
        public CAD_Parameter MaxOperatingTemp { get; set; }         //  deg Celsius
        //
        //  State
        public Boolean IsEnergized { get; set; }
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
        //  Energize the solenoid
        public void Energize()
        {
            IsEnergized = true;
        }
        //
        //  De-energize the solenoid
        public void DeEnergize()
        {
            IsEnergized = false;
        }
        //
        //  Calculate coil current from voltage: I = V / R
        public Double CalculateCoilCurrent(Double appliedVoltage)
        {
            if (CoilResistance == null || !CoilResistance.TryGetDouble(out double resistance) || resistance <= 0)
                return 0d;

            return appliedVoltage / resistance;
        }
        //
        //  Calculate coil power dissipation: P = V² / R
        public Double CalculateCoilPower(Double appliedVoltage)
        {
            if (CoilResistance == null || !CoilResistance.TryGetDouble(out double resistance) || resistance <= 0)
                return 0d;

            return appliedVoltage * appliedVoltage / resistance;
        }
        //
        //  Calculate magnetic force estimate: F ∝ (N × I)² / (2 × μ₀ × A)
        //  Simplified to F = k × I² where k is a force constant
        public Double EstimateForce(Double current, Double forceConstant)
        {
            if (forceConstant <= 0)
                return 0d;

            return forceConstant * current * current;
        }
        //
        //  Calculate inductive time constant: τ = L / R
        public Double CalculateTimeConstant()
        {
            if (CoilInductance == null || !CoilInductance.TryGetDouble(out double inductance))
                return 0d;
            if (CoilResistance == null || !CoilResistance.TryGetDouble(out double resistance) || resistance <= 0)
                return 0d;

            return inductance / resistance;
        }
        //
        //  Calculate energy stored in coil: E = ½ × L × I²
        public Double CalculateStoredEnergy(Double current)
        {
            if (CoilInductance == null || !CoilInductance.TryGetDouble(out double inductance))
                return 0d;

            return 0.5d * inductance * current * current;
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
        public static Solenoid? FromJson(string json)
        {
            return JsonSerializer.Deserialize<Solenoid>(json);
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
