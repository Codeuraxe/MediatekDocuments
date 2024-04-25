
namespace MediaTekDocuments.view
{
    partial class FrmLogin
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
            this.txbLogin = new System.Windows.Forms.TextBox();
            this.lblIdentifiant = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbPwd = new System.Windows.Forms.TextBox();
            this.btnConnec = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbLogin
            // 
            this.txbLogin.Location = new System.Drawing.Point(283, 147);
            this.txbLogin.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txbLogin.Name = "txbLogin";
            this.txbLogin.Size = new System.Drawing.Size(457, 38);
            this.txbLogin.TabIndex = 3;
            this.txbLogin.TextChanged += new System.EventHandler(this.txbLogin_TextChanged);
            // 
            // lblIdentifiant
            // 
            this.lblIdentifiant.AutoSize = true;
            this.lblIdentifiant.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdentifiant.Location = new System.Drawing.Point(32, 129);
            this.lblIdentifiant.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblIdentifiant.Name = "lblIdentifiant";
            this.lblIdentifiant.Size = new System.Drawing.Size(150, 32);
            this.lblIdentifiant.TabIndex = 4;
            this.lblIdentifiant.Text = "Identifiant";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 303);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password";
            // 
            // txbPwd
            // 
            this.txbPwd.Location = new System.Drawing.Point(283, 296);
            this.txbPwd.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txbPwd.Name = "txbPwd";
            this.txbPwd.Size = new System.Drawing.Size(457, 38);
            this.txbPwd.TabIndex = 6;
            this.txbPwd.UseSystemPasswordChar = true;
            // 
            // btnConnec
            // 
            this.btnConnec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnec.Location = new System.Drawing.Point(480, 436);
            this.btnConnec.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnConnec.Name = "btnConnec";
            this.btnConnec.Size = new System.Drawing.Size(267, 55);
            this.btnConnec.TabIndex = 7;
            this.btnConnec.Text = "Connection";
            this.btnConnec.UseVisualStyleBackColor = true;
            this.btnConnec.Click += new System.EventHandler(this.BtnConnec_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 613);
            this.Controls.Add(this.btnConnec);
            this.Controls.Add(this.txbPwd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblIdentifiant);
            this.Controls.Add(this.txbLogin);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "FrmLogin";
            this.Text = "FrmLogin";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbLogin;
        private System.Windows.Forms.Label lblIdentifiant;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbPwd;
        private System.Windows.Forms.Button btnConnec;
    }
}