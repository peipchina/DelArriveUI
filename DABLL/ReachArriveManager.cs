using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.MODEL;
using DA.DAL;

namespace DA.BLL
{
    public class ReachArriveManager
    {
        public List<V_ReachArriveMD> getAllReachArrive()
        {
            ReachArriveService rm = new ReachArriveService();
            return rm.getAllReachArrive();
        }
    }
}
