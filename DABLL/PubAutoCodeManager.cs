using DA.DAL;
using DA.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.BLL
{
    public class PubAutoCodeManager
    {
        /// <summary>
        /// 根据车牌识别车号查询毛重及皮重时间
        /// </summary>
        /// <param name="AutoCode">自动识别的车号</param>
        /// <returns>监装表</returns>
        public List<PubAutoCodeMD> GetPubAutoCode()
        {
            PubAutoCodeService pubAutoCodeService = new PubAutoCodeService();
            return pubAutoCodeService.GetPubAutoCode();
        }
    }
}
