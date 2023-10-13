using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Desafiocdsdsv
{
    public partial class frmCSV : Form
    {
        SqlConnection conexao;
        public frmCSV()
        {
            
            InitializeComponent();
        }

        private void btnCaminho_Click(object sender, EventArgs e)
        {
            frmDesafioDSV frmD = new frmDesafioDSV();
            SaveFileDialog svFileDialog = new SaveFileDialog();
            svFileDialog.Filter = "CSV file (*.csv)|*.csv";
            svFileDialog.Title = "Salve um arquivo excel";
            if (svFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoDoExe = svFileDialog.FileName;
                txtCaminho.Text = caminhoDoExe;
            }

        }

        private void btnCSVgerar_Click(object sender, EventArgs e)
        {
            string arquivoCSV;
            if (string.IsNullOrEmpty(txtCaminho.Text))
            {
                MessageBox.Show("Informe o caminho e nome do arquivo CSV !", "Arquivo CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                arquivoCSV = txtCaminho.Text;
            }
            try
            {
                frmDesafioDSV frmD = new frmDesafioDSV();
                conexao = new SqlConnection($"Server={frmD.txtServer};Database={frmD.txtDatabase};User Id={frmD.txtUserid};Password={frmD.txtPassword};Trusted_Connection = True;");
                SqlDataAdapter adp = new SqlDataAdapter("select * from Cliente", conexao);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                //cria um streamwriter para escrever no arquivo CSV
                StreamWriter sw = new StreamWriter(txtCaminho.Text, false);
                int iColCount = dt.Columns.Count;
                //conta as colunas para montar o cabecalho
                for (int i = 0; i < iColCount; i++)
                {
                    sw.Write(dt.Columns[i]);
                    if (i < iColCount - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
                //percorre cada linha do datatable e monta o arquivo CSV
                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 0; i < iColCount; i++)
                    {
                        if (!Convert.IsDBNull(dr[i]))
                        {
                            sw.Write(dr[i].ToString());
                        }
                        if (i < iColCount - 1)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.Write(sw.NewLine);
                }
                sw.Close();
                MessageBox.Show("Arquivo CSV gerado com sucesso !", "Arquivo CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
