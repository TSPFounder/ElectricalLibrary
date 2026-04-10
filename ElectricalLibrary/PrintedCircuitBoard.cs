using System;
using System.Text.Json;
using CAD;
using SE_Library;
using Electrical;

namespace Electronics
{
    public class PrintedCircuitBoard : SE_System
    {
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
            HDI,
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
            CEM1,
            CEM3,
            Other
        }

        public enum SurfaceFinishEnum
        {
            HASL = 0,           //  Hot Air Solder Leveling
            LeadFreeHASL,
            ENIG,               //  Electroless Nickel Immersion Gold
            OSP,                //  Organic Solderability Preservative
            ImmersionSilver,
            ImmersionTin,
            HardGold,
            ENEPIG,             //  Electroless Nickel Electroless Palladium Immersion Gold
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

        public enum ViaTypeEnum
        {
            ThroughHole = 0,
            BlindVia,
            BuriedVia,
            Microvia,
            ViaInPad,
            Other
        }

        public enum LayerTypeEnum
        {
            Signal = 0,
            Ground,
            Power,
            Mixed,
            Other
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
            BoardArea.MyParameterType = CAD_Parameter.ParameterType.Double;
            DielectricConstant.MyParameterType = CAD_Parameter.ParameterType.Double;
            MaxCurrentPerTrace.MyParameterType = CAD_Parameter.ParameterType.Double;
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
        //  Board Dimensions
        public CAD_Dimension Length { get; set; }
        public CAD_Dimension Width { get; set; }
        public CAD_Parameter Thickness { get; set; } = new();           //  mm
        public CAD_Parameter BoardArea { get; set; } = new();           //  mm²
        public List<CAD_Dimension> MyDimensions { get; set; } = new();
        //
        //  Trace & Spacing
        public CAD_Dimension MinTraceWidth { get; set; }                //  mm
        public CAD_Dimension MaxTraceWidth { get; set; }                //  mm
        public CAD_Dimension MinTraceSpacing { get; set; }              //  mm
        public CAD_Parameter MaxCurrentPerTrace { get; set; } = new();  //  Amps
        //
        //  Via Specifications
        public CAD_Dimension MinViaDiameter { get; set; }               //  mm (finished hole)
        public CAD_Dimension MinViaAnnularRing { get; set; }            //  mm
        public CAD_Dimension MinDrillSize { get; set; }                 //  mm
        public CAD_Dimension AspectRatio { get; set; }                  //  depth:diameter
        public ViaTypeEnum DefaultViaType { get; set; }
        public int ViaCount { get; set; }
        public List<CAD_Hole> MyVias { get; set; } = new();
        //
        //  Physical Properties
        public CAD_Parameter CopperWeight { get; set; } = new();        //  oz/ft²
        public CAD_Parameter Weight { get; set; } = new();
        public CAD_Parameter DielectricConstant { get; set; } = new();  //  Er (substrate)
        public PCBTypeEnum PCBType { get; set; }
        public SubstrateEnum Substrate { get; set; }
        public SurfaceFinishEnum SurfaceFinish { get; set; }
        public SolderMaskColorEnum SolderMaskColor { get; set; }
        //
        //  Layer Stack
        public int NumLayers { get; set; }
        public int NumSignalLayers { get; set; }
        public int NumPlaneLayers { get; set; }
        public Boolean HasGroundPlane { get; set; }
        public Boolean HasPowerPlane { get; set; }
        public List<LayerTypeEnum> LayerStack { get; set; } = new();
        //
        //  Design Rules
        public CAD_Dimension MinPadSize { get; set; }                   //  mm
        public CAD_Dimension MinSolderMaskDam { get; set; }             //  mm
        public Boolean HasImpedanceControl { get; set; }
        public CAD_Parameter ControlledImpedance { get; set; }          //  Ohms
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
        public ElectricCircuit CurrentCircuit { get; set; }
        public List<ElectricCircuit> MyCircuits { get; set; } = new();
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
        //  Remove Component
        public Boolean RemoveComponent(ElectronicComponent component)
        {
            Boolean removed = MyComponents.Remove(component);
            if (removed && CurrentComponent == component)
                CurrentComponent = MyComponents.Count > 0 ? MyComponents[^1] : null;
            return removed;
        }
        //
        //  Add Connector
        public void AddConnector(ElectricalConnector connector)
        {
            CurrentConnector = connector;
            MyConnectors.Add(connector);
        }
        //
        //  Add Circuit
        public void AddCircuit(ElectricCircuit circuit)
        {
            CurrentCircuit = circuit;
            MyCircuits.Add(circuit);
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
        //  Get Via Count
        public int GetViaCount()
        {
            return MyVias.Count;
        }
        //
        //  Add Layer to Stack
        public void AddLayer(LayerTypeEnum layerType)
        {
            LayerStack.Add(layerType);
            NumLayers = LayerStack.Count;

            if (layerType == LayerTypeEnum.Signal)
                NumSignalLayers++;
            else if (layerType == LayerTypeEnum.Ground || layerType == LayerTypeEnum.Power)
                NumPlaneLayers++;

            if (layerType == LayerTypeEnum.Ground)
                HasGroundPlane = true;
            if (layerType == LayerTypeEnum.Power)
                HasPowerPlane = true;
        }
        //
        //  Calculate board area: A = L × W (mm²)
        public Double CalculateBoardArea(Double lengthMm, Double widthMm)
        {
            return lengthMm * widthMm;
        }
        //
        //  Estimate trace current capacity (IPC-2221): I = k × ΔT^0.44 × A^0.725
        //  A = cross-section area in mils², k = 0.048 for external, 0.024 for internal
        public Double EstimateTraceCurrentCapacity(Double traceWidthMils, Double copperThicknessMils, Double tempRiseDegC, Boolean isExternal)
        {
            if (traceWidthMils <= 0 || copperThicknessMils <= 0 || tempRiseDegC <= 0)
                return 0d;

            double crossSection = traceWidthMils * copperThicknessMils;
            double k = isExternal ? 0.048d : 0.024d;

            return k * Math.Pow(tempRiseDegC, 0.44d) * Math.Pow(crossSection, 0.725d);
        }
        //
        //  Estimate via current capacity (single via): I ≈ k × ΔT^0.44 × A^0.725
        //  A = π × (OD² - ID²) / 4 as annular cross-section in mils²
        public Double EstimateViaCurrentCapacity(Double outerDiameterMils, Double drillDiameterMils, Double copperPlatingMils, Double tempRiseDegC)
        {
            if (outerDiameterMils <= 0 || drillDiameterMils <= 0 || copperPlatingMils <= 0 || tempRiseDegC <= 0)
                return 0d;

            double crossSection = Math.PI * drillDiameterMils * copperPlatingMils;
            double k = 0.048d;

            return k * Math.Pow(tempRiseDegC, 0.44d) * Math.Pow(crossSection, 0.725d);
        }
        //
        //  Calculate via aspect ratio: AR = board thickness / drill diameter
        public Double CalculateViaAspectRatio(Double boardThicknessMm, Double drillDiameterMm)
        {
            if (drillDiameterMm <= 0)
                return 0d;

            return boardThicknessMm / drillDiameterMm;
        }
        //
        //  Estimate microstrip impedance: Z₀ ≈ (87 / √(Er + 1.41)) × ln(5.98 × h / (0.8 × w + t))
        public Double EstimateMicrostripImpedance(Double dielectricHeight, Double traceWidth, Double copperThickness, Double er)
        {
            if (er <= 0 || traceWidth <= 0 || copperThickness <= 0 || dielectricHeight <= 0)
                return 0d;

            double denominator = 0.8d * traceWidth + copperThickness;
            if (denominator <= 0)
                return 0d;

            return (87d / Math.Sqrt(er + 1.41d)) * Math.Log(5.98d * dielectricHeight / denominator);
        }
        //
        //  Calculate component density: components / area (per mm²)
        public Double CalculateComponentDensity(Double boardAreaMm2)
        {
            if (boardAreaMm2 <= 0)
                return 0d;

            return MyComponents.Count / boardAreaMm2;
        }
        //
        //  Check if within operating temperature range
        public Boolean IsWithinOperatingTemp(Double temperature)
        {
            if (!MinOperatingTemp.TryGetDouble(out double minTemp))
                return true;
            if (!MaxOperatingTemp.TryGetDouble(out double maxTemp))
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
