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
    public partial class SoybeanFrm : DevExpress.XtraEditors.XtraForm
    {
        public SoybeanFrm()
        {
            InitializeComponent();
            LoadSet();
            InitializeSet();
        }

        int selectRow = -1;
        private void InitializeSet()
        {
            txtFilt.TextChanged += TxtFilt_TextChanged;
            this.gridView1.RowClick += GridView1_RowClick;
            if(LoginForm.loginName!="test")
            {
                sbtnSearch.Enabled = false;
            }
        }

        private void GridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            selectRow = this.gridView1.GetDataSourceRowIndex(e.RowHandle);
            if (selectRow < 0) return;
            List<PurInprisonMD> purInprisonMDs = this.gridControl1.DataSource as List<PurInprisonMD>;
            
        }

        private void TxtFilt_TextChanged(object sender, EventArgs e)
        {
            this.gridView1.FindFilterText = txtFilt.Text.Trim(); 
        }

        private void LoadSet()
        {
            setGridView setGridView = new setGridView();
            setGridView.CustomizeGridView(this.gridView1);
            this.gridView1.OptionsView.ColumnAutoWidth = true;
            ColumnsAdd(this.gridView1);
            
        }
        private void bindingGridview()
        {
            PurInprisonManager purInprisonManager = new PurInprisonManager();
            List<PurInprisonMD> purInprisonMDs= purInprisonManager.getReachAuto(txtLastShip.Text.Trim());
            this.gridControl1.DataSource = purInprisonMDs;
        }

        /// <summary>
        /// 手动添加Gridview列名
        /// </summary>
        /// <param name="gridview"></param>
        private void ColumnsAdd(DevExpress.XtraGrid.Views.Grid.GridView gridview)
        {
            //gridview.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            gridview.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 0, Visible = Enabled });
            gridview.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "AutoCode", FieldName = "AutoCode", Caption = "车号", VisibleIndex = 1, Visible = Enabled });
            gridview.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Driver", FieldName = "Driver", Caption = "司机", VisibleIndex = 2, Visible = Enabled });
            gridview.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ShipName", FieldName = "ShipName", Caption = "船名/船舱号", VisibleIndex = 11, Visible = Enabled });
            gridview.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "TareTime", FieldName = "TareTime", Caption = "皮重时间", VisibleIndex = 12, Visible = Enabled });
            gridview.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "GrossTime", FieldName = "GrossTime", Caption = "毛重时间", VisibleIndex = 13, Visible = Enabled });
            gridview.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "IsFirst", FieldName = "IsFirst", Caption = "第一次过磅", VisibleIndex = 3, Visible = Enabled });
            gridview.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "IsStop", FieldName = "IsStop", Caption = "停用", VisibleIndex = 4, Visible = Enabled });
            //gridview.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "username1", FieldName = "username1", Caption = "司磅员", VisibleIndex = 5, Visible = Enabled });
            //gridview.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "gross", FieldName = "gross", Caption = "毛重（kg）", VisibleIndex = 6, Visible = Enabled });
            //gridview.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "grossdatetime", FieldName = "grossdatetime", Caption = "毛重时间", VisibleIndex = 7, Visible = Enabled });
            //gridview.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "username2", FieldName = "username2", Caption = "司磅员", VisibleIndex = 8, Visible = Enabled });
            //gridview.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "net", FieldName = "net", Caption = "净重（kg）", VisibleIndex = 9, Visible = Enabled });
            //gridview.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "sender", FieldName = "sender", Caption = "发货单位", VisibleIndex = 10, Visible = Enabled });
            gridview.Columns["TareTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridview.Columns["GrossTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";

        }

        private void SoybeanFrm_Load(object sender, EventArgs e)
        {
            
        }

        private void sbtnSearcho_Click(object sender, EventArgs e)
        {
            if(txtLastShip.Text.Trim()=="")
            {
                error.SetError(txtLastShip,"船名不能为空！");
                txtLastShip.Focus();
                return;
            }
            bindingGridview();
        }

        private void sbtnSearch_Click(object sender, EventArgs e)
        {
            if (selectRow < 0) return;
            List<PurInprisonMD> purInprisonMDs = new List<PurInprisonMD>();
            purInprisonMDs = this.gridControl1.DataSource as List<PurInprisonMD>;
            PurInprisonManager purInprisonManager = new PurInprisonManager();
            if (purInprisonManager.delectAutoCode(purInprisonMDs[selectRow].ID) == true)
            {
                MessageBox.Show("删除成功！");
                selectRow = -1;
                bindingGridview();
            }           
            
        }
    }
}