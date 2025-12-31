using System;
using System.Collections.Generic;
using CAD;
//using Power;

namespace Electrical
{
    public class ElectricSwitch : ElectricalElement
    {
        public enum SwitchTypeEnum
        {
            Flip = 0,
            Limit
        }

        public ElectricSwitch()
        {
        }

        public String? Make { get; set; }

        public String? Model { get; set; }

        public String? Version { get; set; }

        public CAD_Dimension? Length { get; set; }

        public CAD_Dimension? Width { get; set; }

        public CAD_Dimension? Height { get; set; }

        public CAD_Dimension? HoleOffset { get; set; }

        public CAD_Parameter? Weight { get; set; }

        public CAD_Parameter? MaxInputCurrent { get; set; }

        public CAD_Parameter? OutputCurrent { get; set; }

        public CAD_Parameter? InputVoltage { get; set; }

        public CAD_Parameter? OutputVoltage { get; set; }

        public CAD_Parameter? Efficiency { get; set; }

        public CAD_Parameter? MinOperatingTemp { get; set; }

        public CAD_Parameter? MaxOperatingTemp { get; set; }

        public List<CAD_Feature> MountingHoles { get; set; } = new();
    }
}
