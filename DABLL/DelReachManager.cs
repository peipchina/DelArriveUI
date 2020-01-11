using DA.DAL;
using DA.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.BLL
{
    public class DelReachManager
    {
        #region 排队未配车
        /// <summary>
        /// 排队未配车
        /// </summary>
        /// <returns></returns>
        public List<V_DelReachMD> getReachAuto()
        {
            DelReachService drs = new DelReachService();
            return drs.getReachAuto();
        }
        #endregion

        #region 根据单据时间获取通知单信息
        /// <summary>
        /// 根据单据时间获取通知单信息
        /// </summary>
        /// <param name="BilDate">单据时间</param>
        /// <returns>通知单对象</returns>
        public List<V_DelReachDtlMD> getAllDelReachDtlByBilDate(DateTime DateStart, DateTime DateEnd)
        {
            DelReachService drs = new DelReachService();
            return drs.getAllDelReachDtlByBilDate(DateStart,DateEnd);
        }
        #endregion

        #region 根据单据ID获取通知单信息
        /// <summary>
        /// 根据单据ID获取通知单信息
        /// </summary>
        /// <param name="ID">ID</param>
        /// <returns>通知单对象</returns>
        public List<V_DelReachDtlMD> getAllDelReachDtlByBilID(long? BilNO)
        {
            DelReachService drs = new DelReachService();
            return drs.getAllDelReachDtlByBilID(BilNO);
        }
        #endregion

        #region 根据车号获取通知单信息
        /// <summary>
        /// 根据车号获取通知单信息
        /// </summary>
        /// <param name="AutoCode">车号</param>
        /// <returns>通知单对象</returns>
        public List<V_DelReachDtlMD> getAllDelReachDtlByAutoCode(string autoCode)
        {
            DelReachService drs = new DelReachService();
            return drs.getAllDelReachDtlByAutoCode(autoCode);
        }
        #endregion
        

    }
}
