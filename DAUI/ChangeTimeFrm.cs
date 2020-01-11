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

namespace DAUI
{
    public partial class ChangeTimeFrm : DevExpress.XtraEditors.XtraForm
    {
        public ChangeTimeFrm()
        {
            InitializeComponent();
        }

        private void ChangeTime(string no,DateTime dt)
        {
            PubBlackAutoCodeManager ps = new PubBlackAutoCodeManager();
            bool change = ps.ChangeTime(no,dt);
            if(change==true)
            {
                MessageBox.Show("修改成功！");
            }else
            {
                MessageBox.Show("修改失败！");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtNo.Text.Trim() == string.Empty) return;
            ChangeTime(txtNo.Text.Trim(),dtChangeTime.DateTime);
        }

        private void ChangeTimeFrm_Load(object sender, EventArgs e)
        {
            dtChangeTime.DateTime = DateTime.Now;
        }
    }
}