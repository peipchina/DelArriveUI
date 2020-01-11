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
    public class sacServiece
    {
        
            #region 根据车号查询发货信息
            /// <summary>
            /// 根据车号及时间查询发货信息
            /// </summary>
            /// <param name="AutoCode">车号</param>        
            /// <returns>发货信息</returns>
            public List<V_SacMD> GetV_SacMDs(DateTime startTime, DateTime endTime)
            {
                string connection = PubClass.getConnecion();
                using (SqlConnection sc = new SqlConnection(connection))
                {
                    string sql = @"SELECT   TS .ID AS AlloTrainID, AutoStatus = (CASE WHEN ISNull(D .QtyNet, 0) > 0 THEN 1 WHEN ISNull(D .QtyTare, 0) > 0 AND 
                ISNull(D .QtyGross, 0) <= 0 THEN 2 WHEN (ISNULL(D .QtyTare, 0) = 0 AND ISNULL(D .QtyGross, 0) = 0) THEN 3 END), 
                H.CorpID, H.DepID, H.BilDate, H.BilNo, D .ID, D .BilID, D .Item, D .Driver, D .DriveLice, D .AutoCode, D .Tel, 
                Saos.TareTime, HDL.CreateTime AS GrossTime, D .QtyTare, D .QtyGross, D .QtyNet, DL.QtyKP, DL.QtyLot, Allo.DeliDate, 
                D .Qty, DL.Price AS Price, DL.QtyRER, TS .DepotFrom, TS .DepotTo, H.PrintTime, (ISNULL(DL.QtyRER, 0) 
                * ISNULL(DL.Price, 0)) AS Amt, Sac.PriceFrei AS PriceFreiCont, ISNULL(ISNULL(Sac.PriceFrei, 0) * ISNULL(DL.QtyRER, 0), 
                0) AS AmtFrei, ISNULL(ISNULL(Allo.PriceFrei, 0) * ISNULL(DL.Qty, 0), 0) AS AmtFrei1, (ISNULL(DL.QtyRER, 0) 
                * ISNULL(DL.Price, 0)) + ISNULL(ISNULL(Sac.PriceFrei, 0) * ISNULL(DL.QtyRER, 0), 0) AS AmtAndFrei, Allo.PriceFrei, 
                Allo.ToCust, SacDtl.MatID, SacDtl.Qty AS QtyCont, Sac.BilNo AS ContBilNo, Allo.CreateTime, SacDtl.StockID, 
                Sac.ContPayTypeID, DL.QtyPack, (CASE WHEN HDL.BilIDFrom = 'SPCF' OR
                H.BilIDFrom = 'SPCF1' THEN '发货变更' WHEN D .BilIDFrom = 'DEAA' THEN '汽车配运' WHEN D .BilIDFrom = 'DEAC' THEN
                 '自提配运' WHEN D .BilIDFrom = 'DESD' THEN '短倒配运' END) AS Rem, ISNull(SacDtl.Qty, 0) - ISNull(SacDtl.QtyTo, 0) 
                + ISNull(SacDtl.QtyRetu, 0) AS QtyStaCont, Sac.CustID, Sac.DeliWayID, Sac.TransportID, Sac.StfID, 0 AS StockIDTo, 
                TS .Consignee, TS .TSCode, d .QtyMeshBag, Sac.AreaID, CASE WHEN m.Name LIKE '%豆粕%' AND 
                sac.BilNo NOT LIKE '%YDK%' THEN (CASE WHEN dl.IsStaStatus = 1 THEN DL.PriceAcc ELSE DL.Price END) 
                + isnull(PPDU.PriceDif, 0) ELSE NULL END AS Price43, SacDtl.PriceTranTypeID, 
                CASE WHEN dl.IsStaStatus = 1 THEN '已结价' WHEN SacDtl.PriceTranTypeID = 2 AND 
                dl.IsStaStatus = 0 THEN '未结价' ELSE '标准价' END AS IsStaStatus, HDl.BilNo AS DelBilNo, Saos.QtyCheck1, 
                Saos.QtyCheck2, Saos.QtyCheck3, Saos.QtyCheck4, Saos.QtyCheck5, Saos.QtyCheck6, Saos.QtyCheck7, 
                Saos.QtyCheck8, Saos.QtyCheck9, Saos.QtyCheck10, Saos.QtyCheck11, Saos.QtyCheck12, Saos.QtyCheck13, 
                Saos.QtyCheck14, Saos.QtyCheck15, Saos.ID AS SaosID, 
                CASE WHEN saos.IsPass = 1 THEN '合格' WHEN Saos.IsPass = 0 THEN '不合格' ELSE '' END AS IsPass, 
                dela.ArriveTime, dela.DriveLice AS ArrDriveLice, dela.Driver AS ArrDriver, dela.DriverOut AS ArrDriverOut, 
                dela.Tel AS ArrTel, CASE WHEN dl.IsStaStatus = 1 THEN DL.PriceAcc ELSE DL.Price END AS PriceAcc, 
                CASE WHEN dl.IsStaStatus = 1 THEN (ISNULL(DL.QtyRER, 0) * ISNULL(DL.PriceAcc, 0)) ELSE (ISNULL(DL.QtyRER, 0) 
                * ISNULL(DL.Price, 0)) END AS AmtAcc, CASE WHEN dl.IsStaStatus = 1 THEN (ISNULL(DL.QtyRER, 0) 
                * ISNULL(DL.PriceAcc, 0)) + ISNULL(ISNULL(Sac.PriceFrei, 0) * ISNULL(DL.QtyRER, 0), 0) ELSE (ISNULL(DL.QtyRER, 0) 
                * ISNULL(DL.Price, 0)) + ISNULL(ISNULL(Sac.PriceFrei, 0) * ISNULL(DL.QtyRER, 0), 0) END AS AmtAcc1, sac.DealerID, 
                HDTF.AmtFrei1 AS AmtFreiT1, HDTF.AmtFrei AS AmtFreiT, ISNULL(HDTF.AmtFrei, 0) - ISNULL(HDTF.AmtFrei1, 0) 
                AS AmtFr, HDTF.ID AS HDTFID, HDTF.BilNo AS HDTFBilNo, 
                CASE WHEN m.Name LIKE '%油%' THEN '18个月' WHEN m.Name LIKE '%豆粕%' THEN '6个月' ELSE '' END AS CheckDate
FROM      DelReachDtl D WITH (nolock) LEFT JOIN
                DelReach H WITH (nolock) ON D .ID = H.ID LEFT JOIN
                    (SELECT   ID, BilID, IDFrom, BilIDFrom, ItemFrom, SUM(QtyRER) AS QtyRER, Price, PriceAcc, IsStaStatus, sum(Qty) 
                                     AS Qty, sum(QtyKP) AS QtyKP, sum(QtyLot) AS QtyLot, SUM(QtyPack) AS QtyPack
                     FROM      DelLeaveDtl WITH (nolock)
                     GROUP BY ID, BilID, IDFrom, BilIDFrom, ItemFrom, Price, PriceAcc, IsStaStatus) DL ON D .ID = DL.IDFrom AND 
                D .Item = DL.ItemFrom AND D .BilID = DL.BilIDFrom LEFT JOIN
                DelLeave HDL WITH (nolock) ON HDL.ID = DL.ID LEFT JOIN
                SacOutSupervise Saos WITH (nolock) ON Saos.IDFrom = D .ID AND Saos.BilIDFrom = D .BilID AND 
                Saos.ItemFrom = D .Item AND Saos.SuperviseID IS NULL LEFT JOIN
                DelArrive dela ON Saos.ArriveID = dela.ID LEFT JOIN
                SacContractDtl SacDtl WITH (nolock) ON D .ContID = SacDtl.ID AND D .ContBilID = SacDtl.BilID AND 
                D .ContItem = SacDtl.Item LEFT JOIN
                SacContract Sac WITH (nolock) ON SacDtl.ID = Sac.ID LEFT JOIN
                PubMaterial M WITH (nolock) ON D .MatID = M.ID LEFT JOIN
                PubPriceDifUpdate PPDU WITH (nolock) ON PPDU.CorpID = SacDtl.CorpID AND PPDU.MatTypeID = M.MatTypeID LEFT 
                JOIN
                    (SELECT   Allo.BilID, Allo.ID, Allo.Item, Allo.DeliDate, Allo.Qty, Allo.PriceFrei, Allo.ToCust, HAllo.CreateTime
                     FROM      DelAlloAutoDtl Allo LEFT JOIN
                                     DelAlloAuto HAllo ON Allo.ID = HAllo.ID
                     WHERE   HAllo.Status IN (4, 5)
                     UNION ALL
                     SELECT   Allo.BilID, Allo.ID, Allo.Item, Allo.DeliDate, Allo.Qty, Allo.PriceFrei, Allo.ToCust, HAllo.CreateTime
                     FROM      DelAlloCustDtl Allo WITH (nolock) LEFT JOIN
                                     DelAlloCust HAllo WITH (nolock) ON Allo.ID = HAllo.ID
                     WHERE   HAllo.Status IN (4, 5)
                     UNION ALL
                     SELECT   Allo.BilID, Allo.ID, Allo.Item, Allo.DeliDate, Allo.Qty, Allo.PriceFrei, Allo.ToCust, HAllo.CreateTime
                     FROM      DelShoDeliDtl Allo WITH (nolock) LEFT JOIN
                                     DelShoDeli HAllo WITH (nolock) ON Allo.ID = HAllo.ID
                     WHERE   HAllo.Status IN (4, 5)) Allo ON D .BilIDFrom = Allo.BilID AND D .IDFrom = Allo.ID AND 
                D .ItemFrom = Allo.Item LEFT JOIN
                    (SELECT   B.ID, B.Item, B.BilID, H.Consignee, B.TrainCode AS TSCode, B.DepotFrom, B.DepotTo
                     FROM      DelAlloTrainDtl B WITH (nolock) LEFT JOIN
                                     DelAlloTrain H WITH (nolock) ON H.ID = B.ID
                     UNION ALL
                     SELECT   B.ID, B.Item, B.BilID, H.Consignee, B.ShipCode AS TSCode, B.DepotFrom, B.DepotTo
                     FROM      DelAlloShipDtl B WITH (nolock) LEFT JOIN
                                     DelAlloShip H WITH (nolock) ON H.ID = B.ID) TS ON D .AlloID = TS .ID AND D .AlloBilID = TS .BilID AND 
                D .AlloItem = TS .Item LEFT JOIN
                DelTrainFreiDtl DTF ON DTF.IDFrom = D .ID AND Dtf.ItemFrom = D .Item LEFT JOIN
                DelTrainFrei HDTF ON HDTF.ID = DTF.ID
WHERE   D .BilIDFrom IN ('DEAA', 'DEAC', 'DESD', 'DEAT') AND D .ContBilID <> 'BOHI16' AND (HDl.Status IN (3, 4) OR
                HDl.Status IS NULL)
UNION ALL
SELECT   TS .ID AS AlloTrainID, AutoStatus = (CASE WHEN ISNull(D .QtyNet, 0) > 0 THEN 1 WHEN ISNull(D .QtyTare, 0) > 0 AND 
                ISNull(D .QtyGross, 0) <= 0 THEN 2 WHEN (ISNULL(D .QtyTare, 0) = 0 AND ISNULL(D .QtyGross, 0) = 0) THEN 3 END), 
                H.CorpID, H.DepID, H.BilDate, H.BilNo, D .ID, D .BilID, D .Item, D .Driver, D .DriveLice, D .AutoCode, D .Tel, 
                Saos.TareTime, HDL.CreateTime AS GrossTime, D .QtyTare, D .QtyGross, D .QtyNet, 0 AS QtyKP, 0 AS QtyLot, 
                Allo.DeliDate, D .Qty, DL.Price, DL.Qty AS QtyRER, TS .DepotFrom, TS .DepotTo, H.PrintTime, DL.Amt, 
                Sac.PriceFrei AS PriceFreiCont, 0 AS AmtFrei, 0 AS AmtFrei1, DL.Amt AS AmtAndFrei, Allo.PriceFrei, 
                (CASE WHEN dl.BilID = 'STF' THEN '' ELSE Allo.ToCust END) 
                AS ToCust , 
                SacDtl.MatID, SacDtl.Qty AS QtyCont, Sac.BilNo AS ContBilNo, Allo.CreateTime, SacDtl.StockID, Sac.ContPayTypeID, 
                DL.QtyPack, (CASE WHEN HDL.BilIDFrom = 'SPCF' OR
                H.BilIDFrom = 'SPCF1' THEN '发货变更' WHEN D .BilIDFrom = 'DEAA' THEN '汽车配运' WHEN D .BilIDFrom = 'DESD' THEN
                 '短倒配运' END) AS Rem, ISNull(SacDtl.Qty, 0) -ISNull(SacDtl.QtyTo, 0) + ISNull(SacDtl.QtyRetu, 0) AS QtyStaCont,
               Sac.CustID, Sac.DeliWayID, Sac.TransportID, Sac.StfID, DP.StockIDTo, TS.Consignee, TS.TSCode, d.QtyMeshBag, 
                Sac.AreaID, CASE WHEN m.Name LIKE '%豆粕%' AND
                sac.BilNo NOT LIKE '%YDK%' THEN DL.price + isnull(PPDU.PriceDif, 0) ELSE NULL END AS Price43, 
                SacDtl.PriceTranTypeID, '标准价' IsStaStatus, HDl.BilNo AS DelBilNo, Saos.QtyCheck1, Saos.QtyCheck2, 
                Saos.QtyCheck3, Saos.QtyCheck4, Saos.QtyCheck5, Saos.QtyCheck6, Saos.QtyCheck7, Saos.QtyCheck8, 
                Saos.QtyCheck9, Saos.QtyCheck10, Saos.QtyCheck11, Saos.QtyCheck12, Saos.QtyCheck13, Saos.QtyCheck14, 
                Saos.QtyCheck15, Saos.ID AS SaosID, 
                CASE WHEN saos.IsPass = 1 THEN '合格' WHEN Saos.IsPass = 0 THEN '不合格' ELSE '' END AS IsPass, 
                dela.ArriveTime, dela.DriveLice AS ArrDriveLice, dela.Driver AS ArrDriver, dela.DriverOut AS ArrDriverOut, 
                dela.Tel AS ArrTel, DL.Price, (ISNULL(DL.Qty, 0) * ISNULL(DL.Price, 0)) AmtAcc, (ISNULL(DL.Qty, 0) * ISNULL(DL.Price, 0))
                + ISNULL(ISNULL(Sac.PriceFrei, 0) * ISNULL(DL.Qty, 0), 0) AS AmtAcc1, sac.DealerID, HDTF.AmtFrei1 AS AmtFreiT1, 
                HDTF.AmtFrei AS AmtFreiT, ISNULL(HDTF.AmtFrei, 0) - ISNULL(HDTF.AmtFrei1, 0) AS AmtFr, HDTF.ID AS HDTFID, 
                HDTF.BilNo AS HDTFBilNo, 
                CASE WHEN m.Name LIKE '%油%' THEN '18个月' WHEN m.Name LIKE '%豆粕%' THEN '6个月' ELSE '' END AS CheckDate
FROM      DelReachDtl D WITH(nolock) LEFT JOIN
                DelReach H WITH(nolock) ON D .ID = H.ID LEFT JOIN
                   (SELECT ID, BilID, IDFrom, BilIDFrom, ItemFrom, SUM(Qty) AS QtyRER, Cost AS Price, Cost AS PriceAcc,
                                     0 IsStaStatus, sum(Qty) AS Qty, 0 AS QtyKP, 0 AS QtyLot, SUM(QtyPack) AS QtyPack, SUM(AmtCost) 
                                     AS Amt
                     FROM StcStockShiftDtl WITH(nolock)
                     GROUP BY ID, BilID, IDFrom, BilIDFrom, ItemFrom, Cost) DL ON D.ID = DL.IDFrom AND D .Item = DL.ItemFrom AND
                D.BilID = DL.BilIDFrom LEFT JOIN
                StcStockShift HDL WITH(nolock) ON HDL.ID = DL.ID LEFT JOIN
                SacOutSupervise Saos WITH(nolock) ON Saos.IDFrom = D.ID AND Saos.BilIDFrom = D.BilID AND
                Saos.ItemFrom = D.Item AND Saos.SuperviseID IS NULL LEFT JOIN
               DelArrive dela ON Saos.ArriveID = dela.ID LEFT JOIN
                SacContractDtl SacDtl WITH(nolock) ON D .ContID = SacDtl.ID AND D .ContBilID = SacDtl.BilID AND
                D.ContItem = SacDtl.Item LEFT JOIN
                SacContract Sac WITH(nolock) ON SacDtl.ID = Sac.ID LEFT JOIN
                PubMaterial M WITH(nolock) ON D .MatID = M.ID LEFT JOIN
                PubPriceDifUpdate PPDU WITH(nolock) ON PPDU.CorpID = SacDtl.CorpID AND PPDU.MatTypeID = M.MatTypeID LEFT
                JOIN
                    (SELECT   Allo.BilID, Allo.ID, Allo.Item, Allo.DeliDate, Allo.Qty, Allo.PriceFrei, Allo.ToCust, HAllo.CreateTime
                     FROM      DelAlloAutoDtl Allo WITH(nolock) LEFT JOIN
                                     DelAlloAuto HAllo WITH(nolock) ON Allo.ID = HAllo.ID
                     WHERE   HAllo.Status IN(3, 4, 5)
                     UNION ALL
                     SELECT   Allo.BilID, Allo.ID, Allo.Item, Allo.DeliDate, Allo.Qty, Allo.PriceFrei, Allo.ToCust, HAllo.CreateTime
                     FROM      DelShoDeliDtl Allo WITH(nolock) LEFT JOIN
                                     DelShoDeli HAllo WITH(nolock) ON Allo.ID = HAllo.ID
                     WHERE   HAllo.Status IN(3, 4, 5)) Allo ON D.BilIDFrom = Allo.BilID AND D .IDFrom = Allo.ID AND
                D.ItemFrom = Allo.Item LEFT JOIN
                DelPlanDtl DP WITH(nolock) ON D .PlanID = Dp.ID AND D .PlanBilID = Dp.BilID AND D .PlanItem = Dp.Item LEFT JOIN
                   (SELECT B.ID, B.Item, B.BilID, H.Consignee, B.TrainCode AS TSCode, B.DepotFrom, B.DepotTo
                    FROM      DelAlloTrainDtl B WITH (nolock) LEFT JOIN
                                    DelAlloTrain H WITH (nolock) ON H.ID = B.ID

                    UNION ALL

                    SELECT B.ID, B.Item, B.BilID, H.Consignee, B.ShipCode AS TSCode, B.DepotFrom, B.DepotTo
                    FROM      DelAlloShipDtl B WITH (nolock) LEFT JOIN
                                    DelAlloShip H WITH (nolock) ON H.ID = B.ID) TS ON D.AlloID = TS.ID AND D .AlloBilID = TS.BilID AND
                D.AlloItem = TS.Item LEFT JOIN
                DelTrainFreiDtl DTF ON DTF.IDFrom = D.ID AND Dtf.ItemFrom = D.Item LEFT JOIN
                DelTrainFrei HDTF ON HDTF.ID = DTF.ID
WHERE D .OBBilID = 'BOHI16' AND(HDl.Status IN(3, 4) OR

              HDl.Status IS NULL)
UNION ALL
SELECT   0 AS AlloTrainID, AutoStatus = (CASE WHEN isnull(saos.QtyGross, 0) -isnull(saos.QtyTare, 0)
                > 0 THEN 1 WHEN ISNull(Saos.QtyTare, 0) > 0 AND ISNull(Saos.QtyGross, 0) <= 0 THEN 2 WHEN(ISNULL(Saos.QtyTare,
                0) = 0 AND ISNULL(Saos.QtyGross, 0) = 0) THEN 3 END), H.CorpID, H.DepID, H.BilDate, H.BilNo, D.ID, D.BilID, D.Item, 
                '' Driver, '' DriveLice, Saos.AutoCode, '' Tel, Saos.GrossTime, h.CheckTime, Saos.QtyTare, Saos.QtyGross, 
                -(isnull(saos.QtyGross, 0) - isnull(saos.QtyTare, 0)) QtyNet, CASE WHEN isnull(d.QtyKP, 0) > 0 AND isnull(saos.QtyTare,
                0) > 0 THEN(isnull(saos.QtyGross, 0) - isnull(saos.QtyTare, 0)) - isnull(d.QtyKP, 0) ELSE 0 END AS QtyKP, 0 AS QtyLot,
              CASE WHEN d .delidate IS NULL THEN h.checktime ELSE d.DeliDate END AS delidate, D .Qty * -1, d.price, 
                D.Qtyapp * -1 AS qtyrer, '' DepotFrom, '' DepotTo, H.PrintTime, d.Amt * -1, Sac.PriceFrei AS PriceFreiCont, 
                -(ISNULL(ISNULL(Sac.PriceFrei, 0) * ISNULL(d.QtyRER, 0), 0)) AS AmtFrei, -(ISNULL(ISNULL(sac.PriceFrei, 0)
              * ISNULL(D.Qty, 0), 0)) AS AmtFrei1, -((ISNULL(D.QtyRER, 0) * ISNULL(D.Price, 0)) + ISNULL(ISNULL(Sac.PriceFrei, 0)
             * ISNULL(D.QtyRER, 0), 0)) AS AmtAndFrei, sac.PriceFrei, '' ToCust, SacDtl.MatID, SacDtl.Qty AS QtyCont, 
                Sac.BilNo AS ContBilNo, h.CreateTime, SacDtl.StockID, Sac.ContPayTypeID, d.QtyPack, '销售退货' AS Rem,
               ISNull(SacDtl.Qty, 0) -ISNull(SacDtl.QtyTo, 0) + ISNull(SacDtl.QtyRetu, 0) AS QtyStaCont, Sac.CustID, Sac.DeliWayID, 
                Sac.TransportID, Sac.StfID AS ContStfID, 
                dpd.StockIDTo AS StockIDTo/*调用运输计划里面的“收货仓库名称”（库存调拨单类型的销售退货单显示“收货仓库名称”问题）*/ ,
                 '' Consignee, '' TSCode, 0 QtyMeshBag, Sac.AreaID, CASE WHEN m.Name LIKE '%豆粕%' AND
                sac.BilNo NOT LIKE '%YDK%' THEN(CASE WHEN d.priceapp IS NOT NULL THEN SacDtl.priceapp ELSE d.Price END)
                + isnull(PPDU.PriceDif, 0) ELSE NULL END AS Price43, SacDtl.PriceTranTypeID, CASE WHEN h.qtyapp IS NOT NULL AND
                 sacdtl.pricetrantypeid = 1 THEN '已结价' WHEN h.qtyapp IS NOT NULL AND
                sacdtl.pricetrantypeid = 2 THEN '未结价' ELSE '标准价' END AS IsStaStatus, D.BilNo AS DelBilNo, Saos.QtyCheck1, 
                Saos.QtyCheck2, Saos.QtyCheck3, Saos.QtyCheck4, Saos.QtyCheck5, Saos.QtyCheck6, Saos.QtyCheck7, 
                Saos.QtyCheck8, Saos.QtyCheck9, Saos.QtyCheck10, Saos.QtyCheck11, Saos.QtyCheck12, Saos.QtyCheck13, 
                Saos.QtyCheck14, Saos.QtyCheck15, Saos.ID AS SaosID, 
                CASE WHEN saos.IsPass = 1 THEN '合格' WHEN Saos.IsPass = 0 THEN '不合格' ELSE '' END AS IsPass, 
                dela.ArriveTime, dela.DriveLice AS ArrDriveLice, dela.Driver AS ArrDriver, dela.DriverOut AS ArrDriverOut, 
                dela.Tel AS ArrTel, CASE WHEN d.priceapp IS NOT NULL THEN SacDtl.priceapp ELSE d.Price END AS Priceacc,
                (ISNULL(D.QtyRER, 0) * ISNULL(CASE WHEN d.priceapp IS NOT NULL

              THEN SacDtl.priceapp * -1 ELSE d.Price * -1 END, 0)) AS AmtAcc, (ISNULL(D.QtyRER, 0)
           * ISNULL(CASE WHEN d.priceapp IS NOT NULL THEN SacDtl.priceapp * -1 ELSE d.Price * -1 END, 0)) 
                +ISNULL(ISNULL(Sac.PriceFrei, 0) * ISNULL(D.QtyRER * -1, 0), 0) AS AmtAcc1, sac.DealerID, 0, 0, 0, 0, '', 
                CASE WHEN m.Name LIKE '%油%' THEN '18个月' WHEN m.Name LIKE '%豆粕%' THEN '6个月' ELSE '' END AS CheckDate
FROM      SalReturnDtl D WITH(nolock) LEFT JOIN
                SalReturn H WITH(nolock) ON D .ID = H.ID LEFT JOIN
                SacOutSupervise Saos WITH(nolock) ON Saos.IDFrom = D.ID AND Saos.BilIDFrom = D.BilID AND
                Saos.ItemFrom = D.Item LEFT JOIN
                DelArrive dela ON Saos.ArriveID = dela.ID LEFT JOIN
                SacContractDtl SacDtl WITH(nolock) ON D .OBID = SacDtl.ID AND D .OBBilID = SacDtl.BilID AND
                D.OBItem = SacDtl.Item LEFT JOIN
                SacContract Sac WITH(nolock) ON SacDtl.ID = Sac.ID LEFT JOIN
                PubMaterial M WITH(nolock) ON D .MatID = M.ID LEFT JOIN
                PubPriceDifUpdate PPDU WITH(nolock) ON PPDU.CorpID = SacDtl.CorpID AND PPDU.MatTypeID = M.MatTypeID LEFT
               JOIN
                DelPlanDtl dpd ON d .IDFrom = dpd.IDFrom AND
                dpd.bilidfrom = 'BOHI16'
/*连接库存调拨单类型的销售退货单的运输计划（库存调拨单类型的销售退货单显示“收货仓库名称”问题）*/ WHERE(H.IsBussAuto
                 = 0 OR
                H.IsBussAuto IS NULL) AND(D.BilIDFrom = 'SABS' OR
                D.BilIDFrom = 'BOHI16')
UNION ALL
SELECT TS .ID AS AlloTrainID, AutoStatus = (CASE WHEN isnull(saos.QtyGross, 0) -isnull(saos.QtyTare, 0)
              > 0 THEN 1 WHEN ISNull(Saos.QtyTare, 0) > 0 AND ISNull(Saos.QtyGross, 0) <= 0 THEN 2 WHEN(ISNULL(Saos.QtyTare,
              0) = 0 AND ISNULL(Saos.QtyGross, 0) = 0) THEN 3 END), H.CorpID, H.DepID, H.BilDate, H.BilNo, D.ID, D.BilID, D.Item, 
                dr.Driver, dr.DriveLice, Saos.AutoCode, dr.Tel, Saos.GrossTime, srt.CheckTime, Saos.QtyTare, Saos.QtyGross, 
                -(isnull(saos.QtyGross, 0) - isnull(saos.QtyTare, 0)) QtyNet, CASE WHEN isnull(sar.QtyKP, 0) > 0 AND
                isnull(saos.QtyTare, 0) > 0 THEN(isnull(saos.QtyGross, 0) - isnull(saos.QtyTare, 0)) - isnull(sar.QtyKP, 0)
                ELSE 0 END AS QtyKP, 0 AS QtyLot, dr.DeliDate, D.Qty * -1 AS Qty, sar.price, sar.Qtyapp * -1 AS QtyRER,
             dr.DepotFrom, dr.DepotTo, H.PrintTime, sar.qtyapp* sar.price * -1, Sac.PriceFrei AS PriceFreiCont, 
                -(ISNULL(ISNULL(Sac.PriceFrei, 0) * ISNULL(sar.Qtyapp, 0), 0)) AS AmtFrei, -(ISNULL(ISNULL(ts.PriceFrei, 0)
               * ISNULL(sar.Qtyapp, 0), 0)) AS AmtFrei1, -((ISNULL(sar.Qtyapp, 0) * ISNULL(sar.price, 0))
               + ISNULL(ISNULL(Sac.PriceFrei, 0) * ISNULL(sar.Qtyapp, 0), 0)) AS AmtAndFrei, sac.PriceFrei, dr.ToCust, SacDtl.MatID, 
                SacDtl.Qty AS QtyCont, Sac.BilNo AS ContBilNo, h.CreateTime, SacDtl.StockID, Sac.ContPayTypeID, -dl.QtyPack, 
                '短倒退货' AS Rem, ISNull(SacDtl.Qty, 0) -ISNull(SacDtl.QtyTo, 0) + ISNull(SacDtl.QtyRetu, 0) AS QtyStaCont, Sac.CustID, 
                Sac.DeliWayID, Sac.TransportID, Sac.StfID AS ContStfID, DP.StockIDTo, ts.Consignee, ts.TSCode, 0 QtyMeshBag, 
                Sac.AreaID, CASE WHEN m.Name LIKE '%豆粕%' AND
                sac.BilNo NOT LIKE '%YDK%' THEN sar.price + isnull(PPDU.PriceDif, 0) ELSE NULL END AS Price43, 
                SacDtl.PriceTranTypeID, CASE WHEN sac.pricetrantypeid = 2 AND
                sacdtl.pricetrantypeid = 1 THEN '已结价' WHEN D .qtyapp IS NOT NULL AND
                sacdtl.pricetrantypeid = 2 THEN '未结价' ELSE '标准价' END AS IsStaStatus, Dl.BilNo AS DelBilNo, Saos.QtyCheck1, 
                Saos.QtyCheck2, Saos.QtyCheck3, Saos.QtyCheck4, Saos.QtyCheck5, Saos.QtyCheck6, Saos.QtyCheck7, 
                Saos.QtyCheck8, Saos.QtyCheck9, Saos.QtyCheck10, Saos.QtyCheck11, Saos.QtyCheck12, Saos.QtyCheck13, 
                Saos.QtyCheck14, Saos.QtyCheck15, Saos.ID AS SaosID, 
                CASE WHEN saos.IsPass = 1 THEN '合格' WHEN Saos.IsPass = 0 THEN '不合格' ELSE '' END AS IsPass, 
                dela.ArriveTime, dela.DriveLice AS ArrDriveLice, dela.Driver AS ArrDriver, dela.DriverOut AS ArrDriverOut, 
                dela.Tel AS ArrTel, /*sar.price as PriceAcc,*/ CASE WHEN sac.pricetrantypeid = 2 AND
                sacdtl.pricetrantypeid = 1 THEN dld.PriceAcc ELSE sar.Price END AS PriceAcc, (ISNULL(sar.Qtyapp * -1, 0)
                * ISNULL(sar.price, 0)) AS AmtAcc, (ISNULL(sar.Qtyapp * -1, 0) * ISNULL(sar.price, 0)) +ISNULL(ISNULL(Sac.PriceFrei, 0)
               * ISNULL(sar.Qtyapp * -1, 0), 0) AS AmtAcc1, sac.DealerID, 0, 0, 0, 0, '', 
                CASE WHEN m.Name LIKE '%油%' THEN '18个月' WHEN m.Name LIKE '%豆粕%' THEN '6个月' ELSE '' END AS CheckDate
FROM      DelShoReturnDtl D WITH(nolock) LEFT JOIN
                DelShoReturn H WITH(nolock) ON D .ID = H.ID LEFT JOIN
                DelDeliReturnDtl DL WITH(nolock) ON D .ID = DL.IDFrom AND D .Item = DL.ItemFrom AND D .BilID = DL.BilIDFrom LEFT
               JOIN
                SacOutSupervise Saos WITH(nolock) ON Saos.IDFrom = D.ID AND Saos.BilIDFrom = D.BilID AND
                Saos.ItemFrom = D.Item LEFT JOIN
                salreturndtl sar WITH(nolock) ON sar.IDFrom = dl.id AND sar.ItemFrom = dl.item AND sar.BilIDFrom = dl.bilid LEFT JOIN
                SalReturn srt ON srt.ID = sar.ID LEFT JOIN
                DelArrive dela ON Saos.ArriveID = dela.ID LEFT JOIN
                DelReachDtl Dr WITH(nolock) ON D .IDFrom = dr.ID AND D .BilIDFrom = dr.BilID AND D .ItemFrom = dr.Item LEFT JOIN
                DelPlanDtl DP WITH(nolock) ON Dr.PlanID = Dp.ID AND Dr.PlanBilID = Dp.BilID AND Dr.PlanItem = Dp.Item LEFT JOIN
                SacContractDtl SacDtl WITH(nolock) ON D .OBID = SacDtl.ID AND D .OBBilID = SacDtl.BilID AND
                D.OBItem = SacDtl.Item LEFT JOIN
                SacContract Sac WITH(nolock) ON SacDtl.ID = Sac.ID LEFT JOIN
                   (SELECT B.ID, B.Item, B.BilID, H.Consignee, B.TrainCode AS TSCode, B.DepotFrom, B.DepotTo, b.pricefrei
                    FROM      DelAlloTrainDtl B WITH (nolock) LEFT JOIN
                                    DelAlloTrain H WITH (nolock) ON H.ID = B.ID

                    UNION ALL

                    SELECT B.ID, B.Item, B.BilID, H.Consignee, B.ShipCode AS TSCode, B.DepotFrom, B.DepotTo, b.pricefrei
                    FROM      DelAlloShipDtl B WITH (nolock) LEFT JOIN
                                    DelAlloShip H WITH (nolock) ON H.ID = B.ID) TS ON Dr.AlloID = TS.ID AND Dr.AlloBilID = TS.BilID AND
                Dr.AlloItem = TS.Item LEFT JOIN
                PubMaterial M WITH(nolock) ON D .MatID = M.ID LEFT JOIN
                PubPriceDifUpdate PPDU WITH(nolock) ON PPDU.CorpID = SacDtl.CorpID AND PPDU.MatTypeID = M.MatTypeID LEFT
               JOIN
                DelLeaveDtl dld ON dld.IDFrom = dr.ID
WHERE(H.IsRetu = 1 OR
                H.IsRetu IS NOT NULL)
/*2015.3.20 更改结价金额，变为负 2015.6.3 所有金额取退货单记账数量计算 */ UNION ALL
SELECT TS .ID AS AlloTrainID, AutoStatus = (CASE WHEN isnull(saos.QtyGross, 0) -isnull(saos.QtyTare, 0)
              > 0 THEN 1 WHEN ISNull(Saos.QtyTare, 0) > 0 AND ISNull(Saos.QtyGross, 0) <= 0 THEN 2 WHEN(ISNULL(Saos.QtyTare,
              0) = 0 AND ISNULL(Saos.QtyGross, 0) = 0) THEN 3 END), H.CorpID, H.DepID, H.BilDate, H.BilNo, D.ID, D.BilID, D.Item, 
                dr.Driver, dr.DriveLice, d.AutoCode, dr.Tel, H.CreateTime, H.CreateTime, 0 AS QtyTare, d .Qty, -d.Qty AS QtyNet,
             CASE WHEN isnull(sar.QtyKP, 0) > 0 AND isnull(saos.QtyTare, 0) > 0 THEN(isnull(saos.QtyGross, 0)
             - isnull(saos.QtyTare, 0)) - isnull(sar.QtyKP, 0) ELSE 0 END AS QtyKP, 0 AS QtyLot, dr.DeliDate, D.Qty * -1 AS Qty,
           D .Price, sar.Qtyapp * -1 AS QtyRER, dr.DepotFrom, dr.DepotTo, H.PrintTime, d.Amt * -1, 
                Sac.PriceFrei AS PriceFreiCont, -(ISNULL(ISNULL(Sac.PriceFrei, 0) * ISNULL(DL.QtyRER, 0), 0)) AS AmtFrei,
                -(ISNULL(ISNULL(sac.PriceFrei, 0) * ISNULL(DL.Qty, 0), 0)) AS AmtFrei1, -((ISNULL(DL.QtyRER, 0) * ISNULL(D.Price, 0))
               + ISNULL(ISNULL(Sac.PriceFrei, 0) * ISNULL(DL.QtyRER, 0), 0)) AS AmtAndFrei, sac.PriceFrei, dr.ToCust, SacDtl.MatID, 
                SacDtl.Qty AS QtyCont, Sac.BilNo AS ContBilNo, h.CreateTime, SacDtl.StockID, Sac.ContPayTypeID, -dl.QtyPack, 
                '短倒退货退司机' AS Rem, ISNull(SacDtl.Qty, 0) -ISNull(SacDtl.QtyTo, 0) + ISNull(SacDtl.QtyRetu, 0) AS QtyStaCont,
               Sac.CustID, Sac.DeliWayID, Sac.TransportID, Sac.StfID AS ContStfID, DP.StockIDTo, ts.Consignee, ts.TSCode, 
                0 QtyMeshBag, Sac.AreaID, CASE WHEN m.Name LIKE '%豆粕%' AND
                sac.BilNo NOT LIKE '%YDK%' THEN D .Price ELSE NULL END AS Price43, SacDtl.PriceTranTypeID, '标准价' IsStaStatus, 
                Dl.BilNo AS DelBilNo, Saos.QtyCheck1, Saos.QtyCheck2, Saos.QtyCheck3, Saos.QtyCheck4, Saos.QtyCheck5, 
                Saos.QtyCheck6, Saos.QtyCheck7, Saos.QtyCheck8, Saos.QtyCheck9, Saos.QtyCheck10, Saos.QtyCheck11, 
                Saos.QtyCheck12, Saos.QtyCheck13, Saos.QtyCheck14, Saos.QtyCheck15, Saos.ID AS SaosID, 
                CASE WHEN saos.IsPass = 1 THEN '合格' WHEN Saos.IsPass = 0 THEN '不合格' ELSE '' END AS IsPass, 
                dela.ArriveTime, dela.DriveLice AS ArrDriveLice, dela.Driver AS ArrDriver, dela.DriverOut AS ArrDriverOut, 
                dela.Tel AS ArrTel, D.Price, (ISNULL(DL.QtyRER, 0) * ISNULL(D.Price, 0)) AS AmtAcc, (ISNULL(DL.QtyRER, 0)
              * ISNULL(D.Price, 0)) +ISNULL(ISNULL(Sac.PriceFrei, 0) * ISNULL(DL.QtyRER, 0), 0) AS AmtAcc1, sac.DealerID, 0, 0, 0, 
                0, '', 
                CASE WHEN m.Name LIKE '%油%' THEN '18个月' WHEN m.Name LIKE '%豆粕%' THEN '6个月' ELSE '' END AS CheckDate
FROM      DelShoReturnDtl D WITH(nolock) LEFT JOIN
                DelShoReturn H WITH(nolock) ON D .ID = H.ID LEFT JOIN
                DelDeliReturnDtl DL WITH(nolock) ON D .ID = DL.IDFrom AND D .Item = DL.ItemFrom AND D .BilID = DL.BilIDFrom LEFT
               JOIN
                SacOutSupervise Saos WITH(nolock) ON Saos.IDFrom = D.ID AND Saos.BilIDFrom = D.BilID AND
                Saos.ItemFrom = D.Item LEFT JOIN
                salreturndtl sar WITH(nolock) ON sar.IDFrom = dl.id AND sar.ItemFrom = dl.item AND sar.BilIDFrom = dl.bilid LEFT JOIN
                DelArrive dela ON Saos.ArriveID = dela.ID LEFT JOIN
                DelReachDtl Dr WITH(nolock) ON D .IDFrom = dr.ID AND D .BilIDFrom = dr.BilID AND D .ItemFrom = dr.Item LEFT JOIN
                DelPlanDtl DP WITH(nolock) ON Dr.PlanID = Dp.ID AND Dr.PlanBilID = Dp.BilID AND Dr.PlanItem = Dp.Item LEFT JOIN
                SacContractDtl SacDtl WITH(nolock) ON D .OBID = SacDtl.ID AND D .OBBilID = SacDtl.BilID AND
                D.OBItem = SacDtl.Item LEFT JOIN
                SacContract Sac WITH(nolock) ON SacDtl.ID = Sac.ID LEFT JOIN
                   (SELECT B.ID, B.Item, B.BilID, H.Consignee, B.TrainCode AS TSCode, B.DepotFrom, B.DepotTo
                    FROM      DelAlloTrainDtl B WITH (nolock) LEFT JOIN
                                    DelAlloTrain H WITH (nolock) ON H.ID = B.ID

                    UNION ALL

                    SELECT B.ID, B.Item, B.BilID, H.Consignee, B.ShipCode AS TSCode, B.DepotFrom, B.DepotTo
                    FROM      DelAlloShipDtl B WITH (nolock) LEFT JOIN
                                    DelAlloShip H WITH (nolock) ON H.ID = B.ID) TS ON Dr.AlloID = TS.ID AND Dr.AlloBilID = TS.BilID AND
                Dr.AlloItem = TS.Item LEFT JOIN
                PubMaterial M WITH(nolock) ON D .MatID = M.ID LEFT JOIN
                PubPriceDifUpdate PPDU WITH(nolock) ON PPDU.CorpID = SacDtl.CorpID AND PPDU.MatTypeID = M.MatTypeID
WHERE(H.IsRetu = 0 OR
                H.IsRetu IS NULL)
UNION ALL
/*20150423改变更到站收货人*/ SELECT TS .ID AS AlloTrainID, AutoStatus = 1, H.CorpID, H.DepID, H.BilDate, H.BilNo, D.ID, 
                D.BilID, D.Item, D.Driver, D.DriveLice, D.AutoCode, D.Tel, Saos.TareTime, DL.CreateTime AS GrossTime, D.QtyTare, 
                D.QtyGross, D.QtyNet, DL.QtyKP, DL.QtyLot, Allo.DeliDate, D.Qty, DL.Price AS Price, DL.QtyRER, TS.DepotFrom, 
                TS.DepotTo, H.PrintTime, (ISNULL(DL.QtyRER, 0) * ISNULL(DL.Price, 0)) AS Amt, Sac.PriceFrei AS PriceFreiCont, 
                ISNULL(ISNULL(Sac.PriceFrei, 0) * ISNULL(DL.QtyRER, 0), 0) AS AmtFrei, ISNULL(ISNULL(Allo.PriceFrei, 0)
                * ISNULL(DL.Qty, 0), 0) AS AmtFrei1, (ISNULL(DL.QtyRER, 0) * ISNULL(DL.Price, 0)) +ISNULL(ISNULL(Sac.PriceFrei, 0)
                * ISNULL(DL.QtyRER, 0), 0) AS AmtAndFrei, Allo.PriceFrei, Allo.ToCust, SacDtl.MatID, SacDtl.Qty AS QtyCont, 
                Sac.BilNo AS ContBilNo, Allo.CreateTime, SacDtl.StockID, Sac.ContPayTypeID, DL.QtyPack, '发货变更(原单)' AS Rem,
                ISNull(SacDtl.Qty, 0) -ISNull(SacDtl.QtyTo, 0) + ISNull(SacDtl.QtyRetu, 0) AS QtyStaCont, Sac.CustID, Sac.DeliWayID, 
                Sac.TransportID, Sac.StfID, dl.StockID AS StockIDTo/*添加“收货仓库名称”的显示--by cjy*/ , TS.Consignee, 
                TS.TSCode, d.QtyMeshBag, Sac.AreaID, CASE WHEN m.Name LIKE '%豆粕%' AND
                sac.BilNo NOT LIKE '%YDK%' THEN(CASE WHEN dl.IsStaStatus = 1 THEN DL.PriceAcc ELSE dl.Price END)
                + isnull(PPDU.PriceDif, 0) ELSE NULL END AS Price43, SacDtl.PriceTranTypeID, 
                /*'标准价' AS IsStaStatus, */ CASE WHEN sac.pricetrantypeid = 2 AND
                sacdtl.pricetrantypeid = 1 THEN '已结价' WHEN D .qtyapp IS NOT NULL AND
                sacdtl.pricetrantypeid = 2 THEN '未结价' ELSE '标准价' END AS IsStaStatus, 
                /*解决“是否结价”始终显示为“标准价”问题;By-cjy-2017.07.17*/ Dl.BilNo AS DelBilNo, Saos.QtyCheck1, 
                Saos.QtyCheck2, Saos.QtyCheck3, Saos.QtyCheck4, Saos.QtyCheck5, Saos.QtyCheck6, Saos.QtyCheck7, 
                Saos.QtyCheck8, Saos.QtyCheck9, Saos.QtyCheck10, Saos.QtyCheck11, Saos.QtyCheck12, Saos.QtyCheck13, 
                Saos.QtyCheck14, Saos.QtyCheck15, Saos.ID AS SaosID, 
                CASE WHEN saos.IsPass = 1 THEN '合格' WHEN Saos.IsPass = 0 THEN '不合格' ELSE '' END AS IsPass, 
                dela.ArriveTime, dela.DriveLice AS ArrDriveLice, dela.Driver AS ArrDriver, dela.DriverOut AS ArrDriverOut, 
                dela.Tel AS ArrTel, CASE WHEN dl.IsStaStatus = 1 THEN DL.PriceAcc ELSE dl.Price END AS priceacc,
                CASE WHEN dl.IsStaStatus = 1 THEN(ISNULL(DL.QtyRER, 0) * ISNULL(DL.PriceAcc, 0)) ELSE(ISNULL(DL.QtyRER, 0)
               * ISNULL(DL.Price, 0)) END AS AmtAcc, CASE WHEN dl.IsStaStatus = 1 THEN(ISNULL(DL.QtyRER, 0)
               * ISNULL(DL.PriceAcc, 0)) + ISNULL(ISNULL(Sac.PriceFrei, 0) * ISNULL(DL.QtyRER, 0), 0) ELSE(ISNULL(DL.QtyRER, 0)
               * ISNULL(DL.Price, 0)) + ISNULL(ISNULL(Sac.PriceFrei, 0) * ISNULL(DL.QtyRER, 0), 0) END AS AmtAcc1, sac.DealerID, 0, 
                0, 0, 0, '', 
                CASE WHEN m.Name LIKE '%油%' THEN '18个月' WHEN m.Name LIKE '%豆粕%' THEN '6个月' ELSE '' END AS CheckDate
FROM      DelReachDtl D WITH(nolock) LEFT JOIN
                DelReach H WITH(nolock) ON D .ID = H.ID LEFT JOIN
                   (SELECT B.ID, B.BilID, B.IDFrom, B.ItemFrom, B.BilIDFrom, B.BilNo, sum(B.Qty) AS Qty, B.price, sum(B.Amt) AS Amt,
                                    B.MatID, sum(B.QtyRER) AS QtyRER, sum(B.QtyPack) AS QtyPack, sum(B.QtyKP) AS QtyKP, sum(B.QtyLot)
                                    AS QtyLot, h.DepID, B.StockID, h.Status, H.CreateTime, B.ContID, B.ContItem, B.ContBilID, B.PriceAcc,
                                    B.IsStaStatus
                    FROM      DelLeaveDtl B WITH (NOLOCK) LEFT JOIN
                                    DelLeave H WITH (NOLOCK) ON b.ID = h.ID

                    GROUP BY B.ID, B.BilID, B.IDFrom, B.ItemFrom, B.BilIDFrom, B.BilNo, B.price, B.MatID, h.DepID, B.StockID,
                                    h.Status, H.CreateTime, B.ContID, B.ContItem, B.ContBilID, B.PriceAcc, B.IsStaStatus
                    UNION ALL
                    SELECT   B.ID, B.BilID, B.IDFrom, B.ItemFrom, B.BilIDFrom, B.BilNo, sum(B.Qty) AS Qty, B.Cost AS Price,
                                    sum(B.AmtCost) AS Amt, B.MatID, sum(B.Qty) AS QtyRER, sum(B.QtyPack) AS QtyPack, 0 QtyKP, 0 QtyLot, 
                                     h.DepID, B.InStockID, h.Status, H.CreateTime, B.OBID, B.OBItem, B.OBBilID, B.Cost, 0
                     FROM StcStockShiftDtl B WITH(NOLOCK) LEFT JOIN
                                     StcStockShift H WITH(NOLOCK) ON b.ID = h.ID
                     GROUP BY B.ID, B.BilID, B.IDFrom, B.ItemFrom, B.BilIDFrom, B.BilNo, B.Cost, B.MatID, h.DepID, B.InStockID, 
                                     h.Status, H.CreateTime, B.OBID, B.OBItem, B.OBBilID) DL ON D.ID = DL.IDFrom AND
                D.Item = DL.ItemFrom AND D .BilID = DL.BilIDFrom LEFT JOIN
                delleavealterdtl dlad ON dlad.idfrom = dl.id /*and dlad.itemfrom=dl.itemfrom */ LEFT JOIN
                delleavealter dla ON dlad.id = dla.id LEFT JOIN
                /*引入发货变更表头（解决车辆发货明细重复记录问题）*/ SacOutSupervise Saos WITH(nolock) ON
                Saos.IDFrom = D.ID AND Saos.BilIDFrom = D.BilID AND Saos.ItemFrom = D.Item AND Saos.SuperviseID IS NULL LEFT
                JOIN
                DelArrive dela ON Saos.ArriveID = dela.ID LEFT JOIN
                SacContractDtl SacDtl WITH(nolock) ON DL.ContID = SacDtl.ID AND DL.ContBilID = SacDtl.BilID AND
                DL.ContItem = SacDtl.Item LEFT JOIN
                SacContract Sac WITH(nolock) ON SacDtl.ID = Sac.ID LEFT JOIN
                PubMaterial M WITH(nolock) ON D .MatID = M.ID LEFT JOIN
                PubPriceDifUpdate PPDU WITH(nolock) ON PPDU.CorpID = SacDtl.CorpID AND PPDU.MatTypeID = M.MatTypeID LEFT
                JOIN
                    (SELECT   Allo.BilID, Allo.ID, Allo.Item, Allo.DeliDate, Allo.Qty, Allo.PriceFrei, Allo.ToCust, HAllo.CreateTime
                     FROM      DelAlloAutoDtl Allo LEFT JOIN
                                     DelAlloAuto HAllo ON Allo.ID = HAllo.ID
                     WHERE   HAllo.Status IN(4, 5)
                     UNION ALL
                     SELECT   Allo.BilID, Allo.ID, Allo.Item, Allo.DeliDate, Allo.Qty, Allo.PriceFrei, Allo.ToCust, HAllo.CreateTime
                     FROM      DelAlloCustDtl Allo WITH(nolock) LEFT JOIN
                                     DelAlloCust HAllo WITH(nolock) ON Allo.ID = HAllo.ID
                     WHERE   HAllo.Status IN(4, 5)
                     UNION ALL
                     SELECT   Allo.BilID, Allo.ID, Allo.Item, Allo.DeliDate, Allo.Qty, Allo.PriceFrei, Allo.ToCust, HAllo.CreateTime
                     FROM      DelShoDeliDtl Allo WITH(nolock) LEFT JOIN
                                     DelShoDeli HAllo WITH(nolock) ON Allo.ID = HAllo.ID
                     WHERE   HAllo.Status IN(4, 5)) Allo ON D.BilIDFrom = Allo.BilID AND D .IDFrom = Allo.ID AND
                D.ItemFrom = Allo.Item LEFT JOIN
                   (SELECT B.ID, B.Item, B.BilID, H.Consignee, B.TrainCode AS TSCode, B.DepotFrom, B.DepotTo
                    FROM      DelAlloTrainDtl B WITH (nolock) LEFT JOIN
                                    DelAlloTrain H WITH (nolock) ON H.ID = B.ID

                    UNION ALL

                    SELECT B.ID, B.Item, B.BilID, H.Consignee, B.ShipCode AS TSCode, B.DepotFrom, B.DepotTo
                    FROM      DelAlloShipDtl B WITH (nolock) LEFT JOIN
                                    DelAlloShip H WITH (nolock) ON H.ID = B.ID) TS ON dlad.oldalloid = TS.ID AND
                D.AlloItem = TS.Item
WHERE Dl.Status = 6 AND
                dla.status <> 6
/*加入对发货变更的判断，若为“作废”，则不显示（解决车辆发货明细重复记录问题）*/ UNION ALL
/*20150423改变更到站收货人*/ SELECT TS .ID AS AlloTrainID, AutoStatus = 1, H.CorpID, Dell.DepID, H.BilDate, Dr.BilNo, D.ID, 
                D.BilID, Dell.Item, dr.Driver, dr.DriveLice, dr.AutoCode, dr.Tel, saos.TareTime AS TareTime, h.CheckTime AS GrossTime, 
                Saos.QtyTare, Saos.QtyGross, -Dell.Qty AS QtyNet, Dell.QtyKP, Dell.QtyLot, h.BilDate, dr.Qty * -1, Dell.Price, 
                Dell.QtyRER * -1, ts.DepotFrom, TS.DepotTo, dd.PrintTime, Dell.Amt * -1, Sac.PriceFrei AS PriceFreiCont, 
                -(ISNULL(ISNULL(Sac.PriceFrei, 0) * ISNULL(Dell.QtyRER, 0), 0)) AS AmtFrei, -(ISNULL(ISNULL(sac.PriceFrei, 0)
               * ISNULL(Dell.Qty, 0), 0)) AS AmtFrei1, -((ISNULL(Dell.QtyRER, 0) * ISNULL(Dell.Price, 0))
               + ISNULL(ISNULL(Sac.PriceFrei, 0) * ISNULL(Dell.QtyRER, 0), 0)) AS AmtAndFrei, sac.PriceFrei, dr.ToCust, SacDtl.MatID, 
                SacDtl.Qty AS QtyCont, Sac.BilNo AS ContBilNo, h.CreateTime, SacDtl.StockID, Sac.ContPayTypeID, Dell.QtyPack, 
                '发货变更(负)' AS Rem, ISNull(SacDtl.Qty, 0) -ISNull(SacDtl.QtyTo, 0) + ISNull(SacDtl.QtyRetu, 0) AS QtyStaCont,
               Sac.CustID, Sac.DeliWayID, Sac.TransportID, Sac.StfID AS ContStfID, Dell.StockID AS StockIDTo, ts.Consignee, 
                TS.TSCode, 0 QtyMeshBag, Sac.AreaID, CASE WHEN m.Name LIKE '%豆粕%' AND
                sac.BilNo NOT LIKE '%YDK%' THEN(CASE WHEN dell.IsStaStatus = 1 THEN Dell.PriceAcc ELSE dell.Price END)
                + isnull(PPDU.PriceDif, 0) ELSE NULL END AS Price43, SacDtl.PriceTranTypeID, 
                /*'标准价' IsStaStatus,*/ CASE WHEN Sac.pricetrantypeid = 2 AND
                SacDtl.pricetrantypeid = 1 THEN '已结价' WHEN Dr.qtyapp IS NOT NULL AND
                SacDtl.pricetrantypeid = 2 THEN '未结价' ELSE '标准价' END AS IsStaStatus, 
                /*解决“是否结价”始终显示为“标准价”问题;By-cjy-2017.07.17*/ Dell.BilNo AS DelBilNo, Saos.QtyCheck1, 
                Saos.QtyCheck2, Saos.QtyCheck3, Saos.QtyCheck4, Saos.QtyCheck5, Saos.QtyCheck6, Saos.QtyCheck7, 
                Saos.QtyCheck8, Saos.QtyCheck9, Saos.QtyCheck10, Saos.QtyCheck11, Saos.QtyCheck12, Saos.QtyCheck13, 
                Saos.QtyCheck14, Saos.QtyCheck15, Saos.ID AS SaosID, 
                CASE WHEN saos.IsPass = 1 THEN '合格' WHEN Saos.IsPass = 0 THEN '不合格' ELSE '' END AS IsPass, 
                dela.ArriveTime, dela.DriveLice AS ArrDriveLice, dela.Driver AS ArrDriver, dela.DriverOut AS ArrDriverOut, 
                dela.Tel AS ArrTel, CASE WHEN dell.IsStaStatus = 1 THEN Dell.PriceAcc ELSE dell.Price END AS priceacc,
                CASE WHEN Dell.IsStaStatus = 1 THEN(ISNULL(Dell.QtyRER, 0) * ISNULL(Dell.PriceAcc, 0))
                * -1 ELSE(ISNULL(Dell.QtyRER, 0) * ISNULL(Dell.Price, 0)) * -1 END AS AmtAcc, 
                CASE WHEN Dell.IsStaStatus = 1 THEN(ISNULL(Dell.QtyRER, 0) * ISNULL(Dell.PriceAcc, 0))
                * -1 + ISNULL(ISNULL(Sac.PriceFrei, 0) * ISNULL(Dell.QtyRER, 0), 0) * -1 ELSE(ISNULL(Dell.QtyRER, 0)
              * ISNULL(Dell.Price, 0)) * -1 + ISNULL(ISNULL(Sac.PriceFrei, 0) * ISNULL(Dell.QtyRER, 0), 0) * -1 END AS AmtAcc1, 
                sac.DealerID, 0, 0, 0, 0, '', 
                CASE WHEN m.Name LIKE '%油%' THEN '18个月' WHEN m.Name LIKE '%豆粕%' THEN '6个月' ELSE '' END AS CheckDate
FROM      DelLeaveAlterDtl D WITH(nolock) LEFT JOIN
                DelLeaveAlter H WITH(nolock) ON D .ID = H.ID LEFT JOIN
                   (SELECT B.ID, B.Item, B.BilID, B.IDFrom, B.ItemFrom, B.BilIDFrom, B.BilNo, B.Qty, B.Price, isnull(B.QtyRER, 0) 
                                     *isnull(B.price, 0) AS Amt, B.MatID, B.QtyRER, B.QtyPack, B.QtyKP, B.QtyLot, h.DepID, B.StockID, 
                                     B.PriceAcc, B.IsStaStatus
                     FROM      DelLeaveDtl B WITH(NOLOCK) LEFT JOIN
                                     DelLeave H WITH(NOLOCK) ON b.ID = h.ID
                     UNION ALL
                     SELECT B.ID, B.Item, B.BilID, B.IDFrom, B.ItemFrom, B.BilIDFrom, B.BilNo, B.Qty, B.cost AS Price, isnull(B.Qty, 0)
                                   * isnull(B.Cost, 0) AS Amt, B.MatID, B.Qty AS QtyRER, B.QtyPack, 0 QtyKP, 0 QtyLot, h.DepID, B.InStockID, 
                                     B.Cost AS Price, 0
                     FROM StcStockShiftDtl B WITH(NOLOCK) LEFT JOIN
                                     StcStockShift H WITH(NOLOCK) ON b.ID = h.ID) Dell ON dell.ID = d.IDFrom AND
                dell.Item = d.ItemFrom LEFT JOIN
                DelReachDtl Dr WITH(NOLOCK) ON Dr.ID = Dell.IDFrom AND Dr.Item = Dell.ItemFrom LEFT JOIN
                delreach dd ON dd.id = dr.id LEFT JOIN
                SacOutSupervise Saos WITH(nolock) ON Saos.IDFrom = dr.ID AND Saos.BilIDFrom = dr.BilID AND
                Saos.ItemFrom = dr.Item AND Saos.SuperviseID IS NULL LEFT JOIN
                DelArrive dela ON Saos.ArriveID = dela.ID LEFT JOIN
                SacContractDtl SacDtl WITH(nolock) ON D .OldContID = SacDtl.ID AND D .OldContBilID = SacDtl.BilID AND
                D.OldContItem = SacDtl.Item LEFT JOIN
                SacContract Sac WITH(nolock) ON SacDtl.ID = Sac.ID LEFT JOIN
                PubMaterial M WITH(nolock) ON Dell.MatID = M.ID LEFT JOIN
                PubPriceDifUpdate PPDU WITH(nolock) ON PPDU.CorpID = SacDtl.CorpID AND PPDU.MatTypeID = M.MatTypeID LEFT
                JOIN
                    (SELECT   B.ID, B.Item, B.BilID, H.Consignee, B.TrainCode AS TSCode, B.DepotFrom, B.DepotTo
                     FROM      DelAlloTrainDtl B WITH(nolock) LEFT JOIN
                                     DelAlloTrain H WITH(nolock) ON H.ID = B.ID
                     UNION ALL
                     SELECT   B.ID, B.Item, B.BilID, H.Consignee, B.ShipCode AS TSCode, B.DepotFrom, B.DepotTo
                     FROM      DelAlloShipDtl B WITH(nolock) LEFT JOIN
                                     DelAlloShip H WITH(nolock) ON H.ID = B.ID) TS ON d.oldalloid = TS.ID AND Dr.AlloItem = TS.Item
WHERE H.Status IN(3, 4) AND H.CheckTime >= '2014-08-07'
GROUP BY h.CorpID, Dell.DepID, H.BilDate, Dr.BilNo, D.ID, D.BilID, dr.Driver, dr.DriveLice, Dr.AutoCode, dr.Tel, h.CheckTime, 
                h.CheckTime, Saos.QtyTare, Saos.QtyGross, Dell.Qty, Dell.QtyKP, Dell.QtyLot, h.BilDate, dr.Qty, Dell.Price, Dell.QtyRER, 
                Dell.Amt, Sac.PriceFrei, dr.ToCust, SacDtl.MatID, SacDtl.Qty, Sac.BilNo, h.CreateTime, SacDtl.StockID, 
                Sac.ContPayTypeID, Dell.QtyPack, SacDtl.Qty, SacDtl.QtyTo, SacDtl.QtyRetu, Sac.CustID, Sac.DeliWayID, 
                Sac.TransportID, Sac.StfID, Dell.StockID, Sac.AreaID, SacDtl.Price, PPDU.PriceDif, SacDtl.PriceTranTypeID, Dell.BilNo, 
                Saos.QtyCheck1, Saos.QtyCheck2, Saos.QtyCheck3, Saos.QtyCheck4, Saos.QtyCheck5, Saos.QtyCheck6, 
                Saos.QtyCheck7, Saos.QtyCheck8, Saos.QtyCheck9, Saos.QtyCheck10, Saos.QtyCheck11, Saos.QtyCheck12, 
                Saos.QtyCheck13, Saos.QtyCheck14, Saos.QtyCheck15, dela.ArriveTime, saos.IsPass, Dell.IsStaStatus, Saos.ID, 
                dela.DriveLice, dela.Driver, dela.DriverOut, dela.Tel, Dell.PriceAcc, Dell.Item, sac.DealerID, ts.DepotFrom, TS.DepotTo, 
                saos.TareTime, ts.TSCode, ts.Consignee, dd.PrintTime, m.Name, Sac.pricetrantypeid, Dr.qtyapp, TS.ID";
                    return (List<V_SacMD>)sc.Query<V_SacMD>(sql);
                }
            
        }
        #endregion
    }
}
