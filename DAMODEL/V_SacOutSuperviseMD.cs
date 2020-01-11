using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.MODEL
{
   public  class V_SacOutSuperviseMD
    {
        public long ID { get; set; }
        public Nullable<long> CorpID { get; set; }
        public string BilIDFrom { get; set; }
        public Nullable<long> IDFrom { get; set; }
        public string AutoCode { get; set; }
        public string Driver { get; set; }
        public string InLine { get; set; }
        public Nullable<long> StockID { get; set; }
        public string StockName { get; set; }
        public Nullable<decimal> QtyTare { get; set; }
        public Nullable<System.DateTime> TareTime { get; set; }
        public Nullable<long> TareStfID { get; set; }
        public string TareStfName { get; set; }
        public Nullable<decimal> QtyGross { get; set; }
        public Nullable<System.DateTime> GrossTime { get; set; }
        public Nullable<long> GrossStfID { get; set; }
        public string GrossStfName { get; set; }
        public Nullable<long> BeginLoadStfID { get; set; }
        public string BeginLoadStfName { get; set; }
        public Nullable<System.DateTime> BeginLoadTime { get; set; }
        public Nullable<long> EndLoadStfID { get; set; }
        public string EndLoadStfName { get; set; }
        public Nullable<System.DateTime> EndLoadTime { get; set; }
        public Nullable<long> QCID { get; set; }
        public Nullable<long> PassStfID { get; set; }
        public string PassStfName { get; set; }
        public Nullable<System.DateTime> PassTime { get; set; }
        public Nullable<long> CreateStfID { get; set; }
        public string CreateStfName { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string Rem { get; set; }
        public Nullable<long> SuperviseID { get; set; }
        public Nullable<int> SuperviseIndex { get; set; }
        public Nullable<int> UpIndex { get; set; }
        public Nullable<long> MultKeyID { get; set; }
        public string BilNo { get; set; }
        public Nullable<long> MatID { get; set; }
        public string MatName { get; set; }
        public string ToCust { get; set; }
        public string QtyCheck15 { get; set; }
    }
}
