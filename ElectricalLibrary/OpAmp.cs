using System;
using System.Text.Json;
using CAD;

namespace Electrical
{
    public class OpAmp : ElectricalElement
    {
        //  *****************************************************************************************
        //  ENUMERATIONS
        //
        //  ************************************************************
        #region
        public enum OpAmpTopologyEnum
        {
            VoltageFollower = 0,
            NonInverting,
            Inverting,
            Differential,
            Instrumentation,
            Transimpedance,
            Summing,
            Integrator,
            Differentiator,
            Comparator,
            Other
        }

        public enum PackageTypeEnum
        {
            DIP8 = 0,
            DIP14,
            SOIC8,
            SOIC14,
            TSSOP,
            MSOP,
            SOT23_5,
            QFN,
            BGA,
            Other
        }

        public enum InputStageEnum
        {
            BJT = 0,
            JFET,
            CMOS,
            BiCMOS,
            Other
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  OPAMP CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public OpAmp()
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
        public String PartNumber { get; set; } = string.Empty;
        //
        //  Package & Dimensions
        public PackageTypeEnum PackageType { get; set; }
        public int NumPins { get; set; }
        public int NumAmplifiers { get; set; } = 1;                 //  single, dual, quad
        public Boolean IsSurfaceMount { get; set; }
        public CAD_Dimension Length { get; set; }
        public CAD_Dimension Width { get; set; }
        public CAD_Dimension Height { get; set; }
        public CAD_Dimension PinPitch { get; set; }                 //  mm
        public CAD_Dimension PadSize { get; set; }                  //  mm (PCB land pattern)
        public List<CAD_Dimension> MyDimensions { get; set; } = new();
        //
        //  Physical Properties
        public CAD_Parameter Weight { get; set; }
        public InputStageEnum InputStage { get; set; }
        public OpAmpTopologyEnum DefaultTopology { get; set; }
        //
        //  Power Supply
        public CAD_Parameter SupplyVoltageMin { get; set; }         //  Volts (V+ - V-)
        public CAD_Parameter SupplyVoltageMax { get; set; }         //  Volts (V+ - V-)
        public CAD_Parameter QuiescentCurrent { get; set; }         //  Amps (Iq, per amp)
        public Boolean IsRailToRailInput { get; set; }
        public Boolean IsRailToRailOutput { get; set; }
        public Boolean IsSingleSupply { get; set; }
        //
        //  Input
        public CAD_Parameter InputOffsetVoltage { get; set; }       //  μV (Vos)
        public CAD_Parameter InputBiasCurrent { get; set; }         //  nA (Ib)
        public CAD_Parameter InputOffsetCurrent { get; set; }       //  nA (Ios)
        public CAD_Parameter InputImpedance { get; set; }           //  Ohms (Zin)
        public CAD_Parameter InputVoltageRangeMin { get; set; }     //  Volts
        public CAD_Parameter InputVoltageRangeMax { get; set; }     //  Volts
        public CAD_Parameter InputNoiseVoltage { get; set; }        //  nV/√Hz (en)
        public CAD_Parameter InputNoiseCurrent { get; set; }        //  pA/√Hz (in)
        public CAD_Parameter CMRR { get; set; }                     //  dB
        public CAD_Parameter PSRR { get; set; }                     //  dB
        //
        //  Output
        public CAD_Parameter OutputVoltageSwingPos { get; set; }    //  Volts (from V+ rail)
        public CAD_Parameter OutputVoltageSwingNeg { get; set; }    //  Volts (from V- rail)
        public CAD_Parameter MaxOutputCurrent { get; set; }         //  Amps
        public CAD_Parameter OutputImpedance { get; set; }          //  Ohms (Zout, open-loop)
        public CAD_Parameter ShortCircuitCurrent { get; set; }      //  Amps (Isc)
        //
        //  AC Performance
        public CAD_Parameter OpenLoopGain { get; set; }             //  dB (Aol)
        public CAD_Parameter UnityGainBandwidth { get; set; }       //  Hz (GBW / fT)
        public CAD_Parameter SlewRate { get; set; }                 //  V/μs
        public CAD_Parameter PhaseMargin { get; set; }              //  degrees
        public CAD_Parameter GainMargin { get; set; }               //  dB
        public CAD_Parameter SettlingTime { get; set; }             //  μs (to 0.1%)
        //
        //  PCB Layout
        public CAD_Parameter RecommendedViaSize { get; set; }      //  mm (for bypass/decoupling)
        public int NumBypassCapacitors { get; set; }
        public int NumPowerLayers { get; set; }
        public int NumSignalLayers { get; set; }
        public Boolean RequiresGroundPlane { get; set; }
        public CAD_Dimension MinDecouplingDistance { get; set; }     //  mm (cap to pin)
        //
        //  Operating Conditions
        public CAD_Parameter MinOperatingTemp { get; set; }         //  deg Celsius
        public CAD_Parameter MaxOperatingTemp { get; set; }         //  deg Celsius
        //
        //  Owned & Owning Objects
        public ElectricalPin CurrentPin { get; set; }
        public List<ElectricalPin> MyPins { get; set; } = new();
        public List<CAD_Hole> MountingHoles { get; set; } = new();

        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  METHODS
        //
        //  ************************************************************
        #region
        //
        //  Calculate non-inverting closed-loop gain: Acl = 1 + (Rf / Ri)
        public Double CalculateNonInvertingGain(Double feedbackResistance, Double inputResistance)
        {
            if (inputResistance <= 0)
                return 0d;

            return 1d + feedbackResistance / inputResistance;
        }
        //
        //  Calculate inverting closed-loop gain: Acl = -(Rf / Ri)
        public Double CalculateInvertingGain(Double feedbackResistance, Double inputResistance)
        {
            if (inputResistance <= 0)
                return 0d;

            return -(feedbackResistance / inputResistance);
        }
        //
        //  Calculate non-inverting output voltage: Vout = Vin × (1 + Rf/Ri)
        public Double CalculateNonInvertingOutput(Double inputVoltage, Double feedbackResistance, Double inputResistance)
        {
            return inputVoltage * CalculateNonInvertingGain(feedbackResistance, inputResistance);
        }
        //
        //  Calculate inverting output voltage: Vout = -Vin × (Rf/Ri)
        public Double CalculateInvertingOutput(Double inputVoltage, Double feedbackResistance, Double inputResistance)
        {
            return inputVoltage * CalculateInvertingGain(feedbackResistance, inputResistance);
        }
        //
        //  Calculate closed-loop bandwidth: BW = GBW / |Acl|
        public Double CalculateClosedLoopBandwidth(Double closedLoopGain)
        {
            if (UnityGainBandwidth == null || !UnityGainBandwidth.TryGetDouble(out double gbw))
                return 0d;
            if (closedLoopGain == 0)
                return 0d;

            return gbw / Math.Abs(closedLoopGain);
        }
        //
        //  Calculate maximum output frequency before slew rate limiting: f = SR / (2π × Vpeak)
        public Double CalculateFullPowerBandwidth(Double peakOutputVoltage)
        {
            if (SlewRate == null || !SlewRate.TryGetDouble(out double sr) || peakOutputVoltage <= 0)
                return 0d;

            return (sr * 1e6d) / (2d * Math.PI * peakOutputVoltage);
        }
        //
        //  Calculate total quiescent power: Pq = Vsupply × Iq × NumAmplifiers
        public Double CalculateQuiescentPower(Double supplyVoltage)
        {
            if (QuiescentCurrent == null || !QuiescentCurrent.TryGetDouble(out double iq))
                return 0d;

            return supplyVoltage * iq * NumAmplifiers;
        }
        //
        //  Calculate output noise voltage: en_out = en_in × |Acl| (simplified, resistor noise excluded)
        public Double EstimateOutputNoise(Double closedLoopGain)
        {
            if (InputNoiseVoltage == null || !InputNoiseVoltage.TryGetDouble(out double enIn))
                return 0d;

            return enIn * Math.Abs(closedLoopGain);
        }
        //
        //  Check if supply voltage is within operating range
        public Boolean IsWithinSupplyRange(Double supplyVoltage)
        {
            if (SupplyVoltageMin == null || !SupplyVoltageMin.TryGetDouble(out double vMin))
                return true;
            if (SupplyVoltageMax == null || !SupplyVoltageMax.TryGetDouble(out double vMax))
                return true;

            return supplyVoltage >= vMin && supplyVoltage <= vMax;
        }
        //
        //  Check if output voltage is within swing limits for given supply rails
        public Boolean IsWithinOutputSwing(Double outputVoltage, Double positiveRail, Double negativeRail)
        {
            double maxOut = positiveRail;
            double minOut = negativeRail;

            if (OutputVoltageSwingPos != null && OutputVoltageSwingPos.TryGetDouble(out double dropPos))
                maxOut = positiveRail - dropPos;
            if (OutputVoltageSwingNeg != null && OutputVoltageSwingNeg.TryGetDouble(out double dropNeg))
                minOut = negativeRail + dropNeg;

            return outputVoltage >= minOut && outputVoltage <= maxOut;
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
        //  Add Pin
        public void AddPin(ElectricalPin pin)
        {
            CurrentPin = pin;
            MyPins.Add(pin);
        }
        //
        //  Get Pin Count
        public int GetPinCount()
        {
            return MyPins.Count;
        }
        //
        //  To JSON
        public string ToJson()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
        //
        //  From JSON
        public static OpAmp? FromJson(string json)
        {
            return JsonSerializer.Deserialize<OpAmp>(json);
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
