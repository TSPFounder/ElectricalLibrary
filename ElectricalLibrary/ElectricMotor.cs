using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemsEngineering;
using CAD;
using MissionsNamespace;
using Electronics;
using Structure;
using Magnetics;

namespace PowerTransmission
{
    public class ElectricMotor : DWM_System
    {
        //  *****************************************************************************************
        //  DECLARATIONS
        //
        //  ************************************************************
        //
        //  Identification

        //  
        //  Data
        //
        //  Type
        private ElectricMotorTypeEnum _ElectricMotorType;
        //
        //  Dimensions
        private CAD_Dimension _Length, _Width, _Height;
        private CAD_Dimension _DefaultFilletRadius;
        //
        //  Dimension List
        private List<CAD_Dimension> _MyDimensions;
        //
        //  Parameters
        private CAD_Parameter _MaxCurrent;
        private CAD_Parameter _PeakTorque;
        private CAD_Parameter _MaxRPM;
        private CAD_Parameter _InputVoltage;
        private CAD_Parameter _Horsepower;
        //
        //  Number of Phases
        private int _NumPhases;
        //
        //  Number of Turns
        private int _NumTurns;
        //
        //  Booleans
        private Boolean _IsOutrunner;
        private Boolean _IsBrushed;
        private Boolean _IsAC;
        //
        //  Owned & Owning Objects
        //
        //  Structural Elements
        private StructuralCase _MyCase;
        private Shaft _MyRotorShaft;
        private Bearing _CurrentBearing;
        private List<Bearing> _MyBearings;
        //
        //  Magnetic Elements
        private ElectricWire _CurrentCoil;
        private List<ElectricWire> _MyCoils;
        private Magnet _CurrentMagnet;
        private List<Magnet> _MyMagnets;
        //
        //  Electric Elements
        private ElectricCable _CurrentElectricCable;
       private List<ElectricCable> _MyElectricCables;
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
        public enum ElectricMotorTypeEnum
        {
            BLDC = 0,
            Stepper,
            PMLSM,
            PMSM,
            Brushed,
            Other
        }
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  ELECTRICMOTOR CONSTRUCTOR
        //
        //  ************************************************************
        public ElectricMotor()
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
        //  Data
        public ElectricMotorTypeEnum ElectricMotorType
        {
            set => _ElectricMotorType = value;
            get { return _ElectricMotorType; }
        }
        //
        //  Parameters
        //
        //  Maximum Current
        public CAD_Parameter MaxCurrent
        {
            set => _MaxCurrent = value;
            get { return _MaxCurrent; }
        }
        //
        //  Peak Torque
        public CAD_Parameter PeakTorque
        {
            set => _PeakTorque = value;
            get { return _PeakTorque; }
        }
        //
        //  Maximum RPM
        public CAD_Parameter MaxRPM
        {
            set => _MaxRPM = value;
            get { return _MaxRPM; }
        }
        //
        //  Input Voltage
        public CAD_Parameter InputVoltage
        {
            set => _InputVoltage = value;
            get { return _InputVoltage; }
        }
        //
        // Horsepower
        public CAD_Parameter Horsepower
        {
            set => _Horsepower = value;
            get { return _Horsepower; }
        }
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
        //  Default Fillet Radius
        public CAD_Dimension DefaultFilletRadius
        {
            set
            {
                _DefaultFilletRadius = value;
                this.MyDimensions.Add(_DefaultFilletRadius);
            }
            get { return _DefaultFilletRadius; }
        }
        //
        //  Dimension List
        public List<CAD_Dimension> MyDimensions
        {
            set => _MyDimensions = value;
            get { return _MyDimensions; }
        }
        //
        //  Number of Phases
        public int NumPhases
        {
            set => _NumPhases = value;
            get { return _NumPhases; }
        }
        //
        //  Number of Turns
        public int NumTurns
        {
            set => _NumTurns = value;
            get { return _NumTurns; }
        }
        //
        //  Booleans
        //
        //  Is an Outrunner
        public Boolean IsOutrunner
        {
            set => _IsOutrunner = value;
            get { return _IsOutrunner; }
        }
        //
        //  Is Brushed
        public Boolean IsBrushed
        {
            set => _IsBrushed = value;
            get { return _IsBrushed; }
        }
        //
        //  Is AC
        public Boolean IsAC
        {
            set => _IsAC = value;
            get { return _IsAC; }
        }
        //
        //  Owned & Owning Objects
        //
        //  Structural Elements
        public StructuralCase MyCase
        {
            set => _MyCase = value;
            get { return _MyCase; }
        }
        public Shaft MyRotorShaft
        {
            set => _MyRotorShaft = value;
            get { return _MyRotorShaft; }
        }
        public Bearing CurrentBearing
        {
            set => _CurrentBearing = value;
            get { return _CurrentBearing; }
        }
        public List<Bearing> MyBearings
        {
            set => _MyBearings = value;
            get { return _MyBearings; }
        }
        //
        //  Magnetic Elements
        public ElectricWire CurrentCoil
        {
            set => _CurrentCoil = value;
            get { return _CurrentCoil; }
        }
        public List<ElectricWire> MyCoils
        {
            set => _MyCoils = value;
            get { return _MyCoils; }
        }
        //
        //  Magnets
        public Magnet CurrentMagnet
        {
            set => _CurrentMagnet = value;
            get { return _CurrentMagnet; }
        }
        public List<Magnet> MyMagnets
        {
            set => _MyMagnets = value;
            get { return _MyMagnets; }
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
