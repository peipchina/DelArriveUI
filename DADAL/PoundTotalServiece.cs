using DA.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace DA.DAL
{
    public class PoundTotalServiece
    {

        /// <summary>
        /// 根据车牌识别车号查询托利多信息
        /// </summary>
        /// <param name="AutoCode">自动识别的车号</param>
        /// <returns>监装表</returns>
        public List<PoundTotalMD> GetPountListByAutoCode(string AutoCode,DateTime dateTime)
        {
            string connection = @"Password=bohi@1218;Persist Security Info=True;User ID=sa;Initial Catalog=BohiErp;Data Source=192.168.51.180";
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"select * from PoundTotal where AutoCode=@AutoCode and IsDelete=0 and TareTime between @startTime and @endTime order by GrossTime desc";
                return (List<PoundTotalMD>)sc.Query<PoundTotalMD>(sql, new { @AutoCode = AutoCode, @startTime= dateTime.AddHours(-1), @endTime=dateTime.AddHours(1) });
            }
        }
        /// <summary>
        /// 根据车牌识别车号查询托利多信息
        /// </summary>
        /// <param name="AutoCode">自动识别的车号</param>
        /// <returns>监装表</returns>
        public List<PoundTotalMD> GetPountListByAutoCodeL(string AutoCode)
        {
            string connection = @"Password=bohi@1218;Persist Security Info=True;User ID=sa;Initial Catalog=BohiErp;Data Source=192.168.51.180";
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"select * from PoundTotal where AutoCode like @AutoCode and IsDelete=0 order by TareTime desc";
                return (List<PoundTotalMD>)sc.Query<PoundTotalMD>(sql, new { @AutoCode = AutoCode });
            }
        }
        /// <summary>
        /// 根据车牌识别车号查询托利多信息
        /// </summary>
        /// <param name="AutoCode">自动识别的车号</param>
        /// <returns>监装表</returns>
        public List<PoundTotalMD> GetPountListByAutoCodeR(string AutoCode)
        {
            string connection = @"Password=bohi@1218;Persist Security Info=True;User ID=sa;Initial Catalog=BohiErp;Data Source=192.168.51.180";
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"select * from PoundTotal where AutoCode=@AutoCode and IsDelete=0 order by TareTime desc";
                return (List<PoundTotalMD>)sc.Query<PoundTotalMD>(sql, new { @AutoCode = AutoCode });
            }
        }
        /// <summary>
        /// 获取某段时间车辆过磅信息
        /// </summary>        
        /// <returns>车辆过磅信息泛型</returns>
        public List<PoundTotalMD> GetPoundListByDateTime(DateTime StartTime, DateTime EndTime)
        {
            try
            {
                string connection = @"Password=bohi@1218;Persist Security Info=True;User ID=sa;Initial Catalog=BohiErp;Data Source=192.168.51.180";
                using (SqlConnection sc = new SqlConnection(connection))
                {
                    string sql = @"select * from PoundTotal
                        WHERE  IsDelete=0  and (IsFinished = 1) AND (GrossTime BETWEEN @StartTime AND @EndTime)
                        ORDER BY No DESC ";
                    return (List<PoundTotalMD>)sc.Query<PoundTotalMD>(sql, new { StartTime = StartTime, EndTime = EndTime });
                }
            }
            catch (Exception)
            {
                return null;
                //throw;
            }
        }
    }
}
