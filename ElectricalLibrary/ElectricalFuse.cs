using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Electronics;
using CAD;

namespace Power
{
    public class ElectricalFuse : ElectricalElement
    {
        //  *****************************************************************************************
        //  DECLARATIONS
        //
        //  ************************************************************
        //
        //  Identification
        private String _Make;
        private String _Model;
        private String _Version;
        //
        //  Data
        //
        //  Dimensions
        private CAD_Dimension _Length;
        private CAD_Dimension _Width;
        private CAD_Dimension _Height;
        //
        //  Physical Properties
        private CAD_Parameter _Weight;
        private String _WireGauge;
        //
        //  Performance
        private CAD_Parameter _MaxInputCurrent;  // ohms
        private CAD_Parameter _InputVoltage;  //  Volts
        //
        //  Owned & Owning Objects
        //
        //  Connector
        private ElectricalConnector _MyConnector;
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

        //  *****************************************************************************************


        //  *****************************************************************************************
        //  ELECTRICALFUSE CONSTRUCTOR
        //
        //  ************************************************************
        public ElectricalFuse()
        {

        }
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  PROPERTIES
        //
        //  ************************************************************
        //
        //  Identification
        //
        //  Make
        public String Make
        {
            set => _Make = value;
            get
            {
                return _Make;
            }
        }
        //
        //  Model
        public String Model
        {
            set => _Model = value;
            get
            {
                return _Model;
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
        //  Data
        //
        //  Dimensions
        public CAD_Dimension Length
        {
            set => _Length = value;
            get
            {
                return _Length;
            }
        }
        public CAD_Dimension Width
        {
            set => _Width = value;
            get
            {
                return _Width;
            }
        }
        public CAD_Dimension Height
        {
            set => _Height = value;
            get
            {
                return _Height;
            }
        }


        //
        //  Physical Properties
        public CAD_Parameter Weight
        {
            set => _Weight = value;
            get
            {
                return _Weight;
            }
        }
        public String WireGauge
        {
            set => _WireGauge = value;
            get
            {
                return _WireGauge;
            }
        }
        //
        //  Performance
        public CAD_Parameter MaxInputCurrent
        {
            set => _MaxInputCurrent = value;
            get
            {
                return _MaxInputCurrent;
            }
        }
        public CAD_Parameter InputVoltage
        {
            set => _InputVoltage = value;
            get
            {
                return _InputVoltage;
            }
        }
        //
        //  Owned & Owning Objects
        //
        //  Connector
        public ElectricalConnector MyConnector
        {
            set => _MyConnector = value;
            get
            {
                return _MyConnector;
            }
        }
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  METHODS
        //
        //  ************************************************************

        //  *****************************************************************************************


        //  *****************************************************************************************
        //  EVENTS
        //
        //  ************************************************************

        //  *****************************************************************************************
    }
}
