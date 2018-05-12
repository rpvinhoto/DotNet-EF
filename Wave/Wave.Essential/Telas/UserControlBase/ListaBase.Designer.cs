namespace Wave.Essential.Telas.UserControlBase
{
    partial class ListaBase
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
            this.tbFiltro = new MetroFramework.Controls.MetroTextBox();
            this.btNovo = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // tbFiltro
            // 
            this.tbFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.tbFiltro.CustomButton.Image = null;
            this.tbFiltro.CustomButton.Location = new System.Drawing.Point(451, 1);
            this.tbFiltro.CustomButton.Name = "";
            this.tbFiltro.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbFiltro.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbFiltro.CustomButton.TabIndex = 1;
            this.tbFiltro.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbFiltro.CustomButton.UseSelectable = true;
            this.tbFiltro.CustomButton.Visible = false;
            this.tbFiltro.Lines = new string[0];
            this.tbFiltro.Location = new System.Drawing.Point(3, 3);
            this.tbFiltro.MaxLength = 32767;
            this.tbFiltro.Name = "tbFiltro";
            this.tbFiltro.PasswordChar = '\0';
            this.tbFiltro.PromptText = "Filtrar";
            this.tbFiltro.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbFiltro.SelectedText = "";
            this.tbFiltro.SelectionLength = 0;
            this.tbFiltro.SelectionStart = 0;
            this.tbFiltro.ShortcutsEnabled = true;
            this.tbFiltro.Size = new System.Drawing.Size(473, 23);
            this.tbFiltro.TabIndex = 2;
            this.tbFiltro.UseSelectable = true;
            this.tbFiltro.WaterMark = "Filtrar";
            this.tbFiltro.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbFiltro.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btNovo
            // 
            this.btNovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btNovo.Location = new System.Drawing.Point(482, 3);
            this.btNovo.Name = "btNovo";
            this.btNovo.Size = new System.Drawing.Size(75, 23);
            this.btNovo.TabIndex = 3;
            this.btNovo.Text = "Novo";
            this.btNovo.UseSelectable = true;
            // 
            // ListaBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btNovo);
            this.Controls.Add(this.tbFiltro);
            this.Name = "ListaBase";
            this.Size = new System.Drawing.Size(560, 370);
            this.ResumeLayout(false);

        }

        #endregion
        protected MetroFramework.Controls.MetroTextBox tbFiltro;
        protected MetroFramework.Controls.MetroButton btNovo;
    }
}
