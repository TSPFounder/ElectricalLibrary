using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemsEngineering;
using CAD;
using Power;
using MissionsNamespace;

namespace Electronics
{
    public class ElectricWire : Wire
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
        private Double _TemperatureRating;
        private ElectricalWireTypeEnum _ElectricalWireType;
        //
        //  Dimensions
        private Double _Length;
        private int _Gauge;
        private Double _InsulationThickness;
        //
        //  
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

        //  *****************************************************************************************


        //  *****************************************************************************************
        //  ENUMERATIONS
        //
        //  ************************************************************
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
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  ELECTRICWIRE CONSTRUCTOR
        //
        //  ************************************************************
        public ElectricWire()
        {

        }
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
            get
            {
                return _Name;
            }
        }
        //
        //  Version
        public String Version
        {
            set => _Version = value;
            get
            {
                return _Version;
            }
        }
        //
        //  Shielding
        public Boolean IsShielded
        {
            set => _IsShielded = value;
            get
            {
                return _IsShielded;
            }
        }
        //
        //  Data
        //
        //  Number of Strands
        public int NumberStrands
        {
            set => _NumberStrands = value;
            get
            {
                return _NumberStrands;
            }
        }
        //
        //  Temperature Rating
        public Double TemperatureRating
        {
            set => _TemperatureRating = value;
            get
            {
                return _TemperatureRating;
            }
        }
        //
        //  Type
        public ElectricalWireTypeEnum ElectricalWireType
        {
            set => _ElectricalWireType = value;
            get
            {
                return _ElectricalWireType;
            }
        }
        //
        //  Dimensions
        //
        //  Length
        public Double Length
        {
            set => _Length = value;
            get
            {
                return _Length;
            }
        }
        //
        //  Gauge
        public int Gauge
        {
            set => _Gauge = value;
            get
            {
                return _Gauge;
            }
        }
        //
        //  Insulation Thickness
        public Double InsulationThickness
        {
            set => _InsulationThickness = value;
            get
            {
                return _InsulationThickness;
            }
        }
        //
        //
        //  
        //
        //  Owned & Owning Objects
        //
        //  Materials
        // 
        //  Conductor Material
        public Material ConductorMaterial
        {
            set => _ConductorMaterial = value;
            get
            {
                return _ConductorMaterial;
            }
        }
        // 
        //  Insulation Material
        public Material InsulationMaterial
        {
            set => _InsulationMaterial = value;
            get
            {
                return _InsulationMaterial;
            }
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  METHODS
        //
        //  ************************************************************
        #region

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
