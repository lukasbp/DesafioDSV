using ClosedXML.Excel;
namespace Desafiocdsdsv
{
    partial class frmDesafioDSV
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnInsert = new Button();
            txtDiretorio = new TextBox();
            label1 = new Label();
            btnBuscaEx = new Button();
            groupBox1 = new GroupBox();
            txtPassword = new MaskedTextBox();
            label5 = new Label();
            label4 = new Label();
            txtUserid = new TextBox();
            label3 = new Label();
            txtDatabase = new TextBox();
            label2 = new Label();
            txtServer = new TextBox();
            btnTestarCon = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(12, 126);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(212, 51);
            btnInsert.TabIndex = 1;
            btnInsert.Text = "Inserir no Banco";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // txtDiretorio
            // 
            txtDiretorio.Location = new Point(12, 97);
            txtDiretorio.Name = "txtDiretorio";
            txtDiretorio.Size = new Size(375, 23);
            txtDiretorio.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 79);
            label1.Name = "label1";
            label1.Size = new Size(117, 15);
            label1.TabIndex = 3;
            label1.Text = "Caminho da planilha";
            // 
            // btnBuscaEx
            // 
            btnBuscaEx.Location = new Point(393, 96);
            btnBuscaEx.Name = "btnBuscaEx";
            btnBuscaEx.Size = new Size(53, 24);
            btnBuscaEx.TabIndex = 5;
            btnBuscaEx.Text = "Buscar Excel";
            btnBuscaEx.UseVisualStyleBackColor = true;
            btnBuscaEx.Click += btnBuscaEx_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtUserid);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtDatabase);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtServer);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(434, 64);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Conexao Banco";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(324, 32);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 7;
            txtPassword.MaskInputRejected += txtPassword_MaskInputRejected;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(324, 14);
            label5.Name = "label5";
            label5.Size = new Size(68, 15);
            label5.TabIndex = 6;
            label5.Text = "PASSWORD";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(218, 14);
            label4.Name = "label4";
            label4.Size = new Size(48, 15);
            label4.TabIndex = 4;
            label4.Text = "USER ID";
            // 
            // txtUserid
            // 
            txtUserid.Location = new Point(218, 32);
            txtUserid.MaxLength = 128;
            txtUserid.Name = "txtUserid";
            txtUserid.Size = new Size(100, 23);
            txtUserid.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(112, 14);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 2;
            label3.Text = "DATABASE";
            // 
            // txtDatabase
            // 
            txtDatabase.Location = new Point(112, 32);
            txtDatabase.MaxLength = 128;
            txtDatabase.Name = "txtDatabase";
            txtDatabase.Size = new Size(100, 23);
            txtDatabase.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 14);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 0;
            label2.Text = "SERVER";
            // 
            // txtServer
            // 
            txtServer.Location = new Point(6, 32);
            txtServer.MaxLength = 128;
            txtServer.Name = "txtServer";
            txtServer.Size = new Size(100, 23);
            txtServer.TabIndex = 1;
            txtServer.TabStop = false;
            // 
            // btnTestarCon
            // 
            btnTestarCon.Location = new Point(234, 126);
            btnTestarCon.Name = "btnTestarCon";
            btnTestarCon.Size = new Size(212, 51);
            btnTestarCon.TabIndex = 7;
            btnTestarCon.Text = "Testar Conexão";
            btnTestarCon.UseVisualStyleBackColor = true;
            btnTestarCon.Click += btnTestarCon_Click;
            // 
            // frmDesafioDSV
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 196);
            Controls.Add(btnTestarCon);
            Controls.Add(groupBox1);
            Controls.Add(btnBuscaEx);
            Controls.Add(label1);
            Controls.Add(txtDiretorio);
            Controls.Add(btnInsert);
            MaximumSize = new Size(476, 235);
            MinimumSize = new Size(476, 235);
            Name = "frmDesafioDSV";
            Text = "Desafio DSV";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnInsert;
        private TextBox txtDiretorio;
        private Label label1;
        private Button btnBuscaEx;
        private GroupBox groupBox1;
        private Label label2;
        private TextBox txtServer;
        private Label label5;
        private Label label4;
        private TextBox txtUserid;
        private Label label3;
        private TextBox txtDatabase;
        private MaskedTextBox txtPassword;
        private Button btnTestarCon;
    }
}