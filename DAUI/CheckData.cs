using DA.BLL;
using DA.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAUI
{
    public partial class CheckData : Form
    {
        public CheckData()
        {
            InitializeComponent();
            LoadSet();
            InitialzeSet();
        }
        #region---初始化---
        private static int rowSelect = -1;
        private void LoadSet()
        {
            gridviewSet();
            gridview1columbinding();
            
        }
        private void InitialzeSet()
        {
            sbtnSearch.Click += SbtnSearch_Click;
            gridView1.RowClick += GridView1_RowClick;
            tedFilter.TextChanged += TedFilter_TextChanged;
            sbtnSearcheN.Click += SbtnSearcheN_Click;
            sbtnExcel.Click += SbtnExcel_Click;
        }

        private void SbtnExcel_Click(object sender, EventArgs e)
        {
            ExportExcel();
        }

        private void SbtnSearcheN_Click(object sender, EventArgs e)
        {
            this.gridView1.Columns.Clear();
            Column1Add();
            GetNewPound();
            this.gridView1.Tag = "new";
        }

        private void TedFilter_TextChanged(object sender, EventArgs e)
        {
            this.gridView1.FindFilterText = tedFilter.Text;
        }

        private void GridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            rowSelect = gridView1.GetDataSourceRowIndex(e.RowHandle);
            if(this.gridView1.Tag.ToString()=="old")
            {
                Get3SDataByAutoCode();
            }
            else
            {
                Get3SDataByAutoCodeN();
            }
           
            
        }

        private void SbtnSearch_Click(object sender, EventArgs e)
        {
            this.gridView1.Columns.Clear();
            ColumnsAdd(gridView1);
            GetListByDate();
            this.gridView1.Tag = "old";
        }
        #endregion

        #region----方法------
        private void gridviewSet()
        {
            setGridView sg = new setGridView();
            sg.CustomizeGridView(gridView1);
            sg.CustomizeGridView(gridView2);
        }
        #region -------------手动添加第一个GridView列-----------
        /// <summary>
        /// 手动添加第二个GridView列
        /// </summary>
        private void gridview1columbinding()
        {

            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "AutoCode", FieldName = "AutoCode", Caption = "车号", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "MatName", FieldName = "MatName", Caption = "物料名", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "IDFrom", FieldName = "IDFrom", Caption = "来源单号", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "AutoCode", FieldName = "AutoCode", Caption = "车号", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Driver", FieldName = "Driver", Caption = "司机", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "BilNo", FieldName = "BilNo", Caption = "来源通知单", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "MatName", FieldName = "MatName", Caption = "货品名称", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ToCust", FieldName = "ToCust", Caption = "客户", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "StockName", FieldName = "StockName", Caption = "仓库", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "QtyTare", FieldName = "QtyTare", Caption = "皮重（顿）", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "TareTime", FieldName = "TareTime", Caption = "皮重过磅时间", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "TareStfName", FieldName = "TareStfName", Caption = "皮重录入", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Qty", FieldName = "QtyGross", Caption = "毛重（顿）", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "GrossTime", FieldName = "GrossTime", Caption = "出货时间", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "GrossStfName", FieldName = "GrossStfName", Caption = "毛重录入", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "BeginLoadStfName", FieldName = "BeginLoadStfName", Caption = "入线装货记录", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "BeginLoadTime", FieldName = "BeginLoadTime", Caption = "入线时间", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "InLine", FieldName = "InLine", Caption = "装货线", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "EndLoadStfName", FieldName = "EndLoadStfName", Caption = "装车完毕记录", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "EndLoadTime", FieldName = "EndLoadTime", Caption = "完成时间", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "PassStfName", FieldName = "PassStfName", Caption = "品管放行人", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "PassTime", FieldName = "PassTime", Caption = "品管放行时间", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "发货单创建人", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateTime", FieldName = "CreateTime", Caption = "发货单创建时间", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "发货单创建人", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "发货单创建人", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "发货单创建人", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "发货单创建人", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "发货单创建人", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns["GrossTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView2.Columns["TareTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView2.Columns["GrossTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView2.Columns["BeginLoadTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView2.Columns["PassTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView2.Columns["CreateTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
        }
        #endregion
        /// <summary>
        /// 手动添加Gridview列名
        /// </summary>
        /// <param name="gridview"></param>
        private void ColumnsAdd(DevExpress.XtraGrid.Views.Grid.GridView gridview)
        {
            //gridview.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "ID", VisibleIndex = 1, Visible = Enabled });
            gridview.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ticketno1", FieldName = "ticketno1", Caption = "No", VisibleIndex = 0, Visible = Enabled });
            gridview.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "truckno", FieldName = "truckno", Caption = "车号", VisibleIndex = 1, Visible = Enabled });
            gridview.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "product", FieldName = "product", Caption = "物料名", VisibleIndex = 2, Visible = Enabled });
            gridview.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "specification", FieldName = "specification", Caption = "船名/船舱号", VisibleIndex = 11, Visible = Enabled });
            gridview.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "receiver", FieldName = "receiver", Caption = "收货单位", VisibleIndex = 12, Visible = Enabled });
            gridview.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "transporter", FieldName = "transporter", Caption = "运输单位", VisibleIndex = 13, Visible = Enabled });
            gridview.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "tare", FieldName = "tare", Caption = "皮重（kg）", VisibleIndex = 3, Visible = Enabled });
            gridview.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "taredatetime", FieldName = "taredatetime", Caption = "皮重时间", VisibleIndex = 4, Visible = Enabled });
            gridview.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "username1", FieldName = "username1", Caption = "司磅员", VisibleIndex = 5, Visible = Enabled });
            gridview.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "gross", FieldName = "gross", Caption = "毛重（kg）", VisibleIndex = 6, Visible = Enabled });
            gridview.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "grossdatetime", FieldName = "grossdatetime", Caption = "毛重时间", VisibleIndex = 7, Visible = Enabled });
            gridview.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "username2", FieldName = "username2", Caption = "司磅员", VisibleIndex = 8, Visible = Enabled });
            gridview.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "net", FieldName = "net", Caption = "净重（kg）", VisibleIndex = 9, Visible = Enabled });
            gridview.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "sender", FieldName = "sender", Caption = "发货单位", VisibleIndex = 10, Visible = Enabled });
            gridview.Columns["taredatetime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridview.Columns["grossdatetime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";

        }
        /// <summary>
        /// 手工添加Gridview3列
        /// </summary>
        private void Column1Add()
        {
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "No", FieldName = "No", Caption = "地磅单号", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "AutoCode", FieldName = "AutoCode", Caption = "车号", VisibleIndex = 2, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "QTYTare", FieldName = "QTYTare", Caption = "皮重数量", VisibleIndex = 3, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "TareTime", FieldName = "TareTime", Caption = "皮重时间", VisibleIndex = 4, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "QTYGross", FieldName = "QTYGross", Caption = "毛重数量", VisibleIndex = 6, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "GrossTime", FieldName = "GrossTime", Caption = "毛重时间", VisibleIndex = 5, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "QTYNet", FieldName = "QTYNet", Caption = "数量", VisibleIndex = 3, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "MatName", FieldName = "MatName", Caption = "物料名", VisibleIndex = 4, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Customer", FieldName = "Customer", Caption = "客户", VisibleIndex = 6, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "PoundTareName", FieldName = "PoundTareName", Caption = "皮重磅名", VisibleIndex = 5, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "TareStfName", FieldName = "TareStfName", Caption = "皮重司磅员", VisibleIndex = 5, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "PoundGrossName", FieldName = "PoundGrossName", Caption = "毛重磅名", VisibleIndex = 5, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "GrossStfName", FieldName = "GrossStfName", Caption = "毛重司磅员", VisibleIndex = 5, Visible = Enabled });
            gridView1.Columns["TareTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView1.Columns["GrossTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
        }

        private void GetListByDate()
        {
            TradeManager tm = new TradeManager();
            if(rbM.Checked==true)
            {
                this.gridControl1.DataSource = tm.GetTrade_mByDate(tedStartDate.DateTime, tedEndDate.DateTime);
            }
            else
            {
                this.gridControl1.DataSource = tm.GetTrade_OByDate(tedStartDate.DateTime, tedEndDate.DateTime);
            }
        }
        private void Get3SDataByAutoCode()
        {
            SacOutSuperviseManager ssm = new SacOutSuperviseManager();
            List<TradeMD> lvs = this.gridControl1.DataSource as List<TradeMD>;
            if (rowSelect < 0) return;
            DateTime dtS = DateTime.Parse(lvs[rowSelect].grossdatetime.ToString()).AddMinutes(-20);
            DateTime dtE = DateTime.Parse(lvs[rowSelect].grossdatetime.ToString()).AddMinutes(20);
            this.gridControl2.DataSource = ssm.getSacOutSuperviseByAutoCode(dtS,dtE,lvs[rowSelect].truckno);
            lbState.Text = "车号："+lvs[rowSelect].truckno+"\t\n"+"托利多净重：" + (lvs[rowSelect].net/1000).ToString() + "  吨。";
            if(gridView2.RowCount>0)
            {
                int a = gridView2.RowCount;
                List<V_SacOutSuperviseMD> lv = this.gridControl2.DataSource as List<V_SacOutSuperviseMD>;
                float total = 0;
                for (int i = 0; i < a; i++)
                {
                    total += float.Parse(lv[i].QtyGross.ToString()) - float.Parse(lv[i].QtyTare.ToString());
                }
                lbState.Text +="\t\n"+ "3  S  净 重：" + total + "  吨。";
            }
        }
        private void GetNewPound()
        {
            PoundTotalManager ptm = new PoundTotalManager();
            this.gridControl1.DataSource = ptm.GetPoundListByDateTime(tedStartTimeN.DateTime,tedEndTimeN.DateTime);
        }
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

                return;
            }
        }
        private void Get3SDataByAutoCodeN()
        {
            SacOutSuperviseManager ssm = new SacOutSuperviseManager();
            List<PoundTotalMD> lvs = this.gridControl1.DataSource as List<PoundTotalMD>;
            if (rowSelect < 0) return;
            DateTime dtS = DateTime.Parse(lvs[rowSelect].GrossTime.ToString()).AddMinutes(-20);
            DateTime dtE = DateTime.Parse(lvs[rowSelect].GrossTime.ToString()).AddMinutes(20);
            this.gridControl2.DataSource = ssm.getSacOutSuperviseByAutoCode(dtS, dtE, lvs[rowSelect].AutoCode);
            lbState.Text = "车号：" + lvs[rowSelect].AutoCode + "\t\n" + "托利多净重：" + lvs[rowSelect].QTYNet / 1000 + "  吨。";
            if (gridView2.RowCount > 0)
            {
                int a = gridView2.RowCount;
                List<V_SacOutSuperviseMD> lv = this.gridControl2.DataSource as List<V_SacOutSuperviseMD>;
                float total=0;
                for (int i = 0; i < a; i++)
                {
                    total += float.Parse(lv[i].QtyGross.ToString()) - float.Parse(lv[i].QtyTare.ToString());
                }                
                lbState.Text += "\t\n" + "3  S  净 重：" + total + "  吨。";
            } 
        }
        #endregion
    }
}
