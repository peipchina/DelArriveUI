using DA.BLL;
using DA.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAUI
{
    public partial class ChangePassWordForm : Form
    {
        public ChangePassWordForm()
        {
            InitializeComponent();
        }

        private void btnCacle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChange_Click(object sender, EventArgs e)
        { 
            string info = "";
            info += String.IsNullOrEmpty(txbOldPassWord.Text.Trim()) ? "旧密码不能为空!\r\n" : "";
            info += String.IsNullOrEmpty(txbNewPassword.Text.Trim()) ? "新密码不能为空!\r\n" : "";
            info += String.IsNullOrEmpty(txbCheckPassword.Text.Trim()) ? "确认密码不能为空!\r\n" : "";
            info += txbNewPassword.Text.Trim()!=txbCheckPassword.Text.Trim() ? "确认密码不一致!\r\n" : "";
            if (!String.IsNullOrEmpty(info))
            {
                MessageBox.Show(info, "提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }                
            List<PubDelInMD> lsu = new List<PubDelInMD>();            
            PubDelINManager sum = new PubDelINManager();
            lsu = sum.getPassWordByLoginName(LoginForm.loginName);
            encry en = new encry();
            string PassWord = en.MD5Dec(txbOldPassWord.Text.Trim());
            string ou = "";
            ou += PassWord != lsu[0].PassWord?"登录密码不正确":"";
            if (!string.IsNullOrEmpty(ou))
            {
                MessageBox.Show(ou, "提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }                
            PubDelInMD pdi = new PubDelInMD { LoginName = LoginForm.loginName,PassWord=en.MD5Dec(txbNewPassword.Text.Trim()) };
            bool a= sum.UpPassWord(pdi);
            if (a == true)
            {
                MessageBox.Show("密码修改成功", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
            else
            {
                MessageBox.Show("密码修改失败", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
