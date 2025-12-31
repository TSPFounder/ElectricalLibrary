using System;
using SE_Library;
using CAD;
using Mathematics;

namespace Electrical
{
    public class ElectricalElement 
    {
        public ElectricalElement? CurrentElectricalElem { get; set; }

        public List<ElectricalElement> MyElectricalElements { get; set; } = new();

        public CAD_Interface? CurrentInterface { get; set; }

        public List<CAD_Interface> MyInterfaces { get; set; } = new();

        
    }
}
