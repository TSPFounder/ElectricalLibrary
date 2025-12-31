using System.Collections.Generic;
using CAD;
using MissionsNamespace;
using Power;
using Structure;
using SystemsEngineering;

namespace Electronics
{
    public class ElectronicDevice : DWM_System
    {
        public ElectronicDevice()
        {
            MyDimensions = new List<CAD_Dimension>();
            MyComponents = new List<ElectronicComponent>();
            MyDevices = new List<ElectronicDevice>();
        }

        public ElectronicComponent? CurrentComponent { get; set; }

        public List<ElectronicComponent> MyComponents { get; set; } = new();

        public ElectronicDevice? CurrentDevice { get; set; }

        public List<ElectronicDevice> MyDevices { get; set; } = new();

        public StructuralCase? MyCase { get; set; }
    }
}
