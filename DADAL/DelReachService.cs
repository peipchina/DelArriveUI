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
    public class DelReachService
    {
        #region 排队未配车
        /// <summary>
        /// 排队未配车
        /// </summary>
        /// <returns></returns>
        public List<V_DelReachMD> getReachAuto()
        {
            string connection = PubClass.getConnecion();
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"SELECT     TOP (100) PERCENT dae.ID, dae.BilID, dae.CorpID, dae.Code, dae.Name, dae.EName, dae.Mnemonic, dae.Driver, dae.DriverOut, dae.Tel, dae.DriveLice, dae.ArriveTime, 
dae.Rem, dae.IsDel, dae.PrintTime, dae.PrintStfID, dae.PrintTimes, dae.CreateStfID, dae.CreateTime, pst.name CreateStfName,
                      dae.ModifyTime, dae.CheckStfID,dae.CheckTime, dae.EffectTime, dae.StopTime, dae.IsUsed, dae.Status, dae.OldAutoCode
                        FROM         dbo.DelArrive AS dae
                        left join PubStaff pst on pst.id=dae.CreateStfID
                        WHERE     (dae.IsDel = 0) AND (dae.CorpID = 1190056) AND (NOT EXISTS
                                                  (SELECT DISTINCT ID
                                                    FROM          dbo.DelReachDtl AS dr
                                                    WHERE      (AutoCode = dae.Code) AND (CorpID = dae.CorpID) AND (QtyNet = 0 OR
                                                                           QtyNet IS NULL)))
                        ORDER BY dae.CreateTime DESC";
                return (List<V_DelReachMD>)sc.Query<V_DelReachMD>(sql, null);
            }
        }
        #endregion

        #region 根据单据时间获取通知单信息
        /// <summary>
        /// 根据单据时间获取通知单信息
        /// </summary>
        /// <param name="BilDate">单据时间</param>
        /// <returns>通知单对象</returns>
        public List<V_DelReachDtlMD> getAllDelReachDtlByBilDate(DateTime DateStart,DateTime DateEnd)
        {
            string connection = PubClass.getConnecion();
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"SELECT     drd.ID, drd.Item, drd.BilID, drd.CorpID, drd.Period, drd.BilDate AS DelReachDtlBilDate, drd.BilNo AS DelReachDtlBilNO, drd.RowIndex, drd.ContBilID, drd.ContItem, drd.AutoID, drd.QtyApp, drd.MatID, 
                      pm.Name AS matMaterial, drd.StockID, pst.Name AS stockName, drd.UnitID, pu.Name AS UnitName, drd.AutoCode, drd.Driver, drd.Tel, drd.DriveLice, drd.Qty, drd.Price, drd.QtyBase, drd.PriceFrei, 
                      drd.Disc, drd.Amt, drd.RateTax, drd.Tax, drd.AmtNoTax, drd.AmtLocal, drd.QtyTare, drd.QtyPack, drd.QtyGross, drd.QtyNet, drd.BilIDTo, drd.QtyTo, drd.BilIDFrom AS DelReachDTLBilIDFrom, 
                      drd.IDFrom AS DelReachDtlIDFrom, drd.ItemFrom, drd.DeliDate, drd.ToCust, drd.OBID, sc.BilNo AS SacContractBilNo, drd.OBBilID, drd.OBItem, drd.QtyPackBag, drd.PlanBilID, drd.PlanID, dp.BilNo, 
                      dr.BilDate AS DelReachBilDate, dr.BilNo AS DelReachBilNo, dr.DepID, dr.BilIDFrom AS DelReachBilIDFrom, dr.IDFrom AS DelReachIDFrom, dr.CreateStfID, ps.Name AS createStfName, 
                      dr.CreateTime, dr.Status, dr.StatusOld, drd.PlanItem
FROM         dbo.DelReachDtl AS drd LEFT OUTER JOIN
                      dbo.PubMaterial AS pm ON pm.ID = drd.MatID LEFT OUTER JOIN
                      dbo.PubUnit AS pu ON pu.ID = drd.UnitID LEFT OUTER JOIN
                      dbo.PubStock AS pst ON pst.ID = drd.StockID LEFT OUTER JOIN
                      dbo.SacContract AS sc ON sc.ID = drd.OBID LEFT OUTER JOIN
                      dbo.DelPlan AS dp ON dp.ID = drd.PlanID LEFT OUTER JOIN
                      dbo.DelReach AS dr ON dr.ID = drd.ID LEFT OUTER JOIN
                      dbo.PubStaff AS ps ON ps.ID = dr.CreateStfID 
                            where drd.corpid=1190056 and drd.BilDate between @DateStart and @DateEnd";
                return (List<V_DelReachDtlMD>)sc.Query<V_DelReachDtlMD>(sql, new { DateStart = DateStart, DateEnd= DateEnd });
            }
        }
        #endregion

        #region 根据通知ID获取通知单信息
        /// <summary>
        /// 根据通知ID获取通知单信息
        /// </summary>
        /// <param name="ID">通知ID</param>
        /// <returns>通知单对象</returns>
        public List<V_DelReachDtlMD> getAllDelReachDtlByBilID(long? ID)
        {
            string connection = PubClass.getConnecion();
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"SELECT     drd.ID, drd.Item, drd.BilID, drd.CorpID, drd.Period, drd.BilDate AS DelReachDtlBilDate, drd.BilNo AS DelReachDtlBilNO, drd.RowIndex, drd.ContBilID, drd.ContItem, drd.AutoID, drd.QtyApp, drd.MatID, 
                      pm.Name AS matMaterial, drd.StockID, pst.Name AS stockName, drd.UnitID, pu.Name AS UnitName, drd.AutoCode, drd.Driver, drd.Tel, drd.DriveLice, drd.Qty, drd.Price, drd.QtyBase, drd.PriceFrei, 
                      drd.Disc, drd.Amt, drd.RateTax, drd.Tax, drd.AmtNoTax, drd.AmtLocal, drd.QtyTare, drd.QtyPack, drd.QtyGross, drd.QtyNet, drd.BilIDTo, drd.QtyTo, drd.BilIDFrom AS DelReachDTLBilIDFrom, 
                      drd.IDFrom AS DelReachDtlIDFrom, drd.ItemFrom, drd.DeliDate, drd.ToCust, drd.OBID, sc.BilNo AS SacContractBilNo, drd.OBBilID, drd.OBItem, drd.QtyPackBag, drd.PlanBilID, drd.PlanID, dp.BilNo, 
                      dr.BilDate AS DelReachBilDate, dr.BilNo AS DelReachBilNo, dr.DepID, dr.BilIDFrom AS DelReachBilIDFrom, dr.IDFrom AS DelReachIDFrom, dr.CreateStfID, ps.Name AS createStfName, 
                      dr.CreateTime, dr.Status, dr.StatusOld, drd.PlanItem
FROM         dbo.DelReachDtl AS drd LEFT OUTER JOIN
                      dbo.PubMaterial AS pm ON pm.ID = drd.MatID LEFT OUTER JOIN
                      dbo.PubUnit AS pu ON pu.ID = drd.UnitID LEFT OUTER JOIN
                      dbo.PubStock AS pst ON pst.ID = drd.StockID LEFT OUTER JOIN
                      dbo.SacContract AS sc ON sc.ID = drd.OBID LEFT OUTER JOIN
                      dbo.DelPlan AS dp ON dp.ID = drd.PlanID LEFT OUTER JOIN
                      dbo.DelReach AS dr ON dr.ID = drd.ID LEFT OUTER JOIN
                      dbo.PubStaff AS ps ON ps.ID = dr.CreateStfID 
                            where drd.ID=@ID";
                return (List<V_DelReachDtlMD>)sc.Query<V_DelReachDtlMD>(sql, new { ID = ID });
            }
        }
        #endregion

        #region 根据车号获取通知单信息
        /// <summary>
        /// 根据车号获取通知单信息
        /// </summary>
        /// <param name="AutoCode">车号</param>
        /// <returns>通知单对象</returns>
        public List<V_DelReachDtlMD> getAllDelReachDtlByAutoCode(string autoCode)
        {
            string connection = PubClass.getConnecion();
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"SELECT     drd.ID, drd.Item, drd.BilID, drd.CorpID, drd.Period, drd.BilDate AS DelReachDtlBilDate, drd.BilNo AS DelReachDtlBilNO, drd.RowIndex, drd.ContBilID, drd.ContItem, drd.AutoID, drd.QtyApp, drd.MatID, 
                      pm.Name AS matMaterial, drd.StockID, pst.Name AS stockName, drd.UnitID, pu.Name AS UnitName, drd.AutoCode, drd.Driver, drd.Tel, drd.DriveLice, drd.Qty, drd.Price, drd.QtyBase, drd.PriceFrei, 
                      drd.Disc, drd.Amt, drd.RateTax, drd.Tax, drd.AmtNoTax, drd.AmtLocal, drd.QtyTare, drd.QtyPack, drd.QtyGross, drd.QtyNet, drd.BilIDTo, drd.QtyTo, drd.BilIDFrom AS DelReachDTLBilIDFrom, 
                      drd.IDFrom AS DelReachDtlIDFrom, drd.ItemFrom, drd.DeliDate, drd.ToCust, drd.OBID, sc.BilNo AS SacContractBilNo, drd.OBBilID, drd.OBItem, drd.QtyPackBag, drd.PlanBilID, drd.PlanID, dp.BilNo, 
                      dr.BilDate AS DelReachBilDate, dr.BilNo AS DelReachBilNo, dr.DepID, dr.BilIDFrom AS DelReachBilIDFrom, dr.IDFrom AS DelReachIDFrom, dr.CreateStfID, ps.Name AS createStfName, 
                      dr.CreateTime, dr.Status, dr.StatusOld, drd.PlanItem
FROM         dbo.DelReachDtl AS drd LEFT OUTER JOIN
                      dbo.PubMaterial AS pm ON pm.ID = drd.MatID LEFT OUTER JOIN
                      dbo.PubUnit AS pu ON pu.ID = drd.UnitID LEFT OUTER JOIN
                      dbo.PubStock AS pst ON pst.ID = drd.StockID LEFT OUTER JOIN
                      dbo.SacContract AS sc ON sc.ID = drd.OBID LEFT OUTER JOIN
                      dbo.DelPlan AS dp ON dp.ID = drd.PlanID LEFT OUTER JOIN
                      dbo.DelReach AS dr ON dr.ID = drd.ID LEFT OUTER JOIN
                      dbo.PubStaff AS ps ON ps.ID = dr.CreateStfID 
                            where  drd.AutoCode like @AutoCode ORDER BY DRD.BilDate DESC ";
                return (List<V_DelReachDtlMD>)sc.Query<V_DelReachDtlMD>(sql, new { AutoCode = autoCode });
            }
        }
        #endregion
    }
}
