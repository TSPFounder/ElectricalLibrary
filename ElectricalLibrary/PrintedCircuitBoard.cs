using System;
using System.Text.Json;
using CAD;
using SE_Library;
using Electrical;

namespace Electronics
{
    public class PrintedCircuitBoard : SE_System
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
        public enum PCBTypeEnum
        {
            SingleSided = 0,
            DoubleSided,
            MultiLayer,
            Flexible,
            RigidFlex,
            MetalCore,
            Other
        }

        public enum SubstrateEnum
        {
            FR4 = 0,
            FR2,
            Rogers,
            Aluminum,
            Polyimide,
            PTFE,
            Other
        }

        public enum SurfaceFinishEnum
        {
            HASL = 0,       //  Hot Air Solder Leveling
            LeadFreeHASL,
            ENIG,           //  Electroless Nickel Immersion Gold
            OSP,            //  Organic Solderability Preservative
            ImmersionSilver,
            ImmersionTin,
            HardGold,
            Other
        }

        public enum SolderMaskColorEnum
        {
            Green = 0,
            Red,
            Blue,
            Black,
            White,
            Yellow,
            Purple,
            None
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  PRINTEDCIRCUITBOARD CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public PrintedCircuitBoard()
        {
            //  Parameter Types
            Thickness.MyParameterType = CAD_Parameter.ParameterType.Double;
            CopperWeight.MyParameterType = CAD_Parameter.ParameterType.Double;
            Weight.MyParameterType = CAD_Parameter.ParameterType.Double;
            MinOperatingTemp.MyParameterType = CAD_Parameter.ParameterType.Double;
            MaxOperatingTemp.MyParameterType = CAD_Parameter.ParameterType.Double;
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
        public String PartNumber { get; set; } = string.Empty;
        public String Revision { get; set; } = string.Empty;
        //
        //  Dimensions
        public CAD_Dimension Length { get; set; }
        public CAD_Dimension Width { get; set; }
        public CAD_Dimension MinTraceWidth { get; set; }        //  mm
        public CAD_Dimension MinViaDiameter { get; set; }      //  mm
        public CAD_Dimension MinDrillSize { get; set; }        //  mm
        public List<CAD_Dimension> MyDimensions { get; set; } = new();
        //
        //  Physical Properties
        public CAD_Parameter Thickness { get; set; } = new();          //  mm
        public CAD_Parameter CopperWeight { get; set; } = new();       //  oz/ft²
        public CAD_Parameter Weight { get; set; } = new();
        public PCBTypeEnum PCBType { get; set; }
        public SubstrateEnum Substrate { get; set; }
        public SurfaceFinishEnum SurfaceFinish { get; set; }
        public SolderMaskColorEnum SolderMaskColor { get; set; }
        //
        //  Layer Stack
        public int NumLayers { get; set; }
        public Boolean HasGroundPlane { get; set; }
        public Boolean HasPowerPlane { get; set; }
        //
        //  Operating Conditions
        public CAD_Parameter MinOperatingTemp { get; set; } = new();    //  deg Celsius
        public CAD_Parameter MaxOperatingTemp { get; set; } = new();    //  deg Celsius
        //
        //  Owned & Owning Objects
        public ElectronicComponent CurrentComponent { get; set; }
        public List<ElectronicComponent> MyComponents { get; set; } = new();
        public ElectricalConnector CurrentConnector { get; set; }
        public List<ElectricalConnector> MyConnectors { get; set; } = new();
        public List<CAD_Hole> MountingHoles { get; set; } = new();
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  METHODS
        //
        //  ************************************************************
        #region
        //
        //  Add Component
        public void AddComponent(ElectronicComponent component)
        {
            CurrentComponent = component;
            MyComponents.Add(component);
        }
        //
        //  Add Connector
        public void AddConnector(ElectricalConnector connector)
        {
            CurrentConnector = connector;
            MyConnectors.Add(connector);
        }
        //
        //  Get Component Count
        public int GetComponentCount()
        {
            return MyComponents.Count;
        }
        //
        //  Get Connector Count
        public int GetConnectorCount()
        {
            return MyConnectors.Count;
        }
        //
        //  To JSON
        public string ToJson()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
        //
        //  From JSON
        public static PrintedCircuitBoard? FromJson(string json)
        {
            return JsonSerializer.Deserialize<PrintedCircuitBoard>(json);
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
