using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.MODEL;
using DA.DAL;

namespace DA.BLL
{
    public class DelArriveManager
    {
        public List<V_DelArrive> getAllDelArrive()
        {
            DelArriveServiece das = new DelArriveServiece();
            return das.getAllDelArrive();
        }

        #region 根据车辆号码获取车辆最近20次抵达信息
        /// <summary>
        /// 根据车辆号码获取车辆最近20次抵达信息
        /// </summary>
        /// <param name="delArrive"></param>
        /// <returns>车辆最近20次抵达信息</returns>
        public List<V_DelArriveMD> getArriveByAutoCode(string Code)
        {
            DelArriveServiece das = new DelArriveServiece();
            return das.getArriveByAutoCode(Code);
        }
        #endregion

        #region 根据车辆号码获取车辆最近20次抵达信息
        /// <summary>
        /// 根据车辆号码获取车辆最近20次抵达信息
        /// </summary>
        /// <param name="delArrive"></param>
        /// <returns>车辆最近20次抵达信息</returns>
        public List<V_DelArriveMD> getArriveByAutoCod(string Code)
        {
            DelArriveServiece das = new DelArriveServiece();
            return das.getArriveByAutoCod(Code);
        }
        #endregion
    }
}
