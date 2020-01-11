using DA.DAL;
using DA.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.BLL
{
    public class GrossTimeManager
    {
        public List<V_GrossTimeMD> getAllGrossTimeByAutoCar(string AutoCode)
        {
            GrossTimeService gts = new GrossTimeService();
            return gts.getAllGrossTimeByAutoCar(AutoCode);
        }
    }
}
