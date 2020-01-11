using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.MODEL
{
    public class DelAlloAutoMD
    {
        public long ID { get; set; }
        public string BilID { get; set; }
        public Nullable<long> CorpID { get; set; }
        public Nullable<int> Period { get; set; }
        public Nullable<System.DateTime> BilDate { get; set; }
        public string BilNo { get; set; }
        public Nullable<long> BilTypeID { get; set; }
        public Nullable<long> DepID { get; set; }
        public Nullable<long> StfID { get; set; }
        public Nullable<long> OBID { get; set; }
        public string OBBilID { get; set; }
        public Nullable<long> ContID { get; set; }
        public string ContBilID { get; set; }
        public Nullable<System.DateTime> DeliDate { get; set; }
        public string Rem { get; set; }
        public Nullable<long> BilTypeID1st { get; set; }
        public string BilIDTo { get; set; }
        public string BilIDFrom { get; set; }
        public Nullable<long> IDFrom { get; set; }
        public Nullable<long> CreateStfID { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public Nullable<long> CheckStfID { get; set; }
        public Nullable<System.DateTime> CheckTime { get; set; }
        public Nullable<System.DateTime> EffectTime { get; set; }
        public Nullable<System.DateTime> FinishTime { get; set; }
        public Nullable<long> VoidStfID { get; set; }
        public Nullable<long> SuspStfID { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> StatusOld { get; set; }
        public Nullable<long> CreateRoleID { get; set; }
        public Nullable<long> CreateDepID { get; set; }
        public Nullable<long> CreateCorpID { get; set; }
        public Nullable<System.DateTime> PrintTime { get; set; }
        public Nullable<long> PrintStfID { get; set; }
        public Nullable<int> PrintTimes { get; set; }
        public bool IsContainer { get; set; }
        public Nullable<decimal> My1_UDsg { get; set; }
    }
}
