using DA.DAL;
using DA.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.BLL
{
    public class StcStockShiftdtlManager
    {
        /// <summary>
        /// 根据时间获取调拨单列表
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<StcStockShiftDtlMD> getSSSByDate(DateTime startTime, DateTime endTime)
        {
            StcStockShiftDtlService stcStockShiftDtlService = new StcStockShiftDtlService();
            return stcStockShiftDtlService.getSSSByDate(startTime, endTime);
        }
        /// <summary>
        /// 根据ID获取调拨单列表
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<StcStockShiftDtlMD> getSSSByID(long ID)
        {
            StcStockShiftDtlService stcStockShiftDtlService = new StcStockShiftDtlService();
            return stcStockShiftDtlService.getSSSByID(ID);
        }
        /// <summary>
        /// 根据ID更新调拨单体列表
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public bool UpdataSSSDtlByID(long ID, DateTime bilDate, DateTime createTime, DateTime checkTime, DateTime effectTime, DateTime printTime)
        {
            StcStockShiftDtlService stcStockShiftDtlService = new StcStockShiftDtlService();
            return stcStockShiftDtlService.UpdataSSSDtlByID(ID,bilDate,createTime,checkTime,effectTime,printTime);
        }
        /// <summary>
        /// 根据ID更新调拨单头列表
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public bool UpdataSSSByID(long ID, DateTime bilDate)
        {
            StcStockShiftDtlService stcStockShiftDtlService = new StcStockShiftDtlService();
            return stcStockShiftDtlService.UpdataSSSByID(ID, bilDate);
        }
        /// <summary>
        /// 根据ID更新监装列表
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public bool UpdataSasByID(long ID, DateTime grossTime)
        {
            StcStockShiftDtlService stcStockShiftDtlService = new StcStockShiftDtlService();
            return stcStockShiftDtlService.UpdataSasByID(ID, grossTime);
        }
    }
}
