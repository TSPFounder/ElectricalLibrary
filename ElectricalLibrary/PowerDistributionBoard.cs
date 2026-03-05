using System;
using System.Text.Json;
using CAD;
using SE_Library;
using Electronics;

namespace Power
{
    public class PowerDistributionBoard : SE_System
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
        public enum PDBTypeEnum
        {
            Integrated = 0,     //  PDB built into frame
            Standalone,         //  Dedicated PDB board
            Stackable,          //  Flight controller stack form factor
            Other
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  POWERDISTRIBUTIONBOARD CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public PowerDistributionBoard()
        {
            //  Parameter Types
            MaxInputVoltage.MyParameterType = CAD_Parameter.ParameterType.Double;
            MaxContinuousCurrent.MyParameterType = CAD_Parameter.ParameterType.Double;
            MaxCurrentPerOutput.MyParameterType = CAD_Parameter.ParameterType.Double;
            BECVoltage.MyParameterType = CAD_Parameter.ParameterType.Double;
            BECCurrent.MyParameterType = CAD_Parameter.ParameterType.Double;
            Weight.MyParameterType = CAD_Parameter.ParameterType.Double;
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
        public CAD_Parameter Weight { get; set; } = new();
        public PDBTypeEnum PDBType { get; set; }
        //
        //  Power Input
        public CAD_Parameter MaxInputVoltage { get; set; } = new();         //  Volts
        public CAD_Parameter MaxContinuousCurrent { get; set; } = new();    //  Amps
        //
        //  Power Outputs
        public int NumOutputs { get; set; }
        public CAD_Parameter MaxCurrentPerOutput { get; set; } = new();     //  Amps
        //
        //  BEC (Battery Eliminator Circuit)
        public Boolean HasBEC { get; set; }
        public CAD_Parameter BECVoltage { get; set; } = new();              //  Volts
        public CAD_Parameter BECCurrent { get; set; } = new();              //  Amps
        //
        //  Sensors
        public Boolean HasCurrentSensor { get; set; }
        public Boolean HasVoltageSensor { get; set; }
        //
        //  Mounting
        public List<CAD_Hole> MountingHoles { get; set; } = new();
        //
        //  Owned & Owning Objects
        public Battery CurrentBattery { get; set; }
        public ElectronicSpeed_Controller CurrentESC { get; set; }
        public List<ElectronicSpeed_Controller> MyESCs { get; set; } = new();
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
        public static PowerDistributionBoard? FromJson(string json)
        {
            return JsonSerializer.Deserialize<PowerDistributionBoard>(json);
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
