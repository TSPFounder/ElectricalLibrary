using System;
using System.Text.Json;
using CAD;

namespace Electrical
{
    public class ElectricalFuse : ElectricalElement
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
        //
        //  Dimensions
        private CAD_Dimension _Length;
        private CAD_Dimension _Width;
        private CAD_Dimension _Height;
        //
        //  Dimension List
        private List<CAD_Dimension> _MyDimensions;
        //
        //  Physical Properties
        private CAD_Parameter _Weight;
        private String _WireGauge;
        private FuseTypeEnum _FuseType;
        //
        //  Performance
        private CAD_Parameter _MaxInputCurrent;  //  Amps
        private CAD_Parameter _InputVoltage;     //  Volts
        private CAD_Parameter _TripTime;         //  ms (response time at rated current)
        //
        //  Owned & Owning Objects
        //
        //  Connector
        private ElectricalConnector _MyConnector;
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
        public enum FuseTypeEnum
        {
            Blade = 0,
            Glass,
            Ceramic,
            Resettable,
            HRC,
            Other
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  ELECTRICALFUSE CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public ElectricalFuse()
        {
            _MyDimensions = new List<CAD_Dimension>();
            _Make = string.Empty;
            _Model = string.Empty;
            _Version = string.Empty;
            _WireGauge = string.Empty;
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
        //  Physical Properties
        //
        //  Weight
        public CAD_Parameter Weight
        {
            set => _Weight = value;
            get { return _Weight; }
        }
        //
        //  Wire Gauge
        public String WireGauge
        {
            set => _WireGauge = value;
            get { return _WireGauge; }
        }
        //
        //  Fuse Type
        public FuseTypeEnum FuseType
        {
            set => _FuseType = value;
            get { return _FuseType; }
        }
        //
        //  Performance
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
        //  Trip Time
        public CAD_Parameter TripTime
        {
            set => _TripTime = value;
            get { return _TripTime; }
        }
        //
        //  Owned & Owning Objects
        //
        //  Connector
        public ElectricalConnector MyConnector
        {
            set => _MyConnector = value;
            get { return _MyConnector; }
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
        public static ElectricalFuse? FromJson(string json)
        {
            return JsonSerializer.Deserialize<ElectricalFuse>(json);
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
