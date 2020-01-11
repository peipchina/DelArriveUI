using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.MODEL
{
    public class V_QCPrintMD
    {
        public long ID { get; set; }
        public Nullable<long> CorpID { get; set; }
        public string BilIDFrom { get; set; }
        public Nullable<long> IDFrom { get; set; }
        public Nullable<int> ItemFrom { get; set; }
        public Nullable<long> IDOutStc { get; set; }
        public Nullable<long> AutoID { get; set; }
        public string AutoCode { get; set; }
        public string Driver { get; set; }
        public Nullable<long> UpStockID { get; set; }
        public string InLine { get; set; }
        public Nullable<System.DateTime> InLineTime { get; set; }
        public Nullable<long> IDInStc { get; set; }
        public Nullable<long> StockID { get; set; }
        public string StockQty { get; set; }
        public Nullable<decimal> QtyTare { get; set; }
        public Nullable<System.DateTime> TareTime { get; set; }
        public Nullable<long> TareStfID { get; set; }
        public Nullable<decimal> QtyGross { get; set; }
        public Nullable<System.DateTime> GrossTime { get; set; }
        public Nullable<long> GrossStfID { get; set; }
        public Nullable<long> BeginLoadStfID { get; set; }
        public Nullable<System.DateTime> BeginLoadTime { get; set; }
        public Nullable<System.DateTime> EndLoadTime { get; set; }
        public Nullable<long> EndLoadStfID { get; set; }
        public Nullable<long> QCID { get; set; }
        public Nullable<System.DateTime> PassTime { get; set; }
        public Nullable<long> PassStfID { get; set; }
        public Nullable<long> SuperviseID { get; set; }
        public Nullable<long> CreateStfID { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string Rem { get; set; }
        public int SuperviseTypeID { get; set; }
        public Nullable<int> SuperviseIndex { get; set; }
        public Nullable<int> UpIndex { get; set; }
        public Nullable<long> MultKeyID { get; set; }
        public Nullable<decimal> QtyLastTare { get; set; }
        public Nullable<System.DateTime> LastTareTime { get; set; }
        public Nullable<long> LastTareStfID { get; set; }
        public bool IsReceipt { get; set; }
        public Nullable<long> AccID { get; set; }
        public Nullable<decimal> RecAmt { get; set; }
        public Nullable<decimal> ReCAmtLocal { get; set; }
        public Nullable<decimal> QtyTareRep { get; set; }
        public Nullable<System.DateTime> TareRepTime { get; set; }
        public Nullable<long> TareRepStfID { get; set; }
        public Nullable<decimal> DelayHours { get; set; }
        public string LoadAdd { get; set; }
        public Nullable<int> IsPass { get; set; }
        public string QtyCheck12 { get; set; }
        public string QtyCheck2 { get; set; }
        public string QtyCheck3 { get; set; }
        public string QtyCheck1 { get; set; }
        public string QtyCheck4 { get; set; }
        public string QtyCheck5 { get; set; }
        public string QtyCheck6 { get; set; }
        public string QtyCheck7 { get; set; }
        public string QtyCheck8 { get; set; }
        public string QtyCheck9 { get; set; }
        public string QtyCheck10 { get; set; }
        public string QtyCheck11 { get; set; }
        public Nullable<long> ArriveID { get; set; }
        public string CheckStfName { get; set; }
        public string QtyCheck13 { get; set; }
        public string QtyCheck14 { get; set; }
        public Nullable<decimal> QtyBZY { get; set; }
        public Nullable<decimal> QtyTray { get; set; }
        public Nullable<decimal> QtyLargess { get; set; }
        public string TrayName { get; set; }
        public string QtyCheck15 { get; set; }
        public Nullable<long> MatID { get; set; }
        public Nullable<long> StockIDDtl { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<long> ContID { get; set; }
        public string ContBilID { get; set; }
        public Nullable<int> ContItem { get; set; }
        public Nullable<int> TransportID { get; set; }
        public string ToCust { get; set; }
        public string MatIDCode { get; set; }
        public string MatIDName { get; set; }
        public string MatTypeName { get; set; }
        public Nullable<long> ContDepID { get; set; }
        public string passName { get; set; }
        public Nullable<long> DCorpID { get; set; }
        public Nullable<long> DrID { get; set; }
        public string ContBilNo { get; set; }
        public Nullable<long> CustID { get; set; }
        public string TSCode { get; set; }
        public string DepotFrom { get; set; }
        public string DepotTo { get; set; }
        public string Consignee { get; set; }
        public string StorckName { get; set; }

    }
}
