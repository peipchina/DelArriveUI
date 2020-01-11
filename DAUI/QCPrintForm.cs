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
using Stimulsoft.Report;
using DevExpress.XtraGrid.Views.Base;

namespace DAUI
{
    public partial class QCPrintForm : DevExpress.XtraEditors.XtraForm
    {
        public QCPrintForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dteStart.EditValue==null)
            {
                MessageBox.Show("开始时间不能为空！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dteStart.Focus();
                return;
            }
            if (dteEnd.EditValue==null)
            {
                MessageBox.Show("结束时间不能为空！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dteEnd.Focus();
                return;
            }
            GridViewBinding();
        }

        private void GridViewBinding()
        {
            QCPrintManger qcp = new QCPrintManger();
            List<V_QCPrintMD> lvq = qcp.getAllQCPrintListByDate(dteStart.DateTime,dteEnd.DateTime);            
            this.gridControl1.DataSource = lvq;
        }
        private void GridViewBindingByLoad()
        {
            QCPrintManger qcp = new QCPrintManger();
            List<V_QCPrintMD> lvq = qcp.getAllQCPrintList();
            this.gridControl1.DataSource = lvq;
        }
        #region --------------------定义时间窗口选择到秒---------------
        /// <summary>
        /// 定义时间窗口选择到秒
        /// </summary>
        /// <param name="de"></param>
        private void showDate(DateEdit de)
        {
            de.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            de.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.True;

            //设置显示长日期模式（精确到秒）：
            de.Properties.DisplayFormat.FormatString = "G";
            de.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            de.Properties.EditFormat.FormatString = "G";
            de.Properties.Mask.EditMask = "G";
            de.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
        }
        #endregion

        private void QCPrintForm_Load(object sender, EventArgs e)
        {
            setGridView sg = new setGridView();
            sg.CustomizeGridView(this.gridView1);
            showDate(dteEnd);
            showDate(dteStart);
           // gridview1columbinding();
            GridViewBindingByLoad();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (select > -1&&lbSelect.SelectedItem!=null)
            {
                string report = lbSelect.SelectedItem.ToString();
                PrinQC(report);
            }
            else
            {
                MessageBox.Show("请选择打印源！","提示框",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
        }

        private void PrinQC(string report)
        {
            try
            {
                List<V_QCPrintMD> lv = this.gridControl1.DataSource as List<V_QCPrintMD>;
                V_QCPrintMD vq = lv[select];
                StiReport sr = new StiReport();
                sr.Load(report + ".mrt");
                sr.Dictionary.Clear();
                sr.Dictionary.BusinessObjects.Clear();
                sr.RegBusinessObject("SacOutSupervise", vq);
                sr.Dictionary.Synchronize();
                sr.Dictionary.SynchronizeBusinessObjects();
                sr.Compile();
                sr.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("无可打印数据源！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void DesintQC(string report)
        {
            try
            {
                List<V_QCPrintMD> lv = this.gridControl1.DataSource as List<V_QCPrintMD>;
                V_QCPrintMD qcp = lv[select];
                StiReport sr = new StiReport();
                sr.Load(report + ".mrt");
                sr.Dictionary.Clear();
                sr.Dictionary.BusinessObjects.Clear();
                sr.RegBusinessObject(report, qcp);
                sr.Dictionary.Synchronize();
                sr.Dictionary.SynchronizeBusinessObjects();                
                sr.Design();
                
            }
            catch (Exception)
            {
                MessageBox.Show("无可打印数据源！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        int select = -1;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            select = this.gridView1.GetDataSourceRowIndex(e.FocusedRowHandle);
            
        }

        private void btnPrintEdit_Click(object sender, EventArgs e)
        {
            if (select>-1)
            {
                string report = lbSelect.SelectedItem.ToString();
                DesintQC(report);                
            }
        }

        private void txbFilter_TextChanged(object sender, EventArgs e)
        {
            string filter = "[MatIDName] Like  " + "'%" + txbFilter.Text.Trim() + "%'";
            gridView1.Columns["MatIDName"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(filter);

            //ColumnView view = gridView1;
            //string filter = "[MatIDName] Like  " + "'%"+ txbFilter.Text.Trim()+"%'";
            //view.ActiveFilter.Add(view.Columns["MatIDName"],new DevExpress.XtraGrid.Columns.ColumnFilterInfo(filter, ""));
            label4.Text = this.gridView1.RowCount+"辆车正在装货！";
           // this.gridView1.FindFilterText = txbFilter.Text.Trim();
        }
        #region -------------手动添加第一个GridView列-----------
        /// <summary>
        /// 手动添加第一个GridView列
        /// </summary>
        private void gridview1columbinding()
        {           
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "AutoCode", FieldName = "AutoCode", Caption = "车号", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CheckStfName", FieldName = "CheckStfName", Caption = "检验人", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "MatIDName", FieldName = "MatIDName", Caption = "物料名", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "passName", FieldName = "passName", Caption = "放行人", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ContBilNo", FieldName = "ContBilNo", Caption = "合同号", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "MatTypeName", FieldName = "MatTypeName", Caption = "物料类型", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "MatName", FieldName = "MatName", Caption = "货品名称", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ToCust", FieldName = "ToCust", Caption = "客户", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "PassTime", FieldName = "PassTime", Caption = "放行时间", VisibleIndex = 1, Visible = Enabled });            
            gridView1.Columns["PassTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";           
        }
        #endregion

        private void lbSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (lbSelect.SelectedItem.ToString())
            {
                case "豆油化验单":
                    this.gridView1.FindFilterText = "一级大豆油";
                    break;
                case "磷脂化验单":
                    this.gridView1.FindFilterText = "大豆磷脂油";
                    break;
                case "豆粕化验单":
                    this.gridView1.FindFilterText = "豆粕";
                    break;
                case "散装豆粕-46合格证":
                    this.gridView1.FindFilterText = "豆粕≥46";
                    break;
                case "散装大豆磷脂油合格证":
                    this.gridView1.FindFilterText = "大豆磷脂油（散）";
                    break;
                case "散装豆粕-43合格证":
                    this.gridView1.FindFilterText = "豆粕≥43%散装";
                    break;
                case "散装植物油装运清单":
                    this.gridView1.FindFilterText = "植物油";
                    break;
                case "一级散油标签":
                    this.gridView1.FindFilterText = "一级大豆油";
                    break;
                case "大豆原油标签":
                    this.gridView1.FindFilterText = "大豆原油";
                    break;
                case "大豆原油化验单":
                    this.gridView1.FindFilterText = "大豆原油";                    
                    break;
                case "皂角化验单":
                    this.gridView1.FindFilterText = "皂角";
                    break;
                case "显示全部":
                    this.gridView1.FindFilterText = "";
                    break;
                default:
                    lbSelect.Tag = lbSelect.SelectedItem.ToString();
                    break;
            }
        }
    }
}