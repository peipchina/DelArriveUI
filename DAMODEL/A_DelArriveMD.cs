using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.MODEL
{
    public class A_DelArriveMD
    {
        public string AutoCode { get; set; }
        public string DriveLice { get; set; }
        public string Tel { get; set; }
        public string Driver { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<long> MatID { get; set; }
        public Nullable<long> IDFrom { get; set; }
        public Nullable<System.DateTime> BilDate { get; set; }
        public string OldCode { get; set; }
        public Nullable<System.DateTime> BilCreateTime { get; set; }
        public string BilType { get; set; }
        public Nullable<long> MSpcID { get; set; }
        public string MMatPropID { get; set; }
        public Nullable<long> MMatTypeID { get; set; }
        public string MUnitID { get; set; }
        public string ContBilNo { get; set; }
        public Nullable<long> CustID { get; set; }
        public string TSCode { get; set; }
        public Nullable<decimal> TSQty { get; set; }
        public Nullable<decimal> TSAQty { get; set; }
        public Nullable<decimal> TSLQty { get; set; }
        public string MatTypeName { get; set; }
        public string MatName { get; set; }
        public string CustName { get; set; }
        public Nullable<System.DateTime> NewCreateTime { get; set; }
    }
}
