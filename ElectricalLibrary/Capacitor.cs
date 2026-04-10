using System;
using System.Text.Json;
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
        //  Data
        private CAD_Parameter _NominalCapacitance;      //  Farads
        private CAD_Parameter _MaxVoltage;              //  Volts
        private CAD_Parameter _ESR;                     //  Ohms (Equivalent Series Resistance)
        private CAD_Parameter _MaxRippleCurrent;        //  Amps
        private CAD_Parameter _Tolerance;               //  %
        private CAD_Parameter _TemperatureCoefficient;  //  ppm/°C
        private CapacitorTypeEnum _CapacitorType;
        private Boolean _IsVariable;
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
        public enum CapacitorTypeEnum
        {
            Ceramic = 0,
            Electrolytic,
            Film,
            Tantalum,
            Supercapacitor,
            Other
        }
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
        //  Data
        //
        //  Nominal Capacitance
        public CAD_Parameter NominalCapacitance
        {
            set => _NominalCapacitance = value;
            get { return _NominalCapacitance; }
        }
        //
        //  Maximum Voltage
        public CAD_Parameter MaxVoltage
        {
            set => _MaxVoltage = value;
            get { return _MaxVoltage; }
        }
        //
        //  Equivalent Series Resistance
        public CAD_Parameter ESR
        {
            set => _ESR = value;
            get { return _ESR; }
        }
        //
        //  Maximum Ripple Current
        public CAD_Parameter MaxRippleCurrent
        {
            set => _MaxRippleCurrent = value;
            get { return _MaxRippleCurrent; }
        }
        //
        //  Tolerance
        public CAD_Parameter Tolerance
        {
            set => _Tolerance = value;
            get { return _Tolerance; }
        }
        //
        //  Temperature Coefficient
        public CAD_Parameter TemperatureCoefficient
        {
            set => _TemperatureCoefficient = value;
            get { return _TemperatureCoefficient; }
        }
        //
        //  Capacitor Type
        public CapacitorTypeEnum CapacitorType
        {
            set => _CapacitorType = value;
            get { return _CapacitorType; }
        }
        //
        //  Is Variable (e.g. trimmer, varicap)
        public Boolean IsVariable
        {
            set => _IsVariable = value;
            get { return _IsVariable; }
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
        //
        //  To JSON
        public string ToJson()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
        //
        //  From JSON
        public static Capacitor? FromJson(string json)
        {
            return JsonSerializer.Deserialize<Capacitor>(json);
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
