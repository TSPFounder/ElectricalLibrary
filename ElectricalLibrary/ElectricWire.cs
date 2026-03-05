using System;
using System.Text.Json;
using CAD;
using CommonObjects;
using  SE_Library;

namespace Electronics
{
    public class ElectricWire
    {
        //  *****************************************************************************************
        //  DECLARATIONS
        //
        //  ************************************************************
        #region
        //
        //  Identification
        private String _Name;
        private String _Version;
        private Boolean _IsShielded;
        //
        //  Data
        private int _NumberStrands;
        private Double _TemperatureRating;  //  deg Celsius
        private CAD_Parameter _MaxCurrentRating;    //  Amps
        private CAD_Parameter _MaxVoltageRating;    //  Volts
        private ElectricalWireTypeEnum _ElectricalWireType;
        //
        //  Dimensions
        private Double _Length;             //  mm
        private int _Gauge;                 //  AWG
        private Double _InsulationThickness; //  mm
        //
        //  Owned & Owning Objects
        private Material _ConductorMaterial;
        private Material _InsulationMaterial;
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
        public enum ElectricalWireTypeEnum
        {
            NM = 1,
            UF,
            THHN,
            THWN,
            LowVoltage,
            Cat5,
            Cat6,
            Coax,
            Magnet,
            Thermocouple,
            Heating
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  ELECTRICWIRE CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public ElectricWire()
        {
            _Name = string.Empty;
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
        //  Name
        public String Name
        {
            set => _Name = value;
            get { return _Name; }
        }
        //
        //  Version
        public String Version
        {
            set => _Version = value;
            get { return _Version; }
        }
        //
        //  Is Shielded
        public Boolean IsShielded
        {
            set => _IsShielded = value;
            get { return _IsShielded; }
        }
        //
        //  Data
        //
        //  Number of Strands
        public int NumberStrands
        {
            set => _NumberStrands = value;
            get { return _NumberStrands; }
        }
        //
        //  Temperature Rating
        public Double TemperatureRating
        {
            set => _TemperatureRating = value;
            get { return _TemperatureRating; }
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
        //  Wire Type
        public ElectricalWireTypeEnum ElectricalWireType
        {
            set => _ElectricalWireType = value;
            get { return _ElectricalWireType; }
        }
        //
        //  Dimensions
        //
        //  Length
        public Double Length
        {
            set => _Length = value;
            get { return _Length; }
        }
        //
        //  Gauge
        public int Gauge
        {
            set => _Gauge = value;
            get { return _Gauge; }
        }
        //
        //  Insulation Thickness
        public Double InsulationThickness
        {
            set => _InsulationThickness = value;
            get { return _InsulationThickness; }
        }
        //
        //  Owned & Owning Objects
        //
        //  Conductor Material
        public Material ConductorMaterial
        {
            set => _ConductorMaterial = value;
            get { return _ConductorMaterial; }
        }
        //
        //  Insulation Material
        public Material InsulationMaterial
        {
            set => _InsulationMaterial = value;
            get { return _InsulationMaterial; }
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
        public static ElectricWire? FromJson(string json)
        {
            return JsonSerializer.Deserialize<ElectricWire>(json);
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
