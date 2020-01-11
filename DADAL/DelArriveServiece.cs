using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DA.MODEL;
using System.Data;
using System.Data.SqlClient;

namespace DA.DAL
{
    public class DelArriveServiece
    {
        #region 绑定配车车辆未抵达信息
        /// <summary>
        /// 绑定配车车辆未抵达信息
        /// </summary>
        /// <returns>车辆未抵达信息</returns>
        public List<V_DelArrive> getAllDelArrive()
        {
            string connection = PubClass.getConnecion();
            using (SqlConnection scn = new SqlConnection(connection))
            {
                string sql = @"select Dr.AutoCode,Dr.DriveLice,Dr.Tel,Dr.Driver,Dr.Qty,Dr.MatID,dr.idfrom,dac.bildate,daccd.AutoCode OldCode,daccd.CreateTime BilCreateTime,
                                    Case when Dr.BilIDFrom='DEAT' and dr.CorpID=2158631 then '短倒车辆'  when Dr.BilIDFrom='DESD' then '短倒车辆' else '非短倒车辆' end as BilType, 
                                    M.SpcID as MSpcID,cs.name as MMatPropID,M.MatTypeID as MMatTypeID,Un.name as MUnitID,Cont.BilNo as ContBilNo,Cont.CustID,TS.TSCode,TS.TSQty,TS.TSAQty,TS.TSLQty,Mt.Name as MatTypeName,M.name as MatName,Cu.Name as CustName
                                    from DelReachDtl Dr with(NOLOCK)  left join DelReach H  with(NOLOCK) on H.ID=Dr.ID left join PubMaterial M with(NOLOCK)  on M.ID=Dr.MatID  left join PubMatType Mt with(NOLOCK)  on M.MatTypeID=Mt.ID 
                                    left join SacContract Cont  with(NOLOCK) on Dr.ContID=Cont.ID  
                                     left join PubCustomer Cu with(NOLOCK)  on Cu.ID=Cont.CustID  
                                      left join PubStock St with(NOLOCK)  on St.ID=Dr.StockID  
                                      left join PubUnit Un with(NOLOCK)  on Un.ID=M.UnitID  
                                      left join DelAlloCust dac on dac.id=dr.idfrom
                                      left join (select dac.CreateTime, dacc.ID,dacc.AutoCode,dacc.NewAutoCode,dacc.IDFrom,dacc.BilNo from  DelAutoCodeChgDtl dacc
                left join DelAutoCodeChg dac on dac.ID=dacc.ID) daccd on daccd.IDFrom=Dr.ID
                                      left join PubConstant Cs with(NOLOCK)  on cs.ID=M.MatPropID and cs.Type='MatProp'  
                                     left join (select Code,CorpID,IsDel from DelArrive group by Code,CorpID,IsDel) Dae on Dr.AutoCode =Dae.Code and Dr.CorpID=Dae.CorpID
                                      left join (select ShipCode as TSCode,ID,BilID,Item,Qty as TSQty,QtyAuto as TSAQty,Qty-ISNULL(QtyAuto,0) as TSLQty  from DelAlloShipDtl
                                    union all 
                                    select TrainCode as TSCode,ID,BilID,Item,Qty as TSQty,QtyAuto as TSAQty,Qty-ISNULL(QtyAuto,0) as TSLQty  from DelAlloTrainDtl
                                    ) TS on Dr.AlloID=TS.ID and Dr.AlloBilID=TS.BilID and Dr.AlloItem=TS.Item 
                                    where H.Status in (3,4)  AND (St.IsNotLocal=0 or St.IsNotLocal is null)  and (Dr.QtyNet is null or dr.QtyNet =0) and (Dr.QtyTare is null or dr.QtyTare =0)  
                                    and (Dae.IsDel is null   or   (Dae.IsDel=1  and 
                                    (not exists(select top 1 1 from DelArrive A where A.Code=Dr.AutoCode and A.IsDel=0  and a. CorpID=1190056 ))) ) and Dr.AlloBilID<>'DEAS' 
                                     And Dr. CorpID=1190056";
                //string sql = @"select Dr.AutoCode,Dr.DriveLice,Dr.Tel,Dr.Driver,Dr.Qty,Dr.MatID,
                //                Case when Dr.BilIDFrom='DEAT' and dr.CorpID=2158631 then '短倒车辆'  when Dr.BilIDFrom='DESD' then '短倒车辆' else '非短倒车辆' end as BilType, 
                //                M.SpcID as MSpcID,cs.name as MMatPropID,M.MatTypeID as MMatTypeID,Un.name as MUnitID,Cont.BilNo as ContBilNo,Cont.CustID,TS.TSCode,TS.TSQty,TS.TSAQty,TS.TSLQty,Mt.Name as MatTypeName,M.name as MatName,Cu.Name as CustName
                //                from DelReachDtl Dr with(NOLOCK)  left join DelReach H  with(NOLOCK) on H.ID=Dr.ID left join PubMaterial M with(NOLOCK)  on M.ID=Dr.MatID  left join PubMatType Mt with(NOLOCK)  on M.MatTypeID=Mt.ID 
                //                left join SacContract Cont  with(NOLOCK) on Dr.ContID=Cont.ID  
                //                 left join PubCustomer Cu with(NOLOCK)  on Cu.ID=Cont.CustID  
                //                  left join PubStock St with(NOLOCK)  on St.ID=Dr.StockID  
                //                  left join PubUnit Un with(NOLOCK)  on Un.ID=M.UnitID  
                //                  left join PubConstant Cs with(NOLOCK)  on cs.ID=M.MatPropID and cs.Type='MatProp'  
                //                 left join (select Code,CorpID,IsDel from DelArrive group by Code,CorpID,IsDel) Dae on Dr.AutoCode =Dae.Code and Dr.CorpID=Dae.CorpID
                //                  left join (select ShipCode as TSCode,ID,BilID,Item,Qty as TSQty,QtyAuto as TSAQty,Qty-ISNULL(QtyAuto,0) as TSLQty  from DelAlloShipDtl
                //                union all 
                //                select TrainCode as TSCode,ID,BilID,Item,Qty as TSQty,QtyAuto as TSAQty,Qty-ISNULL(QtyAuto,0) as TSLQty  from DelAlloTrainDtl
                //                ) TS on Dr.AlloID=TS.ID and Dr.AlloBilID=TS.BilID and Dr.AlloItem=TS.Item 
                //                where H.Status in (3,4)  AND (St.IsNotLocal=0 or St.IsNotLocal is null)  and (Dr.QtyNet is null or dr.QtyNet =0) and (Dr.QtyTare is null or dr.QtyTare =0)  
                //                and (Dae.IsDel is null   or   (Dae.IsDel=1  and 
                //                (not exists(select top 1 1 from DelArrive A where A.Code=Dr.AutoCode and A.IsDel=0  and a. CorpID=1190056  ))) ) and Dr.AlloBilID<>'DEAS' 
                //                 And Dr. CorpID=1190056 and ( 1=1 ) and ( 1=1)";
                //string sql = @"select Dr.AutoCode,Dr.DriveLice,Dr.Tel,Dr.Driver,Dr.Qty,Dr.MatID,
                //                Case when Dr.BilIDFrom='DEAT' and dr.CorpID=2158631 then '短倒车辆'  when Dr.BilIDFrom='DESD' then '短倒车辆' else '非短倒车辆' end as BilType, 
                //                M.SpcID as MSpcID,cs.name as MMatPropID,M.MatTypeID as MMatTypeID,Un.name as MUnitID,Cont.BilNo as ContBilNo,Cont.CustID,TS.TSCode,TS.TSQty,TS.TSAQty,TS.TSLQty,Mt.Name as MatTypeName,M.name as MatName,Cu.Name as CustName
                //                from DelReachDtl Dr with(NOLOCK)  left join DelReach H  with(NOLOCK) on H.ID=Dr.ID left join PubMaterial M with(NOLOCK)  on M.ID=Dr.MatID  left join PubMatType Mt with(NOLOCK)  on M.MatTypeID=Mt.ID 
                //                left join SacContract Cont  with(NOLOCK) on Dr.ContID=Cont.ID  
                //                 left join PubCustomer Cu with(NOLOCK)  on Cu.ID=Cont.CustID  
                //                  left join PubStock St with(NOLOCK)  on St.ID=Dr.StockID  
                //                  left join PubUnit Un with(NOLOCK)  on Un.ID=M.UnitID  
                //                  left join PubConstant Cs with(NOLOCK)  on cs.ID=M.MatPropID and cs.Type='MatProp'  
                //                 left join (select Code,CorpID,IsDel from DelArrive group by Code,CorpID,IsDel) Dae on Dr.AutoCode =Dae.Code and Dr.CorpID=Dae.CorpID
                //                  left join (select ShipCode as TSCode,ID,BilID,Item,Qty as TSQty,QtyAuto as TSAQty,Qty-ISNULL(QtyAuto,0) as TSLQty  from DelAlloShipDtl
                //                union all 
                //                select TrainCode as TSCode,ID,BilID,Item,Qty as TSQty,QtyAuto as TSAQty,Qty-ISNULL(QtyAuto,0) as TSLQty  from DelAlloTrainDtl
                //                ) TS on Dr.AlloID=TS.ID and Dr.AlloBilID=TS.BilID and Dr.AlloItem=TS.Item 
                //                where H.Status in (3,4)  AND (St.IsNotLocal=0 or St.IsNotLocal is null)  and (Dr.QtyNet is null or dr.QtyNet =0) and (Dr.QtyTare is null or dr.QtyTare =0)  
                //                and (Dae.IsDel is null   or   (Dae.IsDel=1  and 
                //                (not exists(select top 1 1 from DelArrive A where A.Code=Dr.AutoCode and A.IsDel=0  and a. CorpID=1190056 ))) ) and Dr.AlloBilID<>'DEAS' 
                //                 And Dr. CorpID=1190056";
                return (List<V_DelArrive>)scn.Query<V_DelArrive>(sql);
            }
        }
        #endregion

