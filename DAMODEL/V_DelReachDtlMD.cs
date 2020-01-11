using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.MODEL
{
    public class V_DelReachDtlMD
    {
        public long ID { get; set; }
        public int Item { get; set; }
        public string BilID { get; set; }
        public Nullable<long> CorpID { get; set; }
        public Nullable<int> Period { get; set; }
        public Nullable<System.DateTime> DelReachDtlBilDate { get; set; }
        public string DelReachDtlBilNO { get; set; }
        public Nullable<int> RowIndex { get; set; }
        public string ContBilID { get; set; }
        public Nullable<int> ContItem { get; set; }
        public Nullable<long> AutoID { get; set; }
        public Nullable<decimal> QtyApp { get; set; }
        public Nullable<long> MatID { get; set; }
        public string matMaterial { get; set; }
        public Nullable<long> StockID { get; set; }
        public string stockName { get; set; }
        public Nullable<long> UnitID { get; set; }
        public string UnitName { get; set; }
        public string AutoCode { get; set; }
        public string Driver { get; set; }
        public string Tel { get; set; }
        public string DriveLice { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> QtyBase { get; set; }
        public Nullable<decimal> PriceFrei { get; set; }
        public Nullable<decimal> Disc { get; set; }
        public Nullable<decimal> Amt { get; set; }
        public Nullable<decimal> RateTax { get; set; }
        public Nullable<decimal> Tax { get; set; }
        public Nullable<decimal> AmtNoTax { get; set; }
        public Nullable<decimal> AmtLocal { get; set; }
        public Nullable<decimal> QtyTare { get; set; }
        public Nullable<decimal> QtyPack { get; set; }
        public Nullable<decimal> QtyGross { get; set; }
        public Nullable<decimal> QtyNet { get; set; }
        public string BilIDTo { get; set; }
        public Nullable<decimal> QtyTo { get; set; }
        public string DelReachDTLBilIDFrom { get; set; }
        public Nullable<long> DelReachDtlIDFrom { get; set; }
        public Nullable<int> ItemFrom { get; set; }
        public Nullable<System.DateTime> DeliDate { get; set; }
        public string ToCust { get; set; }
        public Nullable<long> OBID { get; set; }
        public string SacContractBilNo { get; set; }
        public string OBBilID { get; set; }
        public Nullable<int> OBItem { get; set; }
        public Nullable<decimal> QtyPackBag { get; set; }
        public string PlanBilID { get; set; }
        public Nullable<long> PlanID { get; set; }
        public string BilNo { get; set; }
        public Nullable<System.DateTime> DelReachBilDate { get; set; }
        public string DelReachBilNo { get; set; }
        public Nullable<long> DepID { get; set; }
        public string DelReachBilIDFrom { get; set; }
        public Nullable<long> DelReachIDFrom { get; set; }
        public Nullable<long> CreateStfID { get; set; }
        public string createStfName { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> StatusOld { get; set; }
        public Nullable<int> PlanItem { get; set; }
        public decimal Total { get; set; }
    }
}
