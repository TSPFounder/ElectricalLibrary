using System;
using System.Text.Json;
using CAD;
using SE_Library;
using CommonObjects;

namespace Electrical
{
    public class ElectricalPin : ElectricalElement
    {
        //  *****************************************************************************************
        //  DECLARATIONS
        //
        //  ************************************************************
        #region
        //  
        //  Identification
        private String _PinID;
        //
        //  Enumerations
        private PogoPinTypeEnum _MyPogoPinType;
        private PinTypeEnum _MyPinType;
        private FunctionType _MyFunctionType;
        //
        //  Data
        private Boolean _IsPogoPin;
        private Double _Diameter;
        private Double _MaxFreq, _MinFreq, _AvgFreq;
        private Double _MaxCurrent;
        //
        //  Owned & Owning Objects
        private Material _MyMaterial;

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
        //
        //  Pogo Pin Type Enum
        public enum PogoPinTypeEnum
        {
            BackDrill = 0,
            BiasTail,
            Ball,
            Other
        }
        //
        //  Pin Type Enum
        public enum PinTypeEnum
        {
            Solid = 0,
            Crimp,
            PogoPin,
            Other
        }
        //
        //  Function Type
        public enum FunctionType
        {
            Ground=0,
            InputVoltage,
            Transmit,
            Receive,
            Transmit_Receive,
            PWM,
            Other
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  ELECTRICALPIN CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public ElectricalPin()
        {
            
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  PROPERTIES
        //
        //  ************************************************************
        #region
        
        public String PinID
        {
            set => _PinID = value;
            get { return _PinID; }
        }
        //
        //  Enumerations
        //
        //  Pogo Pin Type
        public PogoPinTypeEnum MyPogoPinType
        {
            set => _MyPogoPinType = value;
            get { return _MyPogoPinType; }
        }
        //
        //  Pin Type
        public PinTypeEnum MyPinType
        {
            set => _MyPinType = value;
            get { return _MyPinType; }
        }
        //
        //  Function Type
        public FunctionType MyFunctionType
        {
            set => _MyFunctionType = value;
            get { return _MyFunctionType; }
        }
        //
        //  Data
        //
        //  Is a Pogo Pin
        public Boolean IsPogoPin
        {
            set => _IsPogoPin = value;
            get { return _IsPogoPin; }
        }
        //
        //  Pin Diamter
        public Double Diameter
        {
            set => _Diameter = value;
            get { return _Diameter; }
        }
        public Double AvgFreq
        {
            set => _AvgFreq = value;
            get { return _AvgFreq; }
        }
        //
        //  Minimum Frequency
        public Double MinFreq
        {
            set => _MinFreq = value;
            get { return _MinFreq; }
        }
        //
        //  Maximum Frequency
        public Double MaxFreq
        {
            set => _MaxFreq = value;
            get { return _MaxFreq; }
        }
        //
        //  Maximum Current
        public Double MaxCurrent
        {
            set => _MaxCurrent = value;
            get { return _MaxCurrent; }
        }
        //
        //  Owned & Owning Objects
        public Material MyMaterial
        {
            set => _MyMaterial = value;
            get { return _MyMaterial; }
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
        public static ElectricalPin? FromJson(string json)
        {
            return JsonSerializer.Deserialize<ElectricalPin>(json);
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
