using System;
using System.Text.Json;
using CAD;
using SE_Library;
using Structures;
using Power;

namespace Electronics
{
    public class ElectronicSpeed_Controller : SE_System
    {
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
        public enum ESCProtocolTypeEnum
        {
            PWM = 0,
            Oneshot125,
            Oneshot42,
            Multishot,
            DSHOT150,
            DSHOT300,
            DSHOT600,
            Other
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  ELECTRONICSPEED_CONTROLLER CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public ElectronicSpeed_Controller()
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
        public String FirmwareVersion { get; set; } = string.Empty;
        //
        //  Dimensions
        public CAD_Dimension Length { get; set; }
        public CAD_Dimension Width { get; set; }
        public CAD_Dimension Height { get; set; }
        public List<CAD_Dimension> MyDimensions { get; set; } = new();
        //
        //  Electrical Parameters
        public CAD_Parameter MaxContinuousCurrent { get; set; }     //  Amps
        public CAD_Parameter PeakCurrent { get; set; }              //  Amps
        public CAD_Parameter MinInputVoltage { get; set; }          //  Volts
        public CAD_Parameter MaxInputVoltage { get; set; }          //  Volts
        public CAD_Parameter PWMFrequency { get; set; }             //  Hz
        public CAD_Parameter SwitchingFrequency { get; set; }       //  Hz
        //
        //  BEC
        public Boolean HasBEC { get; set; }
        public CAD_Parameter BECVoltage { get; set; }               //  Volts
        public CAD_Parameter BECCurrent { get; set; }               //  Amps
        //
        //  Motor Compatibility
        public int MinCellCount { get; set; }
        public int MaxCellCount { get; set; }
        public int NumMotorPhases { get; set; } = 3;
        //
        //  Control Protocol
        public ESCProtocolTypeEnum ProtocolType { get; set; }
        public Boolean IsOptoCoupled { get; set; }
        //
        //  Owned & Owning Objects
        public StructuralCase MyCase { get; set; }
        public PrintedCircuitBoard MyPCB { get; set; }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  METHODS
        //
        //  ************************************************************
        #region
        //
        //  Is Compatible With Battery
        public Boolean IsCompatibleWithBattery(Battery battery)
        {
            if (battery == null) return false;
            return battery.NumCells >= MinCellCount && battery.NumCells <= MaxCellCount;
        }
        //
        //  Is Within Current Limit
        public Boolean IsWithinCurrentLimit(Double requestedCurrent)
        {
            if (MaxContinuousCurrent == null) return false;
            if (!MaxContinuousCurrent.TryGetDouble(out double limit)) return false;
            return requestedCurrent <= limit;
        }
        //
        //  Supports Protocol
        public Boolean SupportsProtocol(ESCProtocolTypeEnum protocol)
        {
            return ProtocolType == protocol;
        }
        //
        //  To JSON
        public string ToJson()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
        //
        //  From JSON
        public static ElectronicSpeed_Controller? FromJson(string json)
        {
            return JsonSerializer.Deserialize<ElectronicSpeed_Controller>(json);
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
