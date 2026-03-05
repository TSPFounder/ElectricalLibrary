using System;
using System.Text.Json;
using CAD;

namespace Electrical
{
    public class Diode : ElectricalElement
    {
        //  *****************************************************************************************
        //  DECLARATIONS
        //
        //  ************************************************************
        #region
        //
        //  Data
        private CAD_Parameter _ForwardVoltage;          //  Volts (Vf)
        private CAD_Parameter _MaxReverseVoltage;       //  Volts (PIV)
        private CAD_Parameter _MaxForwardCurrent;       //  Amps
        private CAD_Parameter _MaxReverseCurrent;       //  Amps (leakage)
        private CAD_Parameter _ReverseRecoveryTime;     //  ns
        private CAD_Parameter _MaxPowerDissipation;     //  Watts
        private DiodeTypeEnum _DiodeType;
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
        public enum DiodeTypeEnum
        {
            Rectifier = 0,
            Zener,
            Schottky,
            LED,
            TVS,
            Varactor,
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
        //
        //  Forward Voltage
        public CAD_Parameter ForwardVoltage
        {
            set => _ForwardVoltage = value;
            get { return _ForwardVoltage; }
        }
        //
        //  Maximum Reverse Voltage
        public CAD_Parameter MaxReverseVoltage
        {
            set => _MaxReverseVoltage = value;
            get { return _MaxReverseVoltage; }
        }
        //
        //  Maximum Forward Current
        public CAD_Parameter MaxForwardCurrent
        {
            set => _MaxForwardCurrent = value;
            get { return _MaxForwardCurrent; }
        }
        //
        //  Maximum Reverse Current
        public CAD_Parameter MaxReverseCurrent
        {
            set => _MaxReverseCurrent = value;
            get { return _MaxReverseCurrent; }
        }
        //
        //  Reverse Recovery Time
        public CAD_Parameter ReverseRecoveryTime
        {
            set => _ReverseRecoveryTime = value;
            get { return _ReverseRecoveryTime; }
        }
        //
        //  Maximum Power Dissipation
        public CAD_Parameter MaxPowerDissipation
        {
            set => _MaxPowerDissipation = value;
            get { return _MaxPowerDissipation; }
        }
        //
        //  Diode Type
        public DiodeTypeEnum DiodeType
        {
            set => _DiodeType = value;
            get { return _DiodeType; }
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
