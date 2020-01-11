﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.MODEL
{
    public class TradeMD
    {
        public int id { get; set; }
        public string cardno { get; set; }
        public string ticketno1 { get; set; }
        public string ticketno2 { get; set; }
        public string fststationcode { get; set; }
        public string fststationname { get; set; }
        public string scndstationcode { get; set; }
        public string scndstationname { get; set; }
        public string truckno { get; set; }
        public string contractno { get; set; }
        public string productcode { get; set; }
        public string product { get; set; }
        public string speccode { get; set; }
        public string specification { get; set; }
        public string sendercode { get; set; }
        public string sender { get; set; }
        public string receivercode { get; set; }
        public string receiver { get; set; }
        public string transcode { get; set; }
        public string transporter { get; set; }
        public Nullable<System.DateTime> firstdatetime { get; set; }
        public Nullable<System.DateTime> seconddatetime { get; set; }
        public Nullable<System.DateTime> grossdatetime { get; set; }
        public Nullable<System.DateTime> taredatetime { get; set; }
        public Nullable<decimal> Firstweight { get; set; }
        public Nullable<decimal> secondweight { get; set; }
        public Nullable<decimal> gross { get; set; }
        public Nullable<decimal> tare { get; set; }
        public Nullable<decimal> net { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<decimal> productnet { get; set; }
        public Nullable<decimal> exceptwater { get; set; }
        public Nullable<decimal> exceptother { get; set; }
        public Nullable<decimal> balancemoney { get; set; }
        public Nullable<decimal> contractfinished { get; set; }
        public Nullable<decimal> LeftWeight { get; set; }
        public string sentflag { get; set; }
        public string userid1 { get; set; }
        public string username1 { get; set; }
        public string userid2 { get; set; }
        public string username2 { get; set; }
        public string groupcode { get; set; }
        public string groupname { get; set; }
        public string tarealarmflag { get; set; }
        public string contractalarmflag { get; set; }
        public string uploadflag { get; set; }
        public string dataeditflag { get; set; }
        public string datastatus { get; set; }
        public string printagainflag { get; set; }
        public string manualinputflag { get; set; }
        public string autoidentifiedflag { get; set; }
        public string spareflag { get; set; }
        public string scaleno1 { get; set; }
        public string scaleno2 { get; set; }
        public string processtype { get; set; }
        public string scalemode { get; set; }
        public string finalflag { get; set; }
        public string sparecode1 { get; set; }
        public string sparestr1 { get; set; }
        public string sparecode2 { get; set; }
        public string sparestr2 { get; set; }
        public string sparecode3 { get; set; }
        public string sparestr3 { get; set; }
        public string sparecode4 { get; set; }
        public string sparestr4 { get; set; }
        public string sparecode5 { get; set; }
        public string sparestr5 { get; set; }
        public string sparecode6 { get; set; }
        public string sparestr6 { get; set; }
        public string sparecode7 { get; set; }
        public string sparestr7 { get; set; }
        public string sparecode8 { get; set; }
        public string sparestr8 { get; set; }
        public Nullable<decimal> sparenum1 { get; set; }
        public Nullable<decimal> sparenum2 { get; set; }
        public Nullable<decimal> sparenum3 { get; set; }
        public Nullable<decimal> sparenum4 { get; set; }
        public Nullable<decimal> sparenum5 { get; set; }
        public Nullable<decimal> sparenum6 { get; set; }
        public Nullable<decimal> sparenum7 { get; set; }
        public Nullable<decimal> sparenum8 { get; set; }
        public string weightunit { get; set; }
        public string timealarmflag { get; set; }
    }
}
