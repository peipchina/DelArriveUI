﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.MODEL
{
    public class StcStockShiftDtlMD
    {
        public long ID { get; set; }
        public int Item { get; set; }
        public string BilID { get; set; }
        public Nullable<long> CorpID { get; set; }
        public Nullable<int> Period { get; set; }
        public Nullable<System.DateTime> BilDate { get; set; }
        public string BilNo { get; set; }
        public Nullable<int> RowIndex { get; set; }
        public Nullable<long> OBID { get; set; }
        public string OBBilID { get; set; }
        public Nullable<int> OBItem { get; set; }
        public string CustSO { get; set; }
        public string OBBatchNum { get; set; }
        public string PrdtBatchNum { get; set; }
        public string BomBatchNum { get; set; }
        public string BatchNum { get; set; }
        public string MCIQGuidNo { get; set; }
        public string MCIQContNo { get; set; }
        public string MCIQBom { get; set; }
        public Nullable<long> MatID { get; set; }
        public Nullable<long> MatMark1 { get; set; }
        public Nullable<long> MatMark2 { get; set; }
        public Nullable<long> MatMark3 { get; set; }
        public Nullable<long> MatMark4 { get; set; }
        public Nullable<long> MatMark5 { get; set; }
        public Nullable<long> MatMark6 { get; set; }
        public Nullable<long> MatMark7 { get; set; }
        public Nullable<long> MatMark8 { get; set; }
        public Nullable<long> BomID { get; set; }
        public Nullable<long> OutStockID { get; set; }
        public Nullable<decimal> OutQtySite { get; set; }
        public Nullable<long> InStockID { get; set; }
        public Nullable<decimal> InQtySite { get; set; }
        public Nullable<decimal> QtyBase { get; set; }
        public Nullable<decimal> PriceBase { get; set; }
        public Nullable<long> UnitID { get; set; }
        public Nullable<decimal> QtyApp { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> Amt { get; set; }
        public Nullable<decimal> QtySite { get; set; }
        public Nullable<decimal> QtySerial { get; set; }
        public Nullable<long> MakeOrderID { get; set; }
        public Nullable<long> PrdtID { get; set; }
        public Nullable<decimal> CostNow { get; set; }
        public Nullable<decimal> CostStd { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<decimal> RateDiff { get; set; }
        public Nullable<long> PackID { get; set; }
        public Nullable<decimal> QtyPack { get; set; }
        public Nullable<double> Area { get; set; }
        public Nullable<double> Volume { get; set; }
        public Nullable<double> Gross { get; set; }
        public Nullable<double> Net { get; set; }
        public Nullable<long> QSID { get; set; }
        public string Rem { get; set; }
        public string BilIDTo { get; set; }
        public Nullable<decimal> QtyTo { get; set; }
        public string BilIDFrom { get; set; }
        public Nullable<long> IDFrom { get; set; }
        public Nullable<int> ItemFrom { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public Nullable<long> CheckStfID { get; set; }
        public Nullable<System.DateTime> CheckTime { get; set; }
        public Nullable<System.DateTime> EffectTime { get; set; }
        public Nullable<System.DateTime> FinishTime { get; set; }
        public Nullable<long> VoidStfID { get; set; }
        public Nullable<long> SuspStfID { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> StatusOld { get; set; }
        public Nullable<decimal> QtyFlow { get; set; }
        public bool IsConfirmOK { get; set; }
        public Nullable<long> ConfirmStfID { get; set; }
        public Nullable<System.DateTime> ConfirmTime { get; set; }
        public string ErrMsg { get; set; }
        public Nullable<decimal> AmtCost { get; set; }
        public Nullable<long> InSCID { get; set; }
        public Nullable<long> OutSCID { get; set; }
        public Nullable<decimal> FeesMat { get; set; }
        public Nullable<decimal> FeesMan { get; set; }
        public Nullable<decimal> FeesMake { get; set; }
        public Nullable<decimal> FeesOus { get; set; }
        public Nullable<decimal> FeesAid { get; set; }
        public Nullable<long> AuxUnitID { get; set; }
        public Nullable<decimal> QtyCfm { get; set; }
        public Nullable<decimal> QtyAux { get; set; }
        public Nullable<long> Expr1 { get; set; }
        public string Expr2 { get; set; }
        public Nullable<long> Expr3 { get; set; }
        public Nullable<int> Expr4 { get; set; }
        public Nullable<System.DateTime> Expr5 { get; set; }
        public string Expr6 { get; set; }
        public Nullable<long> BilTypeID { get; set; }
        public Nullable<long> DepID { get; set; }
        public Nullable<long> StfID { get; set; }
        public string Expr7 { get; set; }
        public Nullable<long> Expr8 { get; set; }
        public string Expr9 { get; set; }
        public Nullable<long> ContID { get; set; }
        public string ContBilID { get; set; }
        public string Expr10 { get; set; }
        public string Expr11 { get; set; }
        public string Expr12 { get; set; }
        public string Expr13 { get; set; }
        public string Expr14 { get; set; }
        public string Expr15 { get; set; }
        public string Expr16 { get; set; }
        public Nullable<long> BilTypeID1st { get; set; }
        public string Expr17 { get; set; }
        public string Expr18 { get; set; }
        public Nullable<long> Expr19 { get; set; }
        public Nullable<long> CreateStfID { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> Expr20 { get; set; }
        public Nullable<long> Expr21 { get; set; }
        public Nullable<System.DateTime> Expr22 { get; set; }
        public Nullable<System.DateTime> Expr23 { get; set; }
        public Nullable<System.DateTime> Expr24 { get; set; }
        public Nullable<long> Expr25 { get; set; }
        public Nullable<long> Expr26 { get; set; }
        public Nullable<int> Expr27 { get; set; }
        public Nullable<int> Expr28 { get; set; }
        public Nullable<long> CreateRoleID { get; set; }
        public Nullable<long> CreateDepID { get; set; }
        public Nullable<long> CreateCorpID { get; set; }
        public Nullable<System.DateTime> PrintTime { get; set; }
        public Nullable<long> PrintStfID { get; set; }
        public Nullable<int> PrintTimes { get; set; }
        public Nullable<bool> IsNoSho { get; set; }
        public Nullable<bool> ErrBil { get; set; }
        public string Consignee { get; set; }
    }
}
