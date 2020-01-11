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
    public partial class ChangeSyobinAutocordeFrm : DevExpress.XtraEditors.XtraForm
    {
        public ChangeSyobinAutocordeFrm()
        {
            InitializeComponent();
            LoadSet();
            InitializeSet();
        }
        /// <summary>
        /// 初始化设置
        /// </summary>
        void InitializeSet()
        {
            txtFilter.TextChanged += TxtFilter_TextChanged;//过滤事件
            sbtnSearch.Click += SbtnSearch_Click;//初始化按钮事件
            sbtnStop.Click += SbtnStop_Click;//停用设备
            this.gridView1.RowClick += GridView1_RowClick;
        }

        private void SbtnStop_Click(object sender, EventArgs e)
        {
            PurAlloShoManager purAlloShoManager = new PurAlloShoManager();
            if(purAlloShoManager.UpdatePurAlloSho(long.Parse(lbID.Tag.ToString()),DateTime.Now)==true)
            {
                MessageBox.Show("OK");
            }
        }

        private void GridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            SelectRow = this.gridView1.GetDataSourceRowIndex(e.RowHandle);           
            List<PurAlloShoMD> purAlloShoMDs = new List<PurAlloShoMD>();
            purAlloShoMDs = this.gridControl1.DataSource as List<PurAlloShoMD>;
            lbID.Text = "ID号：" + purAlloShoMDs[SelectRow].ID.ToString();
            lbID.Tag = purAlloShoMDs[SelectRow].ID;
            txtShipName.Text = purAlloShoMDs[SelectRow].ShipName;
        }

        /// <summary>
        /// 过滤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtFilter_TextChanged(object sender, EventArgs e)
        {
            this.gridView1.FindFilterText=txtFilter.Text.Trim();
        }
        /// <summary>
        /// 点击查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SbtnSearch_Click(object sender, EventArgs e)
        {
            BindingGridview(dtStartTime.DateTime,dtEndTime.DateTime) ;
        }

        /// <summary>
        /// 加载设置
        /// </summary>
        void LoadSet()
        {
            //页面加载时，开始时间调整为一个月前
            dtStartTime.DateTime = DateTime.Now.AddDays(-30);
            dtEndTime.DateTime = DateTime.Now;
            //窗体内容修改
            setGridView setGridView = new setGridView();
            setGridView.CustomizeGridView(this.gridView1);
            gridviewcolumbinding(this.gridView1);
        }
        int SelectRow = -1;

        #region ---------------------------<<方法>>--------------------

        #region --------------<<逻辑方法>>--------------
        /// <summary>
        /// 绑定数据到列表
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        void BindingGridview(DateTime startTime,DateTime endTime)
        {
            PurAlloShoManager purAlloShoManager = new PurAlloShoManager();
            this.gridControl1.DataSource = purAlloShoManager.getDelAlloAuto(startTime,endTime);
        }


        #endregion

        #region ---------------------<<页面方法>>---------------

        private void gridviewcolumbinding(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "AutoCode", FieldName = "AutoCode", Caption = "车号", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Driver", FieldName = "Driver", Caption = "司机", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ShipName", FieldName = "ShipName", Caption = "船名", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Rem", FieldName = "Rem", Caption = "备注", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "UnLoadTime", FieldName = "UnLoadTime", Caption = "卸车时间", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "SealsTime", FieldName = "SealsTime", Caption = "铅封时间", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "IsStop", FieldName = "IsStop", Caption = "是否停用", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "StopTime", FieldName = "StopTime", Caption = "停用时间", VisibleIndex = 1, Visible = Enabled });
            //gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "GrossTime", FieldName = "GrossTime", Caption = "出货时间", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns["UnLoadTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
             gridView.Columns["SealsTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView.Columns["StopTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
           // gridView.Columns["BilDate"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
        }

        #endregion

        #endregion
    }
}