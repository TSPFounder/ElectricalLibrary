using System;
using SE_Library;
using CAD;
using Mathematics;

namespace Electronics
{
    public class ElectricalConnector : ElectricalElement
    {
        public enum ConnectorType
        {
            USB = 0,
            HDMI,
            DisplayPort,
            MiniDisplayPort,
            DVI,
            CompositeVideo,
            VGA,
            BNC,
            F_Connector,
            RJ_45,
            RJ_11,
            DB_9,
            DB_25,
            DIN,
            TRS,
            Other
        }

        public enum USB_ConnectorType
        {
            USB_A = 0,
            USB_B,
            MiniA,
            MiniB,
            MicroA,
            MicroB,
            MicroB_SuperSpeed,
            USB_C,
            USB_3_0_A_SS,
            USB_3_0_B_SS,
            USB_3_0_MicroB_SS,
            None,
            Other
        }

        public ElectricalConnector()
        {
        }

        public ElectricalPin? CurrentPin { get; set; }

        public List<ElectricalPin> MyPins { get; set; } = new();

        
    }
}
