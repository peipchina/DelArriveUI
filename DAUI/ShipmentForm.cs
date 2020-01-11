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
    public partial class ShipmentForm : DevExpress.XtraEditors.XtraForm
    {
        public ShipmentForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            gridviewBinding();
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
            de.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
        }
        #endregion

        #region -------------手动添加第一个GridView列-----------
        /// <summary>
        /// 手动添加第一个GridView列
        /// </summary>
        private void gridview1columbinding()
        {
           
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "AutoCode", FieldName = "AutoCode", Caption = "车号", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "matMaterial", FieldName = "matMaterial", Caption = "物料名", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "DelReachDtlBilNO", FieldName = "DelReachDtlBilNO", Caption = "通知单号", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "AutoCode", FieldName = "AutoCode", Caption = "车号", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "stockName", FieldName = "stockName", Caption = "仓库名", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "BilNo", FieldName = "BilNo", Caption = "来源通知单", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "MatName", FieldName = "MatName", Caption = "货品名称", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ToCust", FieldName = "ToCust", Caption = "客户", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "StockName", FieldName = "StockName", Caption = "仓库", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "QtyTare", FieldName = "QtyTare", Caption = "皮重（顿）", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "TareTime", FieldName = "TareTime", Caption = "皮重过磅时间", VisibleIndex = 1, Visible = false });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "TareStfName", FieldName = "TareStfName", Caption = "皮重录入", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Qty", FieldName = "QtyGross", Caption = "毛重（顿）", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "GrossTime", FieldName = "GrossTime", Caption = "出货时间", VisibleIndex = 1, Visible = false });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "GrossStfName", FieldName = "GrossStfName", Caption = "毛重录入", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "QtyNet", FieldName = "QtyNet", Caption = "净重", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "QtyPackBag", FieldName = "QtyPackBag", Caption = "包装数量", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "createStfName", FieldName = "createStfName", Caption = "创建人", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateTime", FieldName = "CreateTime", Caption = "创建时间", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "EndLoadTime", FieldName = "EndLoadTime", Caption = "完成时间", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "PassStfName", FieldName = "PassStfName", Caption = "品管放行人", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "PassTime", FieldName = "PassTime", Caption = "品管放行时间", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "发货单创建人", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateTime", FieldName = "CreateTime", Caption = "发货单创建时间", VisibleIndex = 1, Visible = Enabled });            
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "发货单创建人", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "发货单创建人", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "发货单创建人", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "发货单创建人", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "发货单创建人", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns["GrossTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            //gridView1.Columns["TareTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView1.Columns["CreateTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            //gridView1.Columns["BeginLoadTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            //gridView1.Columns["PassTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            //gridView1.Columns["CreateTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
        }
        #endregion

        private void ShipmentForm_Load(object sender, EventArgs e)
        {
            setGridView sg = new setGridView();
            sg.CustomizeGridView(this.gridView1);
            gridview1columbinding();
            showDate(dteStart);
            showDate(dteEnd);
            this.gridView1.RowClick += GridView1_RowClick;
            btnTotal.Click += BtnTotal_Click;
        }

        private void BtnTotal_Click(object sender, EventArgs e)
        {
            List<V_DelReachDtlMD> lv = this.gridControl1.DataSource as List<V_DelReachDtlMD>;
            decimal a = 0;
            foreach (V_DelReachDtlMD item in lv)
            {
                if ( item.matMaterial.Contains("70KG") == true )
                {
                    if (item.QtyNet == null || item.QtyNet <= 0) continue;
                    if (item.QtyPackBag == null || item.QtyPackBag <= 0) continue;
                    a += decimal.Parse(item.QtyNet.ToString()) - decimal.Parse(item.QtyPackBag.ToString()) * 70 / 1000;
                }
                else if (item.matMaterial.Contains("50KG") == true)
                {
                    if (item.QtyNet == null || item.QtyNet <= 0) continue;
                    if (item.QtyPackBag == null || item.QtyPackBag <= 0) continue;
                    a += decimal.Parse(item.QtyNet.ToString()) - decimal.Parse(item.QtyPackBag.ToString()) * 50 / 1000;
                }
                else
                {
                    continue;
                }
                
            }
            label8.Text = "统计为："+a+" 吨！";
        }

        private static int RowSelect = -1;
        private void GridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            RowSelect = this.gridView1.GetDataSourceRowIndex(e.RowHandle);
            List<V_DelReachDtlMD> lv = this.gridControl1.DataSource as List<V_DelReachDtlMD>;
            if (RowSelect > -1)
            {
                if (lv[RowSelect].matMaterial.Contains("70KG") == true)
                {
                    label7.Text = lv[RowSelect].AutoCode + "\t\n" + "净  重    为：" + lv[RowSelect].QtyNet.ToString() + " 吨。 包数为 " + lv[RowSelect].QtyPackBag.ToString() + " 包！" + "\t\n" +
                        "理论重量为：" + lv[RowSelect].QtyPackBag * 70 / 1000 + "  吨。" + "差别为： " + (lv[RowSelect].QtyNet - lv[RowSelect].QtyPackBag * 70 / 1000) + " 吨。";
                }
                else if (lv[RowSelect].matMaterial.Contains("50KG") == true)
                {
                    label7.Text = lv[RowSelect].AutoCode + "\t\n" + "净   重   为: " + lv[RowSelect].QtyNet.ToString() + " 吨。 包数为 " + lv[RowSelect].QtyPackBag.ToString() + " 包！" + "\t\n" +
                       "理论重量为：" + lv[RowSelect].QtyPackBag * 50 / 1000 + "  吨。" + "差别为： " + (lv[RowSelect].QtyNet - lv[RowSelect].QtyPackBag * 50 / 1000) + " 吨。";
                }
                else
                {
                    label7.Text = lv[RowSelect].AutoCode + "净重为: " + lv[RowSelect].QtyNet.ToString() + " 吨。  ";
                }
            }
        }

        private void gridviewBinding()
        {
            DelReachManager sosm = new DelReachManager();
            List<V_DelReachDtlMD> lv = sosm.getAllDelReachDtlByBilDate(dteStart.DateTime,dteEnd.DateTime);
            this.gridControl1.DataSource = lv;            
        }

        private void txbFilter_TextChanged(object sender, EventArgs e)
        {
            this.gridView1.FindFilterText = txbFilter.Text.Trim();
        }

        private void btnSearchByAutoCode_Click(object sender, EventArgs e)
        {
            if (txbAutoCode.Text.Trim()==string.Empty)
            {
                MessageBox.Show("车号不能为空！","提示框",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txbAutoCode.Focus();
                return;
            }
            DelReachManager sosm = new DelReachManager();
            List<V_DelReachDtlMD> lv = sosm.getAllDelReachDtlByAutoCode("%"+txbAutoCode.Text.Trim()+"%");
            this.gridControl1.DataSource = lv;
        }

        private void btnSearchByBilNo_Click(object sender, EventArgs e)
        {
            if (txbBilNo.Text.Trim() == string.Empty)
            {
                MessageBox.Show("通知单号不能为空！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbBilNo.Focus();
                return;
            }
            SacOutSuperviseManager sosm = new SacOutSuperviseManager();
            List<V_SacOutSuperviseMD> lv = sosm.getSacOutSuperviseByBilNo("%" + txbBilNo.Text.Trim() + "%");
            this.gridControl1.DataSource = lv;
        }

        private void btnSearchByMatName_Click(object sender, EventArgs e)
        {
            if (lbMatName.SelectedItem == null)
            {
                MessageBox.Show("请选择物料名称！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbMatName.Focus();
                return;
            }
            DelReachManager sosm = new DelReachManager();
            List<V_DelReachDtlMD> lv = sosm.getAllDelReachDtlByAutoCode("%" + lbMatName.SelectedItem.ToString()+ "%" );
            this.gridControl1.DataSource = lv;
        }

        //定义委托
        public delegate void MyDelegate(long a);
        //定义事件
        public event MyDelegate MyEvent;
       

        private void btnUp_Click(object sender, EventArgs e)
        {

            if (lv.Count>0)
            {
                if (lv[select].DelReachBilIDFrom== "DERC")
                {
                   // MyEvent = lv[select].IDFrom;
                    MyEvent(long.Parse(lv[select].DelReachBilIDFrom.ToString()));//引发事件
                   // MyEvent1(12345648);
                    //this.Close();
                }
            }

        }
        int select = -1;
        List<V_DelReachDtlMD> lv = new List<V_DelReachDtlMD>();
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            select = this.gridView1.GetDataSourceRowIndex(e.FocusedRowHandle);
            if (select>-1)
            {
                lv = this.gridControl1.DataSource as List<V_DelReachDtlMD>;
            }
        }

       
    }
}