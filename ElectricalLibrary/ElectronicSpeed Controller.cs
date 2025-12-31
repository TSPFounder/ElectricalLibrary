using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD;
using SE_Library;
using Structures;

namespace Electronics
{
    public class ElectronicSpeed_Controller 
    {
        public ElectronicSpeed_Controller()
        {
        }

        public CAD_Parameter? MaxCurrent { get; set; }

        //public PrintedCircuitBoard? MyPCB { get; set; }

        public StructuralCase? MyCase { get; set; }
    }
}
