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
using DA.MODEL;
using DA.BLL;

namespace DAUI
{
    public partial class BlackAutoCodeForm : DevExpress.XtraEditors.XtraForm
    {
        public BlackAutoCodeForm()
        {
            InitializeComponent();
            if(LoginForm.loginName!="test")
            {
                sbtnDelete.Enabled = false;
            }
            InitializeSet();
        }
        private void InitializeSet()
        {
            txtFilter.TextChanged += TxtFilter_TextChanged;
        }

        private void TxtFilter_TextChanged(object sender, EventArgs e)
        {
            this.gridView1.FindFilterText = txtFilter.Text.Trim();
        }

        int select = -1;
        private void GridViewBinding()
        {
            PubBlackAutoCodeManager pacm = new PubBlackAutoCodeManager();
            List<PubBlackAutoCodeMD> lp = new List<PubBlackAutoCodeMD>();
            lp = pacm.getPubBlackCode();
            this.gridControl1.DataSource = lp;
        }

        private void BlackAutoCodeForm_Load(object sender, EventArgs e)
        {
            setGridView sg = new setGridView();
            sg.CustomizeGridView(this.gridView1);
            sg.CustomizeGridView(this.gridView2);
            gridview1columbinding();
            GridViewBinding();
            
        }
  
        #region 绑定第二个GridView方法
        /// <summary>
        /// 绑定第二个GridView方法
        /// </summary>
        /// <param name="Code">车号</param>
        private void ArriveBinding(string Code)
        {
            //this.gridView2.


            DelArriveManager dam = new DelArriveManager();
            List<V_DelArriveMD> lv = dam.getArriveByAutoCode(Code);
            this.gridControl2.DataSource = lv;
        }
        #endregion

        #region 选择第一个Gridview，根据车号显示第二个gridview内容
        /// <summary>
        /// 选择第一个Gridview，根据车号显示第二个gridview内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">车号</param>
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            lbState.Text = "";
            select = this.gridView1.GetDataSourceRowIndex(e.FocusedRowHandle);

            if (select > -1)
            {
                DelArriveManager dam = new DelArriveManager();
                //List<V_DelArrive> lv = dam.getAllDelArrive();
                PubBlackAutoCodeMD lv = (gridControl1.DataSource as List<PubBlackAutoCodeMD>)[select];
                ArriveBinding(lv.AutoCode);
            }
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lbState.Text = "";
            AddPubAutoCode();
        }
        private void AddPubAutoCode()
        {
            PubBlackAutoCodeManager pb = new PubBlackAutoCodeManager();
            bool add= pb.InsertPubBlackCode180(addBinding());
            if (add == true)
            {
                MessageBox.Show("添加成功！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);                
                GridViewBinding();
            }
            else
            {
                MessageBox.Show("添加失败！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            
        }
        private PubBlackAutoCodeMD addBinding()
        {
            PubBlackAutoCodeMD pbc = new PubBlackAutoCodeMD();
            pbc.AutoCode = txbAutoCode.Text.Trim();
            pbc.BlackTime = dteDateTime.DateTime;
            pbc.CheckName = txbCheckStfName.Text.Trim();
            pbc.Driver = txbDriver.Text.Trim();
            pbc.reason = txbReason.Text.Trim();
            pbc.Results = txbResults.Text.Trim();
            pbc.CreatName = LoginForm.loginName;
            return pbc;
        }

        private void sbtnDelete_Click(object sender, EventArgs e)
        {
            if (select < 0) return;
            List<PubBlackAutoCodeMD> pubBlackAutoCodeMDs = new List<PubBlackAutoCodeMD>();
            pubBlackAutoCodeMDs = this.gridControl1.DataSource as List<PubBlackAutoCodeMD>;
            pubBlackAutoCodeMDs[select].DeleteRem = txtDeleteRem.Text.Trim();
            PubBlackAutoCodeManager pubBlackAutoCodeManager = new PubBlackAutoCodeManager();
            if (pubBlackAutoCodeManager.DeleteBlackCode(pubBlackAutoCodeMDs[select].ID, pubBlackAutoCodeMDs[select].DeleteRem,DateTime.Now) == true)
            {
                lbState.Text = "添加成功！";
                select = -1;
            }
            GridViewBinding();
        }

        private void sbtnRefrash_Click(object sender, EventArgs e)
        {
            GridViewBinding();
        }
        #region 手动添加第一个GridView列
        /// <summary>
        /// 手动添加第一个GridView列
        /// </summary>
        private void gridview1columbinding()
        {
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "AutoCode", FieldName = "AutoCode", Caption = "车号", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Driver", FieldName = "Driver", Caption = "司机", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "BlackTime", FieldName = "BlackTime", Caption = "黑名单时间", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "reason", FieldName = "reason", Caption = "事由", VisibleIndex = 1, Visible = Enabled });
           // gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "交付员", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ArriveTime", FieldName = "ArriveTime", Caption = "抵达时间", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "BilCreateTime", FieldName = "BilCreateTime", Caption = "车号修改时间", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns["BlackTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            
        }
        #endregion
    }
}