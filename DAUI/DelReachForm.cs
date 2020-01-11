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
    public partial class DelReachForm : DevExpress.XtraEditors.XtraForm
    {
        public DelReachForm()
        {
            InitializeComponent();
        }        
        public static string Code;
        ShipmentForm sf = new ShipmentForm();
        private void DelReachForm_Load(object sender, EventArgs e)
        {
            setGridView sg = new setGridView();
            sg.CustomizeGridView(this.gridView1);
            gridView1.OptionsView.ColumnAutoWidth = true;
            gridview1columbinding();
            this.gridView1.OptionsView.ShowFooter=true;
            showDate(dteStart);
            showDate(dteEnd);
            gridView1.RowClick += GridView1_RowClick;
            btnTotal.Click += BtnTotal_Click;
            btnExcel.Click += BtnExcel_Click;
            cmbAutoCode.SelectedIndexChanged += CmbAutoCode_SelectedIndexChanged;
            btnTotalAll.Click += BtnTotalAll_Click;
            txbFilter.TextChanged += TxbFilter_TextChanged;
            //AddFooter();
            //gridViewBinding();
        }

        private void TxbFilter_TextChanged(object sender, EventArgs e)
        {
            this.gridView1.FindFilterText = txbFilter.Text.Trim();
        }

        private void BtnTotalAll_Click(object sender, EventArgs e)
        {
            TotalAll();
        }

        private void CmbAutoCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridviewBindingByAutoCode();
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            ExportExcel();
        }

        private void BtnTotal_Click(object sender, EventArgs e)
        {
            List<V_DelReachDtlMD> lv = this.gridControl1.DataSource as List<V_DelReachDtlMD>;
            if (lv == null) return;
            List<V_DelReachDtlMD> nlv = new List<V_DelReachDtlMD>();
            foreach (V_DelReachDtlMD item in lv)
            {
                if (item.matMaterial.Contains("70KG")==true && (item.QtyNet-item.QtyPackBag*70/1000)<decimal.Parse((-0.02).ToString()))
                {
                    nlv.Add(item);
                }
                else if(item.matMaterial.Contains("50KG") == true && (item.QtyNet - item.QtyPackBag * 50 / 1000) < decimal.Parse((-0.02).ToString()))
                {
                    nlv.Add(item);
                }else
                {
                    continue;
                }
            }
            List<string> ls = new List<string>();
            cmbAutoCode.Items.Clear();
            ls.Add(nlv[0].AutoCode);
            foreach (V_DelReachDtlMD item in nlv)
            {
                if (ls.Contains(item.AutoCode) == true) continue;
                ls.Add(item.AutoCode);
            }
            cmbAutoCode.Items.AddRange(ls.ToArray());
            this.gridControl1.DataSource = nlv;
        }

        private void TotalAll()
        {
            List<V_DelReachDtlMD> lv = this.gridControl1.DataSource as List<V_DelReachDtlMD>;
            if (lv == null) return;
            decimal dd = 0;
            foreach (V_DelReachDtlMD item in lv)
            {
                if (item.QtyPackBag == null) continue;
                if (item.QtyNet == null) continue;
                if (item.matMaterial.Contains("70KG") == true && (item.QtyNet.Value - item.QtyPackBag.Value * 70 / 1000)>-5)
                {
                    dd += item.QtyNet.Value - item.QtyPackBag.Value * 70 / 1000;
                }
                else if (item.matMaterial.Contains("50KG") == true && (item.QtyNet.Value - item.QtyPackBag.Value * 50 / 1000) > -5)
                {
                    dd += item.QtyNet.Value - item.QtyPackBag.Value * 50 / 1000;
                }
            }
            label5.Text = "合计为 "+  dd + " 吨！";
            
        }
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
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "TareTime", FieldName = "TareTime", Caption = "皮重过磅时间", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "TareStfName", FieldName = "TareStfName", Caption = "皮重录入", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Qty", FieldName = "QtyGross", Caption = "毛重（顿）", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "GrossTime", FieldName = "GrossTime", Caption = "出货时间", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "GrossStfName", FieldName = "GrossStfName", Caption = "毛重录入", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "QtyNet", FieldName = "QtyNet", Caption = "净重", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "QtyPackBag", FieldName = "QtyPackBag", Caption = "包装数量", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "createStfName", FieldName = "createStfName", Caption = "创建人", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateTime", FieldName = "CreateTime", Caption = "创建时间", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Total", FieldName = "Total", Caption = "理论差(吨)", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "PassStfName", FieldName = "PassStfName", Caption = "品管放行人", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "PassTime", FieldName = "PassTime", Caption = "品管放行时间", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "发货单创建人", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateTime", FieldName = "CreateTime", Caption = "发货单创建时间", VisibleIndex = 1, Visible = Enabled });            
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "发货单创建人", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "发货单创建人", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "发货单创建人", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "发货单创建人", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "发货单创建人", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns["TareTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView1.Columns["CreateTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView1.Columns["GrossTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            //gridView1.Columns["BeginLoadTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            //gridView1.Columns["PassTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            //gridView1.Columns["CreateTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
        }
        #endregion
        private void GridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            RowSelect = this.gridView1.GetDataSourceRowIndex(e.RowHandle);
            List<V_DelReachDtlMD> lv = this.gridControl1.DataSource as List<V_DelReachDtlMD>;
            if (RowSelect>-1)
            {
                if (lv[RowSelect].matMaterial.Contains("70KG") == true)
                {
                    label3.Text =lv[RowSelect].AutoCode + "\t\n" + "净  重    为: " + lv[RowSelect].QtyNet.ToString() + " 吨。 包数为 " + lv[RowSelect].QtyPackBag.ToString() + " 包！" + "\t\n"+
                        "理论重量为： "+ lv[RowSelect].QtyPackBag*70/1000+ "  吨。" + "差别为： " + (lv[RowSelect].QtyNet-lv[RowSelect].QtyPackBag * 70 / 1000 ) + " 吨。";
                }
                else if(lv[RowSelect].matMaterial.Contains("50KG")==true)
                {
                    label3.Text = lv[RowSelect].AutoCode + "\t\n" + "净   重   为: " + lv[RowSelect].QtyNet.ToString() + " 吨。 包数为 " + lv[RowSelect].QtyPackBag.ToString() + " 包！" + "\t\n" +
                       "理论重量为： " + lv[RowSelect].QtyPackBag * 50 / 1000 + "  吨。"+"差别为： " + (lv[RowSelect].QtyNet-lv[RowSelect].QtyPackBag * 50 / 1000) +" 吨。";
                }
                else
                {
                    label3.Text = lv[RowSelect].AutoCode + "净重为: " + lv[RowSelect].QtyNet.ToString() + " 吨。  ";
                }

            }
        }

        private void gridViewBinding()
        {
            DelReachManager drm = new DelReachManager();
            WaitDialogForm wdf = new WaitDialogForm();
            wdf.Show();
            List<V_DelReachDtlMD> LV = drm.getAllDelReachDtlByBilDate(dteStart.DateTime,dteEnd.DateTime);
            List<V_DelReachDtlMD> ld = new List<V_DelReachDtlMD>();
            foreach (V_DelReachDtlMD item in LV)
            {
                V_DelReachDtlMD vd = new V_DelReachDtlMD();
                vd = item;
                if (item.matMaterial.Contains("70KG") == true)
                {
                    if (item.QtyNet != null && item.QtyNet != 0 && item.QtyPackBag != null && item.QtyPackBag != 0)
                    {
                        vd.Total = decimal.Parse((item.QtyNet - item.QtyPackBag * 70 / 1000).ToString());
                    }
                    else
                    vd.Total = 0;
                    
                }
                else if (item.matMaterial.Contains("50KG") == true)
                {
                    if (item.QtyNet != null && item.QtyNet != 0 && item.QtyPackBag != null && item.QtyPackBag != 0)
                    {
                        vd.Total = decimal.Parse((item.QtyNet - item.QtyPackBag * 50 / 1000).ToString());
                    }
                    else
                        vd.Total = 0;
                    
                }
                else
                {
                    vd.Total = 0;
                }
                ld.Add(vd);
            }
            this.gridControl1.DataSource = ld;
            AddFooter();
            wdf.Hide();
        }
        private void gridViewBindingByBilNo(long  bilno)
        {
            DelReachManager drm = new DelReachManager();
            List<V_DelReachDtlMD> LV = drm.getAllDelReachDtlByBilID(bilno);
            this.gridControl1.DataSource = LV;
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

        private void AddFooter()
        {
            gridView1.Columns["QtyPackBag"].Summary.Clear();
            gridView1.Columns["Total"].Summary.Clear();
            gridView1.Columns["QtyNet"].Summary.Clear();
            gridView1.Columns["QtyPackBag"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "QtyPackBag", "合计：{0:n2}");
            gridView1.Columns["QtyNet"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "QtyNet", "合计：{0:n2}");
            gridView1.Columns["Total"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Total", "合计：{0:n2}");
        }

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
            catch (Exception)
            {

                MessageBox.Show("文件已经打开，保存失败！");
                return;
            }

        }
        #endregion

        private static int RowSelect = -1;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            gridViewBinding();
        }
        public   void bindingGridviewByBilNO(long bilno)
        {
            DelReachManager drm = new DelReachManager();
            List<V_DelReachDtlMD> lv = drm.getAllDelReachDtlByBilID(bilno);
            gridControl1.DataSource = lv;
        }
        private void gridviewBindingByAutoCode()
        {
            DelReachManager drm = new DelReachManager();
            List<V_DelReachDtlMD> lv = drm.getAllDelReachDtlByAutoCode(cmbAutoCode.Text.Trim());
            gridControl1.DataSource = lv;
        }
    }
}