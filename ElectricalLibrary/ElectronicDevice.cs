using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD;
using SE_Library;
using Structures;

namespace Electronics
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CAD;
    using SE_Library;
    using Structures;

    namespace Electronics
    {
        public class ElectronicDevice : SE_System
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
            public List<CAD_Dimension> MyDimensions { get; set; } = new();
        }
    }
}