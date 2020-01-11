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
    public partial class ChangeTime1Frm : DevExpress.XtraEditors.XtraForm
    {
        public ChangeTime1Frm()
        {
            InitializeComponent();
            InitializeSet();
        }
        int selectRow = -1;
        string selectL = "";
        private void InitializeSet()
        {
            this.gridView1.RowClick += GridView1_RowClick;
            this.gridView2.RowClick += GridView2_RowClick;

            sbtnSearch.Click += SbtnSearch_Click;
            sbtnChange.Click += SbtnChange_Click;
            txtFilte.TextChanged += TxtFilte_TextChanged;
            


            gridviewcolumbinding(this.gridView1);
            gridviewcolumbinding(this.gridView2);
            setGridView setGridView = new setGridView();
            setGridView.CustomizeGridView(this.gridView1);
            setGridView.CustomizeGridView(this.gridView2);
            this.gridView1.OptionsView.ColumnAutoWidth = true;
            this.gridView2.OptionsView.ColumnAutoWidth = true;
        }

        

        private void GridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            selectRow = this.gridView2.GetDataSourceRowIndex(e.RowHandle);
            selectL = "Right";
        }

        private void GridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            selectRow = this.gridView1.GetDataSourceRowIndex(e.RowHandle);
            selectL = "Left";
        }

        private void SbtnChange_Click(object sender, EventArgs e)
        {
            if(selectL=="Left")
            {
                MessageBox.Show("操作左边窗体");
                ChangeTime1();
            }
            else if(selectL=="Right")
            {
                MessageBox.Show("操作右边窗体");
                ChangeTime2();
            }
        }

        private void TxtFilte_TextChanged(object sender, EventArgs e)
        {
            this.gridView1.FindFilterText = txtFilte.Text.Trim();
            this.gridView2.FindFilterText = txtFilte.Text.Trim();
        }

        private void SbtnSearch_Click(object sender, EventArgs e)
        {
            bindingGridview1();
            bindingGridview2();
        }
        long a = 0;
        private void bindingGridview1()
        {
            long.TryParse(txtFilte.Text.Trim(),out a);
            DelLeaveDtlManager delLeaveDtlManager = new DelLeaveDtlManager();
            this.gridControl1.DataSource = delLeaveDtlManager.getDelLeave(dtStartTime.DateTime,dtEndTime.DateTime);
        }
        private void bindingGridview2()
        {
            long.TryParse(txtFilte.Text.Trim(), out a);
            DelLeaveDtlManager delLeaveDtlManager = new DelLeaveDtlManager();
            this.gridControl2.DataSource = delLeaveDtlManager.getReachAuto(dtStartTime.DateTime, dtEndTime.DateTime);
        }
        private void ChangeTime1()
        {
            if (selectRow < 0) return;            
            var dd = this.gridControl1.DataSource as List<DelLeaveDtlMD>;
            dd[selectRow].BilDate = dtChangeTime.DateTime;
            DelLeaveDtlManager delLeaveDtlManager = new DelLeaveDtlManager();
            delLeaveDtlManager.updataDelLeave(dd[selectRow]);
        }
        private void ChangeTime2()
        {
            if (selectRow < 0) return;
            var dd = this.gridControl2.DataSource as List<DLMD>;
            dd[selectRow].BilDate = dtChangeTime.DateTime;
            DelLeaveDtlManager delLeaveDtlManager = new DelLeaveDtlManager();
            delLeaveDtlManager.updataStcStockShiftDtl(dd[selectRow]);
        }
        private void gridviewcolumbinding(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "BilID", FieldName = "BilID", Caption = "单据ID", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "BilDate", FieldName = "BilDate", Caption = "订单日期", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "BilNo", FieldName = "BilNo", Caption = "订单号", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "AutoCode", FieldName = "AutoCode", Caption = "车号", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Qty", FieldName = "Qty", Caption = "出货数量（顿）", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "GrossTime", FieldName = "GrossTime", Caption = "出货时间", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns["GrossTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView.Columns["BilDate"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
        }

        private void ChangeTimeFrm_Load(object sender, EventArgs e)
        {
            
        }
    }
}