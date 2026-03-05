using System;
using System.Text.Json;
using CAD;

namespace Electrical
{
    public class Inductor : ElectricalElement
    {
        //  *****************************************************************************************
        //  DECLARATIONS
        //
        //  ************************************************************
        #region
        //
        //  Data
        private CAD_Parameter _NominalInductance;       //  Henries
        private CAD_Parameter _DCResistance;            //  Ohms (DCR)
        private CAD_Parameter _MaxCurrent;              //  Amps (saturation current)
        private CAD_Parameter _SelfResonantFrequency;   //  Hz
        private CAD_Parameter _Tolerance;               //  %
        private InductorTypeEnum _InductorType;
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
        public enum InductorTypeEnum
        {
            Wirewound = 0,
            Multilayer,
            Ferrite,
            Toroidal,
            PowerInductor,
            Other
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  INDUCTOR CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public Inductor()
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
        //  Nominal Inductance
        public CAD_Parameter NominalInductance
        {
            set => _NominalInductance = value;
            get { return _NominalInductance; }
        }
        //
        //  DC Resistance
        public CAD_Parameter DCResistance
        {
            set => _DCResistance = value;
            get { return _DCResistance; }
        }
        //
        //  Maximum Current
        public CAD_Parameter MaxCurrent
        {
            set => _MaxCurrent = value;
            get { return _MaxCurrent; }
        }
        //
        //  Self Resonant Frequency
        public CAD_Parameter SelfResonantFrequency
        {
            set => _SelfResonantFrequency = value;
            get { return _SelfResonantFrequency; }
        }
        //
        //  Tolerance
        public CAD_Parameter Tolerance
        {
            set => _Tolerance = value;
            get { return _Tolerance; }
        }
        //
        //  Inductor Type
        public InductorTypeEnum InductorType
        {
            set => _InductorType = value;
            get { return _InductorType; }
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
        public static Inductor? FromJson(string json)
        {
            return JsonSerializer.Deserialize<Inductor>(json);
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
