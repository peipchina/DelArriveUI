using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UpModel;
using DateConfig;
using System.IO;
using System.Net;

namespace AutoUpdate
{
    public partial class AutoUpDateUI : DevExpress.XtraEditors.XtraForm
    {
        public AutoUpDateUI()
        {
            InitializeComponent();
        }
        #region 检查是否有更新内容
        /// <summary>
        /// #endregion
        /// </summary>
        public void binding()
        {
            UpDateConfig uc = new UpDateConfig();
            List<UpModel.File> lf = new List<UpModel.File>();
            string path = Environment.CurrentDirectory + "\\UpDateConfig.config";
            UpDateConfig ud = new UpDateConfig();
            string url = ud.getUpConfit(path).Updater.Url + "UpDateConfig.config";
            WebClient wc = new WebClient();
            //if (Directory.Exists(Environment.CurrentDirectory + "\\tempconfig") != true)
            //{
            //    Directory.CreateDirectory(Environment.CurrentDirectory + "\\tempconfig");
            //}
            //else
            //{
            //    Directory.Delete(Environment.CurrentDirectory + "\\tempconfig", true);
            //    Directory.CreateDirectory(Environment.CurrentDirectory + "\\tempconfig");
            //}
            lf=ud.getUpConfBySt( wc.DownloadString(url)).Files;
            //wc.DownloadFile(url, Environment.CurrentDirectory + "\\tempconfig" + "\\UpDateConfig.config");
            //lf = ud.getUpConfit(Environment.CurrentDirectory + "\\tempconfig" + "\\UpDateConfig.config").Files;
            if (lf.Count > 0)
            {
                for (int i = 0; i < lf.Count; i++)
                {
                    ListViewItem ii = new ListViewItem(lf[i].Name);
                    ii.SubItems.Add(lf[i].Ver);
                    this.listView1.Items.Add(ii);
                }
            }
        }
        #endregion

        #region 窗体加载事件
        /// <summary>
        /// #endregion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoUpDateUI_Load(object sender, EventArgs e)
        {
            binding();
        } 
        #endregion

        #region 取消事件
        /// <summary>
        /// 取消事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 下一步
        /// <summary>
        /// 下一步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btNext_Click(object sender, EventArgs e)
        {
            UpDate();
        } 
        #endregion

        #region 更新文件
        /// <summary>
        /// 更新文件
        /// </summary>
        private void UpDate()
        {
            try
            {
                WebClient wc = new WebClient();
                UpDateConfig udc = new UpDateConfig();
                pbDown.Value = 0;
                pbDown.Maximum = this.listView1.Items.Count;
                pbDown.Step = 1;
                string url = udc.getUpConfit(Environment.CurrentDirectory + "\\tempconfig" + "\\UpDateConfig.config").Updater.Url;
                if (this.listView1.Items.Count < 1)
                {
                    MessageBox.Show("没有可以更新的内容！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                else
                {
                    for (int i = 0; i < this.listView1.Items.Count; i++)
                    {

                        string upDateFileName = listView1.Items[i].Text.Trim();
                        string upUrl = url + upDateFileName;
                        wc.DownloadFile(upUrl, Environment.CurrentDirectory  +"\\"+ upDateFileName);
                        System.Threading.Thread.Sleep(500);
                        pbDown.Value += pbDown.Step;
                    }
                    wc.Dispose();
                    System.Threading.Thread.Sleep(2000);
                    label2.Text = "下载完成，请重新启动软件！";
                    btCancle.Text = "完成";
                    //binding();
                    // MessageBox.Show("更新成功，请重新启动程序！", "更新提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);     
                }

            }
            catch (Exception)
            {

                MessageBox.Show("更新失败，联系系统管理人员！", "更新提示", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            } 
        }
        #endregion

    
    }
}