using System;
using System.Text.Json;
using CAD;

namespace Electrical
{
    public class Transistor : ElectricalElement
    {
        //  *****************************************************************************************
        //  DECLARATIONS
        //
        //  ************************************************************
        #region
        //
        //  Data
        private CAD_Parameter _MaxCollectorCurrent;         //  Amps (Ic for BJT / Id for MOSFET)
        private CAD_Parameter _MaxCollectorEmitterVoltage;  //  Volts (Vce for BJT / Vds for MOSFET)
        private CAD_Parameter _MaxPowerDissipation;         //  Watts
        private CAD_Parameter _DCCurrentGain;               //  hFE (BJT)
        private CAD_Parameter _TransitionFrequency;         //  Hz (fT)
        private CAD_Parameter _GateThresholdVoltage;        //  Volts (Vgs(th), MOSFET)
        private CAD_Parameter _OnResistance;                //  Ohms (RDS(on), MOSFET)
        private TransistorTypeEnum _TransistorType;
        //
        //  Owned & Owning Objects

        #endregion
        //  *****************************************************************************************


        //  ****************************************************************************************
        //  INITIALIZATIONS
        //
        //  ************************************************************
        #region

        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  ENUMERATIONS
        //
        //  ************************************************************
        #region
        public enum TransistorTypeEnum
        {
            NPN = 0,
            PNP,
            N_MOSFET,
            P_MOSFET,
            JFET,
            IGBT,
            Other
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  TRANSISTOR CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public Transistor()
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
        //
        //  Maximum Collector/Drain Current
        public CAD_Parameter MaxCollectorCurrent
        {
            set => _MaxCollectorCurrent = value;
            get { return _MaxCollectorCurrent; }
        }
        //
        //  Maximum Collector-Emitter / Drain-Source Voltage
        public CAD_Parameter MaxCollectorEmitterVoltage
        {
            set => _MaxCollectorEmitterVoltage = value;
            get { return _MaxCollectorEmitterVoltage; }
        }
        //
        //  Maximum Power Dissipation
        public CAD_Parameter MaxPowerDissipation
        {
            set => _MaxPowerDissipation = value;
            get { return _MaxPowerDissipation; }
        }
        //
        //  DC Current Gain (hFE)
        public CAD_Parameter DCCurrentGain
        {
            set => _DCCurrentGain = value;
            get { return _DCCurrentGain; }
        }
        //
        //  Transition Frequency
        public CAD_Parameter TransitionFrequency
        {
            set => _TransitionFrequency = value;
            get { return _TransitionFrequency; }
        }
        //
        //  Gate Threshold Voltage
        public CAD_Parameter GateThresholdVoltage
        {
            set => _GateThresholdVoltage = value;
            get { return _GateThresholdVoltage; }
        }
        //
        //  On Resistance (RDS(on))
        public CAD_Parameter OnResistance
        {
            set => _OnResistance = value;
            get { return _OnResistance; }
        }
        //
        //  Transistor Type
        public TransistorTypeEnum TransistorType
        {
            set => _TransistorType = value;
            get { return _TransistorType; }
        }
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
        //  To JSON
        public string ToJson()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
        //
        //  From JSON
        public static Transistor? FromJson(string json)
        {
            return JsonSerializer.Deserialize<Transistor>(json);
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
