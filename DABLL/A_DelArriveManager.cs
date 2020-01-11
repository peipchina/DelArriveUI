using DA.DAL;
using DA.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.BLL
{
    public class A_DelArriveManager
    {
        /// <summary>
        /// 获取最近一次保存的资料
        /// </summary>
        /// <param name="newcreatetime"></param>
        /// <returns></returns>
        public List<A_DelArriveMD> Get180List(DateTime newcreatetime)
        {
            A_DelArriveService a_DelArriveService = new A_DelArriveService();
            return a_DelArriveService.Get180List(newcreatetime);
        }
        /// <summary>
        /// 获取最新数据
        /// </summary>
        /// <returns></returns>
        public List<GetLastTime> getLastData()
        {
            A_DelArriveService a_DelArriveService = new A_DelArriveService();
            return a_DelArriveService.getLastData();
        }
    }
}
