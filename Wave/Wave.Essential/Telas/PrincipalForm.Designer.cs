namespace Wave.Essential.Telas
{
    partial class PrincipalForm
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
            this.pnPrincipal = new MetroFramework.Controls.MetroPanel();
            this.lbCopyright = new MetroFramework.Controls.MetroLabel();
            this.lkVoltar = new MetroFramework.Controls.MetroLink();
            this.SuspendLayout();
            // 
            // pnPrincipal
            // 
            this.pnPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnPrincipal.HorizontalScrollbarBarColor = true;
            this.pnPrincipal.HorizontalScrollbarHighlightOnWheel = false;
            this.pnPrincipal.HorizontalScrollbarSize = 10;
            this.pnPrincipal.Location = new System.Drawing.Point(20, 60);
            this.pnPrincipal.Name = "pnPrincipal";
            this.pnPrincipal.Size = new System.Drawing.Size(560, 370);
            this.pnPrincipal.TabIndex = 1;
            this.pnPrincipal.VerticalScrollbarBarColor = true;
            this.pnPrincipal.VerticalScrollbarHighlightOnWheel = false;
            this.pnPrincipal.VerticalScrollbarSize = 10;
            // 
            // lbCopyright
            // 
            this.lbCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbCopyright.AutoSize = true;
            this.lbCopyright.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lbCopyright.Location = new System.Drawing.Point(20, 433);
            this.lbCopyright.Name = "lbCopyright";
            this.lbCopyright.Size = new System.Drawing.Size(226, 15);
            this.lbCopyright.TabIndex = 2;
            this.lbCopyright.Text = "Copyright ©  2018 Comunidade Cristã Wave";
            // 
            // lkVoltar
            // 
            this.lkVoltar.Image = global::Wave.Essential.Properties.Resources.back64x64;
            this.lkVoltar.ImageSize = 32;
            this.lkVoltar.Location = new System.Drawing.Point(5, 10);
            this.lkVoltar.Name = "lkVoltar";
            this.lkVoltar.Size = new System.Drawing.Size(50, 50);
            this.lkVoltar.TabIndex = 0;
            this.lkVoltar.UseSelectable = true;
            this.lkVoltar.Click += new System.EventHandler(this.lkVoltar_Click);
            // 
            // PrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.lbCopyright);
            this.Controls.Add(this.pnPrincipal);
            this.Controls.Add(this.lkVoltar);
            this.Name = "PrincipalForm";
            this.Text = "- Wave -";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Load += new System.EventHandler(this.PrincipalForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLink lkVoltar;
        private MetroFramework.Controls.MetroPanel pnPrincipal;
        private MetroFramework.Controls.MetroLabel lbCopyright;
    }
}