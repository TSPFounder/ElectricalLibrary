using System;
using System.Text.Json;
using CAD;
using SE_Library;

namespace Power
{
    public class Battery : SE_System
    {
        //  *****************************************************************************************
        //  DECLARATIONS
        //
        //  ************************************************************
        #region
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
        //  Dimension List
        private List<CAD_Dimension> _MyDimensions;
        //
        //  States
        private CAD_Parameter _ChargeLevel;
        //
        //  Physical Properties
        private CAD_Parameter _Weight;
        private CAD_Parameter _PanelLeadGauge;
        private Battery_TypeEnum _BatteryType;
        private int _NumCells;
        private int _NumChargeCycles;
        //
        //  Performance
        private CAD_Parameter _MaxCurrent;          //  Amps
        private CAD_Parameter _Capacity;            //  mAh
        private CAD_Parameter _MaxDischargeRate;    //  C
        private CAD_Parameter _MaxChargeRate;       //  C
        private CAD_Parameter _InternalResistance;  //  mΩ
        private CAD_Parameter _NominalVoltage;      //  Volts
        private CAD_Parameter _FullChargeVoltage;   //  Volts
        private CAD_Parameter _StorageVoltage;      //  Volts
        private CAD_Parameter _MinOperatingTemp;    //  deg Celsius
        private CAD_Parameter _MaxOperatingTemp;    //  deg Celsius
        //
        //  Owned & Owning Objects
        //
        //  Discharge Connector
        private CAD_Part _DischargeConnector;
        //
        //  Balance Connector
        private CAD_Part _BalanceConnector;
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
        public enum Battery_TypeEnum
        {
            Lipo = 0,
            LeadAcid,
            NiCad,
            NMH,
            LiIon,
            LiFe,
            Other
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  BATTERY CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public Battery()
        {
            _MyDimensions = new List<CAD_Dimension>();
            _Make = string.Empty;
            _Model = string.Empty;
            _Version = string.Empty;
            //
            //  Parameters
            _Weight = new CAD_Parameter();
            _PanelLeadGauge = new CAD_Parameter();
            _ChargeLevel = new CAD_Parameter();
            _MaxCurrent = new CAD_Parameter();
            _Capacity = new CAD_Parameter();
            _MaxDischargeRate = new CAD_Parameter();
            _MaxChargeRate = new CAD_Parameter();
            _InternalResistance = new CAD_Parameter();
            _NominalVoltage = new CAD_Parameter();
            _FullChargeVoltage = new CAD_Parameter();
            _StorageVoltage = new CAD_Parameter();
            _MinOperatingTemp = new CAD_Parameter();
            _MaxOperatingTemp = new CAD_Parameter();
            //
            //  Parameter Types
            this.Weight.MyParameterType = CAD_Parameter.ParameterType.Double;
            this.PanelLeadGauge.MyParameterType = CAD_Parameter.ParameterType.String;
            this.ChargeLevel.MyParameterType = CAD_Parameter.ParameterType.Double;
            this.MaxCurrent.MyParameterType = CAD_Parameter.ParameterType.Double;
            this.Capacity.MyParameterType = CAD_Parameter.ParameterType.Double;
            this.MaxDischargeRate.MyParameterType = CAD_Parameter.ParameterType.Double;
            this.MaxChargeRate.MyParameterType = CAD_Parameter.ParameterType.Double;
            this.InternalResistance.MyParameterType = CAD_Parameter.ParameterType.Double;
            this.NominalVoltage.MyParameterType = CAD_Parameter.ParameterType.Double;
            this.FullChargeVoltage.MyParameterType = CAD_Parameter.ParameterType.Double;
            this.StorageVoltage.MyParameterType = CAD_Parameter.ParameterType.Double;
            this.MinOperatingTemp.MyParameterType = CAD_Parameter.ParameterType.Double;
            this.MaxOperatingTemp.MyParameterType = CAD_Parameter.ParameterType.Double;
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
        //  Make
        public String Make
        {
            set => _Make = value;
            get { return _Make; }
        }
        //
        //  Model
        public String Model
        {
            set => _Model = value;
            get { return _Model; }
        }
        //
        //  Version
        public String Version
        {
            set => _Version = value;
            get { return _Version; }
        }
        //
        //  Data
        //
        //  Dimensions
        //
        //  Length
        public CAD_Dimension Length
        {
            set
            {
                _Length = value;
                this.MyDimensions.Add(_Length);
            }
            get { return _Length; }
        }
        //
        //  Width
        public CAD_Dimension Width
        {
            set
            {
                _Width = value;
                this.MyDimensions.Add(_Width);
            }
            get { return _Width; }
        }
        //
        //  Height
        public CAD_Dimension Height
        {
            set
            {
                _Height = value;
                this.MyDimensions.Add(_Height);
            }
            get { return _Height; }
        }
        //
        //  Dimension List
        public List<CAD_Dimension> MyDimensions
        {
            set => _MyDimensions = value;
            get { return _MyDimensions; }
        }
        //
        //  States
        //
        //  Charge Level
        public CAD_Parameter ChargeLevel
        {
            set => _ChargeLevel = value;
            get { return _ChargeLevel; }
        }
        //
        //  Physical Properties
        //
        //  Weight
        public CAD_Parameter Weight
        {
            set => _Weight = value;
            get { return _Weight; }
        }
        //
        //  Panel Lead Gauge
        public CAD_Parameter PanelLeadGauge
        {
            set => _PanelLeadGauge = value;
            get { return _PanelLeadGauge; }
        }
        //
        //  Battery Type
        public Battery_TypeEnum BatteryType
        {
            set => _BatteryType = value;
            get { return _BatteryType; }
        }
        //
        //  Number of Cells
        public int NumCells
        {
            set => _NumCells = value;
            get { return _NumCells; }
        }
        //
        //  Number of Charge Cycles
        public int NumChargeCycles
        {
            set => _NumChargeCycles = value;
            get { return _NumChargeCycles; }
        }
        //
        //  Performance
        //
        //  Maximum Current
        public CAD_Parameter MaxCurrent
        {
            set => _MaxCurrent = value;
            get { return _MaxCurrent; }
        }
        //
        //  Capacity
        public CAD_Parameter Capacity
        {
            set => _Capacity = value;
            get { return _Capacity; }
        }
        //
        //  Maximum Discharge Rate
        public CAD_Parameter MaxDischargeRate
        {
            set => _MaxDischargeRate = value;
            get { return _MaxDischargeRate; }
        }
        //
        //  Maximum Charge Rate
        public CAD_Parameter MaxChargeRate
        {
            set => _MaxChargeRate = value;
            get { return _MaxChargeRate; }
        }
        //
        //  Internal Resistance
        public CAD_Parameter InternalResistance
        {
            set => _InternalResistance = value;
            get { return _InternalResistance; }
        }
        //
        //  Nominal Voltage
        public CAD_Parameter NominalVoltage
        {
            set => _NominalVoltage = value;
            get { return _NominalVoltage; }
        }
        //
        //  Full Charge Voltage
        public CAD_Parameter FullChargeVoltage
        {
            set => _FullChargeVoltage = value;
            get { return _FullChargeVoltage; }
        }
        //
        //  Storage Voltage
        public CAD_Parameter StorageVoltage
        {
            set => _StorageVoltage = value;
            get { return _StorageVoltage; }
        }
        //
        //  Minimum Operating Temperature
        public CAD_Parameter MinOperatingTemp
        {
            set => _MinOperatingTemp = value;
            get { return _MinOperatingTemp; }
        }
        //
        //  Maximum Operating Temperature
        public CAD_Parameter MaxOperatingTemp
        {
            set => _MaxOperatingTemp = value;
            get { return _MaxOperatingTemp; }
        }
        //
        //  Owned & Owning Objects
        //
        //  Discharge Connector
        public CAD_Part DischargeConnector
        {
            set => _DischargeConnector = value;
            get { return _DischargeConnector; }
        }
        //
        //  Balance Connector
        public CAD_Part BalanceConnector
        {
            set => _BalanceConnector = value;
            get { return _BalanceConnector; }
        }
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
        public static Battery? FromJson(string json)
        {
            return JsonSerializer.Deserialize<Battery>(json);
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
