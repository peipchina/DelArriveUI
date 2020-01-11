using DA.DAL;
using DA.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.BLL
{
    public class DelAlloAutoManager
    {
        public List<DelAlloAutoMD> getDelAlloAuto(DateTime startTime, DateTime endTime)
        {
            DelAlloAutoService delAlloAutoService = new DelAlloAutoService();
            return delAlloAutoService.getDelAlloAuto(startTime,endTime);
        }
        /// <summary>
        /// 修改客户运价
        /// </summary>
        /// <param name="BilNo"></param>
        /// <param name="My1_UDsg"></param>
        /// <returns></returns>
        public bool UpdateDelAlloAuto(long ID, Decimal My1_UDsg)
        {
            DelAlloAutoService delAlloAutoService = new DelAlloAutoService();
            return delAlloAutoService.UpdateDelAlloAuto(ID, My1_UDsg);
        }
        public List<DelAlloAutoDtlMD> getDelAlloAutoDTL(DateTime startTime, DateTime endTime)
        {
            DelAlloAutoService delAlloAutoService = new DelAlloAutoService();
            return delAlloAutoService.getDelAlloAutoDTL(startTime, endTime);
        }
        /// <summary>
        /// 修改实际运价
        /// </summary>
        /// <param name="BilNo"></param>
        /// <param name="My1_UDsg"></param>
        /// <returns></returns>
        public bool UpdateDelAlloAutoDtl(long ID, Decimal PriceFrei)
        {
            DelAlloAutoService delAlloAutoService = new DelAlloAutoService();
            return delAlloAutoService.UpdateDelAlloAutoDtl(ID, PriceFrei);
        }
    }
}
