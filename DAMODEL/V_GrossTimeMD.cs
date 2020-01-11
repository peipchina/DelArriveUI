using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.MODEL
{
    public class V_GrossTimeMD
    {
        public Nullable<System.DateTime> GrossTime { get; set; }
        public Nullable<long> GrossStfID { get; set; }
        public string GrossStfName { get; set; }
        public string MatName { get; set; }
        public string AutoCode { get; set; }
        public string ToCust { get; set; }
        public string DepotTo { get; set; }
    }
}
