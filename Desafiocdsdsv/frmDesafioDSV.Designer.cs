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
            label6 = new Label();
            btnCaminho = new Button();
            btnCSVgerar = new Button();
            txtCaminho = new TextBox();
            label7 = new Label();
            dtpInicio = new DateTimePicker();
            label8 = new Label();
            label9 = new Label();
            dtpFinal = new DateTimePicker();
            label10 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(12, 126);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(134, 51);
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
            btnBuscaEx.Size = new Size(78, 24);
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
            groupBox1.Size = new Size(459, 64);
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
            btnTestarCon.Location = new Point(161, 126);
            btnTestarCon.Name = "btnTestarCon";
            btnTestarCon.Size = new Size(134, 51);
            btnTestarCon.TabIndex = 7;
            btnTestarCon.Text = "Testar Conexão";
            btnTestarCon.UseVisualStyleBackColor = true;
            btnTestarCon.Click += btnTestarCon_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 194);
            label6.Name = "label6";
            label6.Size = new Size(140, 15);
            label6.TabIndex = 12;
            label6.Text = "Caminho onde será salvo";
            // 
            // btnCaminho
            // 
            btnCaminho.Location = new Point(393, 212);
            btnCaminho.Name = "btnCaminho";
            btnCaminho.Size = new Size(78, 23);
            btnCaminho.TabIndex = 11;
            btnCaminho.Text = "Abrir";
            btnCaminho.UseVisualStyleBackColor = true;
            btnCaminho.Click += btnCaminho_Click;
            // 
            // btnCSVgerar
            // 
            btnCSVgerar.Location = new Point(12, 241);
            btnCSVgerar.Name = "btnCSVgerar";
            btnCSVgerar.Size = new Size(134, 64);
            btnCSVgerar.TabIndex = 10;
            btnCSVgerar.Text = "Gerar CSV";
            btnCSVgerar.UseVisualStyleBackColor = true;
            btnCSVgerar.Click += btnCSVgerar_Click;
            // 
            // txtCaminho
            // 
            txtCaminho.Location = new Point(12, 212);
            txtCaminho.Name = "txtCaminho";
            txtCaminho.Size = new Size(375, 23);
            txtCaminho.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 179);
            label7.Name = "label7";
            label7.Size = new Size(163, 15);
            label7.TabIndex = 13;
            label7.Text = "Gerar CSV do Banco de dados";
            // 
            // dtpInicio
            // 
            dtpInicio.Format = DateTimePickerFormat.Short;
            dtpInicio.Location = new Point(286, 280);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(80, 23);
            dtpInicio.TabIndex = 16;
            dtpInicio.Value = new DateTime(2023, 10, 15, 0, 0, 0, 0);
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(286, 262);
            label8.Name = "label8";
            label8.Size = new Size(36, 15);
            label8.TabIndex = 17;
            label8.Text = "Início";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(384, 260);
            label9.Name = "label9";
            label9.Size = new Size(32, 15);
            label9.TabIndex = 19;
            label9.Text = "Final";
            // 
            // dtpFinal
            // 
            dtpFinal.Format = DateTimePickerFormat.Short;
            dtpFinal.Location = new Point(384, 280);
            dtpFinal.Name = "dtpFinal";
            dtpFinal.Size = new Size(80, 23);
            dtpFinal.TabIndex = 18;
            dtpFinal.Value = new DateTime(2023, 10, 15, 0, 0, 0, 0);
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(286, 241);
            label10.Name = "label10";
            label10.Size = new Size(185, 15);
            label10.TabIndex = 20;
            label10.Text = "Período em que será gerado o csv";
            // 
            // frmDesafioDSV
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(483, 317);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(dtpFinal);
            Controls.Add(label8);
            Controls.Add(dtpInicio);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(btnCaminho);
            Controls.Add(btnCSVgerar);
            Controls.Add(txtCaminho);
            Controls.Add(btnTestarCon);
            Controls.Add(groupBox1);
            Controls.Add(btnBuscaEx);
            Controls.Add(label1);
            Controls.Add(txtDiretorio);
            Controls.Add(btnInsert);
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
        public TextBox txtServer;
        private Label label5;
        private Label label4;
        public TextBox txtUserid;
        private Label label3;
        public TextBox txtDatabase;
        public MaskedTextBox txtPassword;
        private Button btnTestarCon;
        private Button btnCSV;
        private Label label6;
        private Button btnCaminho;
        private Button btnCSVgerar;
        private TextBox txtCaminho;
        private Label label7;
        private RadioButton rbVirgula;
        private RadioButton rbBarra;
        private DateTimePicker dtpInicio;
        private Label label8;
        private Label label9;
        private DateTimePicker dtpFinal;
        private Label label10;
    }
}