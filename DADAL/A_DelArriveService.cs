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
    public class A_DelArriveService
    {
        string connection180 = @"Password=bohi@1218;Persist Security Info=True;User ID=sa;Initial Catalog=BohiErp;Data Source=192.168.51.180";
        /// <summary>
        /// 获取本地数据
        /// </summary>
        /// <returns></returns>
        public List<A_DelArriveMD> Get180List(DateTime newcreatetime)
        {
            string sql = @"select * from A_DelArrive where newcreatetime between @startTime and @endTime order by BilDate";
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connection180);
                sqlConnection.Open();
                List<A_DelArriveMD> a_DelArrives = new List<A_DelArriveMD>();
                a_DelArrives = sqlConnection.Query<A_DelArriveMD>(sql, new { startTime = newcreatetime.AddSeconds(-1), endTime = newcreatetime.AddSeconds(1) }) as List<A_DelArriveMD>;
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
            string sql = @"select top 1 * from A_DelArrive
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
