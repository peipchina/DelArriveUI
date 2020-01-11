using DA.DAL;
using DA.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.BLL
{
    public class PubDelINManager
    {
        #region 根据登录名获取所有信息
        /// <summary>
        /// 根据登录名获取所有信息
        /// </summary>
        /// <param name="lonname"></param>
        /// <returns>登录信息</returns>
        public List<PubDelInMD> getPassWordByLoginName(string lonname)
        {
            PubDelINService pl = new PubDelINService();
            return pl.getPassWordByLoginName(lonname);
        }
        #endregion

        #region 修改密码
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="lonname"></param>
        /// <returns>影响行</returns>
        public bool UpPassWord(PubDelInMD pdi)
        {
            PubDelINService pds = new PubDelINService();
            int up = pds.UpPassWord(pdi);
            bool upd= up > 0 ? true : false;
            return upd;
        }
        #endregion
    }
}
