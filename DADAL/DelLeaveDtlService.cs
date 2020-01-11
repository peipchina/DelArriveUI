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
    public class DelLeaveDtlService
    {
        //string connection = PubClass.getConnecion();
        string connection = @"Password=strive@4012;Persist Security Info=True;User ID=sa;Initial Catalog=SSS_BHSY;Data Source=172.168.1.39";
        public List<DelLeaveDtlMD> getDelLeave(DateTime startTime,DateTime endTime)
        {
            
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"SELECT    dld.ID, dld.Item, dld.BilID, dld.CorpID, dld.Period, dld.BilDate, dld.BilNo, dld.RowIndex, dld.ContID, dld.ContBilID, 
                            dld.ContItem, dld.MatID, dld.MatMark1, dld.MatMark2, dld.MatMark3, dld.MatMark4, dld.MatMark5, dld.MatMark6, 
                            dld.MatMark7, dld.MatMark8, dld.BomID, dld.StockID, dld.UnitID, dld.AutoID, dld.AutoCode, dld.Driver, dld.Tel, 
                            dld.DriveLice, dld.QtyApp, dld.Qty, dld.Price, dld.QtyBase, dld.PriceBase, dld.PriceFrei, dld.Disc, dld.Amt, dld.RateTax, 
                            dld.Tax, dld.AmtNoTax, dld.AmtInTax, dld.AmtLocal, dld.QtyEnter, dld.QtyLog, dld.PackID, dld.QtyPack, dld.Area, 
                            dld.Volume, dld.Gross, dld.Net, dld.Rem, dld.BilIDTo, dld.QtyTo, dld.BilIDFrom, dld.IDFrom, dld.ItemFrom, 
                            dld.ModifyTime, dld.CheckStfID, dld.CheckTime, dld.EffectTime, dld.FinishTime, dld.VoidStfID, dld.SuspStfID, dld.Status, 
                            dld.StatusOld, dld.OBID, dld.OBBilID, dld.OBItem, dld.IsStaStatus, dld.QtyPackBag, dld.QtyRER, dld.QtyDW, 
                            dld.IsReceipt, dld.AccID, dld.RecAmt, dld.ReCAmtLocal, dld.IsConfirmOK, dld.ConfirmStfID, dld.ConfirmTime, 
                            dld.MatIDSale, dld.StockIDSale, dld.QtySale, dld.ErrMsg, dld.PriceAcc, dld.QtyKP, dld.QtyLot, dld.PlanBilID, dld.PlanID, 
                            dld.PlanItem, dld.IsRecord, dr.ID AS Expr1, dr.BilID AS Expr2, dr.CorpID AS Expr3, dr.Period AS Expr4, 
                            dr.BilDate AS Expr5, dr.BilNo AS Expr6, dr.BilTypeID, dr.DepID, dr.StfID, dr.OBBilID AS Expr7, dr.OBID AS Expr8, 
                            dr.CustSO, dr.ContID AS Expr9, dr.ContBilID AS Expr10, dr.OBBatchNum, dr.PrdtBatchNum, dr.BomBatchNum, 
                            dr.BatchNum, dr.MCIQGuidNo, dr.MCIQContNo, dr.Rem AS Expr11, dr.BilTypeID1st, dr.BilIDTo AS Expr12, 
                            dr.BilIDFrom AS Expr13, dr.IDFrom AS Expr14, dr.CreateStfID, dr.CreateTime, dr.ModifyTime AS Expr15, 
                            dr.CheckStfID AS Expr16, dr.CheckTime AS Expr17, dr.EffectTime AS Expr18, dr.FinishTime AS Expr19, 
                            dr.VoidStfID AS Expr20, dr.SuspStfID AS Expr21, dr.Status AS Expr22, dr.StatusOld AS Expr23, dr.CreateRoleID, 
                            dr.CreateDepID, dr.CreateCorpID, dr.PrintTime, dr.PrintStfID, dr.PrintTimes, dr.IsNoSho, dr.ErrBil, dr.Consignee
                            FROM      dbo.DelLeaveDtl AS dld LEFT OUTER JOIN
                            dbo.DelReach AS dr ON dr.ID = dld.IDFrom where dld.CorpID='1190056' and dld.BilDate between @startTime and @endTime";
                return (List<DelLeaveDtlMD>)sc.Query<DelLeaveDtlMD>(sql, new { startTime = startTime, endTime= endTime });
            }
        }
        public List<DelLeaveDtlMD> getDelLeaveByBilNo(string BilNo)
        {

            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"SELECT    dld.ID, dld.Item, dld.BilID, dld.CorpID, dld.Period, dld.BilDate, dld.BilNo, dld.RowIndex, dld.ContID, dld.ContBilID, 
                            dld.ContItem, dld.MatID, dld.MatMark1, dld.MatMark2, dld.MatMark3, dld.MatMark4, dld.MatMark5, dld.MatMark6, 
                            dld.MatMark7, dld.MatMark8, dld.BomID, dld.StockID, dld.UnitID, dld.AutoID, dld.AutoCode, dld.Driver, dld.Tel, 
                            dld.DriveLice, dld.QtyApp, dld.Qty, dld.Price, dld.QtyBase, dld.PriceBase, dld.PriceFrei, dld.Disc, dld.Amt, dld.RateTax, 
                            dld.Tax, dld.AmtNoTax, dld.AmtInTax, dld.AmtLocal, dld.QtyEnter, dld.QtyLog, dld.PackID, dld.QtyPack, dld.Area, 
                            dld.Volume, dld.Gross, dld.Net, dld.Rem, dld.BilIDTo, dld.QtyTo, dld.BilIDFrom, dld.IDFrom, dld.ItemFrom, 
                            dld.ModifyTime, dld.CheckStfID, dld.CheckTime, dld.EffectTime, dld.FinishTime, dld.VoidStfID, dld.SuspStfID, dld.Status, 
                            dld.StatusOld, dld.OBID, dld.OBBilID, dld.OBItem, dld.IsStaStatus, dld.QtyPackBag, dld.QtyRER, dld.QtyDW, 
                            dld.IsReceipt, dld.AccID, dld.RecAmt, dld.ReCAmtLocal, dld.IsConfirmOK, dld.ConfirmStfID, dld.ConfirmTime, 
                            dld.MatIDSale, dld.StockIDSale, dld.QtySale, dld.ErrMsg, dld.PriceAcc, dld.QtyKP, dld.QtyLot, dld.PlanBilID, dld.PlanID, 
                            dld.PlanItem, dld.IsRecord, dr.ID AS Expr1, dr.BilID AS Expr2, dr.CorpID AS Expr3, dr.Period AS Expr4, 
                            dr.BilDate AS Expr5, dr.BilNo AS Expr6, dr.BilTypeID, dr.DepID, dr.StfID, dr.OBBilID AS Expr7, dr.OBID AS Expr8, 
                            dr.CustSO, dr.ContID AS Expr9, dr.ContBilID AS Expr10, dr.OBBatchNum, dr.PrdtBatchNum, dr.BomBatchNum, 
                            dr.BatchNum, dr.MCIQGuidNo, dr.MCIQContNo, dr.Rem AS Expr11, dr.BilTypeID1st, dr.BilIDTo AS Expr12, 
                            dr.BilIDFrom AS Expr13, dr.IDFrom AS Expr14, dr.CreateStfID, dr.CreateTime, dr.ModifyTime AS Expr15, 
                            dr.CheckStfID AS Expr16, dr.CheckTime AS Expr17, dr.EffectTime AS Expr18, dr.FinishTime AS Expr19, 
                            dr.VoidStfID AS Expr20, dr.SuspStfID AS Expr21, dr.Status AS Expr22, dr.StatusOld AS Expr23, dr.CreateRoleID, 
                            dr.CreateDepID, dr.CreateCorpID, dr.PrintTime, dr.PrintStfID, dr.PrintTimes, dr.IsNoSho, dr.ErrBil, dr.Consignee
                            FROM      dbo.DelLeaveDtl AS dld LEFT OUTER JOIN
                            dbo.DelReach AS dr ON dr.ID = dld.IDFrom where dld.CorpID='1190056' and dld.BilNo=@BilNo";
                return (List<DelLeaveDtlMD>)sc.Query<DelLeaveDtlMD>(sql, new { BilNo = BilNo });
            }
        }
        public List<DelLeaveDtlMD> getDelLeaveHeadByBilNo(string BilNo)
        {

            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"select * from DelLeave  where CorpID='1190056' and BilNo=@BilNo";
                return (List<DelLeaveDtlMD>)sc.Query<DelLeaveDtlMD>(sql, new { BilNo = BilNo });
            }
        }
        public bool UpdataDelLeaveDtl(DelLeaveDtlMD delLeaveDtlMD)
        {            
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"update DelLeaveDtl set
				BilDate=@BilDate
				where BilNo=@BilNo";
                return sc.Execute(sql, delLeaveDtlMD) >0;
            }
        }

        public bool UpdataDelLeave(DelLeaveDtlMD delLeaveDtlMD)
        {
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"update DelLeave set
				BilDate=@BilDate,
				CreateTime=@BilDate,
				CheckTime=@BilDate,
				EffectTime=@BilDate
				where BilNo=@BilNo";
                return sc.Execute(sql, delLeaveDtlMD) > 0;
            }
        }

        public bool UpdataSacOutSupervise(DelLeaveDtlMD delLeaveDtlMD)
        {
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"update SacOutSupervise set
				GrossTime=@BilDate
				where IDFrom=@Expr1";
                return sc.Execute(sql, delLeaveDtlMD) > 0;
            }
        }

        public List<DLMD> getReachAuto(DateTime startTime, DateTime endTime)
        {
            string connection = PubClass.getConnecion();
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"SELECT   dld.ID, dld.Item, dld.BilID, dld.CorpID, dld.Period, dld.BilDate, dld.BilNo, dld.RowIndex, dld.OBID, dld.OBBilID, 
                                    dld.OBItem, dld.CustSO, dld.OBBatchNum, dld.PrdtBatchNum, dld.BomBatchNum, dld.BatchNum, dld.MCIQGuidNo, 
                                    dld.MCIQContNo, dld.MCIQBom, dld.MatID, dld.MatMark1, dld.MatMark2, dld.MatMark3, dld.MatMark4, dld.MatMark5, 
                                    dld.MatMark6, dld.MatMark7, dld.MatMark8, dld.BomID, dld.OutStockID, dld.OutQtySite, dld.InStockID, dld.InQtySite, 
                                    dld.QtyBase, dld.PriceBase, dld.UnitID, dld.QtyApp, dld.Qty, dld.Price, dld.Amt, dld.QtySite, dld.QtySerial, 
                                    dld.MakeOrderID, dld.PrdtID, dld.CostNow, dld.CostStd, dld.Cost, dld.RateDiff, dld.PackID, dld.QtyPack, dld.Area, 
                                    dld.Volume, dld.Gross, dld.Net, dld.QSID, dld.Rem, dld.BilIDTo, dld.QtyTo, dld.BilIDFrom, dld.IDFrom, dld.ItemFrom, 
                                    dld.ModifyTime, dld.CheckStfID, dld.CheckTime, dld.EffectTime, dld.FinishTime, dld.VoidStfID, dld.SuspStfID, dld.Status, 
                                    dld.StatusOld, dld.QtyFlow, dld.IsConfirmOK, dld.ConfirmStfID, dld.ConfirmTime, dld.ErrMsg, dld.AmtCost, dld.InSCID, 
                                    dld.OutSCID, dld.FeesMat, dld.FeesMan, dld.FeesMake, dld.FeesOus, dld.FeesAid, dld.AuxUnitID, dld.QtyCfm, 
                                    dld.QtyAux, dr.ID AS Expr1, dr.BilID AS Expr2, dr.CorpID AS Expr3, dr.Period AS Expr4, dr.BilDate AS Expr5, 
                                    dr.BilNo AS Expr6, dr.BilTypeID, dr.DepID, dr.StfID, dr.OBBilID AS Expr7, dr.OBID AS Expr8, dr.CustSO AS Expr9, 
                                    dr.ContID, dr.ContBilID, dr.OBBatchNum AS Expr10, dr.PrdtBatchNum AS Expr11, dr.BomBatchNum AS Expr12, 
                                    dr.BatchNum AS Expr13, dr.MCIQGuidNo AS Expr14, dr.MCIQContNo AS Expr15, dr.Rem AS Expr16, dr.BilTypeID1st, 
                                    dr.BilIDTo AS Expr17, dr.BilIDFrom AS Expr18, dr.IDFrom AS Expr19, dr.CreateStfID, dr.CreateTime, 
                                    dr.ModifyTime AS Expr20, dr.CheckStfID AS Expr21, dr.CheckTime AS Expr22, dr.EffectTime AS Expr23, 
                                    dr.FinishTime AS Expr24, dr.VoidStfID AS Expr25, dr.SuspStfID AS Expr26, dr.Status AS Expr27, dr.StatusOld AS Expr28, 
                                    dr.CreateRoleID, dr.CreateDepID, dr.CreateCorpID, dr.PrintTime, dr.PrintStfID, dr.PrintTimes, dr.IsNoSho, dr.ErrBil, 
                                    dr.Consignee
                    FROM      dbo.StcStockShiftDtl AS dld LEFT OUTER JOIN
                dbo.DelReach AS dr ON dr.ID = dld.IDFrom where dld.CorpID='1190056' and dld.BilDate between @startTime and @endTime";
                return (List<DLMD>)sc.Query<DLMD>(sql, new { startTime = startTime, endTime = endTime });
            }
        }
        public bool UpdataStcStockShift(DLMD delLeaveDtlMD)
        {
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"update StcStockShift set
				BilDate=@BilDate,
				CreateTime=@BilDate,
				CheckTime=@BilDate,
				EffectTime=@BilDate,
				PrintTime=@BilDate
				where bilno=@BilNo";
                return sc.Execute(sql, delLeaveDtlMD) > 0;
            }
        }

        public bool UpdataStcStockShiftDtl(DLMD delLeaveDtlMD)
        {
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"update StcStockShiftDtl set
				BilDate=@BilDate
				where bilno=@BilNo";
                return sc.Execute(sql, delLeaveDtlMD) > 0;
            }
        }

        public bool UpdataSacOutSupervise1(DLMD delLeaveDtlMD)
        {
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"update SacOutSupervise set
				GrossTime=@BilDate
				where IDFrom=@Expr1";
                return sc.Execute(sql, delLeaveDtlMD) > 0;
            }
        }
    }
}
