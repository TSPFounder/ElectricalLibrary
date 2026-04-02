using System;
using System.Text.Json;
using CAD;

namespace Electrical
{
    public class ElectricalFuse : ElectricalElement
    {
        //  *****************************************************************************************
        //  ENUMERATIONS
        //
        //  ************************************************************
        #region
        public enum FuseTypeEnum
        {
            Blade = 0,
            Glass,
            Ceramic,
            Resettable,
            HRC,
            Other
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  ELECTRICALFUSE CONSTRUCTOR
        //
        //  ************************************************************
        #region
        public ElectricalFuse()
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
        public String WireGauge { get; set; } = string.Empty;
        public FuseTypeEnum FuseType { get; set; }
        //
        //  Performance
        public CAD_Parameter MaxInputCurrent { get; set; }   //  Amps
        public CAD_Parameter InputVoltage { get; set; }      //  Volts
        public CAD_Parameter TripTime { get; set; }          //  ms
        //
        //  Owned & Owning Objects
        public ElectricalConnector MyConnector { get; set; }
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
        public static ElectricalFuse? FromJson(string json)
        {
            return JsonSerializer.Deserialize<ElectricalFuse>(json);
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
