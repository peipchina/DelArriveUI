using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.MODEL;
using DA.DAL;

namespace DA.BLL
{
    public class CarArriveManager
    {
        /// <summary>
        /// 根据时间查询某一天的自动识别车辆
        /// </summary>
        /// <param name="in_time">查询时间</param>
        /// <returns>车辆自动识别信息</returns>
        public List<AutoCodeRecordMD> GetAutoArriveCarNo(DateTime InTime,DateTime OutTime)
        {
            CarArriveServiece cas = new CarArriveServiece();
            return cas.GetAutoArriveCarNo(InTime,OutTime);            
        }
        /// <summary>
        /// 根据车牌识别车号查询毛重及皮重时间
        /// </summary>
        /// <param name="AutoCode">自动识别的车号</param>
        /// <returns>监装表</returns>
        public List<TC_GrossTareMD> GetCarTareAndGross(string AutoCode,DateTime dateTime)
        {
            CarArriveServiece cas = new CarArriveServiece();
            return cas.GetCarTareAndGross(AutoCode, dateTime);
        }
        /// <summary>
        /// 根据车牌识别车号和时间查询毛重及皮重时间
        /// </summary>
        /// <param name="AutoCode">自动识别的车号</param>
        /// <returns>监装表</returns>
        public List<TC_GrossTareMD> GetCarTareAndGrossByAutoCodeAndTime(string AutoCode, DateTime dateTime)
        {
            CarArriveServiece cas = new CarArriveServiece();
            return cas.GetCarTareAndGrossByAutoCodeAndTime(AutoCode,dateTime);
        }
        /// <summary>
        /// 根据车牌识别车号模糊查询毛重及皮重时间
        /// </summary>
        /// <param name="AutoCode">模糊车号</param>
        /// <returns>监装表</returns>
        public List<TC_GrossTareMD> GetCarTareAndGrossByAutoCode(string AutoCode,DateTime dateTime)
        {
            CarArriveServiece cas = new CarArriveServiece();
            return cas.GetCarTareAndGrossByAutoCode(AutoCode,dateTime);
        }
    }
}
