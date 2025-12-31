using System.Collections.Generic;
using CAD;
using Data;
using DreamWorldMakerLibrary;
using MissionsNamespace;
using Structure;
using SystemsEngineering;

namespace Electronics
{
    public class ElectricalElement : DWM_Component
    {
        public ElectricalElement? CurrentElectricalElem { get; set; }

        public List<ElectricalElement> MyElectricalElements { get; set; } = new();

        public DWM_Interface? CurrentInterface { get; set; }

        public List<DWM_Interface> MyInterfaces { get; set; } = new();

        public StructuralCase? MyCase { get; set; }
    }
}
