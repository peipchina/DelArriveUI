using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.MODEL
{
    public class PurInprisonMD
    {
        public long ID { get; set; }
        public Nullable<long> CorpID { get; set; }
        public Nullable<long> IDFrom { get; set; }
        public Nullable<int> ItemFrom { get; set; }
        public Nullable<long> IDInStc { get; set; }
        public string BilIDFrom { get; set; }
        public Nullable<long> AutoID { get; set; }
        public string AutoCode { get; set; }
        public string Driver { get; set; }
        public string ShipName { get; set; }
        public string ShipStock { get; set; }
        public Nullable<long> StockID { get; set; }
        public Nullable<System.DateTime> TareTime { get; set; }
        public Nullable<long> TareStfID { get; set; }
        public Nullable<System.DateTime> GrossTime { get; set; }
        public Nullable<long> GrossStfID { get; set; }
        public Nullable<System.DateTime> UnLoadTime { get; set; }
        public Nullable<long> UnLoadStfID { get; set; }
        public Nullable<System.DateTime> SealsTime { get; set; }
        public Nullable<long> SealsStfID { get; set; }
        public string Rem { get; set; }
        public Nullable<decimal> QtyTare { get; set; }
        public Nullable<decimal> QtyGross { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<long> CreateStfID { get; set; }
        public Nullable<int> InPrsionTypeID { get; set; }
        public int SuperviseTypeID { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<long> SuppID { get; set; }
        public string SuppName { get; set; }
        public Nullable<long> MatID { get; set; }
        public bool IsFirst { get; set; }
        public bool IsStop { get; set; }
        public Nullable<int> SuperviseIndex { get; set; }
        public Nullable<long> SuperviseID { get; set; }
        public Nullable<int> UpIndex { get; set; }
        public string SealNo { get; set; }
        public string StockType { get; set; }
    }
}
