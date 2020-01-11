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
    public partial class CustermoPriceFrm : DevExpress.XtraEditors.XtraForm
    {
        public CustermoPriceFrm()
        {
            InitializeComponent();
            InitializeSet();
            Loadset();
        }
        private void Loadset()
        {
            dtEndTime.DateTime = DateTime.Now;
            dtStartTime.DateTime = DateTime.Now.AddDays(-1);
            setGridView setGridView = new setGridView();
            setGridView.CustomizeGridView(gridView1);            
        }
        int selectRow = -1;
        private void InitializeSet()
        {
            sbtnSearch.Click += SbtnSearch_Click;
            rbBody.Click += RbBody_Click;
            rbDtl.Click += RbDtl_Click;
            txtFilter.TextChanged += TxtFilter_TextChanged;
            this.gridView1.RowClick += GridView1_RowClick;
            txtNewQty.TextChanged += TxtNewQty_TextChanged;
        }

        private void TxtNewQty_TextChanged(object sender, EventArgs e)
        {
            error.SetError(txtNewQty,"");
        }

        private void GridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            txtOldQty.Tag = null;
            selectRow = this.gridView1.GetDataSourceRowIndex(e.RowHandle);
            if(rbBody.Checked==true)
            {
                List<DelAlloAutoMD> delAlloAutoMDs = new List<DelAlloAutoMD>();
                delAlloAutoMDs = this.gridControl1.DataSource as List<DelAlloAutoMD>;
                txtOldQty.Text = delAlloAutoMDs[selectRow].My1_UDsg.ToString();
                txtOldQty.Tag = delAlloAutoMDs[selectRow].ID;
            }else if(rbDtl.Checked==true)
            {
                List<DelAlloAutoDtlMD> delAlloAutoMDs = new List<DelAlloAutoDtlMD>();
                delAlloAutoMDs = this.gridControl1.DataSource as List<DelAlloAutoDtlMD>;
                txtOldQty.Text = delAlloAutoMDs[selectRow].PriceFrei.ToString();
                txtOldQty.Tag = delAlloAutoMDs[selectRow].ID;
            }
        }

        private void TxtFilter_TextChanged(object sender, EventArgs e)
        {
            this.gridView1.FindFilterText=txtFilter.Text;
        }

        private void RbDtl_Click(object sender, EventArgs e)
        {
            if(rbDtl.Checked==true)
            {
                this.gridView1.Columns.Clear();
                gridviewcolumbindingDtl(this.gridView1);
                bindingGridviewDtl();
            }
            
        }

        private void RbBody_Click(object sender, EventArgs e)
        {
            if(rbBody.Checked==true)
            {
                this.gridView1.Columns.Clear();
                gridviewcolumbinding(this.gridView1);
                bindingGridview();
                gridView1.OptionsView.ColumnAutoWidth = true;
            }

        }

        private void SbtnSearch_Click(object sender, EventArgs e)
        {
            if(LoginForm.pubDelIn.LoginName!="test")
            {
                sbtnSearch.Enabled = false;
            }
            if(txtNewQty.Text.Trim()=="")
            {
                if(txtNewQty.Text.Trim()=="")
                {
                    error.SetError(txtNewQty,"不能为空！");
                    return;
                }
            }
            if(txtOldQty.Tag==null)
            {
                return;
            }
            if(rbBody.Checked==true)
            {
                Updata(long.Parse(txtOldQty.Tag.ToString()),decimal.Parse(txtNewQty.Text.Trim()));
            }
            else if(rbDtl.Checked==true)
            {
                UpdataDtl(long.Parse(txtOldQty.Tag.ToString()), decimal.Parse(txtNewQty.Text.Trim()));
            }
        }
        private void gridviewcolumbinding(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "BilNo", FieldName = "BilNo", Caption = "单据号", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "BilDate", FieldName = "BilDate", Caption = "订单日期", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "My1_UDsg", FieldName = "My1_UDsg", Caption = "客户运价", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "IDFrom", FieldName = "IDFrom", Caption = "来源单据", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Rem", FieldName = "Rem", Caption = "备注", VisibleIndex = 1, Visible = Enabled });
            //gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "GrossTime", FieldName = "GrossTime", Caption = "出货时间", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns["BilDate"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
           // gridView.Columns["BilDate"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
        }
        private void gridviewcolumbindingDtl(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "BilNo", FieldName = "BilNo", Caption = "单据号", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Qty", FieldName = "Qty", Caption = "数量", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "PriceFrei", FieldName = "PriceFrei", Caption = "实际运价", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "AutoCode", FieldName = "AutoCode", Caption = "车号", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ToCust", FieldName = "ToCust", Caption = "客户", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "MatName", FieldName = "MatName", Caption = "物料名", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "BilDate", FieldName = "BilDate", Caption = "订单时间", VisibleIndex = 1, Visible = Enabled });
            gridView.Columns["BilDate"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            // gridView.Columns["BilDate"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
        }
        private void bindingGridview()
        {
            DelAlloAutoManager delAlloAutoManager = new DelAlloAutoManager();
            this.gridControl1.DataSource = delAlloAutoManager.getDelAlloAuto(dtStartTime.DateTime,dtEndTime.DateTime);
        }
        private void bindingGridviewDtl()
        {
            DelAlloAutoManager delAlloAutoManager = new DelAlloAutoManager();
            this.gridControl1.DataSource = delAlloAutoManager.getDelAlloAutoDTL(dtStartTime.DateTime, dtEndTime.DateTime);
        }
        /// <summary>
        /// 修改实际运价
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="price"></param>
        private void UpdataDtl(long ID,decimal price)
        {
            DelAlloAutoManager delAlloAutoManager = new DelAlloAutoManager();
            if(delAlloAutoManager.UpdateDelAlloAutoDtl(ID, price)==true)
            {
                MessageBox.Show("修改实际运价成功！");
                bindingGridviewDtl();
                selectRow = -1;
            }
            else
            {
                MessageBox.Show("修改实际运价失败！");
            }
        }
        /// <summary>
        /// 修改客户运价
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="price"></param>
        private void Updata(long ID, decimal My1_UDsg)
        {
            DelAlloAutoManager delAlloAutoManager = new DelAlloAutoManager();
            if (delAlloAutoManager.UpdateDelAlloAuto(ID, My1_UDsg) == true)
            {
                MessageBox.Show("修改客户运价成功！");
                bindingGridview();
                selectRow = -1;
            }
            else
            {
                MessageBox.Show("修改客户运价失败！");
            }
        }
    }
}