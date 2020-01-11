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
    public class PurInprisonService
    {
        //string connection = PubClass.getConnecion();
        string connection = @"Password=strive@4012;Persist Security Info=True;User ID=sa;Initial Catalog=SSS_BHSY;Data Source=172.168.1.39";
        public List<PurInprisonMD> getReachAuto(string ShipName)
        {            
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"SELECT * FROM PurInPrison where  CorpID='1190056' and IDInStc is null AND ShipName =@ShipName";
                return (List<PurInprisonMD>)sc.Query<PurInprisonMD>(sql, new { ShipName = ShipName });
            }
        }
        public bool delectAutoCode(long ID)
        {
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"DELETE FROM [dbo].[PurInPrison]
                            WHERE ID=@ID and corpID='1190056' AND IDInStc is null";
                return sc.Execute(sql, new { ID = ID })>0;
            }
        }
    }
}
