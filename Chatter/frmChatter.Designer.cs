namespace Chatter
{
    partial class frmChatter
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
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtConvo = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtType
            // 
            this.txtType.ForeColor = System.Drawing.Color.Black;
            this.txtType.Location = new System.Drawing.Point(12, 308);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(376, 20);
            this.txtType.TabIndex = 1;
            this.txtType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnterDown);
            // 
            // txtConvo
            // 
            this.txtConvo.BackColor = System.Drawing.Color.LightGray;
            this.txtConvo.Location = new System.Drawing.Point(12, 12);
            this.txtConvo.MinimumSize = new System.Drawing.Size(376, 290);
            this.txtConvo.Name = "txtConvo";
            this.txtConvo.ReadOnly = true;
            this.txtConvo.Size = new System.Drawing.Size(376, 290);
            this.txtConvo.TabIndex = 2;
            this.txtConvo.Text = "";
            this.txtConvo.TextChanged += new System.EventHandler(this.txtConvo_TextChanged);
            // 
            // frmChatter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(400, 340);
            this.Controls.Add(this.txtConvo);
            this.Controls.Add(this.txtType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmChatter";
            this.Text = "Chatter!";
            this.Shown += new System.EventHandler(this.frmChatter_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.RichTextBox txtConvo;

    }
}

