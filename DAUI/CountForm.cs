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
using DA.MODEL;
using DA.BLL;
using DevExpress.Utils;


namespace DAUI
{
    public partial class CountForm : DevExpress.XtraEditors.XtraForm
    {
        public CountForm()
        {
            InitializeComponent();
        }

        #region ----------搜索事件-----------
        /// <summary>
        /// 搜索事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            inCheck();
            
            
        } 
        #endregion

        #region ---------------绑定GridView数据----------------
        /// <summary>
        /// 绑定GridView数据
        /// </summary>
        private void gridviewBinding()
        {
            CountQtyManager cqm = new CountQtyManager();
            List<V_CountQtyMD> lv = cqm.getCountByTimeAndMatName(lbMatName.SelectedItem.ToString(), dteStart.DateTime, dteEnd.DateTime);
            this.gridControl1.DataSource = lv;
            lbCount.Text = lbMatName.SelectedItem.ToString() + " 在 " + dteStart.Text + " -- " + dteEnd.Text + "时间内总共出货" + CoutQty().ToString() + " 顿。\t\n" + "出厂车次总数： " + this.gridView1.RowCount.ToString() +
                "台。\t\n"+"出厂车辆总数 " +coutAutoCode().ToString()+" 台。";
        } 
        #endregion

        #region -----------------统计出货数量-----------------
        /// <summary>
        /// 统计出货数量
        /// </summary>
        /// <returns>出库数量</returns>
        private decimal CoutQty()
        {
            List<V_CountQtyMD> lv = this.gridControl1.DataSource as List<V_CountQtyMD>;
            decimal cout = 0;
            foreach (V_CountQtyMD vc in lv)
            {
                cout += (decimal)vc.Qty;
            }
            return cout;
        } 
        #endregion

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
            de.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
        }
        #endregion

        #region --------------------窗体加载------------------
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CountForm_Load(object sender, EventArgs e)
        {
            WaitDialogForm wf = new WaitDialogForm("加载中，请稍后。。。。", "软件提示");
            wf.Show();
            setGridView sg = new setGridView();
            sg.CustomizeGridView(this.gridView1);
            gridView1.OptionsView.ColumnAutoWidth = true;
            gridview2columbinding();
            showDate(dteStart);
            showDate(dteEnd);
            wf.Close();
        }
        #endregion

        #region -----------------输入不内容是否合理------------------
        /// <summary>
        /// 输入不内容是否合理
        /// </summary>
        private void inCheck()
        {
            if (lbMatName.SelectedItem == null)
            {
                MessageBox.Show("请选择需要查询的物料名称！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbMatName.Focus();
                return;
            }
            if (dteStart.EditValue == null)
            {
                MessageBox.Show("开始时间不能为空！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dteStart.Focus();
                return;
            }
            if (dteEnd.EditValue == null)
            {
                MessageBox.Show("结束时间不能为空！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dteEnd.Focus();
                return;
            }
            if (DateTime.Compare(dteStart.DateTime, dteEnd.DateTime) > 0)
            {
                MessageBox.Show("开始时间不能大于结束时间！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dteEnd.Focus();
                return;
            }
            gridviewBinding();
            coutAutoCode();
        } 
        #endregion

        #region -------------手动添加第一个GridView列-----------
        /// <summary>
        /// 手动添加第一个GridView列
        /// </summary>
        private void gridview2columbinding()
        {
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "AutoCode", FieldName = "AutoCode", Caption = "车号", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "MatName", FieldName = "MatName", Caption = "物料名称", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "QtyGross", FieldName = "QtyGross", Caption = "毛重（顿）", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "QtyTare", FieldName = "QtyTare", Caption = "皮重（顿）", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Qty", FieldName = "Qty", Caption = "出货数量（顿）", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "GrossTime", FieldName = "GrossTime", Caption = "出货时间", VisibleIndex = 1, Visible = Enabled });            
            gridView1.Columns["GrossTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
        }
        #endregion

        private int coutAutoCode()
        {
            int a = 0;            
            List<V_CountQtyMD> lv = this.gridControl1.DataSource as List<V_CountQtyMD>;
            foreach (V_CountQtyMD vc in lv)
            {
                if (vc.AutoCode!="无")
                {
                    a += 1;
                }
            }          
            return a;
        }
    }
}