﻿namespace AppBingo
{
    partial class FormRegistros
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
            this.lsbCadastros = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConteudo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lsbCadastros
            // 
            this.lsbCadastros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbCadastros.FormattingEnabled = true;
            this.lsbCadastros.HorizontalScrollbar = true;
            this.lsbCadastros.ItemHeight = 16;
            this.lsbCadastros.Location = new System.Drawing.Point(24, 29);
            this.lsbCadastros.Margin = new System.Windows.Forms.Padding(4);
            this.lsbCadastros.Name = "lsbCadastros";
            this.lsbCadastros.ScrollAlwaysVisible = true;
            this.lsbCadastros.Size = new System.Drawing.Size(296, 228);
            this.lsbCadastros.TabIndex = 10;
            this.lsbCadastros.SelectedIndexChanged += new System.EventHandler(this.lsbCadastros_SelectedIndexChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(369, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Conteúdo:";
            // 
            // txtConteudo
            // 
            this.txtConteudo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConteudo.Location = new System.Drawing.Point(372, 29);
            this.txtConteudo.Margin = new System.Windows.Forms.Padding(4);
            this.txtConteudo.Multiline = true;
            this.txtConteudo.Name = "txtConteudo";
            this.txtConteudo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConteudo.Size = new System.Drawing.Size(296, 228);
            this.txtConteudo.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Cadastro:";
            // 
            // FormRegistros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(681, 308);
            this.Controls.Add(this.lsbCadastros);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtConteudo);
            this.Controls.Add(this.label1);
            this.Name = "FormRegistros";
            this.Text = "FormRegistros";
            this.Load += new System.EventHandler(this.FormRegistros_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lsbCadastros;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConteudo;
        private System.Windows.Forms.Label label1;
    }
}