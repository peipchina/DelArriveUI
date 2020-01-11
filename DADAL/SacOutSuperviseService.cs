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
    public class SacOutSuperviseService
    {
        #region 根据时间查询发货信息
        /// <summary>
        /// 根据时间查询发货信息
        /// </summary>
        /// <param name="datetimeStart">开始时间</param>
        /// <param name="datetimeEnd">结束时间</param>
        /// <returns>发货信息</returns>
        public List<V_SacOutSuperviseMD> getSacOutSupervise(DateTime datetimeStart, DateTime datetimeEnd)
        {
            string connection = PubClass.getConnecion();
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"select  sos.id,sos.corpid,sos.bilidfrom,sos.IDFrom,sos.AutoCode,sos.Driver,sos.InLine,sos.StockID,pst.Name StockName,sos.QtyTare,sos.TareTime,sos.QtyCheck15,sos.TareStfID,ps.name TareStfName,
                                sos.QtyGross,sos.GrossTime,sos.GrossStfID,ps1.Name GrossStfName,sos.BeginLoadStfID,ps2.Name BeginLoadStfName,sos.BeginLoadTime,sos.EndLoadStfID,ps3.Name EndLoadStfName
                                ,sos.EndLoadTime,sos.QCID,sos.PassStfID,ps4.Name PassStfName,sos.PassTime
                                ,sos.CreateStfID,ps5.Name CreateStfName,sos.CreateTime,sos.Rem,sos.SuperviseID,sos.SuperviseIndex,sos.UpIndex,sos.MultKeyID ,
                                case when sos.BilIDFrom='DERC' THEN DRD.BilNo 
                                when sos.BilIDFrom='DESR' then drd2.BilNo
                                when sos.BilIDFrom='SAR' then drd1.BilNo
                                when sos.BilIDFrom='SDERC' then drd3.BilNo
                                END BilNo,drd.MatID,pm.name MatName,drd.ToCust
                                from SacOutSupervise sos 
                                left join PubStaff ps on ps.id=sos.TareStfID
                                left join PubStaff ps1 on ps1.id=sos.GrossStfID
                                left join PubStaff ps2 on ps2.id=sos.BeginLoadStfID
                                left join PubStaff ps3 on ps3.id=sos.EndLoadStfID
                                left join PubStaff ps4 on ps4.id=sos.PassStfID 
                                left join PubStaff ps5 on ps5.id=sos.CreateStfID
                                LEFT JOIN DelReachDtl DRD ON DRD.ID=SOS.IDFrom
                                left join PubStock pst on pst.ID=sos.StockID
                                left join salreturn drd1 on drd1.id=sos.idfrom
                                left join delshoreturn drd2 on drd2.id=sos.idfrom
                                left join delreachsmall drd3 on drd3.id=sos.idfrom
                                left join PubMaterial pm on pm.id=drd.matid
                                where sos.CorpID=1190056 and sos.GrossTime between @datetimeStart and @datetimeEnd
                                order by GrossTime desc";
                return (List<V_SacOutSuperviseMD>)sc.Query<V_SacOutSuperviseMD>(sql, new { datetimeStart = datetimeStart, datetimeEnd = datetimeEnd });
            }
        }
        #endregion

        #region 根据车号查询发货信息
        /// <summary>
        /// 根据车号及时间查询发货信息
        /// </summary>
        /// <param name="AutoCode">车号</param>        
        /// <returns>发货信息</returns>
        public List<V_SacOutSuperviseMD> getSacOutSuperviseByAutoCodeAndTime(string AutoCode,DateTime dateTime)
        {
            string connection = PubClass.getConnecion();
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"select  * from SacOutSupervise where CorpID='1190056' and AutoCode=@AutoCode and TareTime between @startTime and @endTime";
                return (List<V_SacOutSuperviseMD>)sc.Query<V_SacOutSuperviseMD>(sql, new { AutoCode = AutoCode,startTime = dateTime.AddHours(-1), endTime =dateTime.AddHours(1)});
            }
        }
        #endregion

        #region 根据车号查询发货信息
        /// <summary>
        /// 根据车号查询发货信息
        /// </summary>
        /// <param name="AutoCode">车号</param>        
        /// <returns>发货信息</returns>
        public List<V_SacOutSuperviseMD> getSacOutSuperviseByAutoCode(string AutoCode)
        {
            string connection = PubClass.getConnecion();
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"select  sos.id,sos.corpid,sos.bilidfrom,sos.IDFrom,sos.AutoCode,sos.Driver,sos.InLine,sos.StockID,pst.Name StockName,sos.QtyTare,sos.TareTime,sos.TareStfID,ps.name TareStfName,
                                sos.QtyGross,sos.GrossTime,sos.GrossStfID,ps1.Name GrossStfName,sos.BeginLoadStfID,ps2.Name BeginLoadStfName,sos.BeginLoadTime,sos.EndLoadStfID,ps3.Name EndLoadStfName
                                ,sos.EndLoadTime,sos.QCID,sos.PassStfID,ps4.Name PassStfName,sos.PassTime
                                ,sos.CreateStfID,ps5.Name CreateStfName,sos.CreateTime,sos.Rem,sos.SuperviseID,sos.SuperviseIndex,sos.UpIndex,sos.MultKeyID ,
                                case when sos.BilIDFrom='DERC' THEN DRD.BilNo 
                                when sos.BilIDFrom='DESR' then drd2.BilNo
                                when sos.BilIDFrom='SAR' then drd1.BilNo
                                when sos.BilIDFrom='SDERC' then drd3.BilNo
                                END BilNo,drd.MatID,pm.name MatName,drd.ToCust
                                from SacOutSupervise sos 
                                left join PubStaff ps on ps.id=sos.TareStfID
                                left join PubStaff ps1 on ps1.id=sos.GrossStfID
                                left join PubStaff ps2 on ps2.id=sos.BeginLoadStfID
                                left join PubStaff ps3 on ps3.id=sos.EndLoadStfID
                                left join PubStaff ps4 on ps4.id=sos.PassStfID 
                                left join PubStaff ps5 on ps5.id=sos.CreateStfID
                                LEFT JOIN DelReachDtl DRD ON DRD.ID=SOS.IDFrom
                                left join PubStock pst on pst.ID=sos.StockID
                                left join salreturn drd1 on drd1.id=sos.idfrom
                                left join delshoreturn drd2 on drd2.id=sos.idfrom
                                left join delreachsmall drd3 on drd3.id=sos.idfrom
                                left join PubMaterial pm on pm.id=drd.matid
                                where sos.CorpID=1190056 and sos.AutoCode like @AutoCode
                                order by GrossTime desc";
                return (List<V_SacOutSuperviseMD>)sc.Query<V_SacOutSuperviseMD>(sql, new { AutoCode = AutoCode });
            }
        }
        #endregion


        #region 根据通知单号查询发货信息
        /// <summary>
        /// 根据通知单号查询发货信息
        /// </summary>
        /// <param name="BilNo">通知单号</param>        
        /// <returns>发货信息</returns>
        public List<V_SacOutSuperviseMD> getSacOutSuperviseByBilNo(string BilNo)
        {
            string connection = PubClass.getConnecion();
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"select  sos.id,sos.corpid,sos.bilidfrom,sos.IDFrom,sos.AutoCode,sos.Driver,sos.InLine,sos.StockID,pst.Name StockName,sos.QtyTare,sos.TareTime,sos.TareStfID,ps.name TareStfName,
                                sos.QtyGross,sos.GrossTime,sos.GrossStfID,ps1.Name GrossStfName,sos.BeginLoadStfID,ps2.Name BeginLoadStfName,sos.BeginLoadTime,sos.EndLoadStfID,ps3.Name EndLoadStfName
                                ,sos.EndLoadTime,sos.QCID,sos.PassStfID,ps4.Name PassStfName,sos.PassTime
                                ,sos.CreateStfID,ps5.Name CreateStfName,sos.CreateTime,sos.Rem,sos.SuperviseID,sos.SuperviseIndex,sos.UpIndex,sos.MultKeyID ,
                                case when sos.BilIDFrom='DERC' THEN DRD.BilNo 
                                when sos.BilIDFrom='DESR' then drd2.BilNo
                                when sos.BilIDFrom='SAR' then drd1.BilNo
                                when sos.BilIDFrom='SDERC' then drd3.BilNo
                                END as BilNo,drd.MatID,pm.name MatName,drd.ToCust
                                from SacOutSupervise sos 
                                left join PubStaff ps on ps.id=sos.TareStfID
                                left join PubStaff ps1 on ps1.id=sos.GrossStfID
                                left join PubStaff ps2 on ps2.id=sos.BeginLoadStfID
                                left join PubStaff ps3 on ps3.id=sos.EndLoadStfID
                                left join PubStaff ps4 on ps4.id=sos.PassStfID 
                                left join PubStaff ps5 on ps5.id=sos.CreateStfID
                                LEFT JOIN DelReachDtl DRD ON DRD.ID=SOS.IDFrom
                                left join PubStock pst on pst.ID=sos.StockID
                                left join salreturn drd1 on drd1.id=sos.idfrom
                                left join delshoreturn drd2 on drd2.id=sos.idfrom
                                left join delreachsmall drd3 on drd3.id=sos.idfrom
                                left join PubMaterial pm on pm.id=drd.matid
                                where sos.CorpID=1190056 and DRD.BilNo like @BilNo
                                order by GrossTime desc";
                return (List<V_SacOutSuperviseMD>)sc.Query<V_SacOutSuperviseMD>(sql, new { BilNo = BilNo });
            }
        }
        #endregion

        #region 根据来源单号单号查询发货信息
        /// <summary>
        /// 根据来源单号单号查询发货信息
        /// </summary>
        /// <param name="BilNo">来源单号单号</param>        
        /// <returns>发货信息</returns>
        public List<V_SacOutSuperviseMD> getSacOutSuperviseByIDFrom(string BilNo)
        {
            string connection = PubClass.getConnecion();
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"select * from sacoutsupervise where corpid='1190056' and IDFrom=@BilNo";
                return (List<V_SacOutSuperviseMD>)sc.Query<V_SacOutSuperviseMD>(sql, new { BilNo = BilNo });
            }
        }
        #endregion


        #region 根据物料查询发货信息
        /// <summary>
        /// 根据物料查询发货信息
        /// </summary>
        /// <param name="MatName">物料</param>        
        /// <returns>发货信息</returns>
        public List<V_SacOutSuperviseMD> getSacOutSuperviseByMatName(string MatName)
        {
            string connection = PubClass.getConnecion();
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"select  sos.id,sos.corpid,sos.bilidfrom,sos.IDFrom,sos.AutoCode,sos.Driver,sos.InLine,sos.StockID,pst.Name StockName,sos.QtyTare,sos.TareTime,sos.TareStfID,ps.name TareStfName,
                                sos.QtyGross,sos.GrossTime,sos.GrossStfID,ps1.Name GrossStfName,sos.BeginLoadStfID,ps2.Name BeginLoadStfName,sos.BeginLoadTime,sos.EndLoadStfID,ps3.Name EndLoadStfName
                                ,sos.EndLoadTime,sos.QCID,sos.PassStfID,ps4.Name PassStfName,sos.PassTime
                                ,sos.CreateStfID,ps5.Name CreateStfName,sos.CreateTime,sos.Rem,sos.SuperviseID,sos.SuperviseIndex,sos.UpIndex,sos.MultKeyID ,
                                case when sos.BilIDFrom='DERC' THEN DRD.BilNo 
                                when sos.BilIDFrom='DESR' then drd2.BilNo
                                when sos.BilIDFrom='SAR' then drd1.BilNo
                                when sos.BilIDFrom='SDERC' then drd3.BilNo
                                END as BilNo,drd.MatID,pm.name MatName,drd.ToCust
                                from SacOutSupervise sos 
                                left join PubStaff ps on ps.id=sos.TareStfID
                                left join PubStaff ps1 on ps1.id=sos.GrossStfID
                                left join PubStaff ps2 on ps2.id=sos.BeginLoadStfID
                                left join PubStaff ps3 on ps3.id=sos.EndLoadStfID
                                left join PubStaff ps4 on ps4.id=sos.PassStfID 
                                left join PubStaff ps5 on ps5.id=sos.CreateStfID
                                LEFT JOIN DelReachDtl DRD ON DRD.ID=SOS.IDFrom
                                left join PubStock pst on pst.ID=sos.StockID
                                left join salreturn drd1 on drd1.id=sos.idfrom
                                left join delshoreturn drd2 on drd2.id=sos.idfrom
                                left join delreachsmall drd3 on drd3.id=sos.idfrom
                                left join PubMaterial pm on pm.id=drd.matid
                                where sos.CorpID=1190056 and pm.name= @MatName
                                order by GrossTime desc";
                return (List<V_SacOutSuperviseMD>)sc.Query<V_SacOutSuperviseMD>(sql, new { MatName = MatName });
            }
        }
        #endregion

        #region 根据客户查询发货信息
        /// <summary>
        /// 根据客户查询发货信息
        /// </summary>
        /// <param name="ToCust">客户</param>        
        /// <returns>发货信息</returns>
        public List<V_SacOutSuperviseMD> getSacOutSuperviseByToCust(string ToCust)
        {
            string connection = PubClass.getConnecion();
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"select  sos.id,sos.corpid,sos.bilidfrom,sos.IDFrom,sos.AutoCode,sos.Driver,sos.InLine,sos.StockID,pst.Name StockName,sos.QtyTare,sos.TareTime,sos.TareStfID,ps.name TareStfName,
                                sos.QtyGross,sos.GrossTime,sos.GrossStfID,ps1.Name GrossStfName,sos.BeginLoadStfID,ps2.Name BeginLoadStfName,sos.BeginLoadTime,sos.EndLoadStfID,ps3.Name EndLoadStfName
                                ,sos.EndLoadTime,sos.QCID,sos.PassStfID,ps4.Name PassStfName,sos.PassTime
                                ,sos.CreateStfID,ps5.Name CreateStfName,sos.CreateTime,sos.Rem,sos.SuperviseID,sos.SuperviseIndex,sos.UpIndex,sos.MultKeyID ,
                                case when sos.BilIDFrom='DERC' THEN DRD.BilNo 
                                when sos.BilIDFrom='DESR' then drd2.BilNo
                                when sos.BilIDFrom='SAR' then drd1.BilNo
                                when sos.BilIDFrom='SDERC' then drd3.BilNo
                                END as BilNo,drd.MatID,pm.name MatName,drd.ToCust
                                from SacOutSupervise sos 
                                left join PubStaff ps on ps.id=sos.TareStfID
                                left join PubStaff ps1 on ps1.id=sos.GrossStfID
                                left join PubStaff ps2 on ps2.id=sos.BeginLoadStfID
                                left join PubStaff ps3 on ps3.id=sos.EndLoadStfID
                                left join PubStaff ps4 on ps4.id=sos.PassStfID 
                                left join PubStaff ps5 on ps5.id=sos.CreateStfID
                                LEFT JOIN DelReachDtl DRD ON DRD.ID=SOS.IDFrom
                                left join PubStock pst on pst.ID=sos.StockID
                                left join salreturn drd1 on drd1.id=sos.idfrom
                                left join delshoreturn drd2 on drd2.id=sos.idfrom
                                left join delreachsmall drd3 on drd3.id=sos.idfrom
                                left join PubMaterial pm on pm.id=drd.matid
                                where sos.CorpID=1190056 and drd.ToCust= @ToCust
                                order by GrossTime desc";
                return (List<V_SacOutSuperviseMD>)sc.Query<V_SacOutSuperviseMD>(sql, new { ToCust = ToCust });
            }
        }
        #endregion

        #region 根据时间查询发货信息
        /// <summary>
        /// 根据时间查询发货信息
        /// </summary>
        /// <param name="datetimeStart">开始时间</param>
        /// <param name="datetimeEnd">结束时间</param>
        /// <returns>发货信息</returns>
        public List<V_SacOutSuperviseMD> getSacOutSuperviseByAutoCode(DateTime datetimeStart, DateTime datetimeEnd,string AutoCode)
        {
            try
            {
                string connection = PubClass.getConnecion();
                using (SqlConnection sc = new SqlConnection(connection))
                {
                    string sql = @"select  sos.id,sos.corpid,sos.bilidfrom,sos.IDFrom,sos.AutoCode,sos.Driver,sos.InLine,sos.StockID,pst.Name StockName,sos.QtyTare,sos.TareTime,sos.TareStfID,ps.name TareStfName,
                                sos.QtyGross,sos.GrossTime,sos.GrossStfID,ps1.Name GrossStfName,sos.BeginLoadStfID,ps2.Name BeginLoadStfName,sos.BeginLoadTime,sos.EndLoadStfID,ps3.Name EndLoadStfName
                                ,sos.EndLoadTime,sos.QCID,sos.PassStfID,ps4.Name PassStfName,sos.PassTime
                                ,sos.CreateStfID,ps5.Name CreateStfName,sos.CreateTime,sos.Rem,sos.SuperviseID,sos.SuperviseIndex,sos.UpIndex,sos.MultKeyID ,
                                case when sos.BilIDFrom='DERC' THEN DRD.BilNo 
                                when sos.BilIDFrom='DESR' then drd2.BilNo
                                when sos.BilIDFrom='SAR' then drd1.BilNo
                                when sos.BilIDFrom='SDERC' then drd3.BilNo
                                END BilNo,drd.MatID,pm.name MatName,drd.ToCust
                                from SacOutSupervise sos 
                                left join PubStaff ps on ps.id=sos.TareStfID
                                left join PubStaff ps1 on ps1.id=sos.GrossStfID
                                left join PubStaff ps2 on ps2.id=sos.BeginLoadStfID
                                left join PubStaff ps3 on ps3.id=sos.EndLoadStfID
                                left join PubStaff ps4 on ps4.id=sos.PassStfID 
                                left join PubStaff ps5 on ps5.id=sos.CreateStfID
                                LEFT JOIN DelReachDtl DRD ON DRD.ID=SOS.IDFrom
                                left join PubStock pst on pst.ID=sos.StockID
                                left join salreturn drd1 on drd1.id=sos.idfrom
                                left join delshoreturn drd2 on drd2.id=sos.idfrom
                                left join delreachsmall drd3 on drd3.id=sos.idfrom
                                left join PubMaterial pm on pm.id=drd.matid
                                where sos.CorpID=1190056 and sos.AutoCode=@AutoCode and sos.GrossTime between @datetimeStart and @datetimeEnd
                                order by GrossTime desc";
                    return (List<V_SacOutSuperviseMD>)sc.Query<V_SacOutSuperviseMD>(sql, new { datetimeStart = datetimeStart, datetimeEnd = datetimeEnd, AutoCode = AutoCode });
                }
            }
            catch (Exception)
            {

                return null;
            }
        }
        #endregion

        #region 根据ID修改合格证编号
        /// <summary>
        /// 根据ID修改合格证编号
        /// </summary>
        
        public List<V_SacOutSuperviseMD> UpDataOrderNo(long ID,String OrderNo)
        {
            try
            {
                string connection = PubClass.getConnecion();
                using (SqlConnection sc = new SqlConnection(connection))
                {
                    string sql = @"UPDATE [dbo].[SacOutSupervise]
                           SET QtyCheck15 = @QtyCheck15      
                         WHERE  CorpID='1190056' AND ID=@ID";
                    return (List<V_SacOutSuperviseMD>)sc.Query<V_SacOutSuperviseMD>(sql, new { @QtyCheck15= OrderNo, @ID =ID});
                }
            }
            catch (Exception)
            {

                return null;
            }
        }
        #endregion

    }
}
