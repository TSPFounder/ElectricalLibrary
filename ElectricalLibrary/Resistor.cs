using System;
using System.Text.Json;
using CAD;

namespace Electrical
{
    public class Resistor : ElectricalElement
    {
        //  *****************************************************************************************
        //  DECLARATIONS
        //
        //  ************************************************************
        #region
        //
        //  Data
        private CAD_Parameter _NominalResistance;       //  Ohms
        private CAD_Parameter _Tolerance;               //  %
        private CAD_Parameter _PowerRating;             //  Watts
        private CAD_Parameter _MaxVoltage;              //  Volts
        private CAD_Parameter _TemperatureCoefficient;  //  ppm/°C (TCR)
        private ResistorTypeEnum _ResistorType;
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
        public enum ResistorTypeEnum
        {
            CarbonFilm = 0,
            MetalFilm,
            Wirewound,
            ThinFilm,
            ThickFilm,
            Other
        }
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
        //  Data
        //
        //  Nominal Resistance
        public CAD_Parameter NominalResistance
        {
            set => _NominalResistance = value;
            get { return _NominalResistance; }
        }
        //
        //  Tolerance
        public CAD_Parameter Tolerance
        {
            set => _Tolerance = value;
            get { return _Tolerance; }
        }
        //
        //  Power Rating
        public CAD_Parameter PowerRating
        {
            set => _PowerRating = value;
            get { return _PowerRating; }
        }
        //
        //  Maximum Voltage
        public CAD_Parameter MaxVoltage
        {
            set => _MaxVoltage = value;
            get { return _MaxVoltage; }
        }
        //
        //  Temperature Coefficient of Resistance
        public CAD_Parameter TemperatureCoefficient
        {
            set => _TemperatureCoefficient = value;
            get { return _TemperatureCoefficient; }
        }
        //
        //  Resistor Type
        public ResistorTypeEnum ResistorType
        {
            set => _ResistorType = value;
            get { return _ResistorType; }
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
        public static Resistor? FromJson(string json)
        {
            return JsonSerializer.Deserialize<Resistor>(json);
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
