using System;
using System.Text.Json;
using CAD;

namespace Electrical
{
    public class ElectricCable : ElectricalElement
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
        //
        //  Data
        private CableTypeEnum _CableType;
        private Boolean _IsShielded;
        private CAD_Dimension _Length;
        private CAD_Parameter _MaxCurrentRating;    //  Amps
        private CAD_Parameter _MaxVoltageRating;    //  Volts
        //
        //  Owned & Owning Objects
        private ElectricalWire _CurrentWire;
        private List<ElectricalWire> _MyWires;
        private ElectricalConnector _CurrentConnector;
        private List<ElectricalConnector> _MyConnectors;
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
        public enum CableTypeEnum
        {
            Power = 0,
            Signal,
            Coaxial,
            Twisted,
            Ribbon,
            USB,
            HDMI,
            Ethernet,
            Other
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  ELECTRICCABLE CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public ElectricCable()
        {
            _MyWires = new List<ElectricalWire>();
            _MyConnectors = new List<ElectricalConnector>();
            _Make = string.Empty;
            _Model = string.Empty;
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
        //  Data
        //
        //  Cable Type
        public CableTypeEnum CableType
        {
            set => _CableType = value;
            get { return _CableType; }
        }
        //
        //  Is Shielded
        public Boolean IsShielded
        {
            set => _IsShielded = value;
            get { return _IsShielded; }
        }
        //
        //  Length
        public CAD_Dimension Length
        {
            set => _Length = value;
            get { return _Length; }
        }
        //
        //  Maximum Current Rating
        public CAD_Parameter MaxCurrentRating
        {
            set => _MaxCurrentRating = value;
            get { return _MaxCurrentRating; }
        }
        //
        //  Maximum Voltage Rating
        public CAD_Parameter MaxVoltageRating
        {
            set => _MaxVoltageRating = value;
            get { return _MaxVoltageRating; }
        }
        //
        //  Owned & Owning Objects
        //
        //  Current Wire
        public ElectricalWire CurrentWire
        {
            set => _CurrentWire = value;
            get { return _CurrentWire; }
        }
        //
        //  Wire List
        public List<ElectricalWire> MyWires
        {
            set => _MyWires = value;
            get { return _MyWires; }
        }
        //
        //  Current Connector
        public ElectricalConnector CurrentConnector
        {
            set => _CurrentConnector = value;
            get { return _CurrentConnector; }
        }
        //
        //  Connector List
        public List<ElectricalConnector> MyConnectors
        {
            set => _MyConnectors = value;
            get { return _MyConnectors; }
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
        public static ElectricCable? FromJson(string json)
        {
            return JsonSerializer.Deserialize<ElectricCable>(json);
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
