using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpModel;
using System.Xml.Serialization;
using System.IO;
using System.Net;

namespace DateConfig
{
    public class UpDateConfig
    {
        public Updater Updater { get; set; }
        public List<UpModel.File> Files { get; set; }

        #region XML文件对象化
        /// <summary>
        /// XML文件对象化
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public UpDateConfig getUpConfit(string filePath)
        {
            XmlSerializer xs = new XmlSerializer(typeof(UpDateConfig));
            StreamReader sr = new StreamReader(filePath);
            UpDateConfig config = (UpDateConfig)xs.Deserialize(sr);
            sr.Close();
            return config;
        }
        #endregion

        #region XML文件对象化
        /// <summary>
        /// XML文件对象化
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public UpDateConfig getUpConfBySt(string st)
        {
            XmlSerializer xs = new XmlSerializer(typeof(UpDateConfig));
            StringReader sr = new StringReader(st);
            UpDateConfig config = (UpDateConfig)xs.Deserialize(sr);
            sr.Close();
            return config;
        }
        #endregion

        #region
        public bool judgeUpdate()
        {
            bool a;
            string path = Environment.CurrentDirectory + "\\UpDateConfig.config";
            UpDateConfig ud = new UpDateConfig();
            string oldVerson = ud.getUpConfit(path).Updater.Verson;
            string url = ud.getUpConfit(path).Updater.Url+ "UpDateConfig.config";
            WebClient wc = new WebClient();
            if (Directory.Exists(Environment.CurrentDirectory + "\\tempconfig") != true)
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\tempconfig");
            }
            else
            {
                Directory.Delete(Environment.CurrentDirectory + "\\tempconfig", true);
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\tempconfig");
            }
            wc.DownloadFile(url, Environment.CurrentDirectory + "\\tempconfig" + "\\UpDateConfig.config");
            wc.Dispose();
            string newVerson = ud.getUpConfit(Environment.CurrentDirectory + "\\tempconfig" + "\\UpDateConfig.config").Updater.Verson;
            Version ov = new Version(oldVerson);
            Version nv = new Version(newVerson);
            if (nv > ov)
            {
                a = true;
            }
            else
            {
                a = false;
            }
            return a;
        }
        #endregion
    }
}
