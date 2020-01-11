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
    public partial class ChangeDateFrm : DevExpress.XtraEditors.XtraForm
    {
        public ChangeDateFrm()
        {
            InitializeComponent();
            LoadSet();
            InitializeSet();
        }
        int rowselect = -1;
        void InitializeSet()
        {
            txtFilter.TextChanged += TxtFilter_TextChanged;//初始化过滤按钮
            this.gridView1.RowClick += GridView1_RowClick;//初始化点击第一个页面
        }

        private void GridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            rowselect = this.gridView1.GetDataSourceRowIndex(e.RowHandle);
            List<StcStockShiftDtlMD> lsm = this.gridControl1.DataSource as List<StcStockShiftDtlMD>;
            if (rowselect < 0) return;
            this.gridControl3.DataSource=  getSacOutSuperviseByBilNo(lsm[rowselect].IDFrom.ToString());
            bindingGridview2(lsm[rowselect].ID);
        }

        void LoadSet()
        {
            dtStartTime.DateTime = DateTime.Now.AddMonths(-1);
            dtEndTime.DateTime = DateTime.Now;
            dtSetTime.DateTime = DateTime.Now;
            gridviewcolumbinding(this.gridView1);
            gridviewcolumbinding2(this.gridView2);
            gridview3columbinding();
            setGridView setGridView = new setGridView();
            setGridView.CustomizeGridView(gridView1);
            setGridView.CustomizeGridView(gridView2);
            setGridView.CustomizeGridView(gridView3);
            sbtnUpdata1.Click += SbtnUpdata1_Click;//更新第一个页面
        }
        int FirstRow = -1;
        int secondRow = -1;
        int ThreeRow = -1;
        private void SbtnUpdata1_Click(object sender, EventArgs e)
        {
            if(FirstRow<0)
            {
                MessageBox.Show("请选择需要修改的列！");
                return;
            }
            List<StcStockShiftDtlMD> lssd = this.gridControl1.DataSource as List<StcStockShiftDtlMD>;

            if(rbSSS.Checked==true)
            {
                upFirstGridview(lssd[FirstRow].ID, dtSetTime.DateTime);

            }
        }
        #region ------------------------------《事件》-------------------------
        #region 根据通知单号查询发货信息
        /// <summary>
        /// 根据通知单号查询发货信息
        /// </summary>
        /// <param name="BilNo">通知单号</param>        
        /// <returns>发货信息</returns>
        public List<V_SacOutSuperviseMD> getSacOutSuperviseByBilNo(string BilNo)
        {
            groupControl3.Text = "监装信息";
            SacOutSuperviseManager soss = new SacOutSuperviseManager();
            return soss.getSacOutSuperviseByIDFrom(BilNo);
        }
        #endregion
        //过滤查询
        private void TxtFilter_TextChanged(object sender, EventArgs e)
        {
            this.gridView1.FindFilterText = txtFilter.Text.Trim();
        }
        private void btSearch_Click(object sender, EventArgs e)
        {
            if(txtBilNo.Text.Trim()=="")
            {
                error.SetError(txtBilNo,"发货单号不能为空！");
                txtBilNo.Focus();
                return;
            }
            string check = txtBilNo.Text.Trim().Substring(0,4);
            if(check== "DELV")
            {
                
            }else if(check == "DEDR")
            {

            }
            
        }
        #endregion
        #region -------------------------------《方法》--------------------------
        /// <summary>
        /// 表体修改
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="dateTime"></param>
        void upFirstGridview(long ID,DateTime dateTime)
        {
            StcStockShiftdtlManager stc = new StcStockShiftdtlManager();
            if( stc.UpdataSSSDtlByID(ID,dateTime,dateTime,dateTime,dateTime,dateTime)==true)
            {
                MessageBox.Show("第一个表体更新成功！");
                bindingsssGridview();
            }
        }
        /// <summary>
        /// 头修改
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="dateTime"></param>
        void upSecondGridview(long ID, DateTime dateTime)
        {
            StcStockShiftdtlManager stc = new StcStockShiftdtlManager();
            stc.UpdataSSSByID(ID, dateTime);
        }
        /// <summary>
        /// 头修改
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="dateTime"></param>
        void upThreeGridview(long ID, DateTime dateTime)
        {
            StcStockShiftdtlManager stc = new StcStockShiftdtlManager();
            stc.UpdataSasByID(ID, dateTime);
        }
        /// <summary>
        /// 绑定第二个gridview页面
        /// </summary>
        /// <param name="ID"></param>
        void bindingGridview2(long ID)
        {
            groupControl2.Text = "调拨单表头";
            StcStockShiftdtlManager stc = new StcStockShiftdtlManager();
            this.gridControl2.DataSource = stc.getSSSByID(ID);
        }
        /// <summary>
        /// 手动添加第二个GridView列
        /// </summary>
        private void gridview3columbinding()
        {

            gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
           // gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "MatName", FieldName = "MatName", Caption = "物料名", VisibleIndex = 1, Visible = Enabled });
            //gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "IDFrom", FieldName = "IDFrom", Caption = "来源单号", VisibleIndex = 1, Visible = Enabled });
            gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "AutoCode", FieldName = "AutoCode", Caption = "车号", VisibleIndex = 1, Visible = Enabled });
            //gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Driver", FieldName = "Driver", Caption = "司机", VisibleIndex = 1, Visible = Enabled });
            //gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "BilNo", FieldName = "BilNo", Caption = "来源通知单", VisibleIndex = 1, Visible = Enabled });
           // gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "MatName", FieldName = "MatName", Caption = "货品名称", VisibleIndex = 1, Visible = Enabled });
           // gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ToCust", FieldName = "ToCust", Caption = "客户", VisibleIndex = 1, Visible = Enabled });
           // gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "StockName", FieldName = "StockName", Caption = "仓库", VisibleIndex = 1, Visible = Enabled });
           // gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "QtyTare", FieldName = "QtyTare", Caption = "皮重（顿）", VisibleIndex = 1, Visible = Enabled });
           // gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "TareTime", FieldName = "TareTime", Caption = "皮重过磅时间", VisibleIndex = 1, Visible = Enabled });
           // gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "TareStfName", FieldName = "TareStfName", Caption = "皮重录入", VisibleIndex = 1, Visible = Enabled });
           // gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Qty", FieldName = "QtyGross", Caption = "毛重（顿）", VisibleIndex = 1, Visible = Enabled });
            gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "GrossTime", FieldName = "GrossTime", Caption = "出货时间", VisibleIndex = 1, Visible = Enabled });
           // gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "GrossStfName", FieldName = "GrossStfName", Caption = "毛重录入", VisibleIndex = 1, Visible = Enabled });
           // gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "BeginLoadStfName", FieldName = "BeginLoadStfName", Caption = "入线装货记录", VisibleIndex = 1, Visible = Enabled });
           // gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "BeginLoadTime", FieldName = "BeginLoadTime", Caption = "入线时间", VisibleIndex = 1, Visible = Enabled });
           // gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "InLine", FieldName = "InLine", Caption = "装货线", VisibleIndex = 1, Visible = Enabled });
           // gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "EndLoadStfName", FieldName = "EndLoadStfName", Caption = "装车完毕记录", VisibleIndex = 1, Visible = Enabled });
            gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "EndLoadTime", FieldName = "EndLoadTime", Caption = "完成时间", VisibleIndex = 1, Visible = Enabled });
           // gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "PassStfName", FieldName = "PassStfName", Caption = "品管放行人", VisibleIndex = 1, Visible = Enabled });
           // gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "PassTime", FieldName = "PassTime", Caption = "品管放行时间", VisibleIndex = 1, Visible = Enabled });
           // gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "发货单创建人", VisibleIndex = 1, Visible = Enabled });
           // gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateTime", FieldName = "CreateTime", Caption = "发货单创建时间", VisibleIndex = 1, Visible = Enabled });
           // gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "QtyCheck15", FieldName = "QtyCheck15", Caption = "合格证编号", VisibleIndex = 1, Visible = Enabled });
            //gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "发货单创建人", VisibleIndex = 1, Visible = Enabled });
            //gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "发货单创建人", VisibleIndex = 1, Visible = Enabled });
            //gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "发货单创建人", VisibleIndex = 1, Visible = Enabled });
            //gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "发货单创建人", VisibleIndex = 1, Visible = Enabled });
            //gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "发货单创建人", VisibleIndex = 1, Visible = Enabled });
            //gridView3.Columns["GrossTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
           // gridView3.Columns["TareTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView3.Columns["GrossTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
             gridView3.Columns["EndLoadTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
           // gridView3.Columns["PassTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
           // gridView3.Columns["CreateTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
        }

        /// <summary>
        /// 绑定调拨单
        /// </summary>
        void bindingsssGridview()
        {
            groupControl1.Text = "调拨单表体（DTL）";
            StcStockShiftdtlManager stc = new StcStockShiftdtlManager();
            this.gridControl1.DataSource = stc.getSSSByDate(dtStartTime.DateTime,dtEndTime.DateTime);
        }
       
        #endregion
        private void gridviewcolumbinding(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "BilID", FieldName = "BilID", Caption = "单据ID", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "BilDate", FieldName = "BilDate", Caption = "订单日期", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "BilNo", FieldName = "BilNo", Caption = "订单号", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "IDFrom", FieldName = "IDFrom", Caption = "通知单号", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Qty", FieldName = "Qty", Caption = "出货数量（顿）", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "GrossTime", FieldName = "GrossTime", Caption = "出货时间", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns["GrossTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView.Columns["BilDate"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
        }
        private void gridviewcolumbinding2(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            //gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "AutoCode", FieldName = "AutoCode", Caption = "车号", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "BilDate", FieldName = "BilDate", Caption = "订单时间", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateTime", FieldName = "CreateTime", Caption = "创建时间", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CheckTime", FieldName = "CheckTime", Caption = "检查时间", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "EffectTime", FieldName = "EffectTime", Caption = "审核时间", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "PrintTime", FieldName = "PrintTime", Caption = "打印时间", VisibleIndex = 1, Visible = Enabled });
            //gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "GrossTime", FieldName = "GrossTime", Caption = "出货时间", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns["CreateTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView.Columns["BilDate"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView.Columns["CheckTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView.Columns["EffectTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView.Columns["PrintTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
        }

        private void sbtnSearch_Click(object sender, EventArgs e)
        {
            if(rbSSS.Checked==true)
            {
                bindingsssGridview();
            }
        }
    }
}