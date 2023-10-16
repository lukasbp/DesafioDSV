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
                    //DateTime dt = DateTime.ParseExact(txtDataInicio.Text, "yyyy-dd-mm",
                    //              CultureInfo.InvariantCulture);
                    //dt.ToString("dd-MM-yyyy");
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
                    string[] validformats = new[] { "MM/dd/yyyy", "yyyy/MM/dd", "MM/dd/yyyy HH:mm:ss",
                                        "MM/dd/yyyy hh:mm tt", "yyyy-MM-dd HH:mm:ss, fff" };
                    cmd.Parameters.Add("@Emissao", SqlDbType.DateTime).Value = !string.IsNullOrEmpty(Emissao.ToShortDateString()) ? DateTime.ParseExact(Emissao.ToShortDateString(),validformats, CultureInfo.InvariantCulture) : DBNull.Value;
                    cmd.Parameters.Add("@Vencimento", SqlDbType.DateTime).Value = !string.IsNullOrEmpty(Vencimento.ToShortDateString()) ? DateTime.ParseExact(Vencimento.ToShortDateString(),validformats, CultureInfo.InvariantCulture) : DBNull.Value;
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


        private void btnCSVgerar_Click(object sender, EventArgs e)
        {
            string arquivoCSV;
            if (string.IsNullOrEmpty(StringPreenchida()))
            {
                return;
            }

            if (string.IsNullOrEmpty(txtCaminho.Text))
            {
                MessageBox.Show("Informe o caminho e nome do arquivo CSV !", "Arquivo CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                arquivoCSV = txtCaminho.Text;
            }

            //cria um streamwriter para escrever no arquivo CSV
            StreamWriter sw = new StreamWriter(txtCaminho.Text, false, Encoding.UTF8);

            try
            {
                var stringConexao = StringPreenchida();

                conexao = new SqlConnection(stringConexao);
                conexao.Open();


                SqlDataAdapter daCliente = new SqlDataAdapter("select * from Cliente", conexao);
                DataTable dtCliente = new DataTable();
                daCliente.Fill(dtCliente);

                if (dtCliente.Rows.Count == 0)
                {
                    MessageBox.Show("Tabela de clientes vazia. Execute a leitura primeiro!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                sw.Write("Cliente");
                for (int i = 0; i < dtCliente.Columns.Count; i++)
                {
                    sw.Write($"|{dtCliente.Columns[i]}");
                }
                sw.WriteLine("|||");

                for (int i = 0; i < dtCliente.Rows.Count; i++)
                {
                    string ID = dtCliente.Rows[i]["ID"].ToString();
                    string Nome = dtCliente.Rows[i]["Nome"].ToString();
                    string Cidade = dtCliente.Rows[i]["Cidade"].ToString();
                    string UF = dtCliente.Rows[i]["UF"].ToString();
                    string CEP = dtCliente.Rows[i]["CEP"].ToString();
                    string CPF = dtCliente.Rows[i]["CPF"].ToString();

                    sw.WriteLine($"Cliente|{ID}|{Nome}|{Cidade}|{UF}|{CEP}|{CPF}|");
                }

                conexao.Close();
                conexao.Open();

                SqlDataAdapter daDebito = new SqlDataAdapter("select * from Debitos where Emissao between @DataInicial and @DataFinal", conexao);
                daDebito.SelectCommand.Parameters.Add("@DataInicial", SqlDbType.DateTime).Value = dtpInicio.Value;
                daDebito.SelectCommand.Parameters.Add("@DataFinal", SqlDbType.DateTime).Value = dtpFinal.Value;

                DataTable dtDebito = new DataTable();
                daDebito.Fill(dtDebito);

                if (dtDebito.Rows.Count == 0)
                {
                    MessageBox.Show("Tabela de débitos vazia. Execute a leitura primeiro!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                sw.Write($"Debitos");
                for (int i = 0; i < dtDebito.Columns.Count; i++)
                {
                    sw.Write($"|{dtDebito.Columns[i]}");
                }
                sw.WriteLine();

                for (int i = 0; i < dtDebito.Rows.Count; i++)
                {
                    string Fatura = dtDebito.Rows[i]["Fatura"].ToString();
                    string Cliente = dtDebito.Rows[i]["Cliente"].ToString();
                    string Emissao = DateTime.Parse(dtDebito.Rows[i]["Emissao"].ToString()).ToShortDateString();
                    string Vencimento = DateTime.Parse(dtDebito.Rows[i]["Vencimento"].ToString()).ToShortDateString();
                    string Valor = dtDebito.Rows[i]["Valor"].ToString();
                    string Juros = dtDebito.Rows[i]["Juros"].ToString();
                    string Descontos = dtDebito.Rows[i]["Descontos"].ToString();
                    string Pagamento = (string.IsNullOrEmpty(dtDebito.Rows[i]["Pagamento"].ToString()) ? "" : DateTime.Parse(dtDebito.Rows[i]["Pagamento"].ToString()).ToShortDateString());
                    string ValorPago = dtDebito.Rows[i]["ValorPago"].ToString();

                    sw.WriteLine($"Debitos|{Fatura}|{Cliente}|{Emissao}|{Vencimento}|{Valor}|{Juros}|{Descontos}|{Pagamento}|{ValorPago}");
                }

                MessageBox.Show("Arquivo CSV gerado com sucesso !", "Arquivo CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                sw.Close();
            }
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
    }
}