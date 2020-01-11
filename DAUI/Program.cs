using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UpConfig;

namespace DAUI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            UpDateConfig udc = new UpDateConfig();
            if (udc.judgeUpdate() == true)
            {
                Process.Start(Environment.CurrentDirectory + "\\AutoUpdate.exe");///更新程序
            }
            else
            {
                LoginForm lg = new LoginForm();
                lg.ShowDialog();
                if (lg.DialogResult == DialogResult.OK)
                {
                    Application.Run(new MainForm());//密码正确，进入主界面。
                }
            }            
        }
    }
}
