using System;
using System.Collections.Generic;
using CAD;

namespace Electrical
{
    public class CircuitBreaker : ElectronicComponent
    {
        public CircuitBreaker()
        {
        }

        public String? Make { get; set; }

        public String? Model { get; set; }

        public String? Version { get; set; }

        public CAD_Dimension? Length { get; set; }

        public CAD_Dimension? Width { get; set; }

        public CAD_Dimension? Height { get; set; }

        public CAD_Dimension? HoleOffset { get; set; }

        public CAD_Dimension? MountingTabLength { get; set; }

        public CAD_Parameter? Weight { get; set; }

        public String? WireGauge { get; set; }

        public CAD_Parameter? MaxInputCurrent { get; set; }

        public CAD_Parameter? InputVoltage { get; set; }

        public List<CAD_Hole> MountingHoles { get; set; } = new();
    }
}
