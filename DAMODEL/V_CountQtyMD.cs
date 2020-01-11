using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.MODEL
{
    public class V_CountQtyMD
    {
        public long ID { get; set; }
        public Nullable<long> IDFrom { get; set; }
        public string AutoCode { get; set; }
        public string MatName { get; set; }
        public Nullable<decimal> QtyGross { get; set; }
        public Nullable<decimal> QtyTare { get; set; }
        public string BilNo { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<System.DateTime> GrossTime { get; set; }
    }
}
