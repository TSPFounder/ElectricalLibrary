using System;
using System.Text.Json;
using CAD;

namespace Electrical
{
    public class Relay : ElectricalElement
    {
        //  *****************************************************************************************
        //  ENUMERATIONS
        //
        //  ************************************************************
        #region
        public enum RelayTypeEnum
        {
            Electromechanical = 0,
            SolidState,
            Reed,
            Latching,
            Contactor,
            TimerDelay,
            Other
        }

        public enum ContactConfigEnum
        {
            SPST_NO = 0,
            SPST_NC,
            SPDT,
            DPST,
            DPDT,
            ThreePDT,
            FourPDT,
            Other
        }

        public enum MountTypeEnum
        {
            ThroughHole = 0,
            SurfaceMount,
            SocketMount,
            PanelMount,
            DINRail,
            Other
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  RELAY CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public Relay()
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
        public String Make { get; set; } = string.Empty;
        public String Model { get; set; } = string.Empty;
        public String Version { get; set; } = string.Empty;
        //
        //  Dimensions
        public CAD_Dimension Length { get; set; }
        public CAD_Dimension Width { get; set; }
        public CAD_Dimension Height { get; set; }
        public List<CAD_Dimension> MyDimensions { get; set; } = new();
        //
        //  Physical Properties
        public CAD_Parameter Weight { get; set; }
        public RelayTypeEnum RelayType { get; set; }
        public ContactConfigEnum ContactConfig { get; set; }
        public MountTypeEnum MountType { get; set; }
        //
        //  Coil
        public CAD_Parameter CoilVoltage { get; set; }              //  Volts (nominal)
        public CAD_Parameter CoilResistance { get; set; }           //  Ohms
        public CAD_Parameter CoilCurrent { get; set; }              //  Amps (nominal)
        public CAD_Parameter PickUpVoltage { get; set; }            //  Volts (min to energize)
        public CAD_Parameter DropOutVoltage { get; set; }           //  Volts (max to de-energize)
        public CAD_Parameter CoilPower { get; set; }                //  Watts
        //
        //  Contacts
        public CAD_Parameter MaxSwitchingVoltage { get; set; }      //  Volts
        public CAD_Parameter MaxSwitchingCurrent { get; set; }      //  Amps
        public CAD_Parameter MaxSwitchingPower { get; set; }        //  Watts (or VA)
        public CAD_Parameter ContactResistance { get; set; }        //  Ohms
        public CAD_Parameter MaxCarryCurrent { get; set; }          //  Amps (continuous)
        public int NumPoles { get; set; }
        //
        //  Timing
        public CAD_Parameter OperateTime { get; set; }              //  ms (pick-up)
        public CAD_Parameter ReleaseTime { get; set; }              //  ms (drop-out)
        public CAD_Parameter MechanicalLife { get; set; }           //  cycles
        public CAD_Parameter ElectricalLife { get; set; }           //  cycles (at rated load)
        //
        //  Operating Conditions
        public CAD_Parameter MinOperatingTemp { get; set; }         //  deg Celsius
        public CAD_Parameter MaxOperatingTemp { get; set; }         //  deg Celsius
        //
        //  State
        public Boolean IsEnergized { get; set; }
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
        //  Energize the relay coil
        public void Energize()
        {
            IsEnergized = true;
        }
        //
        //  De-energize the relay coil
        public void DeEnergize()
        {
            IsEnergized = false;
        }
        //
        //  Calculate coil current from voltage: I = V / R
        public Double CalculateCoilCurrent(Double appliedVoltage)
        {
            if (CoilResistance == null || !CoilResistance.TryGetDouble(out double resistance) || resistance <= 0)
                return 0d;

            return appliedVoltage / resistance;
        }
        //
        //  Calculate coil power dissipation: P = V² / R
        public Double CalculateCoilPower(Double appliedVoltage)
        {
            if (CoilResistance == null || !CoilResistance.TryGetDouble(out double resistance) || resistance <= 0)
                return 0d;

            return appliedVoltage * appliedVoltage / resistance;
        }
        //
        //  Check if applied voltage is sufficient to energize
        public Boolean WillEnergize(Double appliedVoltage)
        {
            if (PickUpVoltage == null || !PickUpVoltage.TryGetDouble(out double pickUp))
                return false;

            return appliedVoltage >= pickUp;
        }
        //
        //  Check if load current is within contact rating
        public Boolean IsWithinContactRating(Double loadCurrent)
        {
            if (MaxSwitchingCurrent == null || !MaxSwitchingCurrent.TryGetDouble(out double limit))
                return true;

            return loadCurrent <= limit;
        }
        //
        //  Check if load voltage is within contact rating
        public Boolean IsWithinVoltageRating(Double loadVoltage)
        {
            if (MaxSwitchingVoltage == null || !MaxSwitchingVoltage.TryGetDouble(out double limit))
                return true;

            return loadVoltage <= limit;
        }
        //
        //  Check if within operating temperature range
        public Boolean IsWithinOperatingTemp(Double temperature)
        {
            if (MinOperatingTemp == null || !MinOperatingTemp.TryGetDouble(out double minTemp))
                return true;
            if (MaxOperatingTemp == null || !MaxOperatingTemp.TryGetDouble(out double maxTemp))
                return true;

            return temperature >= minTemp && temperature <= maxTemp;
        }
        //
        //  To JSON
        public string ToJson()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
        //
        //  From JSON
        public static Relay? FromJson(string json)
        {
            return JsonSerializer.Deserialize<Relay>(json);
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
