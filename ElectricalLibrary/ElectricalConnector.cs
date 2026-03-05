using System;
using System.Text.Json;
using CAD;

namespace Electrical
{
    public class ElectricalConnector : ElectricalElement
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
        private ConnectorType _MyConnectorType;
        private USB_ConnectorType _MyUSBConnectorType;
        private int _NumPins;
        private CAD_Parameter _MaxCurrentRating;    //  Amps
        private CAD_Parameter _MaxVoltageRating;    //  Volts
        private Boolean _IsLocking;
        private Boolean _IsWaterproof;
        //
        //  Owned & Owning Objects
        private ElectricalPin _CurrentPin;
        private List<ElectricalPin> _MyPins;
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
        public enum ConnectorType
        {
            USB = 0,
            HDMI,
            DisplayPort,
            MiniDisplayPort,
            DVI,
            CompositeVideo,
            VGA,
            BNC,
            F_Connector,
            RJ_45,
            RJ_11,
            DB_9,
            DB_25,
            DIN,
            TRS,
            PowerBarrel,
            XT30,
            XT60,
            Deans,
            Anderson,
            JST,
            Other
        }

        public enum USB_ConnectorType
        {
            USB_A = 0,
            USB_B,
            MiniA,
            MiniB,
            MicroA,
            MicroB,
            MicroB_SuperSpeed,
            USB_C,
            USB_3_0_A_SS,
            USB_3_0_B_SS,
            USB_3_0_MicroB_SS,
            None,
            Other
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  ELECTRICALCONNECTOR CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public ElectricalConnector()
        {
            _MyPins = new List<ElectricalPin>();
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
        //  Connector Type
        public ConnectorType MyConnectorType
        {
            set => _MyConnectorType = value;
            get { return _MyConnectorType; }
        }
        //
        //  USB Connector Type
        public USB_ConnectorType MyUSBConnectorType
        {
            set => _MyUSBConnectorType = value;
            get { return _MyUSBConnectorType; }
        }
        //
        //  Number of Pins
        public int NumPins
        {
            set => _NumPins = value;
            get { return _NumPins; }
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
        //  Is Locking
        public Boolean IsLocking
        {
            set => _IsLocking = value;
            get { return _IsLocking; }
        }
        //
        //  Is Waterproof
        public Boolean IsWaterproof
        {
            set => _IsWaterproof = value;
            get { return _IsWaterproof; }
        }
        //
        //  Owned & Owning Objects
        //
        //  Current Pin
        public ElectricalPin CurrentPin
        {
            set => _CurrentPin = value;
            get { return _CurrentPin; }
        }
        //
        //  Pin List
        public List<ElectricalPin> MyPins
        {
            set => _MyPins = value;
            get { return _MyPins; }
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
        public static ElectricalConnector? FromJson(string json)
        {
            return JsonSerializer.Deserialize<ElectricalConnector>(json);
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
