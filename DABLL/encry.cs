using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DA.BLL
{
    public class encry
    {
        #region MD5加密
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="inCode"></param>
        /// <returns></returns>
        public string MD5Dec(string inCode)
        {
            MD5 mdd = System.Security.Cryptography.MD5.Create();
            byte[] md5Bytes = mdd.ComputeHash(Encoding.Default.GetBytes(inCode + "acb@"));
            string outCode = BitConverter.ToString(md5Bytes).Replace("-", "");
            return outCode;
        }
        #endregion
    }
}
