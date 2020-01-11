using DA.DAL;
using DA.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.BLL
{
    public class DelLeaveDtlManager
    {
        /// <summary>
        /// 发货单
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<DelLeaveDtlMD> getDelLeave(DateTime startTime, DateTime endTime)
        {
            DelLeaveDtlService delArriveServiece = new DelLeaveDtlService();
            return delArriveServiece.getDelLeave(startTime, endTime);
        }
        public List<DelLeaveDtlMD> getDelLeaveByBilNo(string BilNo)
        {
            DelLeaveDtlService delArriveServiece = new DelLeaveDtlService();
            return delArriveServiece.getDelLeaveByBilNo(BilNo);
        }
        public List<DelLeaveDtlMD> getDelLeaveHeadByBilNo(string BilNo)
        {

            DelLeaveDtlService delArriveServiece = new DelLeaveDtlService();
            return delArriveServiece.getDelLeaveHeadByBilNo(BilNo);
        }
        /// <summary>
        /// 更新发货单
        /// </summary>
        /// <param name="delLeaveDtlMD"></param>
        /// <returns></returns>
        public bool updataDelLeave(DelLeaveDtlMD delLeaveDtlMD)
        {
            DelLeaveDtlService delArriveServiece = new DelLeaveDtlService();
            bool a= delArriveServiece.UpdataDelLeaveDtl(delLeaveDtlMD);
            bool b = delArriveServiece.UpdataDelLeave(delLeaveDtlMD);
            bool c = delArriveServiece.UpdataSacOutSupervise(delLeaveDtlMD);
            return c;
        }
        /// <summary>
        /// 库存调拨
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<DLMD> getReachAuto(DateTime startTime, DateTime endTime)
        {
            DelLeaveDtlService delArriveServiece = new DelLeaveDtlService();
            return delArriveServiece.getReachAuto(startTime, endTime);
        }
        /// <summary>
        /// 更新库存调拨
        /// </summary>
        /// <param name="delLeaveDtlMD"></param>
        /// <returns></returns>
        public bool updataStcStockShiftDtl(DLMD delLeaveDtlMD)
        {
            DelLeaveDtlService delArriveServiece = new DelLeaveDtlService();
            bool a = delArriveServiece.UpdataStcStockShift(delLeaveDtlMD);
            bool b = delArriveServiece.UpdataStcStockShiftDtl(delLeaveDtlMD);
            bool c = delArriveServiece.UpdataSacOutSupervise1(delLeaveDtlMD);
            return c;
        }
    }
}
