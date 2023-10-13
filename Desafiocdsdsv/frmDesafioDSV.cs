using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.Excel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Desafiocdsdsv
{
    public partial class frmDesafioDSV : Form
    {
        SqlConnection conexao;
        public frmDesafioDSV()
        {
            InitializeComponent();

        }
        public string StringPreenchida()
        {
            validarCampos(out string erro);
            if (!string.IsNullOrEmpty(erro))
            {
                MessageBox.Show(erro, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
            return $"Server={txtServer.Text};Database={txtDatabase.Text};User Id={txtUserid};Password={txtPassword};Trusted_Connection = True;";
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDiretorio.Text))
            {
                MessageBox.Show("Arquivo não selecionado", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var stringConexao = StringPreenchida();
            if (string.IsNullOrEmpty(stringConexao))
                return;
            try
            {
                conexao = new SqlConnection(stringConexao);
                conexao.Open();
                var xls = new XLWorkbook(txtDiretorio.Text);
                var planilhas = xls.Worksheets.First(w => w.Name == "Cliente");
                var totalLinhas = planilhas.Rows().Count();
                SqlCommand cmd;
                var ids = new List<string>();
                for (int i = 2; i <= totalLinhas; i++)
                {
                    var id = planilhas.Cell($"A{i}").Value.ToString();
                    if (!string.IsNullOrEmpty(ids.Where(a => a == id.ToString()).FirstOrDefault()))
                    {
                        MessageBox.Show("Cliente " + i + " não inserido pois o id já existe");
                        continue;
                    }

                    var Nome = planilhas.Cell($"B{i}").Value.ToString();
                    var Cidade = planilhas.Cell($"C{i}").Value.ToString();
                    var Uf = planilhas.Cell($"D{i}").Value.ToString();
                    var Cep = planilhas.Cell($"E{i}").Value.ToString().Replace("-", "");
                    var Cpf = planilhas.Cell($"F{i}").Value.ToString().Replace(".", "").Replace("-", "");
                    cmd = new SqlCommand($@"SET IDENTITY_INSERT dbo.Cliente ON;
                                            INSERT INTO [dbo].[Cliente]
                                                                ([ID]
                                                                ,[Nome]
                                                                ,[Cidade]
                                                                ,[Uf]
                                                                ,[Cep]
                                                                ,[Cpf])
                                                            VALUES
                                                                (@id,
                                                                @Nome,
                                                                @Cidade,
                                                                @Uf,
                                                                @Cep,
                                                                @Cpf);
                                                            SET IDENTITY_INSERT dbo.Cliente OFF;", conexao);
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@Nome", SqlDbType.VarChar).Value = Nome;
                    cmd.Parameters.Add("@Cidade", SqlDbType.VarChar).Value = Cidade;
                    cmd.Parameters.Add("@Uf", SqlDbType.VarChar).Value = Uf;
                    cmd.Parameters.Add("@Cep", SqlDbType.VarChar).Value = Cep;
                    cmd.Parameters.Add("@Cpf", SqlDbType.VarChar).Value = Cpf;
                    cmd.ExecuteNonQuery();
                    ids.Add(id);
                }
                var planilhas2 = xls.Worksheets.First(w => w.Name == "Debitos");
                var totalLinhas2 = planilhas2.Rows().Count();
                for (int i = 2; i <= totalLinhas2; i++)
                {
                    var Fatura = planilhas2.Cell($"A{i}").Value.ToString();
                    var Cliente = planilhas2.Cell($"B{i}").Value.ToString();
                    if (string.IsNullOrEmpty(ids.Where(a => a == Cliente.ToString()).FirstOrDefault()))
                    {
                        MessageBox.Show("Débito " + i + " não inserido pois o cliente não existe");
                        continue;
                    }
                    DateTime.TryParse(planilhas2.Cell($"C{i}").Value.ToString(), out DateTime Emissao);
                    DateTime.TryParse(planilhas2.Cell($"D{i}").Value.ToString(), out DateTime Vencimento);
                    //string Emissao = planilhas2.Cell($"C{i}").Value.ToString();
                    //string Vencimento = planilhas2.Cell($"D{i}").Value.ToString();
                    decimal.TryParse(planilhas2.Cell($"E{i}").Value.ToString(), out decimal Valor);

                    decimal.TryParse(planilhas2.Cell($"F{i}").Value.ToString(), out decimal Juros);
                    decimal.TryParse(planilhas2.Cell($"G{i}").Value.ToString(), out decimal Descontos);
                    var Pagamento = planilhas2.Cell($"H{i}").Value.ToString();
                    decimal.TryParse(planilhas2.Cell($"I{i}").Value.ToString(), out decimal ValorPago);
                    //'{DateTime.TryParseExact(Emissao.ToString(), "dd/mm/yy", CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces , out Emissao)}',
                    //'{DateTime.TryParseExact(Vencimento.ToString(), "dd/mm/yy", CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out Vencimento)}',
                    cmd = new SqlCommand($@"INSERT INTO [dbo].[Debitos]
                                                            ([Fatura]
                                                            ,[Cliente]
                                                            ,[Emissao]
                                                            ,[Vencimento]
                                                            ,[Valor]
                                                            ,[Juros]
                                                            ,[Descontos]
                                                            ,[Pagamento]
                                                            ,[ValorPago])
                                                        VALUES
                                                            (@Fatura,
                                                            @Cliente,
                                                            @Emissao,
                                                            @Vencimento,
                                                            @Valor,
                                                            @Juros,
                                                            @Descontos,
                                                            @Pagamento,
                                                            @ValorPago)", conexao);
                    cmd.Parameters.Add("@Fatura", SqlDbType.VarChar).Value = Fatura;
                    cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente;
                    cmd.Parameters.Add("@Emissao", SqlDbType.DateTime).Value = Emissao;
                    cmd.Parameters.Add("@Vencimento", SqlDbType.DateTime).Value = Vencimento;
                    cmd.Parameters.Add("@Valor", SqlDbType.Decimal).Value = Valor;
                    cmd.Parameters.Add("@Juros", SqlDbType.Decimal).Value = Juros;
                    cmd.Parameters.Add("@Descontos", SqlDbType.Decimal).Value = Descontos;
                    cmd.Parameters.Add("@Pagamento", SqlDbType.DateTime).Value = !string.IsNullOrEmpty(Pagamento) ? DateTime.Parse(Pagamento) : DBNull.Value;
                    cmd.Parameters.Add("@ValorPago", SqlDbType.Decimal).Value = ValorPago;

                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Dados Inseridos!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Os dados não foram inseridos na tabela. Valide-os\n" + ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public void validarCampos(out string erro)
        {
            erro = "";

            if (string.IsNullOrEmpty(txtServer.Text))
            {
                erro += "Campo Server vazio\n";
            }
            if (string.IsNullOrEmpty(txtDatabase.Text))
            {
                erro += "Campo Database vazio\n";
            }
            if (string.IsNullOrEmpty(txtUserid.Text))
            {
                erro += "Campo User id vazio\n";
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                erro += "Campo Password vazio\n";
            }

        }
        private void btnBuscaEx_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Planilha excel (.xlsx)|*.XLSX";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoDoExe = openFileDialog.FileName;
                txtDiretorio.Text = caminhoDoExe;
            }
        }

        private void btnTestarCon_Click(object sender, EventArgs e)
        {
            var stringConexao = StringPreenchida();
            if (string.IsNullOrEmpty(stringConexao))
                return;
            var conexao = new SqlConnection(stringConexao);
            try
            {
                conexao.Open();
                MessageBox.Show("Conexão Bem sucedida!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Conexão não estabelecida\n" + ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void btnCSV_Click(object sender, EventArgs e)
        {
            frmCSV frm = new frmCSV();
            if (string.IsNullOrEmpty(StringPreenchida()))
            {
                return;
            }
            else
            {
                frm.Show();
            }
        }
    }
}