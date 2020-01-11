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
    public class RebackCheckService
    {
        /// <summary>
        /// 根据车牌查询重量不足信息
        /// </summary>
        /// <param name="AutoCode">车号</param>
        
        public List<RebackCheckMD> GetRebackCheckByAutoCode(string autoCode)
        {
            string connection = @"Password=bohi@1218;Persist Security Info=True;User ID=sa;Initial Catalog=BohiErp;Data Source=192.168.51.180";
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"select * from rebackcheck where autocode like @autoCode and isfinished=0";
                return (List<RebackCheckMD>)sc.Query<RebackCheckMD>(sql, new { autoCode = autoCode });
            }
        }
        /// <summary>
        /// 根据时间查询重量不足信息
        /// </summary>
        /// <param name="AutoCode">车号</param>

        public List<RebackCheckMD> GetRebackCheckByTime(DateTime startTime,DateTime endTime)
        {
            string connection = @"Password=bohi@1218;Persist Security Info=True;User ID=sa;Initial Catalog=BohiErp;Data Source=192.168.51.180";
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"select * from rebackcheck where isfinished=0 and RebackTime between @startTime and @endTime";
                return (List<RebackCheckMD>)sc.Query<RebackCheckMD>(sql, new { startTime= startTime, endTime= endTime });
            }
        }
        
    }
}
