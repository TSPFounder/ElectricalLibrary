using System;
using System.Text.Json;
using CAD;

namespace Electrical
{
    public class Amplifier : ElectricalElement
    {
        //  *****************************************************************************************
        //  ENUMERATIONS
        //
        //  ************************************************************
        #region
        public enum AmplifierClassEnum
        {
            ClassA = 0,
            ClassB,
            ClassAB,
            ClassD,
            ClassG,
            ClassH,
            Other
        }

        public enum AmplifierTypeEnum
        {
            Operational = 0,
            Power,
            Instrumentation,
            Differential,
            Audio,
            RF,
            Transimpedance,
            Other
        }

        public enum ChannelConfigEnum
        {
            Mono = 0,
            Stereo,
            Bridged,
            MultiChannel,
            Other
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  AMPLIFIER CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public Amplifier()
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
        public AmplifierClassEnum AmplifierClass { get; set; }
        public AmplifierTypeEnum AmplifierType { get; set; }
        public ChannelConfigEnum ChannelConfig { get; set; }
        public int NumChannels { get; set; } = 1;
        //
        //  Power Supply
        public CAD_Parameter SupplyVoltageMin { get; set; }         //  Volts
        public CAD_Parameter SupplyVoltageMax { get; set; }         //  Volts
        public CAD_Parameter QuiescentCurrent { get; set; }         //  Amps (Iq)
        public CAD_Parameter MaxPowerConsumption { get; set; }      //  Watts
        //
        //  Gain
        public CAD_Parameter VoltageGain { get; set; }              //  dB (Av)
        public CAD_Parameter OpenLoopGain { get; set; }             //  dB
        public CAD_Parameter GainBandwidthProduct { get; set; }     //  Hz (GBW)
        //
        //  Input
        public CAD_Parameter InputImpedance { get; set; }           //  Ohms
        public CAD_Parameter InputOffsetVoltage { get; set; }       //  mV
        public CAD_Parameter InputBiasCurrent { get; set; }         //  nA
        public CAD_Parameter CMRR { get; set; }                     //  dB
        //
        //  Output
        public CAD_Parameter OutputImpedance { get; set; }          //  Ohms
        public CAD_Parameter OutputPowerPerChannel { get; set; }    //  Watts (RMS)
        public CAD_Parameter MaxOutputVoltageSwing { get; set; }    //  Volts (peak-to-peak)
        public CAD_Parameter MaxOutputCurrent { get; set; }         //  Amps
        //
        //  Performance
        public CAD_Parameter FrequencyMin { get; set; }             //  Hz
        public CAD_Parameter FrequencyMax { get; set; }             //  Hz
        public CAD_Parameter SlewRate { get; set; }                 //  V/μs
        public CAD_Parameter THD { get; set; }                      //  % (total harmonic distortion)
        public CAD_Parameter SNR { get; set; }                      //  dB (signal-to-noise ratio)
        public CAD_Parameter Efficiency { get; set; }               //  %
        public CAD_Parameter ChannelSeparation { get; set; }        //  dB (crosstalk)
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
        //  Calculate voltage gain in linear from dB: Av = 10^(dB/20)
        public Double CalculateLinearGain()
        {
            if (VoltageGain == null || !VoltageGain.TryGetDouble(out double gainDb))
                return 0d;

            return Math.Pow(10d, gainDb / 20d);
        }
        //
        //  Calculate output voltage: Vout = Vin × Av(linear)
        public Double CalculateOutputVoltage(Double inputVoltage)
        {
            double linearGain = CalculateLinearGain();
            if (linearGain <= 0)
                return 0d;

            return inputVoltage * linearGain;
        }
        //
        //  Calculate output power into a load: P = Vout² / Zload
        public Double CalculateOutputPower(Double inputVoltage, Double loadImpedance)
        {
            if (loadImpedance <= 0)
                return 0d;

            double vout = CalculateOutputVoltage(inputVoltage);
            return vout * vout / loadImpedance;
        }
        //
        //  Calculate total power output across all channels
        public Double CalculateTotalOutputPower()
        {
            if (OutputPowerPerChannel == null || !OutputPowerPerChannel.TryGetDouble(out double perChannel))
                return 0d;

            return perChannel * NumChannels;
        }
        //
        //  Check if frequency is within amplifier bandwidth
        public Boolean IsWithinBandwidth(Double frequencyHz)
        {
            if (FrequencyMin == null || !FrequencyMin.TryGetDouble(out double fMin))
                return true;
            if (FrequencyMax == null || !FrequencyMax.TryGetDouble(out double fMax))
                return true;

            return frequencyHz >= fMin && frequencyHz <= fMax;
        }
        //
        //  Check if output current is within rating
        public Boolean IsWithinCurrentRating(Double outputCurrent)
        {
            if (MaxOutputCurrent == null || !MaxOutputCurrent.TryGetDouble(out double limit))
                return true;

            return outputCurrent <= limit;
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
        public static Amplifier? FromJson(string json)
        {
            return JsonSerializer.Deserialize<Amplifier>(json);
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
