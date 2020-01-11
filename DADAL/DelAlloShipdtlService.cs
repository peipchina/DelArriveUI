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
    public class DelAlloShipdtlService
    {
        string connection180 = PubClass.getConnecion();
        /// <summary>
        /// 获取本地数据
        /// </summary>
        /// <returns></returns>
        public List<DelAlloShipdtlMD> Get180List(DateTime startTime,DateTime endTime)
        {
            string sql = @"select * from DelAlloShipdtl where CorpID='1190056' and BilDate between @startTime and @endTime";
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connection180);
                sqlConnection.Open();
                List<DelAlloShipdtlMD> a_DelArrives = new List<DelAlloShipdtlMD>();
                a_DelArrives = sqlConnection.Query<DelAlloShipdtlMD>(sql, new { startTime = @startTime, endTime = @endTime }) as List<DelAlloShipdtlMD>;
                sqlConnection.Close();
                return a_DelArrives;
            }
            catch (Exception)
            {

                return null;
            }
        }
        /// <summary>
        /// 删除黑名单
        /// </summary>
        /// <returns>司机黑名单</returns>
        public bool ChangeShipName(long id, string newShipName)
        {            
            using (SqlConnection sc = new SqlConnection(connection180))
            {
                string sql = @"UPDATE DelAlloShipdtl
                       SET shipCode = @newShipName      
                     WHERE id=@id";
                return sc.Execute(sql, new { ID = id, newShipName = newShipName}) > 0;
            }

        }
    }
}
