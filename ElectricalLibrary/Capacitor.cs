using CAD;

namespace Electronics
{
    public class Capacitor : ElectricalElement
    {
        public Capacitor()
        {
        }

        public CAD_Parameter? NominalCapacitance { get; set; }
    }
}
