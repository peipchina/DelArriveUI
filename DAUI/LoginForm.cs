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
using DA.BLL;
using DA.MODEL;

namespace DAUI
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void contrastPassWord()
        {
            PubDelInMD su = new PubDelInMD();
            su.LoginName = txbLoginName.Text.Trim();
            List<PubDelInMD> lsu = new List<PubDelInMD>();
            PubDelINManager sum = new PubDelINManager();
            lsu = sum.getPassWordByLoginName(txbLoginName.Text.Trim());
            encry en = new encry();
            string PassWord = en.MD5Dec(txbPassword.Text.Trim());
            if (lsu.Count == 0)
            {
                MessageBox.Show("用户名不存在", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (PassWord == lsu[0].PassWord)
            {                
                this.DialogResult = DialogResult.OK;
                pubDelIn = lsu[0];
                this.Close();
            }
            else
            {
                MessageBox.Show("密码不正确！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public static string loginName ="";
        public static PubDelInMD pubDelIn=null;
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txbLoginName.Text.Trim()==string.Empty)
            {
                MessageBox.Show("用户名不能为空！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbLoginName.Focus();
                return;
            }
            if (txbPassword.Text.Trim()==string.Empty)
            {
                MessageBox.Show("密码不能为空！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbPassword.Focus();
                return;
            }
            contrastPassWord();
            loginName = txbLoginName.Text.Trim();
        }
    }
}