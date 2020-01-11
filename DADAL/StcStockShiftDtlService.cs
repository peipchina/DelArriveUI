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
    public class StcStockShiftDtlService
    {
        /// <summary>
        /// 根据时间获取调拨单列表
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<StcStockShiftDtlMD> getSSSByDate(DateTime startTime ,DateTime endTime)
        {
            using (SqlConnection sc = new SqlConnection(PubClass.getConnecion()))
            {
                string sql = @"select * from StcStockShiftdtl where CorpID='1190056' and BilDate between @startTime and @endTime";
                return (List<StcStockShiftDtlMD>)sc.Query<StcStockShiftDtlMD>(sql, new { startTime = startTime, endTime = endTime });
            }
        }
        /// <summary>
        /// 根据ID获取调拨单列表
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<StcStockShiftDtlMD> getSSSByID(long ID)
        {
            using (SqlConnection sc = new SqlConnection(PubClass.getConnecion()))
            {
                string sql = @"select * from StcStockShift where CorpID='1190056' and ID=@ID";
                return (List<StcStockShiftDtlMD>)sc.Query<StcStockShiftDtlMD>(sql, new { ID = ID });
            }
        }
        /// <summary>
        /// 根据ID更新调拨单体列表
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public bool UpdataSSSDtlByID(long ID,DateTime bilDate,DateTime createTime,DateTime checkTime,DateTime effectTime,DateTime printTime)
        {
            using (SqlConnection sc = new SqlConnection(PubClass.getConnecion()))
            {
                string sql = @"UPDATE StcStockShiftDtl SET BilDate=@bilDate,
                    CreateTime=@createTime,checkTime=@checkTime,EffectTime=@effectTime,PrintTime=@printTime
                    WHERE CorpID='1190056' and ID=@ID ";
                return sc.Execute(sql, new { ID = ID , bilDate = bilDate, createTime= createTime, checkTime= checkTime, effectTime= effectTime, printTime= printTime })>0;
            }
        }
        /// <summary>
        /// 根据ID更新调拨单头列表
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public bool UpdataSSSByID(long ID, DateTime bilDate)
        {
            using (SqlConnection sc = new SqlConnection(PubClass.getConnecion()))
            {
                string sql = @"UPDATE StcStockShiftDtl SET BilDate=@bilDate WHERE CorpID='1190056' and ID=@ID ";
                return sc.Execute(sql, new { ID = ID, bilDate = bilDate })>0;
            }
        }
        /// <summary>
        /// 根据ID更新监装列表
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public bool UpdataSasByID(long ID, DateTime grossTime)
        {
            using (SqlConnection sc = new SqlConnection(PubClass.getConnecion()))
            {
                string sql = @"UPDATE sacoutsupervise SET GrossTime=@grossTime WHERE CorpID='1190056' and ID=@ID ";
                return sc.Execute(sql, new { ID = ID, grossTime = grossTime })>0;
            }
        }
    }
}
