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
    public partial class RebackCheckFrm : DevExpress.XtraEditors.XtraForm
    {
        public RebackCheckFrm()
        {
            InitializeComponent();
            LoadSet();
            InitializeSet();
        }
        int selectRow = -1;
        private void LoadSet()
        {
            dtStartTime.DateTime = DateTime.Now.AddDays(-1);
            dtEndTime.DateTime = DateTime.Now;
            
            setGridView setGridView = new setGridView();
            setGridView.CustomizeGridView(gridView1);
            setGridView.CustomizeGridView(gridView2);
            gridview1columbinding();
            Column1Add();
           // this.gridView2.OptionsView.ShowFooter = true;//显示底部状态栏
            //TotalSet();//统计平均数
        }

        private void InitializeSet()
        {
            sbtnSearch2.Click += SbtnSearch2_Click;
            sbtnSearch.Click += SbtnSearch_Click;
            txtFilter.TextChanged += TxtFilter_TextChanged;

            this.gridView1.RowClick += GridView1_RowClick;
        }

        private void GridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            selectRow = this.gridView1.GetDataSourceRowIndex(e.RowHandle);
            List<RebackCheckMD> rebackCheckMDs = this.gridControl1.DataSource as List<RebackCheckMD>;
            gridView2Binding(rebackCheckMDs[selectRow].AutoCode,DateTime.Parse(rebackCheckMDs[selectRow].TareTime.ToString()));
            
        }

        private void TxtFilter_TextChanged(object sender, EventArgs e)
        {
            this.gridView1.FindFilterText = txtFilter.Text;
            this.gridView2.FindFilterText = txtFilter.Text;
        }

        private void SbtnSearch_Click(object sender, EventArgs e)
        {
            if (txtAutoCode.Text.Trim() == "") return;
            bindingv1ByAutoCode();
        }

        private void SbtnSearch2_Click(object sender, EventArgs e)
        {
            bindingv1ByTime();
        }



        #region -------------<<方法>>--------------------
        //根据车号查询历史皮重
        private void gridView2Binding(string AutoCode,DateTime dateTime)
        {
            //GrossQtyManager gqm = new GrossQtyManager();
            //List<V_GrossQtyMD> lv = new List<V_GrossQtyMD>();
            //lv = gqm.getGrossQtyByAutoCode(AutoCode);
            //PoundTotalManager poundTotalManager = new PoundTotalManager();
            //this.gridControl2.DataSource = poundTotalManager.GetPountListByAutoCodeR(AutoCode);
            SacOutSuperviseManager sacOutSuperviseManager = new SacOutSuperviseManager();
            this.gridControl2.DataSource= sacOutSuperviseManager.getSacOutSuperviseByAutoCodeAndTime(AutoCode, dateTime);
        }
        /// <summary>
        /// 手工添加gridView1列
        /// </summary>
        private void Column1Add()
        {
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "AutoCode", FieldName = "AutoCode", Caption = "车号", VisibleIndex = 2, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "QtyTare", FieldName = "QtyTare", Caption = "皮重数量", VisibleIndex = 3, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "TareTime", FieldName = "TareTime", Caption = "皮重时间", VisibleIndex = 4, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "LestQty", FieldName = "LestQty", Caption = "需补重量", VisibleIndex = 6, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "RebackTime", FieldName = "RebackTime", Caption = "返回打包时间", VisibleIndex = 5, Visible = Enabled });          
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "MatName", FieldName = "MatName", Caption = "物料名", VisibleIndex = 4, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "RebackStf", FieldName = "RebackStf", Caption = "司磅员", VisibleIndex = 6, Visible = Enabled });
            gridView1.Columns["TareTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView1.Columns["RebackTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
        }
        #region 手动添加第二个GridView列
        /// <summary>
        /// 手动添加第二个GridView列
        /// </summary>
        private void gridview1columbinding()
        {
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "AutoCode", FieldName = "AutoCode", Caption = "车号", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Driver", FieldName = "Driver", Caption = "司机", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "BeginLoadTime", FieldName = "BeginLoadTime", Caption = "入线时间", VisibleIndex = 3, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "EndLoadTime", FieldName = "EndLoadTime", Caption = "出线时间", VisibleIndex = 4, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "PassTime", FieldName = "PassTime", Caption = "放行时间", VisibleIndex = 5, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "TareTime", FieldName = "TareTime", Caption = "皮重时间", VisibleIndex = 2, Visible = Enabled });
            //gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "MatName", FieldName = "MatName", Caption = "物料名", VisibleIndex = 1, Visible = Enabled });
            
            //gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateTime", FieldName = "CreateTime", Caption = "登记时间", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns["TareTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView2.Columns["BeginLoadTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView2.Columns["EndLoadTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView2.Columns["PassTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            // gridView2.Columns["CreateTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";

        }
        /// <summary>
        /// 统计净重
        /// </summary>
        private void TotalSet()
        {
           // gridView2.Columns["QTYTare"].Summary.Add(DevExpress.Data.SummaryItemType.Average, "QTYTare", "统计：{0:n2}");
        }
        #endregion
        /// <summary>
        /// 根据时间查询车辆回包信息
        /// </summary>
        private void bindingv1ByTime()
        {
            RebackCheckManager rebackCheckManager = new RebackCheckManager();
            this.gridControl1.DataSource = rebackCheckManager.GetRebackCheckByTime(dtStartTime.DateTime,dtEndTime.DateTime);
        }
        private void bindingv1ByAutoCode()
        {
            RebackCheckManager rebackCheckManager = new RebackCheckManager();
            this.gridControl1.DataSource = rebackCheckManager.GetRebackCheckByAutoCode('%'+txtAutoCode.Text.Trim()+'%');
        }
        #endregion
    }
}