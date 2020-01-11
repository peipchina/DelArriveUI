using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.MODEL
{
    public class TC_InoutlsMD
    {
        public int P_KEY { get; set; }
        public string Carno { get; set; }
        public Nullable<int> CLLX { get; set; }
        public Nullable<int> SFLX { get; set; }
        public Nullable<int> CPLX { get; set; }
        public string CardNo { get; set; }
        public string I_CtrlNO { get; set; }
        public string O_CtrlNo { get; set; }
        public Nullable<int> I_CCBH { get; set; }
        public Nullable<int> O_CCBH { get; set; }
        public Nullable<int> I_TDBH { get; set; }
        public Nullable<int> O_TDBH { get; set; }
        public Nullable<System.DateTime> In_time { get; set; }
        public Nullable<System.DateTime> Out_time { get; set; }
        public string I_PicNo { get; set; }
        public string O_PicNo { get; set; }
        public Nullable<int> I_Gate { get; set; }
        public Nullable<int> O_Gate { get; set; }
        public Nullable<int> I_GetData { get; set; }
        public Nullable<int> O_GetData { get; set; }
        public Nullable<int> Inout_Type { get; set; }
        public string I_Oper { get; set; }
        public string O_Oper { get; set; }
        public int OuterType { get; set; }
        public Nullable<int> M_KEY { get; set; }
        public Nullable<int> I_TGLX { get; set; }
        public Nullable<int> O_TGLX { get; set; }
        public string ReMark { get; set; }
        public Nullable<int> I_GTBH { get; set; }
        public string I_CDMC { get; set; }
        public Nullable<int> O_GTBH { get; set; }
        public string O_CDMC { get; set; }
        public Nullable<int> SFLXZH { get; set; }
        public Nullable<System.DateTime> SFZHSJ { get; set; }
        public Nullable<int> I_KZJH { get; set; }
        public Nullable<int> O_KZJH { get; set; }
        public Nullable<int> Balance { get; set; }
        public Nullable<int> car_color { get; set; }
        public string BL_OrderNo { get; set; }
    }
}
