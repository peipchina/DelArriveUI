using DA.DAL;
using DA.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.BLL
{
    public class A_ReachArriveManager
    {
        public List<A_ReachArriveMD> Get180List(DateTime newcreatetime)
        {
            A_ReachArriveService a_ReachArriveService = new A_ReachArriveService();
            return a_ReachArriveService.Get180List(newcreatetime);
        }
        /// <summary>
        /// 获取最新数据
        /// </summary>
        /// <returns></returns>
        public List<GetLastTime> getLastData()
        {
            A_ReachArriveService a_ReachArriveService = new A_ReachArriveService();
            return a_ReachArriveService.getLastData();
        }
    }
}
