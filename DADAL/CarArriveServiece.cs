using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DA.MODEL;
using System.Data;
using System.Data.SqlClient;

namespace DA.DAL
{
    public class CarArriveServiece
    {
        /// <summary>
        /// 根据时间查询某一天的自动识别车辆
        /// </summary>
        /// <param name="in_time">查询时间</param>
        /// <returns>车辆自动识别信息</returns>
        public List<AutoCodeRecordMD> GetAutoArriveCarNo(DateTime InTime,DateTime OutTime)
        {
            string connection = @"Password=bohi@1218;Persist Security Info=True;User ID=sa;Initial Catalog=BohiErp;Data Source=192.168.51.180";
            using (SqlConnection sc = new SqlConnection(connection))
            {
                //string sql = @"select P_KEY, Carno, CLLX, SFLX, CPLX, CardNo, I_CtrlNO, O_CtrlNo, I_CCBH, O_CCBH, I_TDBH, O_TDBH, In_time, 
                //        Out_time, I_PicNo, O_PicNo, I_Gate, O_Gate, I_GetData, O_GetData, Inout_Type, I_Oper, O_Oper, OuterType, 
                //        M_KEY, I_TGLX, O_TGLX, ReMark, I_GTBH, I_CDMC, O_GTBH, O_CDMC, SFLXZH, SFZHSJ, I_KZJH, O_KZJH, Balance, car_color, BL_OrderNo
                //        from TC_Inoutls 
                //        where DATEDIFF(dd,in_time,@In_time)=0";                
                //return (List<TC_InoutlsMD>)sc.Query<TC_InoutlsMD>(sql,new { @In_time=in_time });
                string sql = @"SELECT * FROM AutoCodeRecord WHERE  DATEDIFF(dd,InTime,@InTime)=0 or DATEDIFF(dd,OutTime,@OutTime)=0";
                return (List<AutoCodeRecordMD>)sc.Query<AutoCodeRecordMD>(sql, new { @InTime= InTime, @OutTime= OutTime });
            }
        }
        /// <summary>
        /// 根据车牌识别车号查询毛重及皮重时间
        /// </summary>
        /// <param name="AutoCode">自动识别的车号</param>
        /// <returns>监装表</returns>
        public List<TC_GrossTareMD> GetCarTareAndGross(string AutoCode,DateTime dateTime)
        {
            string connection = PubClass.getConnecion();
            using (SqlConnection sc=new SqlConnection(connection))
            {
                string sql = @"SELECT   dr.MatID, pm.Name MatName, sos.AutoCode,  sos.QtyTare, sos.TareTime, sos.TareStfID, ps1.Name AS TareStrName,sos.QtyGross,sos.GrossTime,sos.GrossStfID,ps2.Name GrossName, dr.ToCust
                                FROM         dbo.SacOutSupervise AS sos LEFT OUTER JOIN
                                dbo.DelReachDtl AS dr ON dr.ID = sos.IDFrom LEFT OUTER JOIN                                
                                dbo.PubStaff AS ps1 ON ps1.ID = sos.TareStfID LEFT OUTER JOIN                                
                                dbo.PubStaff AS ps2 ON ps2.ID = sos.GrossStfID LEFT OUTER JOIN
                                dbo.PubMaterial AS pm ON pm.ID = dr.MatID
                                where sos.AutoCode=@AutoCode and (sos.TareTime between @startTime and @endTime)";//order by sos.TareTime desc
                return (List<TC_GrossTareMD>)sc.Query<TC_GrossTareMD>(sql, new { @AutoCode = AutoCode, @startTime=dateTime.AddDays(-1), @endTime=dateTime.AddDays(1) });
            }            
        }
        /// <summary>
        /// 根据车牌识别车号和时间查询毛重及皮重时间
        /// </summary>
        /// <param name="AutoCode">自动识别的车号</param>
        /// <returns>监装表</returns>
        public List<TC_GrossTareMD> GetCarTareAndGrossByAutoCodeAndTime(string AutoCode,DateTime dateTime)
        {
            string connection = PubClass.getConnecion();
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"SELECT   dr.MatID, pm.Name MatName, sos.AutoCode,  sos.QtyTare, sos.TareTime, sos.TareStfID, ps1.Name AS TareStrName,sos.QtyGross,sos.GrossTime,sos.GrossStfID,ps2.Name GrossName, dr.ToCust
                                FROM         dbo.SacOutSupervise AS sos LEFT OUTER JOIN
                                dbo.DelReachDtl AS dr ON dr.ID = sos.IDFrom LEFT OUTER JOIN                                
                                dbo.PubStaff AS ps1 ON ps1.ID = sos.TareStfID LEFT OUTER JOIN                                
                                dbo.PubStaff AS ps2 ON ps2.ID = sos.GrossStfID LEFT OUTER JOIN
                                dbo.PubMaterial AS pm ON pm.ID = dr.MatID
                                where sos.AutoCode=@AutoCode and (sos.TareTime between @startTime and @endTime or sos.GrossTime between @startTime and @endTime )";
                return (List<TC_GrossTareMD>)sc.Query<TC_GrossTareMD>(sql, new { @AutoCode = AutoCode, @startTime= dateTime.Date.AddMinutes(-15), @endTime=dateTime.AddMinutes(15) });
            }
        }
        /// <summary>
        /// 根据车牌识别车号模糊查询毛重及皮重时间
        /// </summary>
        /// <param name="AutoCode">模糊车号</param>
        /// <returns>监装表</returns>
        public List<TC_GrossTareMD> GetCarTareAndGrossByAutoCode(string AutoCode ,DateTime dateTime)
        {
            string connection = PubClass.getConnecion();
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"SELECT   dr.MatID, pm.Name, sos.AutoCode,  sos.QtyTare, sos.TareTime, sos.TareStfID, ps1.Name AS TareStrName,sos.QtyGross,sos.GrossTime,sos.GrossStfID,ps2.Name GrossName, dr.ToCust
                                FROM         dbo.SacOutSupervise AS sos LEFT OUTER JOIN
                                dbo.DelReachDtl AS dr ON dr.ID = sos.IDFrom LEFT OUTER JOIN                                
                                dbo.PubStaff AS ps1 ON ps1.ID = sos.TareStfID LEFT OUTER JOIN                                
                                dbo.PubStaff AS ps2 ON ps2.ID = sos.GrossStfID LEFT OUTER JOIN
                                dbo.PubMaterial AS pm ON pm.ID = dr.MatID
                                where sos.AutoCode like @AutoCode and sos.GrossTime between @startTime and @endTime";
                return (List<TC_GrossTareMD>)sc.Query<TC_GrossTareMD>(sql, new { @AutoCode = AutoCode,@startTime = dateTime.AddHours(-8), @endTime = dateTime.AddHours(8) });
            }
        }
    }
    
}
