namespace CodeITAirlines.Apresentacao
{
    partial class FrmPrincipal
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
            this.lbxTerminal = new System.Windows.Forms.ListBox();
            this.lbxCarro = new System.Windows.Forms.ListBox();
            this.lbxAviao = new System.Windows.Forms.ListBox();
            this.btnTransportar = new System.Windows.Forms.Button();
            this.lblTerminal = new System.Windows.Forms.Label();
            this.lblCarro = new System.Windows.Forms.Label();
            this.lblAviao = new System.Windows.Forms.Label();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxTerminal
            // 
            this.lbxTerminal.AllowDrop = true;
            this.lbxTerminal.FormattingEnabled = true;
            this.lbxTerminal.Location = new System.Drawing.Point(12, 25);
            this.lbxTerminal.Name = "lbxTerminal";
            this.lbxTerminal.Size = new System.Drawing.Size(150, 121);
            this.lbxTerminal.TabIndex = 0;
            // 
            // lbxCarro
            // 
            this.lbxCarro.AllowDrop = true;
            this.lbxCarro.FormattingEnabled = true;
            this.lbxCarro.Location = new System.Drawing.Point(178, 25);
            this.lbxCarro.Name = "lbxCarro";
            this.lbxCarro.Size = new System.Drawing.Size(150, 43);
            this.lbxCarro.TabIndex = 1;
            this.lbxCarro.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListBoxCarro_DragDrop);
            this.lbxCarro.DragOver += new System.Windows.Forms.DragEventHandler(this.ListBox_DragOver);
            this.lbxCarro.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseDown);
            // 
            // lbxAviao
            // 
            this.lbxAviao.AllowDrop = true;
            this.lbxAviao.FormattingEnabled = true;
            this.lbxAviao.Location = new System.Drawing.Point(344, 25);
            this.lbxAviao.Name = "lbxAviao";
            this.lbxAviao.Size = new System.Drawing.Size(150, 121);
            this.lbxAviao.TabIndex = 2;
            // 
            // btnTransportar
            // 
            this.btnTransportar.Location = new System.Drawing.Point(178, 74);
            this.btnTransportar.Name = "btnTransportar";
            this.btnTransportar.Size = new System.Drawing.Size(150, 23);
            this.btnTransportar.TabIndex = 3;
            this.btnTransportar.Text = "Transportar para avião";
            this.btnTransportar.UseVisualStyleBackColor = true;
            this.btnTransportar.Click += new System.EventHandler(this.btnTransportar_Click);
            // 
            // lblTerminal
            // 
            this.lblTerminal.AutoSize = true;
            this.lblTerminal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTerminal.Location = new System.Drawing.Point(9, 9);
            this.lblTerminal.Name = "lblTerminal";
            this.lblTerminal.Size = new System.Drawing.Size(55, 13);
            this.lblTerminal.TabIndex = 4;
            this.lblTerminal.Text = "Terminal";
            // 
            // lblCarro
            // 
            this.lblCarro.AutoSize = true;
            this.lblCarro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarro.Location = new System.Drawing.Point(175, 9);
            this.lblCarro.Name = "lblCarro";
            this.lblCarro.Size = new System.Drawing.Size(37, 13);
            this.lblCarro.TabIndex = 5;
            this.lblCarro.Text = "Carro";
            // 
            // lblAviao
            // 
            this.lblAviao.AutoSize = true;
            this.lblAviao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAviao.Location = new System.Drawing.Point(341, 9);
            this.lblAviao.Name = "lblAviao";
            this.lblAviao.Size = new System.Drawing.Size(39, 13);
            this.lblAviao.TabIndex = 6;
            this.lblAviao.Text = "Avião";
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.Location = new System.Drawing.Point(178, 123);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(150, 23);
            this.btnReiniciar.TabIndex = 7;
            this.btnReiniciar.Text = "Reiniciar";
            this.btnReiniciar.UseVisualStyleBackColor = true;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 161);
            this.Controls.Add(this.btnReiniciar);
            this.Controls.Add(this.lblAviao);
            this.Controls.Add(this.lblCarro);
            this.Controls.Add(this.lblTerminal);
            this.Controls.Add(this.btnTransportar);
            this.Controls.Add(this.lbxAviao);
            this.Controls.Add(this.lbxCarro);
            this.Controls.Add(this.lbxTerminal);
            this.MaximizeBox = false;
            this.Name = "FrmPrincipal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CodeIT Airlines";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxTerminal;
        private System.Windows.Forms.ListBox lbxCarro;
        private System.Windows.Forms.ListBox lbxAviao;
        private System.Windows.Forms.Button btnTransportar;
        private System.Windows.Forms.Label lblTerminal;
        private System.Windows.Forms.Label lblCarro;
        private System.Windows.Forms.Label lblAviao;
        private System.Windows.Forms.Button btnReiniciar;
    }
}

