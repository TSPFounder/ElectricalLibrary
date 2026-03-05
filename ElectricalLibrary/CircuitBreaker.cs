using System;
using System.Text.Json;
using CAD;

namespace Electrical
{
    public class CircuitBreaker : ElectronicComponent
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
        private CircuitBreakerTypeEnum _CircuitBreakerType;
        private String _WireGauge;
        //
        //  Dimensions
        private CAD_Dimension _Length;
        private CAD_Dimension _Width;
        private CAD_Dimension _Height;
        private CAD_Dimension _HoleOffset;
        private CAD_Dimension _MountingTabLength;
        //
        //  Dimension List
        private List<CAD_Dimension> _MyDimensions;
        //
        //  Performance
        private CAD_Parameter _Weight;
        private CAD_Parameter _MaxInputCurrent;     //  Amps (trip current)
        private CAD_Parameter _TripCurrent;         //  Amps (rated trip threshold)
        private CAD_Parameter _TripTime;            //  ms (response time at rated current)
        private CAD_Parameter _InputVoltage;        //  Volts
        //
        //  Owned & Owning Objects
        private List<CAD_Hole> _MountingHoles;
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
        public enum CircuitBreakerTypeEnum
        {
            Thermal = 0,
            Magnetic,
            ThermalMagnetic,
            Electronic,
            Resettable,
            Other
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  CIRCUITBREAKER CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public CircuitBreaker()
        {
            _MyDimensions = new List<CAD_Dimension>();
            _MountingHoles = new List<CAD_Hole>();
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
        //  Circuit Breaker Type
        public CircuitBreakerTypeEnum CircuitBreakerType
        {
            set => _CircuitBreakerType = value;
            get { return _CircuitBreakerType; }
        }
        //
        //  Wire Gauge
        public String WireGauge
        {
            set => _WireGauge = value;
            get { return _WireGauge; }
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
        //  Mounting Tab Length
        public CAD_Dimension MountingTabLength
        {
            set => _MountingTabLength = value;
            get { return _MountingTabLength; }
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
        //  Trip Current
        public CAD_Parameter TripCurrent
        {
            set => _TripCurrent = value;
            get { return _TripCurrent; }
        }
        //
        //  Trip Time
        public CAD_Parameter TripTime
        {
            set => _TripTime = value;
            get { return _TripTime; }
        }
        //
        //  Input Voltage
        public CAD_Parameter InputVoltage
        {
            set => _InputVoltage = value;
            get { return _InputVoltage; }
        }
        //
        //  Owned & Owning Objects
        //
        //  Mounting Holes
        public List<CAD_Hole> MountingHoles
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
        public static CircuitBreaker? FromJson(string json)
        {
            return JsonSerializer.Deserialize<CircuitBreaker>(json);
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
