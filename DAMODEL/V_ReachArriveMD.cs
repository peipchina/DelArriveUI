using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.MODEL
{
    public class V_ReachArriveMD
    {       
        public long ID { get; set; }
        public string AutoCode { get; set; }
        public string DriveLice { get; set; }
        public string Tel { get; set; }
        public string Driver { get; set; }
        public string OldAutoCode { get; set; }
        public string BilNo { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<System.DateTime> BilDate { get; set; }
        public Nullable<long> MatID { get; set; }
        public Nullable<long> StockID { get; set; }
        public Nullable<long> UnitID { get; set; }
        public Nullable<long> PackID { get; set; }
        public string Rem { get; set; }
        public Nullable<long> CorpID { get; set; }
        public Nullable<long> DepID { get; set; }
        public Nullable<int> Period { get; set; }
        public Nullable<decimal> QtyTare { get; set; }
        public Nullable<decimal> QtyNet { get; set; }
        public Nullable<long> IDFrom { get; set; }
        public string BilIDFrom { get; set; }
        public string MatCode { get; set; }
        public string MatName { get; set; }
        public Nullable<int> MMatPropID { get; set; }
        public Nullable<long> MMatTypeID { get; set; }
        public Nullable<long> MUnitID { get; set; }
        public string Expr1 { get; set; }
        public string BilType { get; set; }
        public string BilType1 { get; set; }
        public string ContBilNo { get; set; }
        public Nullable<long> CustID { get; set; }
        public Nullable<long> ContCorpID { get; set; }
        public Nullable<int> TransportID { get; set; }
        public Nullable<int> DeliWayID { get; set; }
        public Nullable<int> IsContainer { get; set; }
        public string TSCode { get; set; }
        public Nullable<decimal> TSQty { get; set; }
        public Nullable<decimal> TSAQty { get; set; }
        public Nullable<decimal> TSLQty { get; set; }
        public Nullable<decimal> QtyDeli { get; set; }
        public Nullable<decimal> TSDQty { get; set; }
        public Nullable<long> DAEID { get; set; }
        public Nullable<bool> IsDel { get; set; }
        public Nullable<System.DateTime> ArriveTime { get; set; }
        public Nullable<System.DateTime> CallTime { get; set; }
        public Nullable<long> StockIDTo { get; set; }
    }
}
