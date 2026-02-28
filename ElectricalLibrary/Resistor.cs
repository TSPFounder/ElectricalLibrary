using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD;
using SE_Library;
using Structures;

namespace Electrical
{
    public class Resistor :ElectricalElement
    {
        //  *****************************************************************************************
        //  DECLARATIONS
        //
        //  ************************************************************
        #region
        //  
        //  Identification

        //
        //  Data
        private CAD_Parameter _NominalResistance;
        /// <summary>Minimum resistance value (e.g., 1 Ohm).</summary>
        private CAD_Parameter _MinResistance;
        /// <summary>Maximum resistance value (e.g., 10M Ohm).</summary>
        private CAD_Parameter _MaxResistance;
        /// <summary>Tolerance of the resistor (e.g., ±1%).</summary>
        private CAD_Parameter _Tolerance;
        //
        //  Owned & Owning Objects

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

        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  RESISTOR CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public Resistor()
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
        //  Identification

        //  
        //  Data
        public CAD_Parameter NominalResistance
        {
            set => _NominalResistance = value;
            get { return _NominalResistance; }
        }
        //
        //  Minimum Resistance (e.g., 1 Ohm)
        public CAD_Parameter MinResistance
        {
            set => _MinResistance = value;
            get { return _MinResistance; }
        }
        //
        //  Maximum Resistance (e.g., 10M Ohm)
        public CAD_Parameter MaxResistance
        {
            set => _MaxResistance = value;
            get { return _MaxResistance; }
        }
        //
        //  Tolerance (e.g., ±1%)
        public CAD_Parameter Tolerance
        {
            set => _Tolerance = value;
            get { return _Tolerance; }
        }
        //
        //  Owned & Owning Objects

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
