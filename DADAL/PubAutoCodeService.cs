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
    public class PubAutoCodeService
    {
        /// <summary>
        /// 根据车牌识别车号查询毛重及皮重时间
        /// </summary>
        /// <param name="AutoCode">自动识别的车号</param>
        /// <returns>监装表</returns>
        public List<PubAutoCodeMD> GetPubAutoCode()
        {
            string connection = @"Password=bohi@1218;Persist Security Info=True;User ID=sa;Initial Catalog=BohiErp;Data Source=192.168.51.180";
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"select * from PubAutoCode";
                return (List<PubAutoCodeMD>)sc.Query<PubAutoCodeMD>(sql, null);
            }
        }
    }
}
