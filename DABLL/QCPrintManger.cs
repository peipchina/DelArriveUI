using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.MODEL;
using DA.DAL;

namespace DA.BLL
{
    public class QCPrintManger
    {
        #region 根据时间获取打印模板所需要的出厂记录
        /// <summary>
        /// 根据时间获取打印模板所需要的发货单
        /// </summary>
        /// <param name="PassTimeStart">开始时间</param>
        /// <param name="PassTimeEnd">结束时间</param>
        /// <returns>出厂资料</returns>
        public List<V_QCPrintMD> getAllQCPrintListByDate(DateTime PassTimeStart, DateTime PassTimeEnd)
        {
            QCPrintServiec qs = new QCPrintServiec();
            return qs.getAllQCPrintListByDate(PassTimeStart,PassTimeEnd);
        }
        #endregion

        #region 获取当天时间打印模板所需要的出厂记录
        /// <summary>
        /// 获取当天时间打印模板所需要的出厂记录
        /// </summary>        
        /// <returns>出厂资料</returns>
        public List<V_QCPrintMD> getAllQCPrintList()
        {
            QCPrintServiec qs = new QCPrintServiec();
            return qs.getAllQCPrintList();
        
        }
        #endregion

    }
}
