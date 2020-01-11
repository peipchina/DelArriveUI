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
    public partial class AutoCodeForm : DevExpress.XtraEditors.XtraForm
    {
        public AutoCodeForm()
        {
            InitializeComponent();
        }

        private void delReachBingding()
        {
            DelReachManager drm = new DelReachManager();
            List<V_DelReachMD> lv = drm.getReachAuto();
            this.gridControl1.DataSource = lv;
        }
        
        private void delArriveBingding(string Code)
        {
            GrossTimeManager drm = new GrossTimeManager();
            List<V_GrossTimeMD> lv = drm.getAllGrossTimeByAutoCar(Code);
            this.gridControl2.DataSource = lv;
        }

        private void AutoCodeForm_Load(object sender, EventArgs e)
        {
            WaitDialogForm wf = new WaitDialogForm("加载中，请稍后。。。","软件提示！");
            wf.Show();
            setGridView sg = new setGridView();
            sg.CustomizeGridView(this.gridView1);
            sg.CustomizeGridView(this.gridView2);
            gridview1columbinding();
            gridview2columbinding();
            delReachBingding();
            wf.Close();
        }
        int select = -1;
        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            
        }

        #region 手动添加第一个GridView列
        /// <summary>
        /// 手动添加第一个GridView列
        /// </summary>
        private void gridview1columbinding()
        {            
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Code", FieldName = "Code", Caption = "车号", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Driver", FieldName = "Driver", Caption = "司机姓名", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Tel", FieldName = "Tel", Caption = "电话", VisibleIndex = 1, Visible = Enabled });            
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "rem", FieldName = "rem", Caption = "备注", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "MatName", FieldName = "MatName", Caption = "物料名", VisibleIndex = 1, Visible = Enabled });            
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "交付员", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ArriveTime", FieldName = "ArriveTime", Caption = "抵达时间", VisibleIndex = 1, Visible = Enabled });
            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "BilCreateTime", FieldName = "BilCreateTime", Caption = "车号修改时间", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns["ArriveTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            //gridView1.Columns["BilCreateTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
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
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "AutoCode", FieldName = "AutoCode", Caption = "车号", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "GrossTime", FieldName = "GrossTime", Caption = "出货时间", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "GrossStfName", FieldName = "GrossStfName", Caption = "司邦员", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "MatName", FieldName = "MatName", Caption = "物料名", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ToCust", FieldName = "ToCust", Caption = "客户", VisibleIndex = 3, Visible = Enabled });
            //gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateStfName", FieldName = "CreateStfName", Caption = "创建人", VisibleIndex = 1, Visible = Enabled });
            // gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CreateTime", FieldName = "CreateTime", Caption = "创建时间", VisibleIndex = 1, Visible = Enabled });
            // gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "StopTime", FieldName = "StopTime", Caption = "出厂时间", VisibleIndex = 1, Visible = Enabled });
            gridView2.Columns["GrossTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            //gridView2.Columns["CreateTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            //gridView2.Columns["StopTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            select = this.gridView1.GetDataSourceRowIndex(e.FocusedRowHandle);
            if (select > -1)
            {
                List<V_DelReachMD> lv = this.gridControl1.DataSource as List<V_DelReachMD>;
                delArriveBingding(lv[select].Code);
                
                if (gridView2.RowCount > 0)
                {
                    List<V_GrossTimeMD> lvg = this.gridView2.DataSource as List<V_GrossTimeMD>;
                    string da = DateTimeCheck(DateTime.Parse(lvg[0].GrossTime.ToString()), DateTime.Parse(lv[select].ArriveTime.ToString()));
                    lbNotice.Text = lv[select].Code + "  出厂  " + da + " 后重新排队装货。\t\n"+"上次送货地址："+lvg[0].ToCust+" ,"+lvg[0].DepotTo;
                }
                else
                {
                    lbNotice.Text = lv[select].Code + "  未检查到上次出厂时间  ";
                }
                
            }
        }

        private string DateTimeCheck(DateTime start,DateTime end)
        {
            TimeSpan ts = end.Subtract(start);
            string check = ts.Days.ToString() + "天" + ts.Hours.ToString() + "小时" + ts.Minutes.ToString() + "分钟" + ts.Seconds.ToString() + "秒";
            return check;
        }

        
    }
}