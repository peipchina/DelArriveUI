using DA.DAL;
using DA.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.BLL
{
    public class GrossQtyManager
    {
        #region 根据车号获取毛重
        /// <summary>
        /// 根据车号获取毛重
        /// </summary>
        /// <param name="AutoCode"></param>
        /// <returns>车号</returns>
        public List<V_GrossQtyMD> getGrossQtyByAutoCode(string AutoCode)
        {
            GrossQtyService Gqs = new GrossQtyService();
            return Gqs.getGrossQtyByAutoCode(AutoCode);
        }
        #endregion

        #region 根据车号获取毛重
        /// <summary>
        /// 根据车号获取毛重
        /// </summary>
        /// <param name="AutoCode"></param>
        /// <returns>车号</returns>
        public List<V_GrossQtyMD> getGrossQtyByAutoCodelike(string AutoCode)
        {
            GrossQtyService Gqs = new GrossQtyService();
            return Gqs.getGrossQtyByAutoCodeLike(AutoCode);
        }
        #endregion

        #region 根据车号获取毛重
        /// <summary>
        /// 根据车号获取毛重
        /// </summary>
        /// <param name="AutoCode"></param>
        /// <returns>车号</returns>
        public List<V_GrossQtyMD> getGrossQtyByAutoCodeBykv0866()
        {
            GrossQtyService Gqs = new GrossQtyService();
            return Gqs.getGrossQtyByAutoCodeBykv0866();
        }
        #endregion
    }
}
