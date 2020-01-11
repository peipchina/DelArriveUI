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
    public partial class A_DelArriveForm : DevExpress.XtraEditors.XtraForm
    {
        public A_DelArriveForm()
        {
            InitializeComponent();
            LoadSet();
            InitializeSet();
        }

        private void LoadSet()
        {
            setGridView setGridView = new setGridView();
            setGridView.CustomizeGridView(this.gridView1);
            setGridView.CustomizeGridView(this.gridView2);
            setGridView.CustomizeGridView(this.gridView3);
            gridview1columbinding();
            gridview2columbinding();
            gridview3columbinding();
            BandingDataDelArrive();
            BandingDataDelReach();
            BandingDataDelReachArrive();
        }

        private void InitializeSet()
        {
            tbFilter.TextChanged += TbFilter_TextChanged;
            sbRefresh.Click += SbRefresh_Click;
        }

        private void SbRefresh_Click(object sender, EventArgs e)
        {
            tbFilter.Text = "";
            BandingDataDelArrive();
            BandingDataDelReach();
            BandingDataDelReachArrive();
        }

        private void TbFilter_TextChanged(object sender, EventArgs e)
        {
            this.gridView1.FindFilterText = tbFilter.Text.Trim();
            this.gridView2.FindFilterText = tbFilter.Text.Trim();
            this.gridView3.FindFilterText = tbFilter.Text.Trim();
        }

        private void BandingDataDelArrive()
        {
            A_DelArriveManager a_DelArriveManager = new A_DelArriveManager();
            List<GetLastTime> lv = a_DelArriveManager.getLastData() ;
            if (lv == null) lv[0].NewCreateTime = DateTime.Now;
            this.gridControl2.DataSource = a_DelArriveManager.Get180List(DateTime.Parse(lv[0].NewCreateTime.ToString()));
        }
        private void BandingDataDelReach()
        {
            A_DelReachManager a_DelArriveManager = new A_DelReachManager();
            List<GetLastTime> lv = a_DelArriveManager.getLastData();
            if (lv == null) lv[0].NewCreateTime = DateTime.Now;
            this.gridControl1.DataSource = a_DelArriveManager.Get180List(DateTime.Parse(lv[0].NewCreateTime.ToString()));
        }
        private void BandingDataDelReachArrive()
        {
            A_ReachArriveManager a_ReachArriveManager = new A_ReachArriveManager();
            List<GetLastTime> lv = a_ReachArriveManager.getLastData();
            if (lv == null) lv[0].NewCreateTime = DateTime.Now;
            this.gridControl3.DataSource = a_ReachArriveManager.Get180List(DateTime.Parse(lv[0].NewCreateTime.ToString()));
        }
        #region -------------手动添加第一个GridView列-----------
        /// <summary>
        /// 手动添加第一个GridView列
        /// </summary>
        private void gridview1columbinding()
        {
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "AutoCode", FieldName = "AutoCode", Caption = "车号", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Tel", FieldName = "Tel", Caption = "电话", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Driver", FieldName = "Driver", Caption = "司机", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "BilDate", FieldName = "BilDate", Caption = "订单日期", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ContBilNo", FieldName = "ContBilNo", Caption = "合同号", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "MatName", FieldName = "MatName", Caption = "物料名称", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "MatTypeName", FieldName = "MatTypeName", Caption = "货品类别", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CustName", FieldName = "CustName", Caption = "客户名", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Qty", FieldName = "Qty", Caption = "订单数", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "MUnitID", FieldName = "MUnitID", Caption = "单位", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "NewCreateTime", FieldName = "NewCreateTime", Caption = "备份时间", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Rem", FieldName = "Rem", Caption = "备注", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns["BilDate"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView2.Columns["NewCreateTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            //gridView1.Columns["BeginLoadTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            //gridView1.Columns["PassTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            //gridView1.Columns["CreateTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
        }
        /// <summary>
        /// 手动添加第二个GridView列
        /// </summary>
        private void gridview2columbinding()
        {
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Code", FieldName = "Code", Caption = "车号", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Driver", FieldName = "Driver", Caption = "司机", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Tel", FieldName = "Tel", Caption = "电话", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ArriveTime", FieldName = "ArriveTime", Caption = "抵达时间", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "PrintTime", FieldName = "PrintTime", Caption = "打印时间", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateTime", FieldName = "CreateTime", Caption = "创建时间", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "创建人", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "NewCreateTime", FieldName = "NewCreateTime", Caption = "备份时间", VisibleIndex = 1, Visible = Enabled });
           // gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "rem", FieldName = "rem", Caption = "备注", VisibleIndex = 1, Visible = Enabled });
            //gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "MUnitID", FieldName = "MUnitID", Caption = "单位", VisibleIndex = 1, Visible = Enabled });
            //gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "NewCreateTime", FieldName = "NewCreateTime", Caption = "备份时间", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns["ArriveTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView1.Columns["CreateTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView1.Columns["PrintTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView1.Columns["NewCreateTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            //gridView1.Columns["BeginLoadTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            //gridView1.Columns["PassTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            //gridView1.Columns["CreateTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
        }
        /// <summary>
        /// 手动添加第三个GridView列
        /// </summary>
        private void gridview3columbinding()
        {
            gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "AutoCode", FieldName = "AutoCode", Caption = "车号", VisibleIndex = 1, Visible = Enabled });
            gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Tel", FieldName = "Tel", Caption = "电话", VisibleIndex = 1, Visible = Enabled });
            gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Driver", FieldName = "Driver", Caption = "司机", VisibleIndex = 1, Visible = Enabled });
            gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "BilNo", FieldName = "BilNo", Caption = "通知单号", VisibleIndex = 1, Visible = Enabled });
            gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Qty", FieldName = "Qty", Caption = "订单量", VisibleIndex = 1, Visible = Enabled });
            gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "BilDate", FieldName = "BilDate", Caption = "通知单时间", VisibleIndex = 1, Visible = Enabled });
            gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "MatName", FieldName = "MatName", Caption = "物料名", VisibleIndex = 1, Visible = Enabled });
            gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "BilType1", FieldName = "BilType1", Caption = "3S打印", VisibleIndex = 1, Visible = Enabled });
            gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ContBilNo", FieldName = "ContBilNo", Caption = "合同号", VisibleIndex = 1, Visible = Enabled });
            gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ArriveTime", FieldName = "ArriveTime", Caption = "抵达时间", VisibleIndex = 1, Visible = Enabled });
            gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "NewCreateTime", FieldName = "NewCreateTime", Caption = "备份时间", VisibleIndex = 1, Visible = Enabled });
            gridView3.Columns["BilDate"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView3.Columns["ArriveTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";            
            gridView3.Columns["NewCreateTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            //gridView1.Columns["BeginLoadTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            //gridView1.Columns["PassTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            //gridView1.Columns["CreateTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
        }
        #endregion
    }
}