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
using DevExpress.Utils;

namespace DAUI
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        
        public MainForm()
        {
            InitializeComponent();
            
        }        
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (LoginForm.pubDelIn.AutoCodeForm == false)
            {
                MessageBox.Show("权限不足！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string ItemHeaderTest = "抵达未配车信息查询";
                foreach (DevExpress.XtraTabbedMdi.XtraMdiTabPage itemage in this.xtmm.Pages)
                {
                    if (ItemHeaderTest == itemage.Text)
                    {
                        xtmm.SelectedPage = itemage;
                        return;
                    }
                }
                AutoCodeForm XFrmMeasurementUnit = new AutoCodeForm();
                this.xtmm.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageAndTabControlHeader;
                XFrmMeasurementUnit.Text = "抵达未配车信息查询";
                XFrmMeasurementUnit.MdiParent = this;
                XFrmMeasurementUnit.Show();
            }            
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (LoginForm.pubDelIn.UIForm == false)
            {
                MessageBox.Show("权限不足！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string ItemHeaderTest = "配车未抵达信息查询";
                foreach (DevExpress.XtraTabbedMdi.XtraMdiTabPage itemage in this.xtmm.Pages)
                {
                    if (ItemHeaderTest == itemage.Text)
                    {
                        xtmm.SelectedPage = itemage;
                        return;
                    }
                }
                UIForm XFrmMeasurementUnit = new UIForm();
                this.xtmm.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageAndTabControlHeader;
                XFrmMeasurementUnit.Text = "配车未抵达信息查询";
                XFrmMeasurementUnit.MdiParent = this;
                XFrmMeasurementUnit.Show();
            }
           
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChangePassWordForm cpw = new ChangePassWordForm();
            cpw.ShowDialog();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (LoginForm.pubDelIn.GrossQtyForm == false)
            {
                MessageBox.Show("权限不足！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string ItemHeaderTest = "毛重查询";
                foreach (DevExpress.XtraTabbedMdi.XtraMdiTabPage itemage in this.xtmm.Pages)
                {
                    if (ItemHeaderTest == itemage.Text)
                    {
                        xtmm.SelectedPage = itemage;
                        return;
                    }
                }
                GrossQtyForm XFrmMeasurementUnit = new GrossQtyForm();
                this.xtmm.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageAndTabControlHeader;
                XFrmMeasurementUnit.Text = "毛重查询";
                XFrmMeasurementUnit.MdiParent = this;
                XFrmMeasurementUnit.Show();
            }
           
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (LoginForm.pubDelIn.QCPrintForm == false)
            {
                MessageBox.Show("权限不足！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string ItemHeaderTest = "品管化验单打印";
                foreach (DevExpress.XtraTabbedMdi.XtraMdiTabPage itemage in this.xtmm.Pages)
                {
                    if (ItemHeaderTest == itemage.Text)
                    {
                        xtmm.SelectedPage = itemage;
                        return;
                    }
                }
                QCPrintForm XFrmMeasurementUnit = new QCPrintForm();
                this.xtmm.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageAndTabControlHeader;
                XFrmMeasurementUnit.Text = "品管化验单打印";
                XFrmMeasurementUnit.MdiParent = this;
                XFrmMeasurementUnit.Show();
            }            
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (LoginForm.pubDelIn.ShipmentForm == false)
            {
                MessageBox.Show("权限不足！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string ItemHeaderTest = "货品出厂资料";
                foreach (DevExpress.XtraTabbedMdi.XtraMdiTabPage itemage in this.xtmm.Pages)
                {
                    if (ItemHeaderTest == itemage.Text)
                    {
                        xtmm.SelectedPage = itemage;
                        return;
                    }
                }
                ShipmentForm XFrmMeasurementUnit = new ShipmentForm();
                DelReachForm dr = new DelReachForm();
                this.xtmm.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageAndTabControlHeader;
                XFrmMeasurementUnit.Text = "货品出厂资料";
                XFrmMeasurementUnit.MdiParent = this;
                XFrmMeasurementUnit.Show();
                //dr.myevent += new ShipmentForm.MyDelegate();
                XFrmMeasurementUnit.MyEvent += new ShipmentForm.MyDelegate(openDelReach);

            }           
        }
        public static long DelReach { get; set; }

        private void openDelReach(long a )
        {
            if (LoginForm.pubDelIn.DelReachForm == false)
            {
                MessageBox.Show("权限不足！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string ItemHeaderTest = "通知单";
                foreach (DevExpress.XtraTabbedMdi.XtraMdiTabPage itemage in this.xtmm.Pages)
                {
                    if (ItemHeaderTest == itemage.Text)
                    {
                        xtmm.SelectedPage = itemage;
                        DelReachForm df = itemage.MdiChild as DelReachForm;
                        df.bindingGridviewByBilNO(a);
                        return;
                    }
                }
                DelReachForm openForm = new DelReachForm();
                ShipmentForm sf = new ShipmentForm();
                this.xtmm.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageAndTabControlHeader;
                openForm.Text = "通知单";
                openForm.MdiParent = this;
                openForm.bindingGridviewByBilNO(a);
                openForm.Show();
            }
           
        }
        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (LoginForm.pubDelIn.DelReachForm == false)
            {
                MessageBox.Show("权限不足！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string ItemHeaderTest = "通知单";
                foreach (DevExpress.XtraTabbedMdi.XtraMdiTabPage itemage in this.xtmm.Pages)
                {
                    if (ItemHeaderTest == itemage.Text)
                    {
                        xtmm.SelectedPage = itemage;
                        return;
                    }
                }
                DelReachForm XFrmMeasurementUnit = new DelReachForm();
                this.xtmm.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageAndTabControlHeader;
                XFrmMeasurementUnit.Text = "通知单";
                XFrmMeasurementUnit.MdiParent = this;
                XFrmMeasurementUnit.Show();
            }
            
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (LoginForm.pubDelIn.ReachArriveForm == false)
            {
                MessageBox.Show("权限不足！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string ItemHeaderTest = "抵达配车信息查询";
                foreach (DevExpress.XtraTabbedMdi.XtraMdiTabPage itemage in this.xtmm.Pages)
                {
                    if (ItemHeaderTest == itemage.Text)
                    {
                        xtmm.SelectedPage = itemage;
                        return;
                    }
                }
                ReachArriveForm openForm = new ReachArriveForm();
                this.xtmm.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageAndTabControlHeader;
                openForm.Text = "抵达配车信息查询";
                openForm.MdiParent = this;
                openForm.Show();
            }
            
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string ItemHeaderTest = "司机黑名单";
            foreach (DevExpress.XtraTabbedMdi.XtraMdiTabPage itemage in this.xtmm.Pages)
            {
                if (ItemHeaderTest == itemage.Text)
                {
                    xtmm.SelectedPage = itemage;
                    return;
                }
            }
            BlackAutoCodeForm openForm = new BlackAutoCodeForm();
            this.xtmm.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageAndTabControlHeader;
            openForm.Text = "司机黑名单";
            openForm.MdiParent = this;
            openForm.Show();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start(Environment.CurrentDirectory + "\\DAUI.exe");
            this.Close();
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string ItemHeaderTest = "车辆自动记录";
            foreach (DevExpress.XtraTabbedMdi.XtraMdiTabPage itemage in this.xtmm.Pages)
            {
                if (ItemHeaderTest == itemage.Text)
                {
                    xtmm.SelectedPage = itemage;
                    return;
                }
            }
            CarAutoRecord openForm = new CarAutoRecord();
            this.xtmm.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageAndTabControlHeader;
            openForm.Text = "车辆自动记录";
            openForm.MdiParent = this;
            openForm.Show();
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string ItemHeaderTest = "磅重查询";
            foreach (DevExpress.XtraTabbedMdi.XtraMdiTabPage itemage in this.xtmm.Pages)
            {
                if (ItemHeaderTest == itemage.Text)
                {
                    xtmm.SelectedPage = itemage;
                    return;
                }
            }
            CheckData openForm = new CheckData();
            this.xtmm.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageAndTabControlHeader;
            openForm.Text = "磅重查询";
            openForm.MdiParent = this;
            openForm.Show();
        }
        /// <summary>
        /// 断网配车未抵达
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiA_DelArrive_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string ItemHeaderTest = "配车未抵达";
            foreach (DevExpress.XtraTabbedMdi.XtraMdiTabPage itemage in this.xtmm.Pages)
            {
                if (ItemHeaderTest == itemage.Text)
                {
                    xtmm.SelectedPage = itemage;
                    return;
                }
            }
            A_DelArriveForm openForm = new A_DelArriveForm();
            this.xtmm.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageAndTabControlHeader;
            openForm.Text = "配车未抵达";
            openForm.MdiParent = this;
            openForm.Show();
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string ItemHeaderTest = "大豆车修复";
            foreach (DevExpress.XtraTabbedMdi.XtraMdiTabPage itemage in this.xtmm.Pages)
            {
                if (ItemHeaderTest == itemage.Text)
                {
                    xtmm.SelectedPage = itemage;
                    return;
                }
            }
            SoybeanFrm openForm = new SoybeanFrm();
            this.xtmm.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageAndTabControlHeader;
            openForm.Text = "大豆车修复";
            openForm.MdiParent = this;
            openForm.Show();
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string ItemHeaderTest = "调整发货时间";
            foreach (DevExpress.XtraTabbedMdi.XtraMdiTabPage itemage in this.xtmm.Pages)
            {
                if (ItemHeaderTest == itemage.Text)
                {
                    xtmm.SelectedPage = itemage;
                    return;
                }
            }
            ChangeTimeFrm openForm = new ChangeTimeFrm();
            this.xtmm.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageAndTabControlHeader;
            openForm.Text = "调整发货时间";
            openForm.MdiParent = this;
            openForm.Show();
        }

        private void bbiChangeCheckOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string ItemHeaderTest = "修改合格证编号";
            foreach (DevExpress.XtraTabbedMdi.XtraMdiTabPage itemage in this.xtmm.Pages)
            {
                if (ItemHeaderTest == itemage.Text)
                {
                    xtmm.SelectedPage = itemage;
                    return;
                }
            }
            CheckOrderChange openForm = new CheckOrderChange();
            this.xtmm.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageAndTabControlHeader;
            openForm.Text = "修改合格证编号";
            openForm.MdiParent = this;
            openForm.Show();
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {            
            string ItemHeaderTest = "车辆复包";
            foreach (DevExpress.XtraTabbedMdi.XtraMdiTabPage itemage in this.xtmm.Pages)
            {
                if (ItemHeaderTest == itemage.Text)
                {
                    xtmm.SelectedPage = itemage;
                    return;
                }
            }
            RebackCheckFrm openForm = new RebackCheckFrm();
            this.xtmm.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageAndTabControlHeader;
            openForm.Text = "车辆复包";
            openForm.MdiParent = this;
            openForm.Show();
        }

        private void bbiChangePrice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string ItemHeaderTest = "客户运价";
            foreach (DevExpress.XtraTabbedMdi.XtraMdiTabPage itemage in this.xtmm.Pages)
            {
                if (ItemHeaderTest == itemage.Text)
                {
                    xtmm.SelectedPage = itemage;
                    return;
                }
            }
            CustermoPriceFrm openForm = new CustermoPriceFrm();
            this.xtmm.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageAndTabControlHeader;
            openForm.Text = "客户运价";
            openForm.MdiParent = this;
            openForm.Show();
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string ItemHeaderTest = "修改大豆车";
            foreach (DevExpress.XtraTabbedMdi.XtraMdiTabPage itemage in this.xtmm.Pages)
            {
                if (ItemHeaderTest == itemage.Text)
                {
                    xtmm.SelectedPage = itemage;
                    return;
                }
            }
            ChangeSyobinAutocordeFrm openForm = new ChangeSyobinAutocordeFrm();
            this.xtmm.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageAndTabControlHeader;
            openForm.Text = "修改大豆车";
            openForm.MdiParent = this;
            openForm.Show();  
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string ItemHeaderTest = "修改船名";
            foreach (DevExpress.XtraTabbedMdi.XtraMdiTabPage itemage in this.xtmm.Pages)
            {
                if (ItemHeaderTest == itemage.Text)
                {
                    xtmm.SelectedPage = itemage;
                    return;
                }
            }
            ChangeShipNameFrm openForm = new ChangeShipNameFrm();
            this.xtmm.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageAndTabControlHeader;
            openForm.Text = "修改船名";
            openForm.MdiParent = this;
            openForm.Show();

        }
    }
}