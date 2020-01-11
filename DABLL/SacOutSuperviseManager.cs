using DA.DAL;
using DA.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.BLL
{
    public class SacOutSuperviseManager
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
            SacOutSuperviseService soss = new SacOutSuperviseService();
            return soss.getSacOutSupervise(datetimeStart,datetimeEnd);
        }
        #endregion
        #region 根据车号查询发货信息
        /// <summary>
        /// 根据车号及时间查询发货信息
        /// </summary>
        /// <param name="AutoCode">车号</param>        
        /// <returns>发货信息</returns>
        public List<V_SacOutSuperviseMD> getSacOutSuperviseByAutoCodeAndTime(string AutoCode, DateTime dateTime)
        {
            SacOutSuperviseService soss = new SacOutSuperviseService();
            return soss.getSacOutSuperviseByAutoCodeAndTime(AutoCode, dateTime);
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
            SacOutSuperviseService soss = new SacOutSuperviseService();
            return soss.getSacOutSuperviseByAutoCode(AutoCode);
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
            SacOutSuperviseService soss = new SacOutSuperviseService();
            return soss.getSacOutSuperviseByBilNo(BilNo);
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
            SacOutSuperviseService soss = new SacOutSuperviseService();
            return soss.getSacOutSuperviseByIDFrom(BilNo);
        }
        #endregion

        #region 根据物料名查询发货信息
        /// <summary>
        /// 根据物料名查询发货信息
        /// </summary>
        /// <param name="BilNo">物料名</param>        
        /// <returns>发货信息</returns>
        public List<V_SacOutSuperviseMD> getSacOutSuperviseMatName(string MatName)
        {
            SacOutSuperviseService soss = new SacOutSuperviseService();
            return soss.getSacOutSuperviseByMatName(MatName);
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
            SacOutSuperviseService soss = new SacOutSuperviseService();
            return soss.getSacOutSuperviseByToCust(ToCust);
        }
        #endregion

        #region 根据时间查询发货信息
        /// <summary>
        /// 根据时间查询发货信息
        /// </summary>
        /// <param name="datetimeStart">开始时间</param>
        /// <param name="datetimeEnd">结束时间</param>
        /// <returns>发货信息</returns>
        public List<V_SacOutSuperviseMD> getSacOutSuperviseByAutoCode(DateTime datetimeStart, DateTime datetimeEnd, string AutoCode)
        {
            SacOutSuperviseService soss = new SacOutSuperviseService();
            return soss.getSacOutSuperviseByAutoCode(datetimeStart,datetimeEnd,AutoCode);
        }

        #endregion

        #region 根据ID修改合格证编号
        /// <summary>
        /// 根据ID修改合格证编号
        /// </summary>

        public List<V_SacOutSuperviseMD> UpDataOrderNo(long ID, String OrderNo)
        {
            SacOutSuperviseService soss = new SacOutSuperviseService();
            return soss.UpDataOrderNo( ID,OrderNo);
        }
        #endregion

    }
}
