using System;
using System.Text.Json;
using CAD;

namespace Electrical
{
    public class ElectricSwitch : ElectricalElement
    {
        //  *****************************************************************************************
        //  DECLARATIONS
        //
        //  ************************************************************
        #region
        //
        //  Identification
        private String _Make;
        private String _Model;
        private String _Version;
        //
        //  Data
        private SwitchTypeEnum _SwitchType;
        private ContactTypeEnum _ContactType;
        //
        //  Dimensions
        private CAD_Dimension _Length;
        private CAD_Dimension _Width;
        private CAD_Dimension _Height;
        private CAD_Dimension _HoleOffset;
        //
        //  Dimension List
        private List<CAD_Dimension> _MyDimensions;
        //
        //  Performance
        private CAD_Parameter _Weight;
        private CAD_Parameter _MaxInputCurrent;     //  Amps
        private CAD_Parameter _InputVoltage;        //  Volts
        private CAD_Parameter _MinOperatingTemp;    //  deg Celsius
        private CAD_Parameter _MaxOperatingTemp;    //  deg Celsius
        //
        //  Owned & Owning Objects
        private List<CAD_Feature> _MountingHoles;
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
        public enum SwitchTypeEnum
        {
            Toggle = 0,
            Rocker,
            Slide,
            Push,
            Momentary,
            Flip,
            Limit,
            RotarySelector,
            Other
        }

        public enum ContactTypeEnum
        {
            SPST = 0,
            SPDT,
            DPST,
            DPDT,
            Other
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  ELECTRICSWITCH CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public ElectricSwitch()
        {
            _MyDimensions = new List<CAD_Dimension>();
            _MountingHoles = new List<CAD_Feature>();
            _Make = string.Empty;
            _Model = string.Empty;
            _Version = string.Empty;
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
        //
        //  Make
        public String Make
        {
            set => _Make = value;
            get { return _Make; }
        }
        //
        //  Model
        public String Model
        {
            set => _Model = value;
            get { return _Model; }
        }
        //
        //  Version
        public String Version
        {
            set => _Version = value;
            get { return _Version; }
        }
        //
        //  Data
        //
        //  Switch Type
        public SwitchTypeEnum SwitchType
        {
            set => _SwitchType = value;
            get { return _SwitchType; }
        }
        //
        //  Contact Type
        public ContactTypeEnum ContactType
        {
            set => _ContactType = value;
            get { return _ContactType; }
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
        //  Hole Offset
        public CAD_Dimension HoleOffset
        {
            set => _HoleOffset = value;
            get { return _HoleOffset; }
        }
        //
        //  Dimension List
        public List<CAD_Dimension> MyDimensions
        {
            set => _MyDimensions = value;
            get { return _MyDimensions; }
        }
        //
        //  Performance
        //
        //  Weight
        public CAD_Parameter Weight
        {
            set => _Weight = value;
            get { return _Weight; }
        }
        //
        //  Maximum Input Current
        public CAD_Parameter MaxInputCurrent
        {
            set => _MaxInputCurrent = value;
            get { return _MaxInputCurrent; }
        }
        //
        //  Input Voltage
        public CAD_Parameter InputVoltage
        {
            set => _InputVoltage = value;
            get { return _InputVoltage; }
        }
        //
        //  Minimum Operating Temperature
        public CAD_Parameter MinOperatingTemp
        {
            set => _MinOperatingTemp = value;
            get { return _MinOperatingTemp; }
        }
        //
        //  Maximum Operating Temperature
        public CAD_Parameter MaxOperatingTemp
        {
            set => _MaxOperatingTemp = value;
            get { return _MaxOperatingTemp; }
        }
        //
        //  Owned & Owning Objects
        //
        //  Mounting Holes
        public List<CAD_Feature> MountingHoles
        {
            set => _MountingHoles = value;
            get { return _MountingHoles; }
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
        public static ElectricSwitch? FromJson(string json)
        {
            return JsonSerializer.Deserialize<ElectricSwitch>(json);
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
