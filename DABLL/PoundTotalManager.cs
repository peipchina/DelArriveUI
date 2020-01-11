using DA.DAL;
using DA.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.BLL
{
    public class PoundTotalManager
    {
        /// <summary>
        /// 根据车牌识别车号查询托利多信息
        /// </summary>
        /// <param name="AutoCode">自动识别的车号</param>
        /// <returns>监装表</returns>
        public List<PoundTotalMD> GetPountListByAutoCode(string AutoCode,DateTime dateTime)
        {
            PoundTotalServiece pts = new PoundTotalServiece();
            return pts.GetPountListByAutoCode(AutoCode, dateTime);
        }
        /// <summary>
        /// 根据车牌识别车号查询托利多信息
        /// </summary>
        /// <param name="AutoCode">自动识别的车号</param>
        /// <returns>监装表</returns>
        public List<PoundTotalMD> GetPountListByAutoCodeL(string AutoCode)
        {
            PoundTotalServiece pts = new PoundTotalServiece();
            return pts.GetPountListByAutoCodeL(AutoCode);
        }
        /// <summary>
        /// 根据车牌识别车号查询托利多信息
        /// </summary>
        /// <param name="AutoCode">自动识别的车号</param>
        /// <returns>监装表</returns>
        public List<PoundTotalMD> GetPountListByAutoCodeR(string AutoCode)
        {
            PoundTotalServiece pts = new PoundTotalServiece();
            return pts.GetPountListByAutoCodeR(AutoCode);
        }
        /// <summary>
        /// 获取某段时间车辆过磅信息
        /// </summary>        
        /// <returns>车辆过磅信息泛型</returns>
        public List<PoundTotalMD> GetPoundListByDateTime(DateTime StartTime, DateTime EndTime)
        {
            PoundTotalServiece pts = new PoundTotalServiece();
            return pts.GetPoundListByDateTime(StartTime,EndTime);
        }
    }
}
