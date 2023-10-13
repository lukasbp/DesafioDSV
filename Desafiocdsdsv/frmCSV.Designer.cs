namespace Desafiocdsdsv
{
    partial class frmCSV
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
            txtCaminho = new TextBox();
            btnCSVgerar = new Button();
            btnCaminho = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtCaminho
            // 
            txtCaminho.Location = new Point(12, 29);
            txtCaminho.Name = "txtCaminho";
            txtCaminho.Size = new Size(394, 23);
            txtCaminho.TabIndex = 0;
            // 
            // btnCSVgerar
            // 
            btnCSVgerar.Location = new Point(179, 58);
            btnCSVgerar.Name = "btnCSVgerar";
            btnCSVgerar.Size = new Size(134, 50);
            btnCSVgerar.TabIndex = 1;
            btnCSVgerar.Text = "Gerar CSV";
            btnCSVgerar.UseVisualStyleBackColor = true;
            btnCSVgerar.Click += btnCSVgerar_Click;
            // 
            // btnCaminho
            // 
            btnCaminho.Location = new Point(412, 29);
            btnCaminho.Name = "btnCaminho";
            btnCaminho.Size = new Size(75, 23);
            btnCaminho.TabIndex = 2;
            btnCaminho.Text = "Abrir";
            btnCaminho.UseVisualStyleBackColor = true;
            btnCaminho.Click += btnCaminho_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 11);
            label1.Name = "label1";
            label1.Size = new Size(140, 15);
            label1.TabIndex = 3;
            label1.Text = "Caminho onde será salvo";
            // 
            // frmCSV
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(497, 120);
            Controls.Add(label1);
            Controls.Add(btnCaminho);
            Controls.Add(btnCSVgerar);
            Controls.Add(txtCaminho);
            Name = "frmCSV";
            Text = "Gerar CSV";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCaminho;
        private Button btnCSVgerar;
        private Button btnCaminho;
        private Label label1;
    }
}