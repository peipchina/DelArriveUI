using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.MODEL;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace DA.DAL
{
   public  class GrossTimeService
    {
        public List<V_GrossTimeMD> getAllGrossTimeByAutoCar(string AutoCode)
        {
            string connection = PubClass.getConnecion();
            using (SqlConnection sc=new SqlConnection(connection))
            {
                string sql = @"SELECT     TOP (1) sos.GrossTime, sos.GrossStfID, ps.Name GrossStfName,pm.Name  AS MatName, sos.AutoCode,dr.ToCust,dr.DepotTo
                                FROM         dbo.SacOutSupervise AS sos                                
                                LEFT OUTER JOIN                                
                                dbo.PubStaff AS ps ON ps.ID = sos.GrossStfID
                                left join DelReachDtl dr on dr.ID=sos.IDFrom
                                left join PubMaterial pm on pm.ID=dr.MatID
                                where sos.AutoCode=@AutoCode
                                ORDER BY sos.GrossTime DESC";
                return (List<V_GrossTimeMD>)sc.Query<V_GrossTimeMD>(sql,new { AutoCode= AutoCode });
            }
        }
    }
}
