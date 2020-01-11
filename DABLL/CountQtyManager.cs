using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.MODEL;
using DA.DAL;

namespace DA.BLL
{
    public class CountQtyManager
    {
        public List<V_CountQtyMD> getCountByTimeAndMatName(string MatName, DateTime startTime, DateTime endTime)
        {
            CountQtyServiece cqs = new CountQtyServiece();
            return cqs.getCountByTimeAndMatName(MatName,startTime,endTime);
        }
    }
}
