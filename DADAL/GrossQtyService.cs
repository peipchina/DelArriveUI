using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DA.MODEL;
using Dapper;

namespace DA.DAL
{
    public class GrossQtyService
    {
        #region 根据车号获取毛重
        /// <summary>
        /// 根据车号获取毛重
        /// </summary>
        /// <param name="AutoCode"></param>
        /// <returns>车号</returns>
        public List<V_GrossQtyMD> getGrossQtyByAutoCode(string AutoCode)
        {
            string connection = "Password=strive@4012;Persist Security Info=True;User ID=sa;Initial Catalog=SSS_BHSY;Data Source=172.168.1.39";
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"SELECT     TOP (100) PERCENT dr.MatID, pm.Name, sos.AutoCode,  sos.QtyTare, sos.TareTime, sos.TareStfID, ps1.Name AS TareStrName, dr.ToCust
                                FROM         dbo.SacOutSupervise AS sos LEFT OUTER JOIN
                                dbo.DelReachDtl AS dr ON dr.ID = sos.IDFrom LEFT OUTER JOIN                                
                                dbo.PubStaff AS ps1 ON ps1.ID = sos.TareStfID LEFT OUTER JOIN
                                dbo.PubMaterial AS pm ON pm.ID = dr.MatID
                                where sos.AutoCode=@AutoCode
                                ORDER BY sos.GrossTime DESC";
                return (List<V_GrossQtyMD>)sc.Query<V_GrossQtyMD>(sql, new { AutoCode = AutoCode });
            }
        }
        #endregion

        #region 根据车号获取毛重
        /// <summary>
        /// 根据车号获取毛重
        /// </summary>
        /// <param name="AutoCode"></param>
        /// <returns>车号</returns>
        public List<V_GrossQtyMD> getGrossQtyByAutoCodeLike(string AutoCode)
        {
            string connection = PubClass.getConnecion();
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"SELECT     TOP (100) PERCENT dr.MatID, pm.Name, sos.AutoCode,  sos.QtyTare, sos.TareTime, sos.TareStfID, ps1.Name AS TareStrName, dr.ToCust
                                FROM         dbo.SacOutSupervise AS sos LEFT OUTER JOIN
                                dbo.DelReachDtl AS dr ON dr.ID = sos.IDFrom LEFT OUTER JOIN                                
                                dbo.PubStaff AS ps1 ON ps1.ID = sos.TareStfID LEFT OUTER JOIN
                                dbo.PubMaterial AS pm ON pm.ID = dr.MatID
                                where sos.AutoCode like @AutoCode
                                ORDER BY sos.GrossTime DESC";
                return (List<V_GrossQtyMD>)sc.Query<V_GrossQtyMD>(sql, new { AutoCode = AutoCode });
            }
        }
        #endregion

        #region 根据车号获取毛重
        /// <summary>
        /// 根据车号获取毛重
        /// </summary>
        /// <param name="AutoCode"></param>
        /// <returns>车号</returns>
        public List<V_GrossQtyMD> getGrossQtyByAutoCodeBykv0866()
        {
            string connection = "Password=strive@4012;Persist Security Info=True;User ID=sa;Initial Catalog=SSS_BHSY;Data Source=172.168.1.39";
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"SELECT     TOP (100) PERCENT dr.MatID, pm.Name, sos.AutoCode,  sos.QtyTare, sos.TareTime, sos.TareStfID, ps1.Name AS TareStrName, dr.ToCust
                                FROM         dbo.SacOutSupervise AS sos LEFT OUTER JOIN
                                dbo.DelReachDtl AS dr ON dr.ID = sos.IDFrom LEFT OUTER JOIN                                
                                dbo.PubStaff AS ps1 ON ps1.ID = sos.TareStfID LEFT OUTER JOIN
                                dbo.PubMaterial AS pm ON pm.ID = dr.MatID
                                where sos.AutoCode like '%0866%'
                                ORDER BY sos.GrossTime DESC";
                return (List<V_GrossQtyMD>)sc.Query<V_GrossQtyMD>(sql, null);
            }
        }
        #endregion

    }
}
