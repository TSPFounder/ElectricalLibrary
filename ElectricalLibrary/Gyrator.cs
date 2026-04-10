using System;
using System.Text.Json;
using CAD;

namespace Electrical
{
    public class Gyrator : ElectricalElement
    {
        //  *****************************************************************************************
        //  ENUMERATIONS
        //
        //  ************************************************************
        #region
        public enum GyratorTypeEnum
        {
            Passive = 0,
            Active,
            OpAmpBased,
            TransistorBased,
            Ideal,
            Other
        }

        public enum ApplicationEnum
        {
            InductorSimulation = 0,
            ImpedanceInversion,
            FilterDesign,
            ImpedanceMatching,
            Other
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  GYRATOR CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public Gyrator()
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
        public GyratorTypeEnum GyratorType { get; set; }
        public ApplicationEnum Application { get; set; }
        //
        //  Gyration Resistance
        public CAD_Parameter GyrationResistance { get; set; }       //  Ohms (R)
        //
        //  Port 1
        public CAD_Parameter Port1Voltage { get; set; }             //  Volts
        public CAD_Parameter Port1Current { get; set; }             //  Amps
        public CAD_Parameter Port1Impedance { get; set; }           //  Ohms
        //
        //  Port 2
        public CAD_Parameter Port2Voltage { get; set; }             //  Volts
        public CAD_Parameter Port2Current { get; set; }             //  Amps
        public CAD_Parameter Port2Impedance { get; set; }           //  Ohms
        //
        //  Performance
        public CAD_Parameter FrequencyMin { get; set; }             //  Hz
        public CAD_Parameter FrequencyMax { get; set; }             //  Hz
        public CAD_Parameter MaxPowerDissipation { get; set; }      //  Watts
        public CAD_Parameter SupplyVoltageMin { get; set; }         //  Volts (active types)
        public CAD_Parameter SupplyVoltageMax { get; set; }         //  Volts (active types)
        public CAD_Parameter MinOperatingTemp { get; set; }         //  deg Celsius
        public CAD_Parameter MaxOperatingTemp { get; set; }         //  deg Celsius
        //
        //  Simulated Component Values (inductor simulation)
        public CAD_Parameter LoadCapacitance { get; set; }          //  Farads (C at port 2)
        public CAD_Parameter SimulatedInductance { get; set; }      //  Henries (L = R² × C)
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
        //  Calculate inverted impedance: Z_out = R² / Z_in
        public Double CalculateInvertedImpedance(Double inputImpedance)
        {
            if (GyrationResistance == null || !GyrationResistance.TryGetDouble(out double r) || inputImpedance <= 0)
                return 0d;

            return r * r / inputImpedance;
        }
        //
        //  Calculate simulated inductance from capacitor: L = R² × C
        public Double CalculateSimulatedInductance(Double capacitanceFarads)
        {
            if (GyrationResistance == null || !GyrationResistance.TryGetDouble(out double r))
                return 0d;

            return r * r * capacitanceFarads;
        }
        //
        //  Calculate required capacitance for target inductance: C = L / R²
        public Double CalculateRequiredCapacitance(Double targetInductanceHenries)
        {
            if (GyrationResistance == null || !GyrationResistance.TryGetDouble(out double r) || r <= 0)
                return 0d;

            return targetInductanceHenries / (r * r);
        }
        //
        //  Calculate port 1 voltage from port 2 current: V1 = R × I2
        public Double CalculatePort1Voltage(Double port2Current)
        {
            if (GyrationResistance == null || !GyrationResistance.TryGetDouble(out double r))
                return 0d;

            return r * port2Current;
        }
        //
        //  Calculate port 2 voltage from port 1 current: V2 = R × I1
        public Double CalculatePort2Voltage(Double port1Current)
        {
            if (GyrationResistance == null || !GyrationResistance.TryGetDouble(out double r))
                return 0d;

            return r * port1Current;
        }
        //
        //  Calculate capacitive reactance inverted to inductive reactance
        //  XL = R² / XC = R² × ω × C = R² × 2πfC
        public Double CalculateSimulatedReactance(Double frequencyHz, Double capacitanceFarads)
        {
            if (GyrationResistance == null || !GyrationResistance.TryGetDouble(out double r))
                return 0d;

            return r * r * 2d * Math.PI * frequencyHz * capacitanceFarads;
        }
        //
        //  Check if frequency is within operating bandwidth
        public Boolean IsWithinBandwidth(Double frequencyHz)
        {
            if (FrequencyMin == null || !FrequencyMin.TryGetDouble(out double fMin))
                return true;
            if (FrequencyMax == null || !FrequencyMax.TryGetDouble(out double fMax))
                return true;

            return frequencyHz >= fMin && frequencyHz <= fMax;
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
        public static Gyrator? FromJson(string json)
        {
            return JsonSerializer.Deserialize<Gyrator>(json);
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
