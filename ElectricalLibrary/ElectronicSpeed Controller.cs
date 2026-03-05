using System;
using System.Text.Json;
using CAD;
using SE_Library;
using Structures;

namespace Electronics
{
    public class ElectronicSpeed_Controller : SE_System
    {
        //  *****************************************************************************************
        //  DECLARATIONS
        //
        //  ************************************************************
        #region
        //
        //  Data
        //
        //  Protocol Type
        private ESCProtocolTypeEnum _ProtocolType;
        //
        //  Dimensions
        private CAD_Dimension _Length;
        private CAD_Dimension _Width;
        private CAD_Dimension _Height;
        //
        //  Dimension List
        private List<CAD_Dimension> _MyDimensions;
        //
        //  Parameters
        private CAD_Parameter _MaxContinuousCurrent;
        private CAD_Parameter _PeakCurrent;
        private CAD_Parameter _MinInputVoltage;
        private CAD_Parameter _MaxInputVoltage;
        private CAD_Parameter _BECVoltage;
        private CAD_Parameter _BECCurrent;
        private CAD_Parameter _PWMFrequency;
        private CAD_Parameter _SwitchingFrequency;
        //
        //  Cell Count
        private int _MinCellCount;
        private int _MaxCellCount;
        //
        //  Number of Motor Phases
        private int _NumMotorPhases;
        //
        //  Booleans
        private Boolean _HasBEC;
        private Boolean _IsOptoCoupled;
        //
        //  Firmware Version
        private string _FirmwareVersion;
        //
        //  Structural Elements
        private StructuralCase _MyCase;
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
        public enum ESCProtocolTypeEnum
        {
            PWM = 0,
            Oneshot125,
            Oneshot42,
            Multishot,
            DSHOT150,
            DSHOT300,
            DSHOT600,
            Other
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  ELECTRONICSPEED_CONTROLLER CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public ElectronicSpeed_Controller()
        {
            _MyDimensions = new List<CAD_Dimension>();
            _NumMotorPhases = 3;
            _FirmwareVersion = string.Empty;
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  PROPERTIES
        //
        //  ************************************************************
        #region
        //
        //  Protocol Type
        public ESCProtocolTypeEnum ProtocolType
        {
            set => _ProtocolType = value;
            get { return _ProtocolType; }
        }
        //
        //  Parameters
        //
        //  Maximum Continuous Current
        public CAD_Parameter MaxContinuousCurrent
        {
            set => _MaxContinuousCurrent = value;
            get { return _MaxContinuousCurrent; }
        }
        //
        //  Peak Current
        public CAD_Parameter PeakCurrent
        {
            set => _PeakCurrent = value;
            get { return _PeakCurrent; }
        }
        //
        //  Minimum Input Voltage
        public CAD_Parameter MinInputVoltage
        {
            set => _MinInputVoltage = value;
            get { return _MinInputVoltage; }
        }
        //
        //  Maximum Input Voltage
        public CAD_Parameter MaxInputVoltage
        {
            set => _MaxInputVoltage = value;
            get { return _MaxInputVoltage; }
        }
        //
        //  BEC Voltage
        public CAD_Parameter BECVoltage
        {
            set => _BECVoltage = value;
            get { return _BECVoltage; }
        }
        //
        //  BEC Current
        public CAD_Parameter BECCurrent
        {
            set => _BECCurrent = value;
            get { return _BECCurrent; }
        }
        //
        //  PWM Frequency
        public CAD_Parameter PWMFrequency
        {
            set => _PWMFrequency = value;
            get { return _PWMFrequency; }
        }
        //
        //  Switching Frequency
        public CAD_Parameter SwitchingFrequency
        {
            set => _SwitchingFrequency = value;
            get { return _SwitchingFrequency; }
        }
        //
        //  Dimensions
        //
        //  Length
        public CAD_Dimension Length
        {
            set
            {
                _Length = value;
                this.MyDimensions.Add(_Length);
            }
            get { return _Length; }
        }
        //
        //  Width
        public CAD_Dimension Width
        {
            set
            {
                _Width = value;
                this.MyDimensions.Add(_Width);
            }
            get { return _Width; }
        }
        //
        //  Height
        public CAD_Dimension Height
        {
            set
            {
                _Height = value;
                this.MyDimensions.Add(_Height);
            }
            get { return _Height; }
        }
        //
        //  Dimension List
        public List<CAD_Dimension> MyDimensions
        {
            set => _MyDimensions = value;
            get { return _MyDimensions; }
        }
        //
        //  Minimum Cell Count
        public int MinCellCount
        {
            set => _MinCellCount = value;
            get { return _MinCellCount; }
        }
        //
        //  Maximum Cell Count
        public int MaxCellCount
        {
            set => _MaxCellCount = value;
            get { return _MaxCellCount; }
        }
        //
        //  Number of Motor Phases
        public int NumMotorPhases
        {
            set => _NumMotorPhases = value;
            get { return _NumMotorPhases; }
        }
        //
        //  Booleans
        //
        //  Has BEC
        public Boolean HasBEC
        {
            set => _HasBEC = value;
            get { return _HasBEC; }
        }
        //
        //  Is Opto-Coupled
        public Boolean IsOptoCoupled
        {
            set => _IsOptoCoupled = value;
            get { return _IsOptoCoupled; }
        }
        //
        //  Firmware Version
        public string FirmwareVersion
        {
            set => _FirmwareVersion = value;
            get { return _FirmwareVersion; }
        }
        //
        //  Structural Elements
        public StructuralCase MyCase
        {
            set => _MyCase = value;
            get { return _MyCase; }
        }
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
        public static ElectronicSpeed_Controller? FromJson(string json)
        {
            return JsonSerializer.Deserialize<ElectronicSpeed_Controller>(json);
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
