namespace DAUI
{
    partial class ChangePassWordForm
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
            this.btnChange = new System.Windows.Forms.Button();
            this.btnCacle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbOldPassWord = new System.Windows.Forms.TextBox();
            this.txbNewPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbCheckPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(55, 182);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 23);
            this.btnChange.TabIndex = 0;
            this.btnChange.Text = "修 改";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnCacle
            // 
            this.btnCacle.Location = new System.Drawing.Point(162, 182);
            this.btnCacle.Name = "btnCacle";
            this.btnCacle.Size = new System.Drawing.Size(75, 23);
            this.btnCacle.TabIndex = 1;
            this.btnCacle.Text = "取 消";
            this.btnCacle.UseVisualStyleBackColor = true;
            this.btnCacle.Click += new System.EventHandler(this.btnCacle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "原密码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "新密码";
            // 
            // txbOldPassWord
            // 
            this.txbOldPassWord.Location = new System.Drawing.Point(112, 30);
            this.txbOldPassWord.Name = "txbOldPassWord";
            this.txbOldPassWord.PasswordChar = '*';
            this.txbOldPassWord.Size = new System.Drawing.Size(100, 21);
            this.txbOldPassWord.TabIndex = 1;
            // 
            // txbNewPassword
            // 
            this.txbNewPassword.Location = new System.Drawing.Point(112, 81);
            this.txbNewPassword.Name = "txbNewPassword";
            this.txbNewPassword.PasswordChar = '*';
            this.txbNewPassword.Size = new System.Drawing.Size(100, 21);
            this.txbNewPassword.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "确认密码";
            // 
            // txbCheckPassword
            // 
            this.txbCheckPassword.Location = new System.Drawing.Point(112, 132);
            this.txbCheckPassword.Name = "txbCheckPassword";
            this.txbCheckPassword.PasswordChar = '*';
            this.txbCheckPassword.Size = new System.Drawing.Size(100, 21);
            this.txbCheckPassword.TabIndex = 3;
            // 
            // ChangePassWordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.txbCheckPassword);
            this.Controls.Add(this.txbNewPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbOldPassWord);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCacle);
            this.Controls.Add(this.btnChange);
            this.Name = "ChangePassWordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改密码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnCacle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbOldPassWord;
        private System.Windows.Forms.TextBox txbNewPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbCheckPassword;
    }
}