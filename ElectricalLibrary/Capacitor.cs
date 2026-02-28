using CAD;

namespace Electrical
{
    public class Capacitor : ElectricalElement
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
        private CAD_Parameter? _NominalCapacitance;
        /// <summary>Minimum capacitance value (e.g., 1 pF).</summary>
        private CAD_Parameter? _MinCapacitance;
        /// <summary>Maximum capacitance value (e.g., 1 F).</summary>
        private CAD_Parameter? _MaxCapacitance;
        /// <summary>Voltage rating of the capacitor (e.g., 25V).</summary>
        private CAD_Parameter? _VoltageRating;
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
        //  CAPACITOR CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public Capacitor()
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
        public CAD_Parameter? NominalCapacitance
        {
            set => _NominalCapacitance = value;
            get { return _NominalCapacitance; }
        }
        //
        //  Minimum Capacitance (e.g., 1 pF)
        public CAD_Parameter? MinCapacitance
        {
            set => _MinCapacitance = value;
            get { return _MinCapacitance; }
        }
        //
        //  Maximum Capacitance (e.g., 1 F)
        public CAD_Parameter? MaxCapacitance
        {
            set => _MaxCapacitance = value;
            get { return _MaxCapacitance; }
        }
        //
        //  Voltage Rating (e.g., 25V)
        public CAD_Parameter? VoltageRating
        {
            set => _VoltageRating = value;
            get { return _VoltageRating; }
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
