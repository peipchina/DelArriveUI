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
    public class A_DelReachService
    {
        string connection180 = @"Password=bohi@1218;Persist Security Info=True;User ID=sa;Initial Catalog=BohiErp;Data Source=192.168.51.180";
        /// <summary>
        /// 获取本地数据
        /// </summary>
        /// <returns></returns>
        public List<A_DelReachMD> Get180List(DateTime newcreatetime)
        {
            string sql = @"select * from A_DelReach where newcreatetime between @startTime and @endTime order by  ArriveTime ";
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connection180);
                sqlConnection.Open();
                List<A_DelReachMD> a_DelArrives = new List<A_DelReachMD>();
                a_DelArrives = sqlConnection.Query<A_DelReachMD>(sql, new { startTime = newcreatetime.AddSeconds(-1), endTime = newcreatetime.AddSeconds(1) }) as List<A_DelReachMD>;
                sqlConnection.Close();
                return a_DelArrives;
            }
            catch (Exception)
            {

                return null;
            }
        }
        /// <summary>
        /// 获取最新数据
        /// </summary>
        /// <returns></returns>
        public List<GetLastTime> getLastData()
        {
            string sql = @"select top 1 * from A_DelReach
                order by newcreatetime desc";
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connection180);
                sqlConnection.Open();
                List<GetLastTime> getLastTimes = new List<GetLastTime>();
                getLastTimes = sqlConnection.Query<GetLastTime>(sql, null) as List<GetLastTime>;
                sqlConnection.Close();
                return getLastTimes;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
