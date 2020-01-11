using DA.DAL;
using DA.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.BLL
{
    public class PurAlloShoManager
    {
        public List<PurAlloShoMD> getDelAlloAuto(DateTime startTime, DateTime endTime)
        {
            PurAlloShoService purAlloShoService = new PurAlloShoService();
            return purAlloShoService.getPurAlloSho(startTime,endTime);
        }
        /// <summary>
        /// 停用车号
        /// </summary>
        /// <param name="BilNo"></param>
        /// <param name="My1_UDsg"></param>
        /// <returns></returns>
        public bool UpdatePurAlloSho(long ID, DateTime stopTime)
        {
            PurAlloShoService purAlloShoService = new PurAlloShoService();
            return purAlloShoService.UpdateDelAlloAuto(ID, stopTime);
        }
    }
}
