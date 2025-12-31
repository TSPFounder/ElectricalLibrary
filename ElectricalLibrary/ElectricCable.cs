using System.Collections.Generic;
using CAD;
using MissionsNamespace;
using Power;
using SystemsEngineering;

namespace Electronics
{
    public class ElectricCable : ElectricalElement
    {
        public ElectricCable()
        {
        }

        public CAD_Dimension? Length { get; set; }

        public List<ElectricWire> MyWires { get; set; } = new();

        public ElectricalConnector? CurrentConnector { get; set; }

        public List<ElectricalConnector> MyConnectors { get; set; } = new();
    }
}
