using DA.DAL;
using DA.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.BLL
{
   public class DelAlloShipdtlManager
    {
        public List<DelAlloShipdtlMD> GetAutoArriveCarNo(DateTime startTime, DateTime endTime)
        {
            DelAlloShipdtlService cas = new DelAlloShipdtlService();
            return cas.Get180List(startTime, endTime);
        }
        public bool ChangeShipName(long id, string newShipName)
        {
            DelAlloShipdtlService cas = new DelAlloShipdtlService();
            return cas.ChangeShipName(id, newShipName);
        }
    }
}
