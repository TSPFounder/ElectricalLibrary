using System;
using SE_Library;
using CAD;
using Mathematics;

namespace Electrical
{
    public class ElectricCable : ElectricalElement
    {
        public ElectricCable()
        {
        }

        public CAD_Dimension? Length { get; set; }

        public List<ElectricalWire> MyWires { get; set; } = new();

        public ElectricalConnector? CurrentConnector { get; set; }

        public List<ElectricalConnector> MyConnectors { get; set; } = new();
    }
}
