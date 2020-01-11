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
    public class DelAlloAutoService
    {
        public List<DelAlloAutoMD> getDelAlloAuto(DateTime startTime,DateTime endTime)
        {
            using (SqlConnection sc = new SqlConnection(PubClass.getConnecion()))
            {
                string sql = @"select * from DelAlloAuto where corpid='1190056' and bildate between @startTime and @endTime";
                return (List<DelAlloAutoMD>)sc.Query<DelAlloAutoMD>(sql, new { startTime = startTime, endTime = endTime });
            }
        }
        /// <summary>
        /// 修改客户运价
        /// </summary>
        /// <param name="BilNo"></param>
        /// <param name="My1_UDsg"></param>
        /// <returns></returns>
        public bool UpdateDelAlloAuto(long ID, Decimal My1_UDsg)
        {
            using (SqlConnection sc = new SqlConnection(PubClass.getConnecion()))
            {
                string sql = @"UPDATE DelAlloAuto SET My1_UDsg=@My1_UDsg WHERE CorpID='1190056' and ID=@ID";
                return sc.Execute(sql, new { My1_UDsg = My1_UDsg, ID = ID })>0;
            }
        }
        public List<DelAlloAutoDtlMD> getDelAlloAutoDTL(DateTime startTime, DateTime endTime)
        {
            using (SqlConnection sc = new SqlConnection(PubClass.getConnecion()))
            {
                string sql = @"select pm.Name as MatName, dt.* from DelAlloAutoDtl dt 
                            left join PubMaterial pm on pm.ID=dt.MatID where dt.corpid='1190056' and dt.bildate between @startTime and @endTime";
                return (List<DelAlloAutoDtlMD>)sc.Query<DelAlloAutoDtlMD>(sql, new { startTime = startTime, endTime = endTime });
            }
        }
        /// <summary>
        /// 修改实际运价
        /// </summary>
        /// <param name="BilNo"></param>
        /// <param name="My1_UDsg"></param>
        /// <returns></returns>
        public bool UpdateDelAlloAutoDtl(long ID, Decimal PriceFrei)
        {
            using (SqlConnection sc = new SqlConnection(PubClass.getConnecion()))
            {
                string sql = @"UPDATE DelAlloAutoDtl SET PriceFrei=@PriceFrei WHERE CorpID='1190056' and ID=@ID";
                return sc.Execute(sql, new { PriceFrei = PriceFrei, ID = ID }) > 0;
            }
        }
    }
}
