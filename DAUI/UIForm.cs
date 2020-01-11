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
using DevExpress.Utils;

namespace DAUI
{
    public partial class UIForm : DevExpress.XtraEditors.XtraForm
    {
        public UIForm()
        {
            InitializeComponent();
        }

        #region 绑定第一个GridView方法
        /// <summary>
        /// 绑定第一个GridView方法
        /// </summary>
        private void DelArriveBinding()
        {
            
            setGridView sg = new setGridView();
            sg.CustomizeGridView(gridView1);
            DelArriveManager dam = new DelArriveManager();
            List<V_DelArrive> lv = dam.getAllDelArrive();
            this.gridControl1.DataSource = lv;
        }
        #endregion

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

        #region 绑定第二个Gridview方法查询
        /// <summary>
        /// 绑定第二个Gridview方法查询
        /// </summary>
        /// <param name="Code">车号</param>
        private void ArriveCodeBinding(string Code)
        {
            
            
            DelArriveManager dam = new DelArriveManager();
            List<V_DelArriveMD> lv = dam.getArriveByAutoCod(Code);
            this.gridControl2.DataSource = lv;
        } 
        #endregion

        #region 窗体加载事件
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UIForm_Load(object sender, EventArgs e)
        {
            WaitDialogForm wdf = new WaitDialogForm("加载中，请稍后。。。。", "软件提示");
            wdf.Show();
            gridview2columbinding();
            gridview1columbinding();
            setGridView sg = new setGridView();
            sg.CustomizeGridView(gridView2);
            sg.CustomizeGridView(gridView1);
            DelArriveBinding();
            wdf.Close();
        }
        #endregion

        #region 选择第一个Gridview，根据车号显示第二个gridview内容
        /// <summary>
        /// 选择第一个Gridview，根据车号显示第二个gridview内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">车号</param>
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            int select = -1;
            select = this.gridView1.GetDataSourceRowIndex(e.RowHandle);

            if (select > -1)
            {
                DelArriveManager dam = new DelArriveManager();
                //List<V_DelArrive> lv = dam.getAllDelArrive();
                V_DelArrive lv = (gridControl1.DataSource as List<V_DelArrive>)[select];
                ArriveBinding(lv.AutoCode);
            }
        }
        #endregion

        #region 刷新事件
        /// <summary>
        /// 刷新事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            DelArriveBinding();
        }
        #endregion

        #region 车号过滤事件
        /// <summary>
        /// 车号过滤事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbFilter_TextChanged(object sender, EventArgs e)
        {
            this.gridView1.FindFilterText = txbFilter.Text.Trim();
            this.gridView2.FindFilterText = txbFilter.Text.Trim();
        }
        #endregion

        #region 更加车号模糊查询事件
        /// <summary>
        /// 更加车号模糊查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (txbAutoCode.Text.Trim() != string.Empty)
            {
                ArriveCodeBinding("%" + txbAutoCode.Text.Trim() + "%");
            }
        }
        #endregion


        #region 手动添加第一个GridView列
        /// <summary>
        /// 手动添加第一个GridView列
        /// </summary>
        private void gridview1columbinding()
        {
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "AutoCode", FieldName = "AutoCode", Caption = "车号", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Driver", FieldName = "Driver", Caption = "司机姓名", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Tel", FieldName = "Tel", Caption = "电话", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ContBilNo", FieldName = "ContBilNo", Caption = "合同号", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "MatName", FieldName = "MatName", Caption = "物料", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CustName", FieldName = "CustName", Caption = "客户", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "BilDate", FieldName = "BilDate", Caption = "配车时间", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Qty", FieldName = "Qty", Caption = "配车数量", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "OldCode", FieldName = "OldCode", Caption = "旧车号", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "BilCreateTime", FieldName = "BilCreateTime", Caption = "车号修改时间", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns["BilDate"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView1.Columns["BilCreateTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
        }
        #endregion

        #region 手动添加第二个Gridview列
        /// <summary>
        /// 手动添加第二个Gridview列
        /// </summary>
        private void gridview2columbinding()
        {
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Code", FieldName = "Code", Caption = "车号", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Driver", FieldName = "Driver", Caption = "司机姓名", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Tel", FieldName = "Tel", Caption = "电话", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ArriveTime", FieldName = "ArriveTime", Caption = "抵达时间", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Rem", FieldName = "Rem", Caption = "备注", VisibleIndex = 3, Visible = Enabled });            
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "创建人", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateTime", FieldName = "CreateTime", Caption = "创建时间", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "StopTime", FieldName = "StopTime", Caption = "出厂时间", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns["ArriveTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView2.Columns["CreateTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView2.Columns["StopTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
        }
        #endregion

        #region 导出Excel方法
        /// <summary>
        /// 导出Excel方法
        /// </summary>
        public void ExportExcel()
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Excel文件|*.XLS|所有文件|*.*";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filename = saveFileDialog1.FileName;
                    this.gridView1.ExportToXls(filename);
                    MessageBox.Show("数据导出成功!", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception )
            {

                MessageBox.Show("文件已经打开，保存失败！") ;
                return;
            }
            
        }
        #endregion

        #region 导出Excel事件
        /// <summary>
        /// 导出Excel事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExportExcel();
        }
        #endregion

       
    }
}