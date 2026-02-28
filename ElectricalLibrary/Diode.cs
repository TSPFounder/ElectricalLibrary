using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD;

namespace Electrical
{
    public class Diode : ElectricalElement
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
        /// <summary>Forward voltage drop of the diode (e.g., 0.7V for silicon).</summary>
        private CAD_Parameter _ForwardVoltageDrop;
        /// <summary>Maximum reverse voltage the diode can withstand.</summary>
        private CAD_Parameter _MaxReverseVoltage;
        /// <summary>Reverse recovery time of the diode.</summary>
        private CAD_Parameter _ReverseRecoveryTime;
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
        //  DIODE CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public Diode()
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
        //
        //  Forward Voltage Drop (e.g., 0.7V for silicon)
        public CAD_Parameter ForwardVoltageDrop
        {
            set => _ForwardVoltageDrop = value;
            get { return _ForwardVoltageDrop; }
        }
        //
        //  Maximum Reverse Voltage
        public CAD_Parameter MaxReverseVoltage
        {
            set => _MaxReverseVoltage = value;
            get { return _MaxReverseVoltage; }
        }
        //
        //  Reverse Recovery Time
        public CAD_Parameter ReverseRecoveryTime
        {
            set => _ReverseRecoveryTime = value;
            get { return _ReverseRecoveryTime; }
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