        #region 根据车辆号码获取车辆最近20次抵达信息
        /// <summary>
        /// 根据车辆号码获取车辆最近20次抵达信息
        /// </summary>
        /// <param name="delArrive"></param>
        /// <returns>车辆最近20次抵达信息</returns>
        public List<V_DelArriveMD> getArriveByAutoCode(string Code)
        {
            string connection = "Password=strive@4012;Persist Security Info=True;User ID=sa;Initial Catalog=SSS_BHSY;Data Source=172.168.1.39";
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"SELECT  top 20   da.ID, da.BilID, da.Code, da.Driver, da.Tel, da.DriveLice, da.ArriveTime, da.Rem, ps.Name AS CreateStfName, da.CreateTime, pst.Name AS CheckStfName, da.CheckTime, da.StopTime
                                FROM         dbo.DelArrive AS da LEFT OUTER JOIN
                                dbo.PubStaff AS ps ON ps.ID = da.CreateStfID LEFT OUTER JOIN
                                dbo.PubStaff AS pst ON pst.ID = da.CheckStfID Where da.Code=@Code and da.CorpID=1190056 order by da.ArriveTime desc";
                List<V_DelArriveMD> aa= (List<V_DelArriveMD>)sc.Query<V_DelArriveMD>(sql,new {Code=Code });
                return aa;
            }
        }
        #endregion

