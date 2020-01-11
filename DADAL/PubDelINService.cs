using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.MODEL;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace DA.DAL
{
    public class PubDelINService
    {
        #region 根据登录名获取所有信息
        /// <summary>
        /// 根据登录名获取所有信息
        /// </summary>
        /// <param name="lonname"></param>
        /// <returns>登录信息</returns>
        public List<PubDelInMD> getPassWordByLoginName(string lonname)
        {
            string connection = @"Password=bohi@1218;Persist Security Info=True;User ID=sa;Initial Catalog=BohiERP;Data Source=192.168.51.180";
            using (SqlConnection sc = new SqlConnection(connection))
            {
                //string sql = @"SELECT     pn.LoginName, pn.LastLoginIPAdress, pr.StfID, pr.AutoCodeForm, pr.CountForm, pr.DelReachForm, pr.GrossQtyForm, pr.QCPrintForm, pr.ReachArriveForm, pr.ShipmentForm, pr.UIForm, 
                //      pn.PassWord
                //    FROM         dbo.PubRole AS pr LEFT OUTER JOIN
                //      dbo.pubDelIn AS pn ON pn.ID = pr.StfID Where pn.LoginName=@LoginName";
                string sql = @"SELECT     pn.LoginName, pn.LastLoginIPAdress, pr.StfID, pr.AutoCodeForm, pr.CountForm, pr.DelReachForm, pr.GrossQtyForm, pr.QCPrintForm, pr.ReachArriveForm, pr.ShipmentForm, pr.UIForm, 
                      pn.PassWord
                    FROM         dbo.PubRole AS pr LEFT OUTER JOIN
                      dbo.pubDelIn AS pn ON pn.ID = pr.StfID Where pn.LoginName=@LoginName";
                return (List<PubDelInMD>)sc.Query<PubDelInMD>(sql, new { LoginName = lonname });
            }
        }
        #endregion

        #region 修改密码
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="lonname"></param>
        /// <returns>影响行</returns>
        public int UpPassWord(PubDelInMD pdi)
        {
            string connection = @"Password=bohi@1218;Persist Security Info=True;User ID=sa;Initial Catalog=BohiERP;Data Source=192.168.51.180";
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @" update pubDelIn set PassWord=@PassWord where LoginName=@LoginName";
                int a = sc.Execute(sql,pdi);
                return a;
            }
        }
        #endregion
    }
}
