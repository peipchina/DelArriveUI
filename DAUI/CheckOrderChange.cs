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
using DevExpress.XtraSplashScreen;

namespace DAUI
{
    public partial class CheckOrderChange : DevExpress.XtraEditors.XtraForm
    {
        public CheckOrderChange()
        {
            InitializeComponent();
            LoadSet();
            InitializeSet();
        }
        int select = -1;
        private void InitializeSet()
        {
            sbtnSearch.Click += SbtnSearch_Click;
            txtFilter.TextChanged += TxtFilter_TextChanged;
            gridView1.RowCellClick += GridView1_RowCellClick;
            sbtnChange.Click += SbtnChange_Click;
        }

        private void SbtnChange_Click(object sender, EventArgs e)
        {
            if(txtOrderNo.Tag==null)
            {
                MessageBox.Show("请选择需要修改的列名！");
                return;
            }
            ChangeOrderNo();
            bindingGridview();
        }


        private void GridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            select = this.gridView1.GetDataSourceRowIndex(e.RowHandle);
            List<V_SacOutSuperviseMD> v_SacOutSuperviseMDs = new List<V_SacOutSuperviseMD>();
            v_SacOutSuperviseMDs = this.gridControl1.DataSource as List<V_SacOutSuperviseMD>;
            txtOrderNo.Text = v_SacOutSuperviseMDs[select].QtyCheck15;
            txtOrderNo.Tag = v_SacOutSuperviseMDs[select].ID;
        }

        private void TxtFilter_TextChanged(object sender, EventArgs e)
        {
            this.gridView1.FindFilterText = txtFilter.Text.Trim();
        }

        private void SbtnSearch_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm();
            bindingGridview();
            SplashScreenManager.CloseDefaultWaitForm();
        }
       private void ChangeOrderNo()
        {
            SacOutSuperviseManager sacOutSuperviseManager = new SacOutSuperviseManager();
            sacOutSuperviseManager.UpDataOrderNo(long.Parse(txtOrderNo.Tag.ToString()),txtOrderNo.Text.Trim());
            txtOrderNo.Tag = null;
            txtOrderNo.Text = "";
        }
        private void LoadSet()
        {
            dtEndTime.DateTime = DateTime.Now;
            dtStartTime.DateTime = DateTime.Now;
            gridview1columbinding();
            setGridView setGridView = new setGridView();
            setGridView.CustomizeGridView(gridView1);
            if( LoginForm.pubDelIn.LoginName!="test")
            {
                sbtnChange.Enabled = false;
            }
        }

        /// <summary>
        /// 手动添加第二个GridView列
        /// </summary>
        private void gridview1columbinding()
        {

            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "AutoCode", FieldName = "AutoCode", Caption = "车号", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "MatName", FieldName = "MatName", Caption = "物料名", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "IDFrom", FieldName = "IDFrom", Caption = "来源单号", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "AutoCode", FieldName = "AutoCode", Caption = "车号", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Driver", FieldName = "Driver", Caption = "司机", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "BilNo", FieldName = "BilNo", Caption = "来源通知单", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "MatName", FieldName = "MatName", Caption = "货品名称", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ToCust", FieldName = "ToCust", Caption = "客户", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "StockName", FieldName = "StockName", Caption = "仓库", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "QtyTare", FieldName = "QtyTare", Caption = "皮重（顿）", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "TareTime", FieldName = "TareTime", Caption = "皮重过磅时间", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "TareStfName", FieldName = "TareStfName", Caption = "皮重录入", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Qty", FieldName = "QtyGross", Caption = "毛重（顿）", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "GrossTime", FieldName = "GrossTime", Caption = "出货时间", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "GrossStfName", FieldName = "GrossStfName", Caption = "毛重录入", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "BeginLoadStfName", FieldName = "BeginLoadStfName", Caption = "入线装货记录", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "BeginLoadTime", FieldName = "BeginLoadTime", Caption = "入线时间", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "InLine", FieldName = "InLine", Caption = "装货线", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "EndLoadStfName", FieldName = "EndLoadStfName", Caption = "装车完毕记录", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "EndLoadTime", FieldName = "EndLoadTime", Caption = "完成时间", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "PassStfName", FieldName = "PassStfName", Caption = "品管放行人", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "PassTime", FieldName = "PassTime", Caption = "品管放行时间", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "发货单创建人", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateTime", FieldName = "CreateTime", Caption = "发货单创建时间", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "QtyCheck15", FieldName = "QtyCheck15", Caption = "合格证编号", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "发货单创建人", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "发货单创建人", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "发货单创建人", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "发货单创建人", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "发货单创建人", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns["GrossTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView1.Columns["TareTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView1.Columns["GrossTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView1.Columns["BeginLoadTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView1.Columns["PassTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView1.Columns["CreateTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
        }


        private void bindingGridview()
        {
            SacOutSuperviseManager sacOutSuperviseManager = new SacOutSuperviseManager();
            this.gridControl1.DataSource = sacOutSuperviseManager.getSacOutSupervise(dtStartTime.DateTime,dtEndTime.DateTime);
        }
    }
}