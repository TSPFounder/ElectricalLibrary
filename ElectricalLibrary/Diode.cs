using System;
using System.Text.Json;
using CAD;

namespace Electrical
{
    public class Diode : ElectricalElement
    {
        //  *****************************************************************************************
        //  ENUMERATIONS
        //
        //  ************************************************************
        #region
        public enum DiodeTypeEnum
        {
            Rectifier = 0,
            Zener,
            Schottky,
            LED,
            TVS,
            Varactor,
            FastRecovery,
            Tunnel,
            Other
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  DIODE CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public Diode()
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
        //  Data
        public CAD_Parameter ForwardVoltage { get; set; }           //  Volts (Vf)
        public CAD_Parameter MaxReverseVoltage { get; set; }        //  Volts (PIV)
        public CAD_Parameter MaxForwardCurrent { get; set; }        //  Amps (If)
        public CAD_Parameter MaxReverseCurrent { get; set; }        //  Amps (leakage, Ir)
        public CAD_Parameter MaxSurgeCurrent { get; set; }          //  Amps (IFSM)
        public CAD_Parameter ReverseRecoveryTime { get; set; }      //  ns (trr)
        public CAD_Parameter MaxPowerDissipation { get; set; }      //  Watts
        public CAD_Parameter JunctionCapacitance { get; set; }      //  pF (Cj)
        public CAD_Parameter ZenerVoltage { get; set; }             //  Volts (Vz)
        public CAD_Parameter BreakdownVoltage { get; set; }         //  Volts (Vbr)
        public CAD_Parameter DynamicResistance { get; set; }        //  Ohms (rd)
        public CAD_Parameter Tolerance { get; set; }                //  %
        public CAD_Parameter TemperatureCoefficient { get; set; }   //  mV/°C
        public DiodeTypeEnum DiodeType { get; set; }
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
        //  Calculate Power Dissipation: P = Vf × If
        public Double CalculatePowerDissipation(Double forwardCurrent)
        {
            if (ForwardVoltage == null || !ForwardVoltage.TryGetDouble(out double vf))
                return 0d;

            return vf * forwardCurrent;
        }
        //
        //  Calculate Series Resistor: R = (Vs - Vf) / If
        public Double CalculateSeriesResistor(Double supplyVoltage, Double desiredCurrent)
        {
            if (ForwardVoltage == null || !ForwardVoltage.TryGetDouble(out double vf) || desiredCurrent <= 0)
                return 0d;

            return (supplyVoltage - vf) / desiredCurrent;
        }
        //
        //  Check if forward current is within maximum rating
        public Boolean IsWithinCurrentRating(Double forwardCurrent)
        {
            if (MaxForwardCurrent == null || !MaxForwardCurrent.TryGetDouble(out double limit))
                return true;

            return forwardCurrent <= limit;
        }
        //
        //  Check if reverse voltage is within PIV rating
        public Boolean IsWithinVoltageRating(Double reverseVoltage)
        {
            if (MaxReverseVoltage == null || !MaxReverseVoltage.TryGetDouble(out double limit))
                return true;

            return reverseVoltage <= limit;
        }
        //
        //  Calculate Forward Current: If = (Vs - Vf) / R
        public Double CalculateForwardCurrent(Double supplyVoltage, Double seriesResistance)
        {
            if (ForwardVoltage == null || !ForwardVoltage.TryGetDouble(out double vf) || seriesResistance <= 0)
                return 0d;

            return (supplyVoltage - vf) / seriesResistance;
        }
        //
        //  To JSON
        public string ToJson()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
        //
        //  From JSON
        public static Diode? FromJson(string json)
        {
            return JsonSerializer.Deserialize<Diode>(json);
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
