using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.MODEL
{
    public class LeaveReachMD
    {
        public long ID { get; set; }
        public Nullable<System.DateTime> BilDate { get; set; }
        public string AutoCode { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<long> IDFrom { get; set; }
        public Nullable<long> DRID { get; set; }
    }
}
