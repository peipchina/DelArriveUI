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
    public class CountQtyServiece
    {
        public List<V_CountQtyMD> getCountByTimeAndMatName(string MatName,DateTime startTime,DateTime endTime)
        {
            string connection = PubClass.getConnecion();
            using (SqlConnection sc=new SqlConnection(connection))
            {
                string sql = @"select sos.ID,sos.IDFrom,sos.AutoCode,pm.name MatName,sos.QtyGross,sos.QtyTare,drd.BilNo,sos.QtyGross-sos.QtyTare as Qty,sos.GrossTime from SacOutSupervise sos
                                left join DelReachDtl drd on drd.id=sos.idfrom 
                                left join PubMaterial pm on pm.id=drd.matid
                                where sos.CorpID=1190056 and pm.name=@MatName and sos.GrossTime between @startTime and @endTime";
                return (List<V_CountQtyMD>)sc.Query<V_CountQtyMD>(sql,new { MatName= MatName, startTime= startTime, endTime= endTime }); 
            }
        }
    }
}
