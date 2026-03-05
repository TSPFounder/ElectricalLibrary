using System;
using System.Text.Json;
using CAD;
using Mathematics;

namespace Electrical
{
    public class Magnet
    {
        //  *****************************************************************************************
        //  DECLARATIONS
        //
        //  ************************************************************
        #region
        //
        //  Data
        private MagnetTypeEnum _MagnetType;
        private CAD_Parameter _ResidualFluxDensity;     //  Tesla (Br)
        private CAD_Parameter _CoerciveField;           //  kA/m (Hc)
        private CAD_Parameter _MaxEnergyProduct;        //  kJ/m³ (BHmax)
        private CAD_Parameter _MaxOperatingTemp;        //  deg Celsius
        private CAD_Parameter _RelativePermeability;    //  dimensionless (μr)
        //
        //  Owned & Owning Objects
        private ThreeDGeometry _MyGeometry;
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
        public enum MagnetTypeEnum
        {
            Neodymium = 0,
            Ferrite,
            AlNiCo,
            SamariumCobalt,
            Electromagnet,
            Permanent,
            Other
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  MAGNET CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public Magnet()
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
        //  Magnet Type
        public MagnetTypeEnum MagnetType
        {
            set => _MagnetType = value;
            get { return _MagnetType; }
        }
        //
        //  Residual Flux Density (Br)
        public CAD_Parameter ResidualFluxDensity
        {
            set => _ResidualFluxDensity = value;
            get { return _ResidualFluxDensity; }
        }
        //
        //  Coercive Field (Hc)
        public CAD_Parameter CoerciveField
        {
            set => _CoerciveField = value;
            get { return _CoerciveField; }
        }
        //
        //  Maximum Energy Product (BHmax)
        public CAD_Parameter MaxEnergyProduct
        {
            set => _MaxEnergyProduct = value;
            get { return _MaxEnergyProduct; }
        }
        //
        //  Maximum Operating Temperature
        public CAD_Parameter MaxOperatingTemp
        {
            set => _MaxOperatingTemp = value;
            get { return _MaxOperatingTemp; }
        }
        //
        //  Relative Permeability
        public CAD_Parameter RelativePermeability
        {
            set => _RelativePermeability = value;
            get { return _RelativePermeability; }
        }
        //
        //  Owned & Owning Objects
        //
        //  Geometry
        public ThreeDGeometry MyGeometry
        {
            set => _MyGeometry = value;
            get { return _MyGeometry; }
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
        public static Magnet? FromJson(string json)
        {
            return JsonSerializer.Deserialize<Magnet>(json);
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