        #region 根据车辆号码获取车辆最近20次抵达信息
        /// <summary>
        /// 根据车辆号码获取车辆最近20次抵达信息
        /// </summary>
        /// <param name="delArrive"></param>
        /// <returns>车辆最近20次抵达信息</returns>
        public List<V_DelArriveMD> getArriveByAutoCod(string Code)
        {
            string connection = "Password=strive@4012;Persist Security Info=True;User ID=sa;Initial Catalog=SSS_BHSY;Data Source=172.168.1.39";
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"SELECT  top 20   da.ID, da.BilID, da.Code, da.Driver, da.Tel, da.DriveLice, da.ArriveTime, da.Rem, ps.Name AS CreateStfName, da.CreateTime, pst.Name AS CheckStfName, da.CheckTime, da.StopTime
                                FROM         dbo.DelArrive AS da LEFT OUTER JOIN
                                dbo.PubStaff AS ps ON ps.ID = da.CreateStfID LEFT OUTER JOIN
                                dbo.PubStaff AS pst ON pst.ID = da.CheckStfID Where da.Code like @Code and da.CorpID=1190056 order by da.ArriveTime desc";
                List<V_DelArriveMD> aa = (List<V_DelArriveMD>)sc.Query<V_DelArriveMD>(sql, new { Code = Code });
                return aa;
            }
        }
        #endregion
    }
}
