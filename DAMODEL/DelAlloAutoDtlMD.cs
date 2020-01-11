using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.MODEL
{
    public class DelAlloAutoDtlMD
    {
        public long ID { get; set; }
        public int Item { get; set; }
        public string BilID { get; set; }
        public Nullable<long> CorpID { get; set; }
        public Nullable<int> Period { get; set; }
        public Nullable<System.DateTime> BilDate { get; set; }
        public string BilNo { get; set; }
        public Nullable<int> RowIndex { get; set; }
        public Nullable<long> OBID { get; set; }
        public string OBBilID { get; set; }
        public Nullable<int> OBItem { get; set; }
        public Nullable<long> ContID { get; set; }
        public string MatName { get; set; }
        public string ContBilID { get; set; }
        public Nullable<int> ContItem { get; set; }
        public Nullable<long> MatID { get; set; }
        public Nullable<long> MatMark1 { get; set; }
        public Nullable<long> MatMark2 { get; set; }
        public Nullable<long> MatMark3 { get; set; }
        public Nullable<long> MatMark4 { get; set; }
        public Nullable<long> MatMark5 { get; set; }
        public Nullable<long> MatMark6 { get; set; }
        public Nullable<long> MatMark7 { get; set; }
        public Nullable<long> MatMark8 { get; set; }
        public Nullable<long> BomID { get; set; }
        public Nullable<long> StockID { get; set; }
        public Nullable<decimal> QtyBase { get; set; }
        public Nullable<decimal> PriceBase { get; set; }
        public Nullable<long> UnitID { get; set; }
        public Nullable<decimal> QtyApp { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> DeliDate { get; set; }
        public Nullable<decimal> QtyDeli { get; set; }
        public Nullable<decimal> Disc { get; set; }
        public Nullable<decimal> Amt { get; set; }
        public Nullable<decimal> RateTax { get; set; }
        public Nullable<decimal> Tax { get; set; }
        public Nullable<decimal> AmtNoTax { get; set; }
        public Nullable<decimal> AmtInTax { get; set; }
        public Nullable<decimal> AmtLocal { get; set; }
        public Nullable<decimal> PriceFrei { get; set; }
        public string AutoCode { get; set; }
        public string Driver { get; set; }
        public string Tel { get; set; }
        public string DriveLice { get; set; }
        public Nullable<long> PackID { get; set; }
        public Nullable<decimal> QtyPack { get; set; }
        public Nullable<double> Area { get; set; }
        public Nullable<double> Volume { get; set; }
        public Nullable<double> Gross { get; set; }
        public Nullable<double> Net { get; set; }
        public string Rem { get; set; }
        public string BilIDTo { get; set; }
        public Nullable<decimal> QtyTo { get; set; }
        public string BilIDFrom { get; set; }
        public Nullable<long> IDFrom { get; set; }
        public Nullable<int> ItemFrom { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public Nullable<long> CheckStfID { get; set; }
        public Nullable<System.DateTime> CheckTime { get; set; }
        public Nullable<System.DateTime> EffectTime { get; set; }
        public Nullable<System.DateTime> FinishTime { get; set; }
        public Nullable<long> VoidStfID { get; set; }
        public Nullable<long> SuspStfID { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> StatusOld { get; set; }
        public string ToCust { get; set; }
        public bool IsConfirmOK { get; set; }
        public Nullable<long> ConfirmStfID { get; set; }
        public Nullable<System.DateTime> ConfirmTime { get; set; }
        public string PlanBilID { get; set; }
        public Nullable<long> PlanID { get; set; }
        public Nullable<int> PlanItem { get; set; }
        public Nullable<decimal> My1_UDsg { get; set; }
    }
}
