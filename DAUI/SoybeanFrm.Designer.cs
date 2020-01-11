namespace DAUI
{
    partial class SoybeanFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilt = new DevExpress.XtraEditors.TextEdit();
            this.sbtnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtLastShip = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sbtnSearcho = new DevExpress.XtraEditors.SimpleButton();
            this.error = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sbtnSearcho);
            this.panel1.Controls.Add(this.txtLastShip);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtFilt);
            this.panel1.Controls.Add(this.sbtnSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1010, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "过滤：";
            // 
            // txtFilt
            // 
            this.txtFilt.Location = new System.Drawing.Point(102, 27);
            this.txtFilt.Name = "txtFilt";
            this.txtFilt.Size = new System.Drawing.Size(100, 20);
            this.txtFilt.TabIndex = 1;
            // 
            // sbtnSearch
            // 
            this.sbtnSearch.Location = new System.Drawing.Point(231, 26);
            this.sbtnSearch.Name = "sbtnSearch";
            this.sbtnSearch.Size = new System.Drawing.Size(75, 23);
            this.sbtnSearch.TabIndex = 0;
            this.sbtnSearch.Text = "修   复";
            this.sbtnSearch.Click += new System.EventHandler(this.sbtnSearch_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 100);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1010, 460);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // txtLastShip
            // 
            this.txtLastShip.Location = new System.Drawing.Point(409, 26);
            this.txtLastShip.Name = "txtLastShip";
            this.txtLastShip.Size = new System.Drawing.Size(185, 22);
            this.txtLastShip.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(332, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "上一船船名:";
            // 
            // sbtnSearcho
            // 
            this.sbtnSearcho.Location = new System.Drawing.Point(623, 25);
            this.sbtnSearcho.Name = "sbtnSearcho";
            this.sbtnSearcho.Size = new System.Drawing.Size(75, 23);
            this.sbtnSearcho.TabIndex = 4;
            this.sbtnSearcho.Text = "查 询";
            this.sbtnSearcho.Click += new System.EventHandler(this.sbtnSearcho_Click);
            // 
            // error
            // 
            this.error.ContainerControl = this;
            // 
            // SoybeanFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 560);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel1);
            this.Name = "SoybeanFrm";
            this.Text = "SoybeanFrm";
            this.Load += new System.EventHandler(this.SoybeanFrm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtFilt;
        private DevExpress.XtraEditors.SimpleButton sbtnSearch;
        private System.Windows.Forms.TextBox txtLastShip;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton sbtnSearcho;
        private System.Windows.Forms.ErrorProvider error;
    }
}