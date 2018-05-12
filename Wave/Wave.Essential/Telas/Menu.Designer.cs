namespace Wave.Essential.Telas
{
    partial class Menu
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
            this.tlFinanceiro = new MetroFramework.Controls.MetroTile();
            this.tlMembros = new MetroFramework.Controls.MetroTile();
            this.tlUsuarios = new MetroFramework.Controls.MetroTile();
            this.tlConfiguracoes = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // tlFinanceiro
            // 
            this.tlFinanceiro.ActiveControl = null;
            this.tlFinanceiro.Location = new System.Drawing.Point(3, 3);
            this.tlFinanceiro.Name = "tlFinanceiro";
            this.tlFinanceiro.Size = new System.Drawing.Size(206, 100);
            this.tlFinanceiro.TabIndex = 0;
            this.tlFinanceiro.Text = "Financeiro";
            this.tlFinanceiro.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.tlFinanceiro.UseSelectable = true;
            // 
            // tlMembros
            // 
            this.tlMembros.ActiveControl = null;
            this.tlMembros.Location = new System.Drawing.Point(3, 109);
            this.tlMembros.Name = "tlMembros";
            this.tlMembros.Size = new System.Drawing.Size(100, 100);
            this.tlMembros.TabIndex = 1;
            this.tlMembros.Text = "Membros";
            this.tlMembros.UseSelectable = true;
            // 
            // tlUsuarios
            // 
            this.tlUsuarios.ActiveControl = null;
            this.tlUsuarios.Location = new System.Drawing.Point(109, 109);
            this.tlUsuarios.Name = "tlUsuarios";
            this.tlUsuarios.Size = new System.Drawing.Size(100, 100);
            this.tlUsuarios.TabIndex = 3;
            this.tlUsuarios.Text = "Usuários";
            this.tlUsuarios.UseSelectable = true;
            this.tlUsuarios.Click += new System.EventHandler(this.tlUsuarios_Click);
            // 
            // tlConfiguracoes
            // 
            this.tlConfiguracoes.ActiveControl = null;
            this.tlConfiguracoes.Location = new System.Drawing.Point(3, 215);
            this.tlConfiguracoes.Name = "tlConfiguracoes";
            this.tlConfiguracoes.Size = new System.Drawing.Size(206, 50);
            this.tlConfiguracoes.TabIndex = 4;
            this.tlConfiguracoes.Text = "Configurações";
            this.tlConfiguracoes.UseSelectable = true;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlConfiguracoes);
            this.Controls.Add(this.tlUsuarios);
            this.Controls.Add(this.tlMembros);
            this.Controls.Add(this.tlFinanceiro);
            this.Name = "Menu";
            this.Size = new System.Drawing.Size(560, 370);
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile tlFinanceiro;
        private MetroFramework.Controls.MetroTile tlMembros;
        private MetroFramework.Controls.MetroTile tlUsuarios;
        private MetroFramework.Controls.MetroTile tlConfiguracoes;
    }
}
