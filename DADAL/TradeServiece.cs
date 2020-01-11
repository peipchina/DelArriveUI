﻿using DA.MODEL;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.DAL
{
    public class TradeServiece
    {
        /// <summary>
        /// 机修楼托利多数据
        /// </summary>
        /// <returns></returns>
        public List<TradeMD> GetTrade_M()
        {
            string connection = @"Password=bohi@1218;Persist Security Info=True;User ID=sa;Initial Catalog=BohiErp;Data Source=192.168.51.180";
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"select top 500 * from trade_m where datastatus='1' order by ticketno1 desc";
                return (List<TradeMD>)sc.Query<TradeMD>(sql, null);
            }
        }
        /// <summary>
        /// 办公楼多利多数据
        /// </summary>
        /// <returns></returns>
        public List<TradeMD> GetTrade_O()
        {
            string connection = @"Password=bohi@1218;Persist Security Info=True;User ID=sa;Initial Catalog=BohiErp;Data Source=192.168.51.180";
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"select top 500 * from trade_O where datastatus='1' order by ticketno1 desc";
                return (List<TradeMD>)sc.Query<TradeMD>(sql, null);
            }
        }
        /// <summary>
        /// 按时间获取办公楼多利多数据
        /// </summary>
        /// <returns></returns>
        public List<TradeMD> GetTrade_OByDate(DateTime startDate, DateTime endDate)
        {
            string connection = @"Password=bohi@1218;Persist Security Info=True;User ID=sa;Initial Catalog=BohiErp;Data Source=192.168.51.180";
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"select  * from trade_O where datastatus='1'and seconddatetime between @startDate and @endDate order by ticketno1 desc";
                return (List<TradeMD>)sc.Query<TradeMD>(sql, new { startDate = startDate, endDate = endDate });
            }
        }
        /// <summary>
        /// 按时间获取机修楼多利多数据
        /// </summary>
        /// <returns></returns>
        public List<TradeMD> GetTrade_mByDate(DateTime startDate, DateTime endDate)
        {
            string connection = @"Password=bohi@1218;Persist Security Info=True;User ID=sa;Initial Catalog=BohiErp;Data Source=192.168.51.180";
            using (SqlConnection sc = new SqlConnection(connection))
            {
                string sql = @"select  * from trade_m where datastatus='1'and seconddatetime between @startDate and @endDate order by ticketno1 desc";
                return (List<TradeMD>)sc.Query<TradeMD>(sql, new { startDate = startDate, endDate = endDate });
            }
        }
    }
}
