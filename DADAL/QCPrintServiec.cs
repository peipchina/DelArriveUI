using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using DA.MODEL;

namespace DA.DAL
{
   public  class QCPrintServiec
    {
        #region 根据时间获取打印模板所需要的出厂记录
        /// <summary>
        /// 根据时间获取打印模板所需要的发货单
        /// </summary>
        /// <param name="PassTimeStart">开始时间</param>
        /// <param name="PassTimeEnd">结束时间</param>
        /// <returns>出厂资料</returns>
        public List<V_QCPrintMD> getAllQCPrintListByDate(DateTime PassTimeStart, DateTime PassTimeEnd)
        {
            string connection = PubClass.getConnecion();
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"SELECT     TOP (100) PERCENT a.ID, a.CorpID, a.BilIDFrom, a.IDFrom, a.ItemFrom, a.IDOutStc, a.AutoID, a.AutoCode, a.Driver, a.UpStockID, a.InLine, a.InLineTime, a.IDInStc, a.StockID,pst.name StorckName, a.StockQty, a.QtyTare, 
                      a.TareTime, a.TareStfID, a.QtyGross, a.GrossTime, a.GrossStfID, a.BeginLoadStfID, a.BeginLoadTime, a.EndLoadTime, a.EndLoadStfID, a.QCID, a.PassTime, a.PassStfID, a.SuperviseID, 
                      a.CreateStfID, a.CreateTime, a.Rem, a.SuperviseTypeID, a.SuperviseIndex, a.UpIndex, a.MultKeyID, a.QtyLastTare, a.LastTareTime, a.LastTareStfID, a.IsReceipt, a.AccID, a.RecAmt, a.ReCAmtLocal, 
                      a.QtyTareRep, a.TareRepTime, a.TareRepStfID, a.DelayHours, a.LoadAdd, a.IsPass, a.QtyCheck12, a.QtyCheck2, a.QtyCheck3, a.QtyCheck1, a.QtyCheck4, a.QtyCheck5, a.QtyCheck6, a.QtyCheck7, 
                      a.QtyCheck8, a.QtyCheck9, a.QtyCheck10, a.QtyCheck11, a.ArriveID, a.CheckStfName, a.QtyCheck13, a.QtyCheck14, a.QtyBZY, a.QtyTray, a.QtyLargess, a.TrayName, a.TrayName AS QtyCheck15, 
                      b.MatID, b.StockID AS StockIDDtl, b.Qty, b.ContID, b.ContBilID, b.ContItem, e.TransportID, b.ToCust, c.Code AS MatIDCode, c.Name AS MatIDName, mt.Name AS MatTypeName, 
                      e.DepID AS ContDepID,ps.Name passName, b.CorpID AS DCorpID, d.ID AS DrID, e.BilNo AS ContBilNo, e.CustID, TS.TSCode, TS.DepotFrom, TS.DepotTo, TS.Consignee
FROM         dbo.SacOutSupervise AS a WITH (NOLOCK) 
						LEFT OUTER JOIN  dbo.DelReachDtl AS b WITH (NOLOCK) ON a.IDFrom = b.ID AND a.ItemFrom = b.Item 
						left join PubStaff ps on ps.ID=a.PassStfID
                      LEFT OUTER JOIN
                      dbo.PubMaterial AS c WITH (NOLOCK) ON b.MatID = c.ID 
                      LEFT OUTER JOIN
                      dbo.PubMatType AS mt WITH (NOLOCK) ON c.MatTypeID = mt.ID 
                      left join PubStock pst on pst.id=a.StockID
                      LEFT OUTER JOIN
                      dbo.DelReach AS d WITH (NOLOCK) ON b.ID = d.ID
                       LEFT OUTER JOIN
                      dbo.SacContract AS e WITH (NOLOCK) ON b.ContID = e.ID 
                      LEFT OUTER JOIN
                          (SELECT     B.ID, B.Item, B.ShipCode AS TSCode, B.DepotFrom, B.DepotTo, H.Consignee
                            FROM          dbo.DelAlloShipDtl AS B WITH (NOLOCK) LEFT OUTER JOIN
                                                   dbo.DelAlloShip AS H WITH (NOLOCK) ON H.ID = B.ID
                            UNION ALL
                            SELECT     B.ID, B.Item, B.TrainCode AS TSCode, B.DepotFrom, B.DepotTo, H.Consignee
                            FROM         dbo.DelAlloTrainDtl AS B WITH (NOLOCK) 
                            LEFT OUTER JOIN
                                                  dbo.DelAlloTrain AS H WITH (NOLOCK) ON H.ID = B.ID) AS TS ON TS.ID = b.AlloID AND TS.Item = b.AlloItem
WHERE     (a.SuperviseTypeID IN (5, 7)) AND (a.IsPass IS NOT NULL) AND (a.CorpID = 1190056) and a.PassTime between @PassTimeStart and @PassTimeEnd
ORDER BY a.PassTime ";
                return (List<V_QCPrintMD>)sc.Query<V_QCPrintMD>(sql, new { PassTimeStart = PassTimeStart, PassTimeEnd = PassTimeEnd });
            }
        }
        #endregion

