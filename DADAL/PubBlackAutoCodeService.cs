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
   public class PubBlackAutoCodeService
    {
        #region 获取黑名单列表
        /// <summary>
        /// 获取黑名单列表
        /// </summary>
        /// <returns>司机黑名单</returns>
        public List<PubBlackAutoCodeMD> getPubBlackCode()
        {
            string connection = PubClass.getConnecion180();
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"SELECT  [ID]
                          ,[AutoCode]
                          ,[Driver]
                          ,[BlackTime]
                          ,[reason]
                          ,[CheckName]
                          ,[Results]
                          ,[CreatName]
                      FROM [BohiErp].[dbo].[PubBlackAutoCode] where isdelete=0";
                return (List<PubBlackAutoCodeMD>)sc.Query<PubBlackAutoCodeMD>(sql, null);
            }

        }
        #endregion

        #region 删除黑名单
        /// <summary>
        /// 删除黑名单
        /// </summary>
        /// <returns>司机黑名单</returns>
        public bool DeleteBlackCode(int ID,string deleteRem,DateTime dateTime)
        {
            string connection = PubClass.getConnecion180();
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"UPDATE [BohiErp].[dbo].[PubBlackAutoCode]
                               SET 
                                  [IsDelete] = 1
                                  ,[DeleteRem] = @DeleteRem
                                  ,[DeleteTime] = @DeleteTime
                             WHERE ID=@ID";
                return sc.Execute(sql,new { ID= ID, DeleteTime= dateTime, DeleteRem = deleteRem })>0;
            }

        }
        #endregion
        private long getDelLeave(string BilNoNeedToModify)
        {
            string connection = PubClass.getConnecion();
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @" SELECT dr.ID FROM DelLeaveDtl dld
				                        left join DelReach dr on dr.ID=dld.IDFrom
				                        where dld.BilNo=@BilNoNeedToModify
					                        and dld.Item=1 ";
                return sc.Execute(sql, new { BilNoNeedToModify = BilNoNeedToModify });
            }
        }
        private long getStcStock(string BilNoNeedToModify)
        {
            string connection = PubClass.getConnecion();
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"SELECT dr.ID FROM StcStockShiftDtl dld
				                        left join DelReach dr on dr.ID=dld.IDFrom
				                        where dld.BilNo=@BilNoNeedToModify
					                        and dld.Item=1";
                return sc.Execute(sql, new { BilNoNeedToModify = BilNoNeedToModify });
            }
        }
        #region 修改出厂日期
        /// <summary>
        /// 修改出厂日期
        /// </summary>
        /// <returns>修改出厂日期</returns>
        public bool ChangeTime(string no,  DateTime changeTime)
        {
            string noid = no.Substring(0,4);
            long idOfDel = 0;
            if (noid == "DELV")
            {

            }
            string connection = PubClass.getConnecion();
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"         update DelLeaveDtl set
				                        BilDate=@userGrossTime
				                        where BilNo=@BilNoNeedToModify
			                        update DelLeave set
				                        BilDate=@userGrossTime,
				                        CreateTime=@userGrossTime,
				                        CheckTime=@userGrossTime,
				                        EffectTime=@userGrossTime
				                        where BilNo=@BilNoNeedToModify
			                        update SacOutSupervise set
				                        GrossTime=@userGrossTime
				                        where IDFrom=@IDOfDelReach
		                        END
	                        ELSE
		                        BEGIN
			                        SELECT @IDOfDelReach=dr.ID FROM StcStockShiftDtl dld
				                        left join DelReach dr on dr.ID=dld.IDFrom
				                        where dld.BilNo=@BilNoNeedToModify
					                        and dld.Item=1	
			                        update StcStockShift set
				                        BilDate=@userGrossTime,
				                        CreateTime=@userGrossTime,
				                        CheckTime=@userGrossTime,
				                        EffectTime=@userGrossTime,
				                        PrintTime=@userGrossTime
				                        where bilno=@BilNoNeedToModify
	
			                        update StcStockShiftDtl set
				                        BilDate=@userGrossTime
				                        where bilno=@BilNoNeedToModify
				
			                        update SacOutSupervise set
				                        GrossTime=@userGrossTime
				                        where IDFrom=@IDOfDelReach
		                        END
                        END";
                return sc.Execute(sql, new { no = no, changeTime = changeTime}) > 0;
            }

        }
        #endregion

        #region 获取黑名单列表
        /// <summary>
        /// 获取黑名单列表
        /// </summary>
        /// <returns>司机黑名单</returns>
        public int InsertPubBlackCode180(PubBlackAutoCodeMD pubBlack)
        {
            string connection =PubClass.getConnecion180();
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"INSERT INTO [BohiErp].[dbo].[PubBlackAutoCode]
                               ([AutoCode]
                               ,[Driver]
                               ,[BlackTime]
                               ,[reason]
                               ,[CheckName]
                               ,[Results]
                               ,[CreatName])
                         VALUES
                               (@AutoCode
                               ,@Driver
                               ,@BlackTime
                               ,@reason
                               ,@CheckName
                               ,@Results
                               ,@CreatName)";
                int a= sc.Execute(sql,pubBlack);
                return a;
            }

        }
        #endregion

    }
}
