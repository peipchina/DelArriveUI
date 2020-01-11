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
    public class ReachArriveService
    {
        /// <summary>
        /// 车辆抵达排号
        /// </summary>
        /// <returns></returns>
        public List<V_ReachArriveMD> getAllReachArrive()
        {
            string connection = PubClass.getConnecion();
            using (SqlConnection sc=new SqlConnection(connection))
            {
                string sql = @"select Drd.ID,Drd.AutoCode,Dae.DriveLice,Dae.Tel,Dae.Driver,Dae.OldAutoCode,Drd.BilNo,Drd.Qty,Drd.BilDate,Drd.MatID,Drd.StockID,Drd.UnitID,
      Drd.PackID,Drd.Rem,Drd.CorpID,Drd.CorpID as DepID,Drd.Period,Drd.QtyTare,Drd.QtyNet,Drd.IDFrom,Drd.BilIDFrom,
      M.Code as MatCode,M.Name as MatName,M.MatPropID as MMatPropID,M.MatTypeID as MMatTypeID,M.UnitID as MUnitID,      
       Drd.BilIDFrom,
      Case when Drd.BilIDFrom='DEAT' and Drd.CorpID=2158631 then '短倒车辆'  when Drd.BilIDFrom='DESD' then '短倒车辆' else '非短倒车辆' end as BilType,
	  Case when  Drd.QtyTare >0 then '已进厂过皮' when H.PrintTime is not null then '已打印'  else  '未打印' end as BilType1, 
					Cont.BilNo as ContBilNo,Cont.CustID,Cont.CorpID as ContCorpID,Cont.TransportID,Cont.DeliWayID,
	  Case when Allo.IsContainer IS null then 0 else Allo.IsContainer end as IsContainer,TS.TSCode,TS.TSQty,TS.TSAQty,TS.TSLQty,Ts.QtyDeli,TS.TSDQty  
      ,Dae.ID as DAEID,dae.IsDel,Dae.ArriveTime,Dae.CheckTime as CallTime,Dp.StockIDTo 
 from (select dr.ID,AutoCode,Qty,BilDate,BilNo,MatID,StockID,UnitID,PackID,dr.Rem,dr.CorpID,Period,PlanID,PlanItem,
		 ContBilID,ContID,ContItem,IDFrom,ItemFrom,BilIDFrom,AlloID,AlloBilID,AlloItem,QtyNet,QtyGross,QtyTare 
		 from DelReachDtl dr with(NOLOCK) 
		 left join DelArrive Dae  with(NOLOCK) on Dr.AutoCode =Dae.Code and Dr.CorpID=Dae.CorpID and Dae.IsDel=0
		 where  ( exists(select top 1 1 from DelArrive A where A.Code=Dr.AutoCode and A.IsDel=0 ))
		 and  Dr.AlloBilID<>'DEAS' and (Dr.QtyNet is null or dr.QtyNet =0)
		 and (Dr.QtyTare is null or dr.QtyTare =0) 
		 union all 
		 select dr.ID,AutoCode,Qty,BilDate,BilNo,MatID,StockID,UnitID,PackID,dr.Rem,dr.CorpID,Period,PlanID,PlanItem,
		 ContBilID,ContID,ContItem,IDFrom,ItemFrom,BilIDFrom,AlloID,AlloBilID,AlloItem,QtyNet,QtyGross,QtyTare 
		 from DelReachDtl dr with(NOLOCK) 
		 where   dr.BilIDFrom ='DESD' and Dr.AlloBilID<>'DEAT'  and (Dr.QtyNet is null or dr.QtyNet =0)
		 and (Dr.QtyTare is null or dr.QtyTare =0) 
		) as Drd  
		left join DelReach H with(NOLOCK)  on H.ID=Drd.ID 
		left join PubMaterial M with(NOLOCK)  on M.ID=Drd.MatID 
		left join PubMatType Mt  with(NOLOCK) on M.MatTypeID=Mt.ID 
		left join PubMatTypeCheck MtC  with(NOLOCK) on Mtc.MatTypeID=Mt.ID and Mtc.CorpID=Drd.CorpID 
		left join SacContract Cont  with(NOLOCK) on Drd.ContID=Cont.ID  
		left join PubDep Dep with(NOLOCK)  on Dep.ID=Drd.CorpID 
		left join PubStock St with(NOLOCK)  on Drd.StockID=St.ID 
		left join DelPlanDtl Dp with(NOLOCK)  on Drd.PlanID=Dp.ID and Drd.PlanItem =Dp.Item
		left join DelArrive Dae  with(NOLOCK) on Dae.IsDel=0 and Drd.AutoCode =Dae.Code and Drd.CorpID=Dae.CorpID  
		left join (select IsContainer,ID,Status from DelAlloCust  
					union all select IsContainer,ID,Status from DelAlloAuto
					) Allo  
					on Drd.IDFrom =Allo.ID and Drd.BilIDFrom in('DEAC','DEAA') and Allo.Status in(3,4,5) 
		left join (select ShipCode as TSCode,ID,BilID,Item,Qty as TSQty,QtyAuto as TSAQty,Qty-ISNULL(QtyAuto,0) as TSLQty,QtyDeli,Qty-ISNULL(QtyDeli,0) as TSDQty  from DelAlloShipDtl
				 union all 
				 select TrainCode as TSCode,ID,BilID,Item,Qty as TSQty,QtyAuto as TSAQty,Qty-ISNULL(QtyAuto,0) as TSLQty,QtyDeli,Qty-ISNULL(QtyDeli,0) as TSDQty  from DelAlloTrainDtl
					) TS on Drd.AlloID=TS.ID and Drd.AlloBilID=TS.BilID and Drd.AlloItem=TS.Item 
					
 where H.Status in (3,4)   AND (St.IsNotLocal=0 or St.IsNotLocal is null)   
 and dae.arrivetime is not null --增加抵达时间不为零 
 And Drd. CorpID=1190056 and ( 1=1 ) and (H.CorpID=1190056) order by BilType asc,Allo.IsContainer desc,Dae.ArriveTime asc,h.CreateTime  asc ";
                return (List<V_ReachArriveMD>)sc.Query<V_ReachArriveMD>(sql,null);
            }
        }
    }
}
