namespace Wave.Essential.Telas.UserControlBase
{
    partial class FormularioBase
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btSalvar = new MetroFramework.Controls.MetroButton();
            this.lbCodigo = new MetroFramework.Controls.MetroLabel();
            this.tbCodigo = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // btSalvar
            // 
            this.btSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSalvar.Location = new System.Drawing.Point(482, 344);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(75, 23);
            this.btSalvar.TabIndex = 0;
            this.btSalvar.Text = "Salvar";
            this.btSalvar.UseSelectable = true;
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(3, 0);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(53, 19);
            this.lbCodigo.TabIndex = 1;
            this.lbCodigo.Text = "Código";
            // 
            // tbCodigo
            // 
            // 
            // 
            // 
            this.tbCodigo.CustomButton.Image = null;
            this.tbCodigo.CustomButton.Location = new System.Drawing.Point(78, 1);
            this.tbCodigo.CustomButton.Name = "";
            this.tbCodigo.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbCodigo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbCodigo.CustomButton.TabIndex = 1;
            this.tbCodigo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbCodigo.CustomButton.UseSelectable = true;
            this.tbCodigo.CustomButton.Visible = false;
            this.tbCodigo.Lines = new string[0];
            this.tbCodigo.Location = new System.Drawing.Point(3, 22);
            this.tbCodigo.MaxLength = 32767;
            this.tbCodigo.Name = "tbCodigo";
            this.tbCodigo.PasswordChar = '\0';
            this.tbCodigo.ReadOnly = true;
            this.tbCodigo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbCodigo.SelectedText = "";
            this.tbCodigo.SelectionLength = 0;
            this.tbCodigo.SelectionStart = 0;
            this.tbCodigo.ShortcutsEnabled = true;
            this.tbCodigo.Size = new System.Drawing.Size(100, 23);
            this.tbCodigo.TabIndex = 2;
            this.tbCodigo.UseSelectable = true;
            this.tbCodigo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbCodigo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // FormularioBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbCodigo);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.btSalvar);
            this.Name = "FormularioBase";
            this.Size = new System.Drawing.Size(560, 370);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected MetroFramework.Controls.MetroButton btSalvar;
        protected MetroFramework.Controls.MetroLabel lbCodigo;
        protected MetroFramework.Controls.MetroTextBox tbCodigo;
    }
}
