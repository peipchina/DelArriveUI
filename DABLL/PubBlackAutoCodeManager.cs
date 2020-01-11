using DA.DAL;
using DA.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.BLL
{
    public class PubBlackAutoCodeManager
    {
        public bool ChangeTime(string no, DateTime changeTime)
        {
            PubBlackAutoCodeService ps = new PubBlackAutoCodeService();
            return ps.ChangeTime(no,changeTime);
        }
            #region 获取黑名单列表
            /// <summary>
            /// 获取黑名单列表
            /// </summary>
            /// <returns>司机黑名单</returns>
            public List<PubBlackAutoCodeMD> getPubBlackCode()
        {
            PubBlackAutoCodeService ps = new PubBlackAutoCodeService();
            return ps.getPubBlackCode();
        }
        #endregion

        #region 删除黑名单
        /// <summary>
        /// 删除黑名单
        /// </summary>
        /// <returns>司机黑名单</returns>
        public bool DeleteBlackCode(int ID, string deleteRem,DateTime dateTime)
        {
            PubBlackAutoCodeService ps = new PubBlackAutoCodeService();
            return ps.DeleteBlackCode(ID, deleteRem, dateTime);

        }
        #endregion

        #region 获取黑名单列表
        /// <summary>
        /// 获取黑名单列表
        /// </summary>
        /// <returns>司机黑名单</returns>
        public bool InsertPubBlackCode180(PubBlackAutoCodeMD pubBlack)
        {
            PubBlackAutoCodeService pb = new PubBlackAutoCodeService();
            int a= pb.InsertPubBlackCode180(pubBlack);
            bool b;
            if (a > 0)
            {
                b = true;
            }
            else
            {
                b = false;
            }
            return b;
        }
        #endregion
    }
}
