namespace Chatter
{
    partial class frmSettings
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
            this.txtServer = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.lblTextColor = new System.Windows.Forms.Label();
            this.cboTextColor = new System.Windows.Forms.ComboBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(125, 22);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(100, 20);
            this.txtServer.TabIndex = 0;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(12, 25);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(109, 13);
            this.lblServer.TabIndex = 1;
            this.lblServer.Text = "Input Server Address:";
            // 
            // lblTextColor
            // 
            this.lblTextColor.AutoSize = true;
            this.lblTextColor.Location = new System.Drawing.Point(12, 62);
            this.lblTextColor.Name = "lblTextColor";
            this.lblTextColor.Size = new System.Drawing.Size(95, 13);
            this.lblTextColor.TabIndex = 2;
            this.lblTextColor.Text = "*Select Text Color:";
            // 
            // cboTextColor
            // 
            this.cboTextColor.FormattingEnabled = true;
            this.cboTextColor.Items.AddRange(new object[] {
            "Black",
            "Blue",
            "Green",
            "Pink",
            "Red"});
            this.cboTextColor.Location = new System.Drawing.Point(125, 59);
            this.cboTextColor.Name = "cboTextColor";
            this.cboTextColor.Size = new System.Drawing.Size(100, 21);
            this.cboTextColor.TabIndex = 3;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(12, 99);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(62, 13);
            this.lblUser.TabIndex = 4;
            this.lblUser.Text = "*Username:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(125, 96);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(100, 20);
            this.txtUser.TabIndex = 5;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(75, 176);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(87, 13);
            this.lblInfo.TabIndex = 6;
            this.lblInfo.Text = "* = Optional Field";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(81, 134);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 201);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.cboTextColor);
            this.Controls.Add(this.lblTextColor);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.txtServer);
            this.Name = "frmSettings";
            this.Text = "frmSettings";
            this.Shown += new System.EventHandler(this.frmSettings_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblTextColor;
        private System.Windows.Forms.ComboBox cboTextColor;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnSave;
    }
}