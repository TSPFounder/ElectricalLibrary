using System;
using CAD;
using MissionsNamespace;
using Power;
using SystemsEngineering;

namespace Electronics
{
    public class ElectronicComponent : ElectricalElement
    {
        public enum ElectronicComponentType
        {
            Resistor = 0,
            Capacitor,
            Inductor,
            Diode,
            Triode,
            IntegratedCircuit,
            ElectricCoil,
            Transformer,
            Other
        }

        public ElectronicComponent()
        {
        }

        public Boolean IsSurfaceMount { get; set; }

        public CAD_Dimension? Length { get; set; }

        public CAD_Dimension? Width { get; set; }

        public CAD_Dimension? Height { get; set; }

        public CAD_Dimension? DefaultRadius { get; set; }
    }
}
