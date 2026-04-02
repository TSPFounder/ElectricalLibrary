using System;
using System.Text.Json;
using CAD;

namespace Electrical
{
    public class ElectricCircuit : ElectricalElement
    {
        //  *****************************************************************************************
        //  ENUMERATIONS
        //
        //  ************************************************************
        #region
        public enum CircuitTypeEnum
        {
            Series = 0,
            Parallel,
            SeriesParallel,
            Bridge,
            Wheatstone,
            Other
        }

        public enum CircuitDomainEnum
        {
            DC = 0,
            AC,
            Mixed,
            Other
        }

        public enum CircuitStatusEnum
        {
            Open = 0,
            Closed,
            Faulted,
            Other
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  ELECTRICCIRCUIT CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public ElectricCircuit()
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
        public String Name { get; set; } = string.Empty;
        public String Description { get; set; } = string.Empty;
        public String Version { get; set; } = string.Empty;
        //
        //  Configuration
        public CircuitTypeEnum CircuitType { get; set; }
        public CircuitDomainEnum CircuitDomain { get; set; }
        public CircuitStatusEnum CircuitStatus { get; set; }
        //
        //  Source
        public CAD_Parameter SourceVoltage { get; set; }            //  Volts
        public CAD_Parameter SourceCurrent { get; set; }            //  Amps
        public CAD_Parameter OperatingFrequency { get; set; }       //  Hz (AC circuits)
        //
        //  Aggregate Values
        public CAD_Parameter TotalResistance { get; set; }          //  Ohms
        public CAD_Parameter TotalCapacitance { get; set; }         //  Farads
        public CAD_Parameter TotalInductance { get; set; }          //  Henries
        //
        //  Owned & Owning Objects
        public ElectricalElement CurrentElement { get; set; }
        public List<ElectricalElement> MyElements { get; set; } = new();
        public ElectricalWire CurrentWire { get; set; }
        public List<ElectricalWire> MyWires { get; set; } = new();
        public ElectricalConnector CurrentConnector { get; set; }
        public List<ElectricalConnector> MyConnectors { get; set; } = new();
        public ElectricalFuse CurrentFuse { get; set; }
        public List<ElectricalFuse> MyFuses { get; set; } = new();

        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  METHODS
        //
        //  ************************************************************
        #region
        //
        //  Add Element
        public void AddElement(ElectricalElement element)
        {
            CurrentElement = element;
            MyElements.Add(element);
        }
        //
        //  Remove Element
        public Boolean RemoveElement(ElectricalElement element)
        {
            Boolean removed = MyElements.Remove(element);
            if (removed && CurrentElement == element)
                CurrentElement = MyElements.Count > 0 ? MyElements[^1] : null;
            return removed;
        }
        //
        //  Get Element Count
        public int GetElementCount()
        {
            return MyElements.Count;
        }
        //
        //  Add Wire
        public void AddWire(ElectricalWire wire)
        {
            CurrentWire = wire;
            MyWires.Add(wire);
        }
        //
        //  Add Connector
        public void AddConnector(ElectricalConnector connector)
        {
            CurrentConnector = connector;
            MyConnectors.Add(connector);
        }
        //
        //  Add Fuse
        public void AddFuse(ElectricalFuse fuse)
        {
            CurrentFuse = fuse;
            MyFuses.Add(fuse);
        }
        //
        //  Calculate total series resistance: Rtotal = R1 + R2 + ... + Rn
        public Double CalculateTotalSeriesResistance(List<Double> resistances)
        {
            double total = 0d;
            foreach (double r in resistances)
                total += r;
            return total;
        }
        //
        //  Calculate total parallel resistance: 1/Rtotal = 1/R1 + 1/R2 + ... + 1/Rn
        public Double CalculateTotalParallelResistance(List<Double> resistances)
        {
            double reciprocalSum = 0d;
            foreach (double r in resistances)
            {
                if (r <= 0)
                    return 0d;
                reciprocalSum += 1d / r;
            }
            return reciprocalSum > 0 ? 1d / reciprocalSum : 0d;
        }
        //
        //  Calculate current: I = V / R (Ohm's Law)
        public Double CalculateCurrent(Double voltage, Double resistance)
        {
            if (resistance <= 0)
                return 0d;

            return voltage / resistance;
        }
        //
        //  Calculate voltage: V = I × R (Ohm's Law)
        public Double CalculateVoltage(Double current, Double resistance)
        {
            return current * resistance;
        }
        //
        //  Calculate power from voltage and current: P = V × I
        public Double CalculatePower(Double voltage, Double current)
        {
            return voltage * current;
        }
        //
        //  Calculate power from current and resistance: P = I² × R
        public Double CalculatePowerFromCurrent(Double current, Double resistance)
        {
            return current * current * resistance;
        }
        //
        //  Calculate power from voltage and resistance: P = V² / R
        public Double CalculatePowerFromVoltage(Double voltage, Double resistance)
        {
            if (resistance <= 0)
                return 0d;

            return voltage * voltage / resistance;
        }
        //
        //  Calculate total series capacitance: 1/Ctotal = 1/C1 + 1/C2 + ... + 1/Cn
        public Double CalculateTotalSeriesCapacitance(List<Double> capacitances)
        {
            double reciprocalSum = 0d;
            foreach (double c in capacitances)
            {
                if (c <= 0)
                    return 0d;
                reciprocalSum += 1d / c;
            }
            return reciprocalSum > 0 ? 1d / reciprocalSum : 0d;
        }
        //
        //  Calculate total parallel capacitance: Ctotal = C1 + C2 + ... + Cn
        public Double CalculateTotalParallelCapacitance(List<Double> capacitances)
        {
            double total = 0d;
            foreach (double c in capacitances)
                total += c;
            return total;
        }
        //
        //  Calculate total series inductance: Ltotal = L1 + L2 + ... + Ln
        public Double CalculateTotalSeriesInductance(List<Double> inductances)
        {
            double total = 0d;
            foreach (double l in inductances)
                total += l;
            return total;
        }
        //
        //  Calculate total parallel inductance: 1/Ltotal = 1/L1 + 1/L2 + ... + 1/Ln
        public Double CalculateTotalParallelInductance(List<Double> inductances)
        {
            double reciprocalSum = 0d;
            foreach (double l in inductances)
            {
                if (l <= 0)
                    return 0d;
                reciprocalSum += 1d / l;
            }
            return reciprocalSum > 0 ? 1d / reciprocalSum : 0d;
        }
        //
        //  Calculate resonant frequency: f = 1 / (2π√(LC))
        public Double CalculateResonantFrequency(Double inductance, Double capacitance)
        {
            if (inductance <= 0 || capacitance <= 0)
                return 0d;

            return 1d / (2d * Math.PI * Math.Sqrt(inductance * capacitance));
        }
        //
        //  Calculate impedance magnitude for RLC series: Z = √(R² + (XL - XC)²)
        public Double CalculateImpedance(Double resistance, Double inductance, Double capacitance, Double frequencyHz)
        {
            if (frequencyHz <= 0)
                return resistance;

            double xl = 2d * Math.PI * frequencyHz * inductance;
            double xc = capacitance > 0 ? 1d / (2d * Math.PI * frequencyHz * capacitance) : 0d;
            double netReactance = xl - xc;

            return Math.Sqrt(resistance * resistance + netReactance * netReactance);
        }
        //
        //  To JSON
        public string ToJson()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
        //
        //  From JSON
        public static ElectricCircuit? FromJson(string json)
        {
            return JsonSerializer.Deserialize<ElectricCircuit>(json);
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
