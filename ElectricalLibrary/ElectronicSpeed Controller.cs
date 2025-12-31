using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mathematics;
using SystemsEngineering;
using CAD;
using Structure;
using MissionsNamespace;
using Power;
using Electronics;

namespace Controls
{
    public class ElectronicSpeed_Controller : Controller
    {
        public ElectronicSpeed_Controller()
        {
        }

        public CAD_Parameter? MaxCurrent { get; set; }

        public PrintedCircuitBoard? MyPCB { get; set; }

        public StructuralCase? MyCase { get; set; }
    }
}
