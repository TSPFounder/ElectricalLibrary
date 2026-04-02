using System;
using System.Collections.Generic;
using System.Text.Json;
using CAD;

namespace Electrical
{
    public class ThreePhaseCircuit : ElectricCircuit
    {
        //  *****************************************************************************************
        //  ENUMERATIONS
        //
        //  ************************************************************
        #region
        public enum WindingConfigEnum
        {
            Wye = 0,
            Delta,
            WyeDelta,
            DeltaWye,
            OpenDelta,
            Other
        }

        public enum LoadBalanceEnum
        {
            Balanced = 0,
            Unbalanced,
            Other
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  THREEPHASECIRCUIT CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public ThreePhaseCircuit()
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
        //  Configuration
        public WindingConfigEnum WindingConfig { get; set; }
        public LoadBalanceEnum LoadBalance { get; set; }
        public Double PhaseAngle { get; set; } = 120d;              //  degrees
        //
        //  Voltages
        public CAD_Parameter LineVoltage { get; set; }              //  Volts (line-to-line)
        public CAD_Parameter PhaseVoltage { get; set; }             //  Volts (line-to-neutral)
        public CAD_Parameter VoltagePhaseA { get; set; }            //  Volts
        public CAD_Parameter VoltagePhaseB { get; set; }            //  Volts
        public CAD_Parameter VoltagePhaseC { get; set; }            //  Volts
        //
        //  Currents
        public CAD_Parameter LineCurrent { get; set; }              //  Amps (line)
        public CAD_Parameter PhaseCurrent { get; set; }             //  Amps (per phase)
        public CAD_Parameter CurrentPhaseA { get; set; }            //  Amps
        public CAD_Parameter CurrentPhaseB { get; set; }            //  Amps
        public CAD_Parameter CurrentPhaseC { get; set; }            //  Amps
        public CAD_Parameter NeutralCurrent { get; set; }           //  Amps
        //
        //  Power
        public CAD_Parameter PowerFactor { get; set; }              //  cos(φ)
        public CAD_Parameter ActivePower { get; set; }              //  Watts
        public CAD_Parameter ReactivePower { get; set; }            //  VAR
        public CAD_Parameter ApparentPower { get; set; }            //  VA
        //
        //  Per-Phase Load
        public CAD_Parameter LoadResistancePerPhase { get; set; }   //  Ohms
        public CAD_Parameter LoadReactancePerPhase { get; set; }    //  Ohms
        public CAD_Parameter LoadImpedancePerPhase { get; set; }    //  Ohms
        //
        //  Owned & Owning Objects
        public Transformer CurrentTransformer { get; set; }
        public List<Transformer> MyTransformers { get; set; } = new();
        public CircuitBreaker CurrentBreaker { get; set; }
        public List<CircuitBreaker> MyBreakers { get; set; } = new();

        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  METHODS
        //
        //  ************************************************************
        #region
        //
        //  Calculate line voltage from phase voltage (Wye): VL = VP × √3
        public Double CalculateLineVoltageFromPhase(Double phaseVoltage)
        {
            return phaseVoltage * Math.Sqrt(3d);
        }
        //
        //  Calculate phase voltage from line voltage (Wye): VP = VL / √3
        public Double CalculatePhaseVoltageFromLine(Double lineVoltage)
        {
            return lineVoltage / Math.Sqrt(3d);
        }
        //
        //  Calculate line current from phase current (Delta): IL = IP × √3
        public Double CalculateLineCurrentFromPhase(Double phaseCurrent)
        {
            return phaseCurrent * Math.Sqrt(3d);
        }
        //
        //  Calculate phase current from line current (Delta): IP = IL / √3
        public Double CalculatePhaseCurrentFromLine(Double lineCurrent)
        {
            return lineCurrent / Math.Sqrt(3d);
        }
        //
        //  Calculate active power: P = √3 × VL × IL × cos(φ)
        public Double CalculateActivePower(Double lineVoltage, Double lineCurrent, Double powerFactor)
        {
            return Math.Sqrt(3d) * lineVoltage * lineCurrent * powerFactor;
        }
        //
        //  Calculate reactive power: Q = √3 × VL × IL × sin(φ)
        public Double CalculateReactivePower(Double lineVoltage, Double lineCurrent, Double powerFactor)
        {
            double sinPhi = Math.Sqrt(1d - powerFactor * powerFactor);
            return Math.Sqrt(3d) * lineVoltage * lineCurrent * sinPhi;
        }
        //
        //  Calculate apparent power: S = √3 × VL × IL
        public Double CalculateApparentPower(Double lineVoltage, Double lineCurrent)
        {
            return Math.Sqrt(3d) * lineVoltage * lineCurrent;
        }
        //
        //  Calculate power factor from active and apparent power: PF = P / S
        public Double CalculatePowerFactor(Double activePower, Double apparentPower)
        {
            if (apparentPower <= 0)
                return 0d;

            return activePower / apparentPower;
        }
        //
        //  Calculate per-phase current from power (balanced): IP = P / (3 × VP × cos(φ))
        public Double CalculatePhaseCurrentFromPower(Double totalActivePower, Double phaseVoltage, Double powerFactor)
        {
            if (phaseVoltage <= 0 || powerFactor <= 0)
                return 0d;

            return totalActivePower / (3d * phaseVoltage * powerFactor);
        }
        //
        //  Calculate neutral current (unbalanced Wye): IN = √(IA² + IB² + IC² - IA·IB - IB·IC - IA·IC)
        public Double CalculateNeutralCurrent(Double currentA, Double currentB, Double currentC)
        {
            double phaseRad = PhaseAngle * Math.PI / 180d;

            double iaX = currentA;
            double iaY = 0d;
            double ibX = currentB * Math.Cos(-phaseRad);
            double ibY = currentB * Math.Sin(-phaseRad);
            double icX = currentC * Math.Cos(-2d * phaseRad);
            double icY = currentC * Math.Sin(-2d * phaseRad);

            double sumX = iaX + ibX + icX;
            double sumY = iaY + ibY + icY;

            return Math.Sqrt(sumX * sumX + sumY * sumY);
        }
        //
        //  Check if the load is balanced (all phase currents equal within tolerance)
        public Boolean IsBalanced(Double currentA, Double currentB, Double currentC, Double tolerancePercent)
        {
            double avg = (currentA + currentB + currentC) / 3d;
            if (avg <= 0)
                return true;

            double maxDeviation = Math.Max(Math.Abs(currentA - avg),
                                  Math.Max(Math.Abs(currentB - avg),
                                           Math.Abs(currentC - avg)));

            return (maxDeviation / avg * 100d) <= tolerancePercent;
        }
        //
        //  Calculate per-phase impedance: Z = V / I
        public Double CalculatePhaseImpedance(Double phaseVoltage, Double phaseCurrent)
        {
            if (phaseCurrent <= 0)
                return 0d;

            return phaseVoltage / phaseCurrent;
        }
        //
        //  Add Transformer
        public void AddTransformer(Transformer transformer)
        {
            CurrentTransformer = transformer;
            MyTransformers.Add(transformer);
        }
        //
        //  Add Circuit Breaker
        public void AddBreaker(CircuitBreaker breaker)
        {
            CurrentBreaker = breaker;
            MyBreakers.Add(breaker);
        }
        //
        //  To JSON
        public new string ToJson()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
        //
        //  From JSON
        public new static ThreePhaseCircuit? FromJson(string json)
        {
            return JsonSerializer.Deserialize<ThreePhaseCircuit>(json);
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
