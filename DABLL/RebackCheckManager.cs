using DA.DAL;
using DA.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.BLL
{
    public class RebackCheckManager
    {
        /// <summary>
        /// 根据车牌查询重量不足信息
        /// </summary>
        /// <param name="AutoCode">车号</param>

        public List<RebackCheckMD> GetRebackCheckByAutoCode(string AutoCode)
        {
            RebackCheckService rebackCheckService = new RebackCheckService();
            return rebackCheckService.GetRebackCheckByAutoCode(AutoCode);
        }
        /// <summary>
        /// 根据时间查询重量不足信息
        /// </summary>
        /// <param name="AutoCode">车号</param>

        public List<RebackCheckMD> GetRebackCheckByTime(DateTime startTime, DateTime endTime)
        {
            RebackCheckService rebackCheckService = new RebackCheckService();
            return rebackCheckService.GetRebackCheckByTime(startTime,endTime);
        }
    }
}
