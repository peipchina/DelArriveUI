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
using DevExpress.XtraGrid.Views.Base;
using System.Diagnostics;
using DevExpress.XtraSplashScreen;

namespace DAUI
{
    public partial class CarAutoRecord : DevExpress.XtraEditors.XtraForm
    {
        public CarAutoRecord()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 根据日期，绑定Gridview数据
        /// </summary>
        private void GridViewBinding(DateTime theSameDay)
        {    
            CarArriveManager cam = new CarArriveManager();
            List<AutoCodeRecordMD> lt = cam.GetAutoArriveCarNo(theSameDay,theSameDay);
            this.gridControl1.DataSource = lt;
        }
        public int selectRow = -1;
        public string oldPaht=string.Empty;
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CarAutoRecord_Load(object sender, EventArgs e)
        {
            Column1Add();
            Column2Add();
            Column3Add();
            setGridView sgv = new setGridView();
            sgv.CustomizeGridView(this.gridView1);
            sgv.CustomizeGridView(this.gridView2);
            sgv.CustomizeGridView(gridView3);
            SearchCarArrive(btnSearch);
            dteDateTime.DateTime = DateTime.Now;
            GridViewBinding(DateTime.Now);//获取当日的车辆进厂情况
            TextChange(txbFilter);//根据车号过滤
            bt(btnPreview);
            GridViewRowClick(this.gridView1);            
            SearchList(btnSearchList);
            PicturMove(picbCarNo);
            FuzzyQuery(btnFuzzyQuery);
        }
        private void Refresh(Button btn)
        {
            btn.Click += Btn_Click;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            GridViewBinding(DateTime.Now);
        }

        /// <summary>
        /// 搜索事件
        /// </summary>
        /// <param name="search">搜索按钮</param>
        private void SearchCarArrive(Button search)
        {
            search.Click += Search_Click;
        }

        private void Search_Click(object sender, EventArgs e)
        {
            GridViewBinding(dteDateTime.DateTime);//根据日期获取车辆进厂情况
        }

        private void TextChange(TextBox tb)
        {
            tb.TextChanged += Tb_TextChanged;
        }
        /// <summary>
        /// 过滤车号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_TextChanged(object sender, EventArgs e)
        {
            this.gridView1.FindFilterText = txbFilter.Text.Trim();
            //ColumnView view = gridView1;
            //string filter = "[CardNo] like " + "'%" + txbFilter.Text.Trim() + "%'";
            //view.ActiveFilter.Add(view.Columns["CardNo"], new DevExpress.XtraGrid.Columns.ColumnFilterInfo(filter, ""));
        }
        /// <summary>
        /// 预览车号图片
        /// </summary>
        /// <param name="btd"></param>
        private void bt(Button btd)
        {
            btd.Click += Btd_Click;
        }

