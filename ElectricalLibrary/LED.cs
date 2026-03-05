using System;
using System.Text.Json;
using CAD;
using Electrical;

namespace Electronics
{
    public class LED : ElectricalElement
    {
        //  *****************************************************************************************
        //  DECLARATIONS
        //
        //  ************************************************************
        #region
        //
        //  Data
        private CAD_Parameter _ForwardVoltage;          //  Volts (Vf)
        private CAD_Parameter _MaxForwardCurrent;       //  Amps
        private CAD_Parameter _LuminousIntensity;       //  mcd (millicandela)
        private CAD_Parameter _WavelengthPeak;          //  nm
        private CAD_Parameter _ViewingAngle;            //  degrees
        private CAD_Parameter _ColorTemperature;        //  Kelvin (white LEDs)
        private CAD_Parameter _MaxPowerDissipation;     //  Watts
        private LEDColorEnum _LEDColor;
        private LEDPackageEnum _PackageType;
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
        public enum LEDColorEnum
        {
            Red = 0,
            Green,
            Blue,
            White,
            Yellow,
            Orange,
            Infrared,
            Ultraviolet,
            RGB,
            Other
        }

        public enum LEDPackageEnum
        {
            ThroughHole = 0,
            SMD_0402,
            SMD_0603,
            SMD_0805,
            SMD_1206,
            PowerLED,
            Other
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  LED CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public LED()
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
        //  Forward Voltage
        public CAD_Parameter ForwardVoltage
        {
            set => _ForwardVoltage = value;
            get { return _ForwardVoltage; }
        }
        //
        //  Maximum Forward Current
        public CAD_Parameter MaxForwardCurrent
        {
            set => _MaxForwardCurrent = value;
            get { return _MaxForwardCurrent; }
        }
        //
        //  Luminous Intensity
        public CAD_Parameter LuminousIntensity
        {
            set => _LuminousIntensity = value;
            get { return _LuminousIntensity; }
        }
        //
        //  Peak Wavelength
        public CAD_Parameter WavelengthPeak
        {
            set => _WavelengthPeak = value;
            get { return _WavelengthPeak; }
        }
        //
        //  Viewing Angle
        public CAD_Parameter ViewingAngle
        {
            set => _ViewingAngle = value;
            get { return _ViewingAngle; }
        }
        //
        //  Color Temperature
        public CAD_Parameter ColorTemperature
        {
            set => _ColorTemperature = value;
            get { return _ColorTemperature; }
        }
        //
        //  Maximum Power Dissipation
        public CAD_Parameter MaxPowerDissipation
        {
            set => _MaxPowerDissipation = value;
            get { return _MaxPowerDissipation; }
        }
        //
        //  LED Color
        public LEDColorEnum LEDColor
        {
            set => _LEDColor = value;
            get { return _LEDColor; }
        }
        //
        //  Package Type
        public LEDPackageEnum PackageType
        {
            set => _PackageType = value;
            get { return _PackageType; }
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
        public static LED? FromJson(string json)
        {
            return JsonSerializer.Deserialize<LED>(json);
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
