using DA.MODEL;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.DAL
{
    public class PurAlloShoService
    {
        public List<PurAlloShoMD> getPurAlloSho(DateTime startTime, DateTime endTime)
        {
            using (SqlConnection sc = new SqlConnection(PubClass.getConnecion()))
            {
                string sql = @"select * from PurAlloSho where CorpID='1190056' and CreateTime between @startTime and @endTime";
                return (List<PurAlloShoMD>)sc.Query<PurAlloShoMD>(sql, new { startTime = startTime, endTime = endTime });
            }
        }
        /// <summary>
        /// 停用车号
        /// </summary>
        /// <param name="BilNo"></param>
        /// <param name="My1_UDsg"></param>
        /// <returns></returns>
        public bool UpdateDelAlloAuto(long ID, DateTime stopTime)
        {
            using (SqlConnection sc = new SqlConnection(PubClass.getConnecion()))
            {
                string sql = @"UPDATE PurAlloSho SET IsStop=1 , StopTime=@stopTime WHERE CorpID='1190056' and ID=@ID";
                return sc.Execute(sql, new { stopTime = stopTime, ID = ID }) > 0;
            }
        }
    }
}