        private void Btd_Click(object sender, EventArgs e)
        {
            if (selectRow>-1)
            {
                try
                {
                    picbCarNo.Image = Bitmap.FromFile(GetCarNoImage(oldPaht));
                    picbCarNo.Tag = GetCarNoImage(oldPaht);
                }
                catch (Exception)
                {
                    return ;
                   // throw;
                }
            }
            
        }
        /// <summary>
        /// 获取车牌图片共享路径
        /// </summary>
        /// <returns></returns>
        private string GetCarNoImage(string paht)
        {
            try
            {
                bool connecton;
                connecton = connectState(@"\\192.168.52.180", "master.com", "bohi1218@");
                if (connecton == true)
                {
                    string imagePath = @"\\192.168.52.180" + oldPaht.Substring(2);
                    return imagePath;
                }
                else
                {
                    return null;
                }
                
            }
            catch (Exception)
            {
                return null;
                //throw;
            }
        }
        /// <summary>
        /// 连接远程共享文件夹
        /// </summary>
        /// <param name="path">远程共享文件夹的路径</param>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>
        /// <returns>真、假</returns>
        public static bool connectState(string path, string userName, string passWord)
        {
            bool Flag = false;
            Process proc = new Process();
            try
            {
                proc.StartInfo.FileName = "cmd.exe";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardInput = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
                string dosLine = "net use " + path + " " + passWord + " /user:" + userName;
                proc.StandardInput.WriteLine(dosLine);
                proc.StandardInput.WriteLine("exit");
                while (!proc.HasExited)
                {
                    proc.WaitForExit(1000);
                }
                string errormsg = proc.StandardError.ReadToEnd();
                proc.StandardError.Close();
                if (string.IsNullOrEmpty(errormsg))
                {
                    Flag = true;
                }
                else
                {
                    throw new Exception(errormsg);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                proc.Close();
                proc.Dispose();
            }
            return Flag;
        }
        #region----------查询车辆是否为大豆车辆------
       

        #endregion
        private void GridViewRowClick(DevExpress.XtraGrid.Views.Grid.GridView gv)
        {
            gv.RowClick += Gv_RowClick;
        }
        /// <summary>
        /// 点击Gridview1，获取相关信息,绑定Gridview2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Gv_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (cbFuzzyQuery.CheckState!=CheckState.Checked)
            {
                lbCareList.Text = "";
                lbTest.Text = "";
                selectRow = this.gridView1.GetDataSourceRowIndex(e.RowHandle);               
                List<AutoCodeRecordMD> lt = this.gridControl1.DataSource as List<AutoCodeRecordMD>;
                AutoCodeRecordMD ti = lt[selectRow];
                oldPaht = ti.PicPath;
                if (selectRow > -1)
                {
                    picbCarNo.Image = null;
                    //DelReachManager drm = new DelReachManager();
                    //this.gridControl2.DataSource= drm.getAllDelReachDtlByAutoCode(ti.CardNo);
                    PoundTotalManager pm = new PoundTotalManager();
                    DateTime dateTime1 = DateTime.Now;
                    if(ti.InTime!=null)
                    {
                        dateTime1 = DateTime.Parse(ti.InTime.ToString());
                    }
                    if(ti.OutTime!=null)
                    {
                        dateTime1 = DateTime.Parse(ti.OutTime.ToString());
                    }
                    this.gridControl3.DataSource = pm.GetPountListByAutoCode(ti.AutoCode,dateTime1);
                    CarArriveManager drm = new CarArriveManager();
                    DateTime dateTime=DateTime.Now;
                    if(ti.InTime != null)
                    {
                        dateTime = DateTime.Parse(ti.InTime.ToString());
                    }
                    if(ti.OutTime!=null)
                    {
                        dateTime = DateTime.Parse(ti.OutTime.ToString());
                    }
                    this.gridControl2.DataSource = drm.GetCarTareAndGross(ti.AutoCode,dateTime);
                    List<TC_GrossTareMD> lt1 = drm.GetCarTareAndGross(ti.AutoCode, dateTime);
                    DateTime dt;
                    if (lt[selectRow].InTime==null)
                    {
                        dt = DateTime.Parse(lt[selectRow].OutTime.ToString());
                    }
                    else
                    {
                        dt = DateTime.Parse(lt[selectRow].InTime.ToString());
                    }
                    var result = lt1.Find(delegate (TC_GrossTareMD tcgt)
                    {
                        return tcgt.TareTime > dt.AddMinutes(-10) && tcgt.TareTime < dt.AddMinutes(10);
                    });
                    if (result == null)
                    {
                        result = lt1.Find(delegate (TC_GrossTareMD tcgt)
                        {
                            return tcgt.GrossTime > dt.AddMinutes(-10) && tcgt.GrossTime < dt.AddMinutes(10);
                        });
                    } 
                    try
                    {
                        AutoCodeRecordMD ti1 = lt[selectRow];
                        DateTime a;
                        if (ti1.InTime == null)
                        {
                            a = DateTime.Parse(ti1.OutTime.ToString());
                        }
                        else
                        {
                            a= DateTime.Parse(ti1.InTime.ToString());
                        }
                        lbTest.Text = "车号 " + result.AutoCode + "\n" + "自动记录时间是 " + a + "\n" + "车辆皮重时间是 " + result.TareTime + "\n" + "车辆毛重时间是 " + result.GrossTime;
                        if (result.GrossTime != null && result.TareTime != null)
                        {
                            lbCareList.Text = "车辆 " + result.AutoCode + " 进厂装货 " + TimeCheck((DateTime)(result.TareTime), (DateTime)result.GrossTime) + "后出厂！";
                        }
                        else if (result.TareTime != null && result.GrossTime == null)
                        {
                            lbCareList.Text = "车辆 " + result.AutoCode + " 于 " + result.TareTime + "开始装货！";
                        }
                        else
                        {
                            lbCareList.Text = "厂区油罐车进厂？或者车号有问题！";
                        }
                    }
                    catch (Exception )
                    {
                       // MessageBox.Show(ex.Message);
                        return;
                        throw;
                    }
                }
            }
            else
            {
                lbCareList.Text = "";
                lbTest.Text = "";
                selectRow = this.gridView1.GetDataSourceRowIndex(e.RowHandle);
                CarArriveManager cam = new CarArriveManager();
                List<AutoCodeRecordMD> lt = this.gridControl1.DataSource as List<AutoCodeRecordMD>;
                string a = ChangeCarNo(lt[selectRow].AutoCode);
                oldPaht = lt[selectRow].PicPath;
                string autoCode = "%" + a + "%";
                
                this.gridControl2.DataSource = cam.GetCarTareAndGrossByAutoCode(autoCode,dteDateTime.DateTime);
                List<TC_GrossTareMD> lt1 = cam.GetCarTareAndGrossByAutoCode(autoCode,dteDateTime.DateTime);
                DateTime dt = DateTime.Parse(lt[selectRow].InTime.ToString());
                var result = lt1.Find(delegate (TC_GrossTareMD tcgt)
                  {
                      return  tcgt.TareTime > dt.AddMinutes(-10) && tcgt.TareTime<dt.AddMinutes(10);
                  });
                if (result == null) return;
                try
                {
                    AutoCodeRecordMD ti = lt[selectRow];
                    lbTest.Text = "车号 " + result.AutoCode + "\n" + "自动记录时间是 " + ti.InTime + "\n" + "车辆皮重时间是 " + result.TareTime + "\n" + "车辆毛重时间是 " + result.GrossTime;
                    if (result.GrossTime != null && result.TareTime != null)
                    {
                        lbCareList.Text = "车辆 " + result.AutoCode + " 进厂装货 " + TimeCheck((DateTime)(result.TareTime), (DateTime)result.GrossTime) + "后出厂！";
                    }
                    else if (result.TareTime != null && result.GrossTime == null)
                    {
                        lbCareList.Text = "车辆 " + result.AutoCode + " 于 " + result.TareTime + "开始装货！";
                    }
                    else
                    {
                        lbCareList.Text = "厂区油罐车进厂？或者车号有问题！";
                    }
                }
                catch (Exception)
                {
                    lbTest.Text = "";
                    return;
                    throw;
                }
            }
        }
        
