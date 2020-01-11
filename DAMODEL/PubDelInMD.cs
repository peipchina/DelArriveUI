using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.MODEL
{
   public  class PubDelInMD
    {
        public string LoginName { get; set; }
        public string LastLoginIPAdress { get; set; }
        public int StfID { get; set; }
        public bool AutoCodeForm { get; set; }
        public bool CountForm { get; set; }
        public bool DelReachForm { get; set; }
        public bool GrossQtyForm { get; set; }
        public bool QCPrintForm { get; set; }
        public bool ReachArriveForm { get; set; }
        public bool ShipmentForm { get; set; }
        public bool UIForm { get; set; }
        public string PassWord { get; set; }
    }
}
