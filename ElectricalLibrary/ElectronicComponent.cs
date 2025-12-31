using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD;
using SE_Library;
using Structures;

namespace Electrical
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
