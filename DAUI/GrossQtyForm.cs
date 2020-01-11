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
using DevExpress.XtraSplashScreen;

namespace DAUI
{
    public partial class GrossQtyForm : DevExpress.XtraEditors.XtraForm
    {
        public GrossQtyForm()
        {
            InitializeComponent();
            InitializeSet();
        }
        private void InitializeSet()
        {
            rbTare.CheckedChanged += RbTare_CheckedChanged;
            gridview1columbinding();
            btnSearch.Click += BtnSearch_Click;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            gridview1Binding();
        }

        private void RbTare_CheckedChanged(object sender, EventArgs e)
        {
            if(rbTare.Checked==true)
            {
                this.gridView2.Columns.Clear();
                gridview1columbinding();
            }
            else
            {
                this.gridView2.Columns.Clear();
                gridview2columbinding();
            }
        }
        /// <summary>
        /// 统计净重
        /// </summary>
        private void TotalSet()
        {
            gridView2.Columns["QTYNet"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "QTYNet", "统计：{0:n2}");
        }

        private void gridView2Binding(string AutoCode)
        {
            GrossQtyManager gqm = new GrossQtyManager();
            List<V_GrossQtyMD> lv = new List<V_GrossQtyMD>();
            lv = gqm.getGrossQtyByAutoCode(AutoCode);
            this.gridControl2.DataSource = lv;
        }
        private void AddFooter()
        {
            this.gridView2.OptionsView.ShowFooter = true;
            //gridView2.Columns["QtyPack"].Summary.Clear();
            gridView2.Columns["Total"].Summary.Clear();
            gridView2.Columns["QtyNet"].Summary.Clear();
           // gridView2.Columns["QtyPack"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "QtyPackBag", "合计：{0:n2}");
            gridView2.Columns["QtyNet"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "QtyNet", "合计：{0:n2}");
            gridView2.Columns["Total"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Total", "合计：{0:n2}");
        }
        private void gridview2columbinding()
        {

            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "AutoCode", FieldName = "AutoCode", Caption = "车号", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "matMaterial", FieldName = "matMaterial", Caption = "物料名", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "DelReachDtlBilNO", FieldName = "DelReachDtlBilNO", Caption = "通知单号", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "AutoCode", FieldName = "AutoCode", Caption = "车号", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "stockName", FieldName = "stockName", Caption = "仓库名", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "BilNo", FieldName = "BilNo", Caption = "来源通知单", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "MatName", FieldName = "MatName", Caption = "货品名称", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ToCust", FieldName = "ToCust", Caption = "客户", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "StockName", FieldName = "StockName", Caption = "仓库", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "QtyTare", FieldName = "QtyTare", Caption = "皮重（顿）", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "TareTime", FieldName = "TareTime", Caption = "皮重过磅时间", VisibleIndex = 1, Visible = false });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "TareStfName", FieldName = "TareStfName", Caption = "皮重录入", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Qty", FieldName = "QtyGross", Caption = "毛重（顿）", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "GrossTime", FieldName = "GrossTime", Caption = "出货时间", VisibleIndex = 1, Visible = false });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "GrossStfName", FieldName = "GrossStfName", Caption = "毛重录入", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "QtyNet", FieldName = "QtyNet", Caption = "净重", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "QtyPackBag", FieldName = "QtyPackBag", Caption = "包装数量", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "createStfName", FieldName = "createStfName", Caption = "创建人", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateTime", FieldName = "CreateTime", Caption = "创建时间", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Total", FieldName = "Total", Caption = "理论差(吨)", VisibleIndex = 1, Visible = Enabled });
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
            gridView2.Columns["CreateTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView2.Columns["TareTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            //gridView1.Columns["GrossTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            //gridView1.Columns["BeginLoadTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            //gridView1.Columns["PassTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            //gridView1.Columns["CreateTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
        }
        private void GridView2TotalBingding(string autoCode)
        {
            DelReachManager drm = new DelReachManager();
            SplashScreenManager.ShowDefaultWaitForm();
            List<V_DelReachDtlMD> LV = drm.getAllDelReachDtlByAutoCode(autoCode);
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
           
            this.gridControl2.DataSource = ld;
            AddFooter();
            SplashScreenManager.CloseDefaultWaitForm();
        }
        private void gridview1Binding()
        {
            DelArriveManager dam = new DelArriveManager();
            List<V_DelArrive> lv = dam.getAllDelArrive();
            var dd = from ss in lv
                     where ss.MatName.Contains("豆粕≥")
                     select ss;
            List<V_DelArrive> lc = new List<V_DelArrive>();
            lc.AddRange(dd.ToArray());
            this.gridControl1.DataSource = lc;
        }

        private void GrossQtyForm_Load(object sender, EventArgs e)
        {
            
           // gridview1columbinding();
            setGridView sg = new setGridView();
            sg.CustomizeGridView(this.gridView1);
            sg.CustomizeGridView(this.gridView2);
            
           // gridview1Binding();
                    
        }
        int select = -1;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if(rbTare.Checked==true)
            {
                select = this.gridView1.GetDataSourceRowIndex(e.FocusedRowHandle);
                if (select > 0)
                {
                    List<V_DelArrive> lv = this.gridControl1.DataSource as List<V_DelArrive>;
                    gridView2Binding(lv[select].AutoCode);
                }
            }
            else
            {
                
                select = this.gridView1.GetDataSourceRowIndex(e.FocusedRowHandle);
                if (select > 0)
                {
                    List<V_DelArrive> lv = this.gridControl1.DataSource as List<V_DelArrive>;
                    GridView2TotalBingding(lv[select].AutoCode);
                }
            }
        }
        #region 手动添加第二个GridView列
        /// <summary>
        /// 手动添加第二个GridView列
        /// </summary>
        private void gridview1columbinding()
        {
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "AutoCode", FieldName = "AutoCode", Caption = "车号", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Name", FieldName = "Name", Caption = "货品名", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "QtyTare", FieldName = "QtyTare", Caption = "皮重(顿)", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "TareTime", FieldName = "TareTime", Caption = "皮重登记时间", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "TareStrName", FieldName = "TareStrName", Caption = "皮重登记人", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ToCust", FieldName = "ToCust", Caption = "客户", VisibleIndex = 1, Visible = Enabled });
            //gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateTime", FieldName = "CreateTime", Caption = "登记时间", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns["TareTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
           // gridView2.Columns["CreateTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
        }
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GrossQtyManager gqm = new GrossQtyManager();
            List<V_GrossQtyMD> lv = new List<V_GrossQtyMD>();
            lv = gqm.getGrossQtyByAutoCodelike("%"+txbAutoCode.Text.Trim()+"%");
            this.gridControl2.DataSource = lv;
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
                    this.gridView2.ExportToXls(filename);
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

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportExcel();
        }

        
    }
}