using DA.DAL;
using DA.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.BLL
{
    public class PurInprisonManager
    {
        public List<PurInprisonMD> getReachAuto(string ShipName)
        {
            PurInprisonService purInprisonService = new PurInprisonService();
            return purInprisonService.getReachAuto(ShipName);
        }
        public bool delectAutoCode(long ID)
        {
            PurInprisonService purInprisonService = new PurInprisonService();
            return purInprisonService.delectAutoCode(ID);
        }
    }
}
