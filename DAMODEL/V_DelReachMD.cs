using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.MODEL
{
    public class V_DelReachMD
    {
        public long ID { get; set; }
        public string BilID { get; set; }
        public Nullable<long> CorpID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string EName { get; set; }
        public string Mnemonic { get; set; }
        public string Driver { get; set; }
        public string DriverOut { get; set; }
        public string Tel { get; set; }
        public string DriveLice { get; set; }
        public Nullable<System.DateTime> ArriveTime { get; set; }
        public string Rem { get; set; }
        public bool IsDel { get; set; }
        public Nullable<System.DateTime> PrintTime { get; set; }
        public string  CreateStfName { get; set; }
        public Nullable<int> PrintTimes { get; set; }
        public Nullable<long> CreateStfID { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public Nullable<long> CheckStfID { get; set; }
        public Nullable<System.DateTime> CheckTime { get; set; }
        public Nullable<System.DateTime> EffectTime { get; set; }
        public Nullable<System.DateTime> StopTime { get; set; }
        public bool IsUsed { get; set; }
        public Nullable<int> Status { get; set; }
        public string OldAutoCode { get; set; }
        public Nullable<long> DepID { get; set; }
        public string BilNo { get; set; }
    }
}
