using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.MODEL
{
    public class V_GrossQtyMD
    {
        public Nullable<long> MatID { get; set; }
        public string Name { get; set; }
        public string AutoCode { get; set; }
       // public Nullable<decimal> QtyGross { get; set; }
       // public Nullable<System.DateTime> GrossTime { get; set; }
       // public Nullable<long> GrossStfID { get; set; }
        public Nullable<decimal> QtyTare { get; set; }
        public Nullable<System.DateTime> TareTime { get; set; }
        public Nullable<long> TareStfID { get; set; }
        public string TareStrName { get; set; }
        public string ToCust { get; set; }
       // public string GrossStfName { get; set; }

    }
}
