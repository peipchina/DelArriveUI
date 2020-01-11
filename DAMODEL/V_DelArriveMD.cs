using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.MODEL
{
    public class V_DelArriveMD
    {
        public long ID { get; set; }
        public string BilID { get; set; }
        public string Code { get; set; }
        public string Driver { get; set; }
        public string Tel { get; set; }
        public string DriveLice { get; set; }
        public Nullable<System.DateTime> ArriveTime { get; set; }
        public string Rem { get; set; }
        public string CreateStfName { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string CheckStfName { get; set; }
        public Nullable<System.DateTime> CheckTime { get; set; }
        public Nullable<System.DateTime> StopTime { get; set; }
    }
}