        /// <summary>
        /// 手工添加Gridview1列
        /// </summary>
        private void Column1Add()
        {
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ID", FieldName = "ID", Caption = "序号", VisibleIndex = 1, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "AutoCode", FieldName = "AutoCode", Caption = "车号", VisibleIndex = 2, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "InTime", FieldName = "InTime", Caption = "进厂时间", VisibleIndex = 3, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "OutTime", FieldName = "OutTime", Caption = "出厂时间", VisibleIndex = 4, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "PicPath", FieldName = "PicPath", Caption = "车号图片", VisibleIndex = 6, Visible = Enabled });
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "CDMPlace", FieldName = "CDMPlace", Caption = "地磅名", VisibleIndex = 5, Visible = Enabled });
            gridView1.Columns["InTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";            
            gridView1.Columns["OutTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";            
        }
        /// <summary>
        /// 手工添加Gridview3列
        /// </summary>
        private void Column3Add()
        {
            gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "No", FieldName = "No", Caption = "地磅单号", VisibleIndex = 1, Visible = Enabled });
            gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "AutoCode", FieldName = "AutoCode", Caption = "车号", VisibleIndex = 2, Visible = Enabled });
            gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "QTYTare", FieldName = "QTYTare", Caption = "皮重数量", VisibleIndex = 3, Visible = Enabled });
            gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "TareTime", FieldName = "TareTime", Caption = "皮重时间", VisibleIndex = 4, Visible = Enabled });
            gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "QTYGross", FieldName = "QTYGross", Caption = "毛重数量", VisibleIndex = 6, Visible = Enabled });
            gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "GrossTime", FieldName = "GrossTime", Caption = "毛重时间", VisibleIndex = 5, Visible = Enabled });
            gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "QTYNet", FieldName = "QTYNet", Caption = "数量", VisibleIndex = 3, Visible = Enabled });
            gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "MatName", FieldName = "MatName", Caption = "物料名", VisibleIndex = 4, Visible = Enabled });
            gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Customer", FieldName = "Customer", Caption = "客户", VisibleIndex = 6, Visible = Enabled });
            gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "PoundTareName", FieldName = "PoundTareName", Caption = "皮重磅名", VisibleIndex = 5, Visible = Enabled });
            gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "TareStfName", FieldName = "TareStfName", Caption = "皮重司磅员", VisibleIndex = 5, Visible = Enabled });
            gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "PoundGrossName", FieldName = "PoundGrossName", Caption = "毛重磅名", VisibleIndex = 5, Visible = Enabled });
            gridView3.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "GrossStfName", FieldName = "GrossStfName", Caption = "毛重司磅员", VisibleIndex = 5, Visible = Enabled });
            gridView3.Columns["TareTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView3.Columns["GrossTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
        }
        /// <summary>
        /// 手工添加Gridview2列
        /// </summary>
        private void Column2Add()
        {            
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "AutoCode", FieldName = "AutoCode", Caption = "车号", VisibleIndex = 2, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "QtyTare", FieldName = "QtyTare", Caption = "皮重", VisibleIndex = 3, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "TareTime", FieldName = "TareTime", Caption = "皮重时间", VisibleIndex = 4, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "TareStrName", FieldName = "TareStrName", Caption = "皮重称重人", VisibleIndex = 5, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "QtyGross", FieldName = "QtyGross", Caption = "毛重", VisibleIndex = 6, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "GrossTime", FieldName = "GrossTime", Caption = "毛重时间", VisibleIndex = 7, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "GrossName", FieldName = "GrossName", Caption = "毛重称重人", VisibleIndex = 8, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "MatName", FieldName = "MatName", Caption = "货品", VisibleIndex = 8, Visible = Enabled });
            gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ToCust", FieldName = "ToCust", Caption = "客户", VisibleIndex = 10, Visible = Enabled });           
            gridView2.Columns["TareTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView2.Columns["GrossTime"].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
        }
        private void SearchList(Button bt)
        {
            bt.Click += Bt_Click;
        }

        private void Bt_Click(object sender, EventArgs e)
        {
            if (txbCarNo.Text.Trim()==string.Empty)
            {
                MessageBox.Show("车号不能为空！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                lbCareList.Text = "";
                lbTest.Text = "";
                string autoCode = "%" + txbCarNo.Text.Trim() + "%";
                CarArriveManager cam = new CarArriveManager();
                List<AutoCodeRecordMD> lt = this.gridControl1.DataSource as List<AutoCodeRecordMD>;                
                this.gridControl2.DataSource = cam.GetCarTareAndGrossByAutoCode(autoCode,dteDateTime.DateTime);
                PoundTotalManager pt = new PoundTotalManager();
                this.gridControl3.DataSource = pt.GetPountListByAutoCodeL(autoCode);
                List<TC_GrossTareMD> lt1 = cam.GetCarTareAndGrossByAutoCode(autoCode,dteDateTime.DateTime);
                try
                {
                    AutoCodeRecordMD ti = lt[selectRow];
                    lbTest.Text = "车号 " + lt1[0].AutoCode + "\n" + "自动记录时间是 " + ti.InTime + "\n" + "车辆皮重时间是 " + lt1[0].TareTime + "\n" + "车辆毛重时间是 " + lt1[0].GrossTime;
                    if (lt1[0].GrossTime != null &&lt1[0].TareTime!=null)
                    {
                        lbCareList.Text= "车辆 " + lt1[0].AutoCode + " 进厂装货 " + TimeCheck((DateTime)(lt1[0].TareTime), (DateTime)lt1[0].GrossTime)+"后出厂！";
                    }
                    else if (lt1[0].TareTime!=null&&lt1[0].GrossTime==null)
                    {
                        lbCareList.Text = "车辆 " + lt1[0].AutoCode +" 于 "+ lt1[0].TareTime + "开始装货！";
                    }
                    else
                    {
                        lbCareList.Text = "厂区油罐车进厂？或者车号有问题！";
                    }
                }
                catch (Exception)
                {
                    lbTest.Text = "";
                    return;
                    throw;
                }
            }
        }
        private void PicturMove(PictureBox pb)
        {
            pb.MouseHover += Pb_MouseHover;
        }
        
        private void Pb_MouseHover(object sender, EventArgs e)
        {
            if (oldPaht!=string.Empty)
            {
                CarNoPictureForm cp = new CarNoPictureForm();
                cp.Tag = picbCarNo.Tag;
                cp.ShowDialog();
            }            
        }
        /// <summary>
        /// 车辆信息提示
        /// </summary>
        /// <param name="dateTimeStare">开始时间</param>
        /// <param name="dateTimeEnd">结束时间</param>
        /// <returns></returns>
        private string TimeCheck(DateTime dateTimeStare,DateTime dateTimeEnd)
        {
            string check;
            if (DateTime.Compare(dateTimeEnd,dateTimeStare)>0)
            {
                TimeSpan ts = dateTimeEnd.Subtract(dateTimeStare);
                check = ts.Days.ToString() + "天" + ts.Hours.ToString() + "小时" + ts.Minutes.ToString()+"分" + ts.Seconds.ToString() + "秒";
                return check;
            }
            else
            {
                check="车辆正在装货，未出场" ;
                return check;
            }
        }
        private string ChangeCarNo(string CarNo)
        {
            string newCarNo="";
            for (int i = 1; i < CarNo.Length; i++)
            {
                if (CarNo.Substring(i,1)=="s"||CarNo.Substring(i,1)=="S")
                {
                    newCarNo += "5";
                }
                else if (CarNo.Substring(i,1)=="Z"||CarNo.Substring(i,1)=="z")
                {
                    newCarNo += "2";
                }
                else if (CarNo.Substring(i, 1) == "B" )
                {
                    newCarNo += "8";
                }
                else if (CarNo.Substring(i, 1) == "Q")
                {
                    newCarNo += "0";
                }
                else
                {
                    newCarNo += CarNo.Substring(i,1);
                }
                
            }
            return newCarNo;
        }
       private void FuzzyQuery(Button fq)
        {
            fq.Click += Fq_Click;
        }

        private void Fq_Click(object sender, EventArgs e)
        {
            if (selectRow==-1)
            {
                MessageBox.Show("请选择需要查询的数据！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                lbCareList.Text = "";
                lbTest.Text = "";                
                
                CarArriveManager cam = new CarArriveManager();
                List<AutoCodeRecordMD> lt = this.gridControl1.DataSource as List<AutoCodeRecordMD>;
                string a=ChangeCarNo(lt[selectRow].AutoCode);
                string autoCode = "%" + a + "%";
                DateTime dateTime = DateTime.Now;
                if(lt[selectRow].InTime!=null)
                {
                    dateTime = DateTime.Parse(lt[selectRow].InTime.ToString());
                }
                if(lt[selectRow].OutTime != null)
                {
                    dateTime = DateTime.Parse(lt[selectRow].OutTime.ToString());
                }
                this.gridControl2.DataSource = cam.GetCarTareAndGrossByAutoCode(autoCode, dateTime);
                List<TC_GrossTareMD> lt1 = cam.GetCarTareAndGrossByAutoCode(autoCode, dateTime);
                try
                {
                    AutoCodeRecordMD ti = lt[selectRow];
                    lbTest.Text = "车号 " + lt1[0].AutoCode + "\n" + "自动记录时间是 " + ti.InTime + "\n" + "车辆皮重时间是 " + lt1[0].TareTime + "\n" + "车辆毛重时间是 " + lt1[0].GrossTime;
                    if (lt1[0].GrossTime != null && lt1[0].TareTime != null)
                    {
                        lbCareList.Text = "车辆 " + lt1[0].AutoCode + " 进厂装货 " + TimeCheck((DateTime)(lt1[0].TareTime), (DateTime)lt1[0].GrossTime) + "后出厂！";
                    }
                    else if (lt1[0].TareTime != null && lt1[0].GrossTime == null)
                    {
                        lbCareList.Text = "车辆 " + lt1[0].AutoCode + " 于 " + lt1[0].TareTime + "开始装货！";
                    }
                    else
                    {
                        lbCareList.Text = "厂区油罐车进厂？或者车号有问题！";
                    }
                }
                catch (Exception)
                {
                    lbTest.Text = "";
                    return;
                    throw;
                }
            }

        }

        private List<PubAutoCodeMD> getPubAuto()
        {
            PubAutoCodeManager pubAutoCodeManager = new PubAutoCodeManager();
            return pubAutoCodeManager.GetPubAutoCode();
        }

        private void sbtnCheck_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm();
            List<PubAutoCodeMD> pubAutoCodeMDs = new List<PubAutoCodeMD>();
            PubAutoCodeManager pubAutoCodeManager = new PubAutoCodeManager();
            pubAutoCodeMDs = pubAutoCodeManager.GetPubAutoCode();
            List<AutoCodeRecordMD> autoCodeRecordMDs = new List<AutoCodeRecordMD>();
            autoCodeRecordMDs = this.gridControl1.DataSource as List<AutoCodeRecordMD>;
            List<AutoCodeRecordMD> liji = new List<AutoCodeRecordMD>();
            foreach (AutoCodeRecordMD item in autoCodeRecordMDs)
            {
                bool a111 = false;
                foreach (PubAutoCodeMD item1 in pubAutoCodeMDs)
                {
                    if (item.AutoCode == item1.autocode)
                    {
                        a111 = true;
                        break;
                    }      
                    
                }
                if (a111==false)
                {
                    liji.Add(item);
                }
               
            }
            List<TC_GrossTareMD> lt1 = new List<TC_GrossTareMD>();
            CarArriveManager carArriveManager = new CarArriveManager();
            List<AutoCodeRecordMD> autos = new List<AutoCodeRecordMD>();
            foreach (AutoCodeRecordMD item2 in liji)
            {
                DateTime dateTime = DateTime.Now;
                if (item2.InTime != null)
                {
                    dateTime = DateTime.Parse(item2.InTime.ToString());
                }
                else if (item2.OutTime != null)
                {
                    dateTime = DateTime.Parse(item2.OutTime.ToString());
                }
                if (carArriveManager.GetCarTareAndGrossByAutoCodeAndTime(item2.AutoCode, dateTime).Count>0)
                {
                    lt1.AddRange(carArriveManager.GetCarTareAndGrossByAutoCodeAndTime(item2.AutoCode, dateTime));
                }
                else
                {
                    autos.Add(item2);
                } 
            }
            this.gridControl2.DataSource = lt1;
            this.gridControl3.DataSource = liji;
            this.gridControl1.DataSource = autos;
            SplashScreenManager.CloseDefaultWaitForm();
        }

        
    }
}