        #region 获取当天时间打印模板所需要的出厂记录
        /// <summary>
        /// 获取当天时间打印模板所需要的出厂记录
        /// </summary>        
        /// <returns>出厂资料</returns>
        public List<V_QCPrintMD> getAllQCPrintList()
        {
            string connection = PubClass.getConnecion();
            DateTime ps = DateTime.Now;
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"SELECT     TOP (100) PERCENT a.ID, a.CorpID, a.BilIDFrom, a.IDFrom, a.ItemFrom, a.IDOutStc, a.AutoID, a.AutoCode, a.Driver, a.UpStockID, a.InLine, a.InLineTime, a.IDInStc, a.StockID,pst.name StorckName, a.StockQty, a.QtyTare, 
                      a.TareTime, a.TareStfID, a.QtyGross, a.GrossTime, a.GrossStfID, a.BeginLoadStfID, a.BeginLoadTime, a.EndLoadTime, a.EndLoadStfID, a.QCID, a.PassTime, a.PassStfID, a.SuperviseID, 
                      a.CreateStfID, a.CreateTime, a.Rem, a.SuperviseTypeID, a.SuperviseIndex, a.UpIndex, a.MultKeyID, a.QtyLastTare, a.LastTareTime, a.LastTareStfID, a.IsReceipt, a.AccID, a.RecAmt, a.ReCAmtLocal, 
                      a.QtyTareRep, a.TareRepTime, a.TareRepStfID, a.DelayHours, a.LoadAdd, a.IsPass, a.QtyCheck12, a.QtyCheck2, a.QtyCheck3, a.QtyCheck1, a.QtyCheck4, a.QtyCheck5, a.QtyCheck6, a.QtyCheck7, 
                      a.QtyCheck8, a.QtyCheck9, a.QtyCheck10, a.QtyCheck11, a.ArriveID, a.CheckStfName, a.QtyCheck13, a.QtyCheck14, a.QtyBZY, a.QtyTray, a.QtyLargess, a.TrayName, a.TrayName AS QtyCheck15, 
                      b.MatID, b.StockID AS StockIDDtl, b.Qty, b.ContID, b.ContBilID, b.ContItem, e.TransportID, b.ToCust, c.Code AS MatIDCode, c.Name AS MatIDName, mt.Name AS MatTypeName, 
                      e.DepID AS ContDepID,ps.Name passName, b.CorpID AS DCorpID, d.ID AS DrID, e.BilNo AS ContBilNo, e.CustID, TS.TSCode, TS.DepotFrom, TS.DepotTo, TS.Consignee
FROM         dbo.SacOutSupervise AS a WITH (NOLOCK) 
						LEFT OUTER JOIN  dbo.DelReachDtl AS b WITH (NOLOCK) ON a.IDFrom = b.ID AND a.ItemFrom = b.Item 
						left join PubStaff ps on ps.ID=a.PassStfID
                      LEFT OUTER JOIN
                      dbo.PubMaterial AS c WITH (NOLOCK) ON b.MatID = c.ID 
                      LEFT OUTER JOIN
                      dbo.PubMatType AS mt WITH (NOLOCK) ON c.MatTypeID = mt.ID 
                      left join PubStock pst on pst.id=a.StockID
                      LEFT OUTER JOIN
                      dbo.DelReach AS d WITH (NOLOCK) ON b.ID = d.ID
                       LEFT OUTER JOIN
                      dbo.SacContract AS e WITH (NOLOCK) ON b.ContID = e.ID 
                      LEFT OUTER JOIN
                          (SELECT     B.ID, B.Item, B.ShipCode AS TSCode, B.DepotFrom, B.DepotTo, H.Consignee
                            FROM          dbo.DelAlloShipDtl AS B WITH (NOLOCK) LEFT OUTER JOIN
                                                   dbo.DelAlloShip AS H WITH (NOLOCK) ON H.ID = B.ID
                            UNION ALL
                            SELECT     B.ID, B.Item, B.TrainCode AS TSCode, B.DepotFrom, B.DepotTo, H.Consignee
                            FROM         dbo.DelAlloTrainDtl AS B WITH (NOLOCK) 
                            LEFT OUTER JOIN
                                                  dbo.DelAlloTrain AS H WITH (NOLOCK) ON H.ID = B.ID) AS TS ON TS.ID = b.AlloID AND TS.Item = b.AlloItem
WHERE     (a.SuperviseTypeID IN (5, 7)) AND (a.IsPass IS NOT NULL) AND (a.CorpID = 1190056) and  DateDiff(dd,a.PassTime,@PassTime)=0 ";
                return (List<V_QCPrintMD>)sc.Query<V_QCPrintMD>(sql, new { PassTime = ps });
            }
        }
        #endregion
    }
}
