using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.MODEL
{
    public class AutoCodeRecordMD
    {
        public int ID { get; set; }
        public string AutoCode { get; set; }
        public Nullable<System.DateTime> InTime { get; set; }
        public Nullable<System.DateTime> OutTime { get; set; }
        public string PicPath { get; set; }
        public string CDMPlace { get; set; }
        public string CarColor { get; set; }
        public bool IsFinish { get; set; }

    }
}
