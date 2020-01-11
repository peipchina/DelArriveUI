using DA.DAL;
using DA.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.BLL
{
    public class A_DelReachManager
    {
        /// <summary>
        /// 获取最近一次保存的资料
        /// </summary>
        /// <param name="newcreatetime"></param>
        /// <returns></returns>
        public List<A_DelReachMD> Get180List(DateTime newcreatetime)
        {
            A_DelReachService a_DelArriveService = new A_DelReachService();
            return a_DelArriveService.Get180List(newcreatetime);
        }
        /// <summary>
        /// 获取最新数据
        /// </summary>
        /// <returns></returns>
        public List<GetLastTime> getLastData()
        {
            A_DelReachService a_DelArriveService = new A_DelReachService();
            return a_DelArriveService.getLastData();
        }
    }
}
