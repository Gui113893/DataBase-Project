using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CompanyBrandManager
{
    public partial class Form1 : Form
    {
        private SqlConnection cn;
        private int currentPessoaIndex;
        private int currentLojaIndex;
        private int currentProdutoIndex;
        private int currentMarcaIndex;
        private int currentLocalidadeIndex;
        private int currentFornecedorIndex;
        private List<String> deletedLocalidadesMarca;
        private List<String> addedLocalidadesMarca;

        private Pessoa currentPessoa;
        private Loja currentLoja;
        private Produto currentProduto;
        private Fornecedor currentFornecedor;
        private Marca currentMarca;
        private bool adding_pessoa;
        private bool adding_loja;
        private bool adding_produto;
        private bool adding_fornecedor;

        private bool adding_marca;

        private int filterProdutoByLoja;
        private String filterPessoa;

        public Form1()
        {
            InitializeComponent();
            cn = getSqlConnection();
            loadPessoas("");
            loadLojas("");
            loadProdutos(0);
            loadMarcas();
            loadFornecedores();
            deletedLocalidadesMarca = new List<String>();
            addedLocalidadesMarca = new List<String>();
            filterPessoa = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cn = getSqlConnection();
            deletedLocalidadesMarca = new List<String>();
            addedLocalidadesMarca = new List<String>();
            filterPessoa = "";
        }

        private SqlConnection getSqlConnection()
        {
            string connectionString = "Server=tcp:mednat.ieeta.pt\\SQLSERVER,8101;Database=p5g10;User Id=p5g10;Password=sql_grupo10;";
            return new SqlConnection(connectionString);
        }

        private bool verifyConnection()
        {
            if (cn == null)
                cn = getSqlConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        // Event-Funcs
        private void TabControlPessoasLojas_Click(object sender, EventArgs e)
        {
            loadPessoas(filterPessoa);
            loadLojas(""); 
            loadProdutos(filterProdutoByLoja); 
            loadMarcas(); 
            loadFornecedores();
        }

        private void PessoasList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PessoasList.SelectedIndex >= 0)
            {
                currentPessoaIndex = PessoasList.SelectedIndex;
                currentPessoa = (Pessoa)PessoasList.Items[currentPessoaIndex];
                ShowPessoa();
            }
        }

        private void LojasList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LojasList.SelectedIndex >= 0)
            {
                currentLojaIndex = LojasList.SelectedIndex;
                currentLoja = (Loja)LojasList.Items[currentLojaIndex];
                ShowLoja();
            }
        }

        private void ProdutosList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProdutosList.SelectedIndex >= 0)
            {
                currentProdutoIndex = ProdutosList.SelectedIndex;
                currentProduto = (Produto)ProdutosList.Items[currentProdutoIndex];
                ShowProduto();
            }
        }

        private void MarcasList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MarcasList.SelectedIndex >= 0)
            {
                currentMarcaIndex = MarcasList.SelectedIndex;
                currentMarca = (Marca)MarcasList.Items[currentMarcaIndex];
                deletedLocalidadesMarca.Clear();
                addedLocalidadesMarca.Clear();
                ShowMarca();
            }
        }

        

        private void LocalidadesListaMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LocalidadesListMarca.SelectedIndex >= 0)
            {
                currentLocalidadeIndex = LocalidadesListMarca.SelectedIndex;
                deleteLocalidadeButtonMarca.Visible = true;
            }
        }
        private void FornecedoresList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FornecedoresList.SelectedIndex >= 0)
            {
                currentFornecedorIndex = FornecedoresList.SelectedIndex;
                currentFornecedor = (Fornecedor)FornecedoresList.Items[currentFornecedorIndex];
                ShowFornecedor();
            }
        }
        private void SearchProduto_Click(object sender, EventArgs e)
        {
            if (searchProdutoByLoja.Text != "")
            {
                filterProdutoByLoja = Int32.Parse(searchProdutoByLoja.Text);
                if (!doesLojaExist(filterProdutoByLoja))
                    filterProdutoByLoja = 0;
                loadProdutos(filterProdutoByLoja);
            }
            else
            {
                filterProdutoByLoja = 0;
                loadProdutos(0);
            }
        }

        private void SearchPessoaButton_Click(object sender, EventArgs e)
        {
            loadPessoas(filterPessoa);
        }

        private void SearchLojaButton_Click(object sender, EventArgs e)
        {
            loadLojas(searchSubempresaLojaTxt.Text);
        }

        private void DistributeProduto_Click(object sender, EventArgs e)
        {
            if (currentProdutoIndex < 0)
            {
                MessageBox.Show("Seleciona um produto para distribuir");
                return;
            }
            cn.Close();            
            DistributeForm distributeForm = new DistributeForm(currentProduto);
            distributeForm.Show();
        }

        private void FornecerProduto_Click(object sender, EventArgs e)
        {
            if (currentFornecedorIndex < 0)
            {
                MessageBox.Show("Seleciona um produto para fornecer");
                return;
            }
            cn.Close();
            FornecerForm fornecerForm = new FornecerForm(currentFornecedor);
            fornecerForm.Show();
        }

        private void EditButtonPessoa_Click(object sender, EventArgs e)
        {
            currentPessoaIndex = PessoasList.SelectedIndex;
            if (currentPessoaIndex < 0)
            {
                MessageBox.Show("Seleciona uma pessoa para editar");
                return;
            } 
            adding_pessoa = false;
            PessoasList.Enabled = false;
            SavePessoa(adding_pessoa, currentPessoa, currentPessoa.Tipo);
            PessoasList.Enabled = true;
        }

        private void EditButtonLoja_Click(object sender, EventArgs e)
        {
            currentLojaIndex = LojasList.SelectedIndex;
            if (currentLojaIndex < 0)
            {
                MessageBox.Show("Seleciona uma loja para editar");
                return;
            }
            adding_loja = false;
            LojasList.Enabled = false;
            SaveLoja(adding_loja, currentLoja);
            LojasList.Enabled = true;
        }

        private void EditButtonProduto_Click(object sender, EventArgs e)
        {
            currentProdutoIndex = ProdutosList.SelectedIndex;
            if (currentProdutoIndex < 0)
            {
                MessageBox.Show("Seleciona um produto para editar");
                return;
            }
            adding_produto = false;
            ProdutosList.Enabled = false;
            SaveProduto(adding_produto, currentProduto);
            ProdutosList.Enabled = true;
        }

        private void EditButtonMarca_Click(object sender, EventArgs e)
        {
            currentMarcaIndex = MarcasList.SelectedIndex;
            if (currentMarcaIndex < 0)
            {
                MessageBox.Show("Seleciona uma marca para editar");
                return;
            }
            adding_marca = false;
            MarcasList.Enabled = false;
            SaveMarca(adding_marca, currentMarca);
            MarcasList.Enabled = true;
        }

        private void EditButtonFornecedor_Click(object sender, EventArgs e)
        {
            currentFornecedorIndex = FornecedoresList.SelectedIndex;
            if (currentFornecedorIndex < 0)
            {
                MessageBox.Show("Seleciona um fornecedor para editar");
                return;
            }
            adding_fornecedor = false;
            FornecedoresList.Enabled = false;
            SaveFornecedor(adding_fornecedor, currentFornecedor);
            FornecedoresList.Enabled = true;
        }

        private void DeleteButtonPessoa_Click(object sender, EventArgs e)
        {
            if  (currentPessoaIndex < 0)
            {
                MessageBox.Show("Seleciona uma pessoa para eliminar ");
                return;
            }

            if (RemovePessoa(currentPessoa))
            {
                PessoasList.Items.RemoveAt(PessoasList.SelectedIndex);
                if (currentPessoaIndex == PessoasList.Items.Count && currentPessoaIndex != 0)
                {
                    currentPessoaIndex = PessoasList.Items.Count - 1;
                    currentPessoa = (Pessoa)PessoasList.Items[currentPessoaIndex];
                }

                if (currentPessoaIndex == -1)
                {
                    ClearPessoaFields();
                    MessageBox.Show("Não há mais pessoas na base de dados");
                }
                else
                {
                    ShowPessoa();
                }

            }
        }

        private void DeleteButtonLoja_Click(object sender, EventArgs e)
        {
            if (currentLojaIndex < 0)
            {
                MessageBox.Show("Seleciona uma loja para eliminar ");
                return;
            }

            if (RemoveLoja(currentLoja))
            {
                LojasList.Items.RemoveAt(LojasList.SelectedIndex);
                if (currentLojaIndex == LojasList.Items.Count && currentLojaIndex != 0)
                {
                    currentLojaIndex = LojasList.Items.Count - 1;
                    currentLoja = (Loja)LojasList.Items[currentLojaIndex];
                }

                if (currentLojaIndex == -1)
                {
                    ClearLojaFields();
                    MessageBox.Show("Não há mais lojas na base de dados");
                }
                else
                {
                    ShowLoja();
                }

            }
        }

        private void DeleteButtonProduto_Click(object sender, EventArgs e)
        {
            if (currentProdutoIndex < 0)
            {
                MessageBox.Show("Seleciona um produto para eliminar ");
                return;
            }

            if (RemoveProduto(currentProduto))
            {
                ProdutosList.Items.RemoveAt(ProdutosList.SelectedIndex);
                if (currentProdutoIndex == ProdutosList.Items.Count && currentProdutoIndex != 0)
                {
                    currentProdutoIndex = ProdutosList.Items.Count - 1;
                    currentProduto = (Produto)ProdutosList.Items[currentProdutoIndex];
                }

                if (currentProdutoIndex == -1)
                {
                    ClearProdutoFields();
                    MessageBox.Show("Não há mais produtos na base de dados");
                }
                else
                {
                    ShowProduto();
                }

            }
        }

        private void DeleteButtonMarca_Click(object sender, EventArgs e)
        {
            if (currentMarcaIndex < 0)
            {
                MessageBox.Show("Seleciona uma marca para eliminar ");
                return;
            }

            if (RemoveMarca(currentMarca))
            {
                MarcasList.Items.RemoveAt(MarcasList.SelectedIndex);
                if (currentMarcaIndex == MarcasList.Items.Count && currentMarcaIndex != 0)
                {
                    currentMarcaIndex = MarcasList.Items.Count - 1;
                    currentMarca = (Marca)MarcasList.Items[currentMarcaIndex];
                }

                if (currentMarcaIndex == -1)
                {
                    ClearMarcaFields();
                    MessageBox.Show("Não há mais marcas na base de dados");
                }
                else
                {
                    ShowMarca();
                }

            }
        }

        private void DeleteButtonFornecedor_Click(object sender, EventArgs e)
        {
            if (currentFornecedorIndex < 0)
            {
                MessageBox.Show("Seleciona um fornecedor para eliminar ");
                return;
            }

            if (RemoveFornecedor(currentFornecedor))
            {
                FornecedoresList.Items.RemoveAt(FornecedoresList.SelectedIndex);
                if (currentFornecedorIndex == FornecedoresList.Items.Count && currentFornecedorIndex != 0)
                {
                    currentFornecedorIndex = FornecedoresList.Items.Count - 1;
                    currentFornecedor = (Fornecedor)FornecedoresList.Items[currentFornecedorIndex];
                }

                if (currentFornecedorIndex == -1)
                {
                    ClearFornecedorFields();
                    MessageBox.Show("Não há mais fornecedores na base de dados");
                }
                else
                {
                    ShowFornecedor();
                }

            }
        }

        private void DeleteLocalidadeButtonMarca_Click(object sender, EventArgs e)
        {
            if (currentLocalidadeIndex < 0)
            {
                MessageBox.Show("Seleciona uma localidade para eliminar ");
                return;
            }
            deletedLocalidadesMarca.Add(LocalidadesListMarca.Items[currentLocalidadeIndex].ToString());
            LocalidadesListMarca.Items.RemoveAt(currentLocalidadeIndex);
            deleteLocalidadeButtonMarca.Visible = false;
        }

        private void AddButtonPessoa_Click(object sender, EventArgs e)
        {
            adding_pessoa = true;
            String tipo = "";
            if (horasTxtPessoa.Visible) // se estou a adicionar um Part-Time
            {
                tipo = "Part-Time";
            }
            else if (!lojaTxtPessoa.Visible) // se a loja não está visível então estou a adicionar um Diretor
            {
                tipo = "Diretor";
            }
            else if (contratoLabelPessoa.Visible) // se o contrato está visível então estou a adicionar um Efetivo
            {
                tipo = "Efetivo";
            }
            PessoasList.Enabled = false;
            SavePessoa(adding_pessoa, currentPessoa, tipo);
            PessoasList.Enabled = true;

        }

        private void AddButtonLoja_Click(object sender, EventArgs e)
        {
            adding_loja = true;
            LojasList.Enabled = false;
            SaveLoja(adding_loja, currentLoja);
            LojasList.Enabled = true;
        }

        private void AddButtonProduto_Click(object sender, EventArgs e)
        {
            adding_produto = true;
            ProdutosList.Enabled = false;
            SaveProduto(adding_produto, currentProduto);
            ProdutosList.Enabled = true;
        }

        private void AddButtonMarca_Click(object sender, EventArgs e)
        {
            adding_marca = true;
            MarcasList.Enabled = false;
            SaveMarca(adding_marca, currentMarca);
            MarcasList.Enabled = true;
        }

        private void AddButtonLocalidadeMarca_Click(object sender, EventArgs e)
        {
            if (currentMarcaIndex < 0)
            {
                MessageBox.Show("Seleciona uma marca para adicionar uma localidade");
                return;
            }
            if (localidadeTxtMarca.Text == "")
            {
                MessageBox.Show("Insere uma localidade para adicionar");
                return;
            }
            String localidade = localidadeTxtMarca.Text;
            addedLocalidadesMarca.Add(localidade);
            LocalidadesListMarca.Items.Add(localidade);
        }

        private void AddButtonFornecedor_Click(object sender, EventArgs e)
        {
            adding_fornecedor = true;
            FornecedoresList.Enabled = false;
            SaveFornecedor(adding_fornecedor, currentFornecedor);
            FornecedoresList.Enabled = true;
        }

        private void AddToolStripPessoa_Click(object sender, EventArgs e)
        {
            ClearPessoaFields();
            HideSpecifics();
        }

        private void AddToolStripLoja_Click(object sender, EventArgs e)
        {
            ClearLojaFields();
        }

        private void AddToolStrioProduto_Click(object sender, EventArgs e)
        {
            ClearProdutoFields();
        }

        private void AddToolStripMarca_Click(object sender, EventArgs e)
        {
            ClearMarcaFields();
        }

        private void AddToolStripFornecedor_Click(object sender, EventArgs e)
        {
            ClearFornecedorFields();
        }

        private void AddPartTime_Click(object sender, EventArgs e)
        {
            showPartTimeSpecifics();
        }

        private void AddEfetivo_Click(object sender, EventArgs e)
        {
            showEfetivoSpecifics();
        }

        private void AddDiretor_Click(object sender, EventArgs e)
        {
            showDiretorSpecifics();
        }


        private void PessoaFilterByDiretor_Click(object sender, EventArgs e)
        {
            filterPessoa = "Diretor";
            loadPessoas("Diretor");   
        }

        private void PessoaFilterByPartTime_Click(object sender, EventArgs e)
        {
            filterPessoa = "Part-Time";
            loadPessoas("Part-Time");
        }

        private void PessoaFilterByEfetivo_Click(object sender, EventArgs e)
        {
            filterPessoa = "Efetivo";
            loadPessoas("Efetivo");
        }

        private void PessoaRemoveFilter_Click(object sender, EventArgs e)
        {
            filterPessoa = "";
            loadPessoas("");
        }
        
        // Aux Funcs
        public void ShowPessoa()
        {
            if (PessoasList.Items.Count == 0 | currentPessoaIndex < 0)
                return;
            Pessoa pessoa = new Pessoa();
            pessoa = (Pessoa)PessoasList.Items[currentPessoaIndex];
            nifTxtPessoa.Text = pessoa.Nif;
            nomeTxtPessoa.Text = pessoa.Nome;
            emailTxtPessoa.Text = pessoa.Email;
            sexoTxtPessoa.Text = pessoa.Sexo;
            telefoneTxtPessoa.Text = pessoa.Telefone;
            ruaTxtPessoa.Text = pessoa.Rua;
            codpostalTxtPessoa.Text = pessoa.Codigo_Postal;
            localidadeTxtPessoa.Text = pessoa.Localidade;
            salarioTxtPessoa.Text = pessoa.Salario;

            if (pessoa.Tipo == "Part-Time"){
                HideSpecifics();
                showPartTimeSpecifics();
                if (!verifyConnection())
                    return;
                // Obter horas semanais
                SqlCommand cmd = new SqlCommand("SELECT Part_Time.horas_semanais, Funcionario.loja\r\nFROM Pessoa\r\nJOIN Funcionario ON Pessoa.nif = Funcionario.nif\r\nJOIN Part_Time ON Pessoa.nif = Part_Time.nif\r\nWHERE Pessoa.nif = @nif;", cn);
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@nif", SqlDbType.Decimal) { Precision = 9, Scale = 0, Value = pessoa.Nif });
                cmd.Connection = cn;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    horasTxtPessoa.Text = reader["horas_semanais"].ToString();
                    lojaTxtPessoa.Text = reader["loja"].ToString();
                }
            }
            else if (pessoa.Tipo == "Diretor")
            {
                HideSpecifics();
            }
            else if (pessoa.Tipo == "Efetivo")
            {
                HideSpecifics();
                showEfetivoSpecifics();
                if (!verifyConnection())
                    return;
                // Obter loja e datas de contrato
                SqlCommand cmd = new SqlCommand("SELECT \r\n    Funcionario.loja,\r\n    Contrato.data_inicio,\r\n    Contrato.data_fim\r\nFROM \r\n    Funcionario\r\nJOIN \r\n    Efetivo ON Funcionario.nif = Efetivo.nif\r\nJOIN \r\n    Contrato ON Efetivo.contrato = Contrato.id_contrato\r\nWHERE \r\n    Funcionario.nif = @Nif;\r\n", cn);
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@nif", SqlDbType.Decimal) { Precision = 9, Scale = 0, Value = pessoa.Nif });
                cmd.Connection = cn;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lojaTxtPessoa.Text = reader["loja"].ToString();
                    DateTime dataInicio = reader.GetDateTime(reader.GetOrdinal("data_inicio"));
                    DateTime dataFim = reader.GetDateTime(reader.GetOrdinal("data_fim"));

                    inicioContratoTxt.Text = dataInicio.ToString("yyyy-MM-dd");
                    fimContratoTxt.Text = dataFim.ToString("yyyy-MM-dd");
                }
            }
            cn.Close();
        }

        public void ShowLoja()
        {
            if (LojasList.Items.Count == 0 | currentLojaIndex < 0)
                return;
            Loja loja = new Loja();
            loja = (Loja)LojasList.Items[currentLojaIndex];
            telefoneTxtLoja.Text = loja.Telefone;
            ruaTxtLoja.Text = loja.Rua;
            codpostalTxtLoja.Text = loja.Codigo_postal;
            localidadeTxtLoja.Text = loja.Localidade;
            gerenteTxtLoja.Text = loja.Gerente;
            subempresaTxtLoja.Text = loja.SubempresaID;
        }

        public void ShowProduto()
        {
            if (ProdutosList.Items.Count == 0 | currentProdutoIndex < 0)
                return;
            Produto produto = new Produto();
            produto = (Produto)ProdutosList.Items[currentProdutoIndex];
            precoTxtProduto.Text = produto.Preco;
            nomeTxtProduto.Text = produto.Nome;
            marcaTxtProduto.Text = produto.MarcaId;

            if (!verifyConnection())
            {
                return;
            }
            // Obter stock em circulação
            SqlCommand cmd = new SqlCommand("SELECT dbo.fn_QuantidadeProdutoLojas(@id_produto) AS QuantidadeTotal;", cn);
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("@id_produto", SqlDbType.Int) { Value = produto.ID });
            cmd.Connection = cn;
            SqlDataReader reader = cmd.ExecuteReader();
            String stock_circulação = "0";
            if (reader.Read())
            {
                stock_circulação = reader["QuantidadeTotal"].ToString();
            } 
            if (filterProdutoByLoja > 0)
            {
                // Se o filtro por loja está ativo mostra stock_em_loja/stock_em_circulação
                stockLabel.Text = "Stock Loja:";
                stockProdutoLabel.Text = produto.QuantidadeLoja.ToString();
            }
            else
            {
                stockLabel.Text = "Stock em Lojas:";
                stockProdutoLabel.Text = stock_circulação;
            }
            cn.Close();
            // Colocar o stock disponível (stock fornecido - stock_circulação) por query
            if (!verifyConnection())
            {
                return;
            }
            SqlCommand cmd2 = new SqlCommand("SELECT (dbo.fn_TotalFornecidoPorProduto(@id_produto) - dbo.fn_QuantidadeProdutoLojas(@id_produto)) AS QuantidadeDisponível;",cn);
            cmd2.Parameters.Clear();
            cmd2.Parameters.Add(new SqlParameter("@id_produto", SqlDbType.Int) { Value = produto.ID });
            cmd2.Connection = cn;
            SqlDataReader reader2 = cmd2.ExecuteReader();
            String stock_disponivel = "0";
            if (reader2.Read())
            {
                stock_disponivel = reader2["QuantidadeDisponível"].ToString();
            }
            stockDisponivelLabel.Text = stock_disponivel.ToString();
            cn.Close();

        }

        public void ShowMarca()
        {
            deleteLocalidadeButtonMarca.Visible = false;
            if (MarcasList.Items.Count == 0 | currentMarcaIndex < 0)
                return;
            Marca marca = new Marca();
            marca = (Marca)MarcasList.Items[currentMarcaIndex];
            nomeTxtMarca.Text = marca.Nome;
            dataRegistoTxtMarca.Text = marca.Data_inicio;
            dataVencimentoTxtMarca.Text = marca.Data_vencimento;

            if (!verifyConnection())
            {
                return;
            }

            // Obter localidades da marca
            SqlCommand cmd = new SqlCommand("SELECT * FROM Pat_Locs WHERE patente = @marcaId", cn);
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("@marcaId", SqlDbType.Int) { Value = marca.ID });
            cmd.Connection = cn;
            SqlDataReader reader = cmd.ExecuteReader();
            String localidade = "";
            LocalidadesListMarca.Items.Clear();
            while (reader.Read())
            {
                localidade = reader["Ploc"].ToString();
                LocalidadesListMarca.Items.Add(localidade);
                
            }
            cn.Close();
        }

        public void ShowFornecedor()
        {
            if (FornecedoresList.Items.Count == 0 | currentFornecedorIndex < 0)
                return;
            Fornecedor fornecedor = new Fornecedor();
            fornecedor = (Fornecedor)FornecedoresList.Items[currentFornecedorIndex];
            telefoneFornecedorTxt.Text = fornecedor.Telefone;
            ruaFornecedorTxt.Text = fornecedor.Rua;
            codPostalFornecedorTxt.Text = fornecedor.Codigo_Postal;
            localidadeFornecedorTxt.Text = fornecedor.Localidade;
        }

        public void ClearPessoaFields()
        {
            nifTxtPessoa.Text = "";
            nomeTxtPessoa.Text = "";
            emailTxtPessoa.Text = "";
            sexoTxtPessoa.Text = "";
            telefoneTxtPessoa.Text = "";
            ruaTxtPessoa.Text = "";
            codpostalTxtPessoa.Text = "";
            localidadeTxtPessoa.Text = "";
            salarioTxtPessoa.Text = "";
            horasTxtPessoa.Text = "";
            lojaTxtPessoa.Text = "";
            DateTime now = DateTime.Now;
            inicioContratoTxt.Text = now.ToString("yyyy-MM-dd");
            fimContratoTxt.Text = "";
        }

        public void ClearLojaFields()
        {
            telefoneTxtLoja.Text = "";
            ruaTxtLoja.Text = "";
            codpostalTxtLoja.Text = "";
            localidadeTxtLoja.Text = "";
            gerenteTxtLoja.Text = "";
            subempresaTxtLoja.Text = "";
        }

        public void ClearProdutoFields()
        {
            precoTxtProduto.Text = "";
            nomeTxtProduto.Text = "";
            marcaTxtProduto.Text = "";
            stockProdutoLabel.Text = "";
            stockDisponivelLabel.Text = "";
        }


        public void ClearMarcaFields()
        {
            nomeTxtMarca.Text = "";
            dataVencimentoTxtMarca.Text = "";
            LocalidadesListMarca.Items.Clear();
            DateTime now = DateTime.Now;
            dataRegistoTxtMarca.Text = now.ToString("yyyy-MM-dd");
            deleteLocalidadeButtonMarca.Visible = false;
        }

        public void ClearFornecedorFields()
        {
            telefoneFornecedorTxt.Text = "";
            ruaFornecedorTxt.Text = "";
            codPostalFornecedorTxt.Text = "";
            localidadeFornecedorTxt.Text = "";
        }

        public void HideSpecifics()
        {
            horasLabelPessoa.Visible = false;
            horasTxtPessoa.Visible = false;
            lojaLabelPessoa.Visible = false;
            lojaTxtPessoa.Visible = false;
            contratoLabelPessoa.Visible = false;
            inicioContratoLabel.Visible = false;
            inicioContratoTxt.Visible = false;  
            fimContratoLabel.Visible = false;
            fimContratoTxt.Visible = false;
        }

        private bool SavePessoa(bool adding_pessoa, Pessoa currentPessoa, String tipo)
        {
            // currentPessoa serve só para o caso de estar a editar para guardar informação antiga
            Pessoa pessoa = new Pessoa();
            try
            {
                pessoa.Nif = nifTxtPessoa.Text;
                pessoa.Nome = nomeTxtPessoa.Text;
                pessoa.Email = emailTxtPessoa.Text;
                pessoa.Sexo = sexoTxtPessoa.Text;
                pessoa.Telefone = telefoneTxtPessoa.Text;
                pessoa.Rua = ruaTxtPessoa.Text;
                pessoa.Codigo_Postal = codpostalTxtPessoa.Text;
                pessoa.Localidade = localidadeTxtPessoa.Text;
                pessoa.Salario = salarioTxtPessoa.Text;
                pessoa.Tipo = tipo;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return false;
            }
            if (!adding_pessoa)
            {
                if (UpdatePessoa(pessoa, currentPessoa))
                    PessoasList.Items[currentPessoaIndex] = pessoa;
                else
                    return false;
            }
            else
            {
                if (AddPessoa(pessoa, tipo))
                    PessoasList.Items.Add(pessoa);
                else
                    return false;
            }
            return true;
        }

        private bool SaveLoja(bool adding_loja, Loja currentLoja)
        {
            // currentLoja serve só para o caso de estar a editar para guardar informação antiga
            Loja loja = new Loja();
            try
            {
                loja.Telefone = telefoneTxtLoja.Text;
                loja.Rua = ruaTxtLoja.Text;
                loja.Codigo_postal = codpostalTxtLoja.Text;
                loja.Localidade = localidadeTxtLoja.Text;
                loja.SubempresaID = subempresaTxtLoja.Text;
                loja.ID = currentLoja.ID;

                if (gerenteTxtLoja.Text == "")
                    loja.Gerente = null;
                else
                    loja.Gerente = gerenteTxtLoja.Text;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return false;
            }
            if (!adding_loja)
            {
                if (UpdateLoja(loja, currentLoja))
                {
                    LojasList.Items[currentLojaIndex] = loja;
                    loadLojas("");
                }
                else
                return false;
            }
            else
            {
                if (AddLoja(loja))
                {
                    LojasList.Items.Add(loja);
                    loadLojas("");
                }
                else
                    return false;
            }
            return true;
        }

        private bool SaveProduto(bool adding_produto, Produto currentProduto)
        {
            // currentProduto serve só para o caso de estar a editar para guardar informação antiga
            Produto produto = new Produto();
            try
            {
                produto.Preco = precoTxtProduto.Text;
                produto.Nome = nomeTxtProduto.Text;
                produto.MarcaId = marcaTxtProduto.Text;
                produto.ID = currentProduto.ID;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return false;
            }
            if (!adding_produto)
            {
                if (UpdateProduto(produto, currentProduto))
                {
                    ProdutosList.Items[currentProdutoIndex] = produto;
                    loadProdutos(filterProdutoByLoja);
                }
                else
                    return false;
            }
            else
            {
                if (AddProduto(produto))
                {
                    ProdutosList.Items.Add(produto);
                    loadProdutos(filterProdutoByLoja);
                }
                else
                    return false;
            }
            return true;
        }

        private bool SaveMarca(bool adding_marca, Marca currentMarca)
        {
            // currentMarca serve só para o caso de estar a editar para guardar informação antiga
            Marca marca = new Marca();
            try
            {
                marca.Nome = nomeTxtMarca.Text;
                marca.Data_inicio = dataRegistoTxtMarca.Text;
                marca.Data_vencimento = dataVencimentoTxtMarca.Text;
                marca.ID = currentMarca.ID;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return false;
            }
            if (!adding_marca)
            {
                if (UpdateMarca(marca, currentMarca))
                {
                    MarcasList.Items[currentMarcaIndex] = marca;
                    loadMarcas();
                }
                else
                    return false;
            }
            else
            {
                if (AddMarca(marca))
                {
                    MarcasList.Items.Add(marca);
                    loadMarcas();
                }
                else
                    return false;
            }
            return true;
        }

        private bool SaveFornecedor(bool adding_fornecedor, Fornecedor currentFornecedor)
        {
            // currentFornecedor serve só para o caso de estar a editar para guardar informação antiga
            Fornecedor fornecedor = new Fornecedor();
            try
            {
                fornecedor.Telefone = telefoneFornecedorTxt.Text;
                fornecedor.Rua = ruaFornecedorTxt.Text;
                fornecedor.Codigo_Postal = codPostalFornecedorTxt.Text;
                fornecedor.Localidade = localidadeFornecedorTxt.Text;
                fornecedor.ID = currentFornecedor.ID;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return false;
            }
            if (!adding_fornecedor)
            {
                if (UpdateFornecedor(fornecedor, currentFornecedor))
                {
                    FornecedoresList.Items[currentFornecedorIndex] = fornecedor;
                    loadFornecedores();
                }
                else
                    return false;
            }
            else
            {
                if (AddFornecedor(fornecedor))
                {
                    FornecedoresList.Items.Add(fornecedor);
                    loadFornecedores();
                }
                else
                    return false;
            }
            return true;
        }

        private bool AddPessoa(Pessoa pessoa, String tipo)
        {
            if (!verifyConnection())
                return false;
            
            if (tipo == "Part-Time")
            {
                using (SqlCommand cmd = new SqlCommand("AddPartTimeEmployee", cn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@Nif", SqlDbType.Decimal) { Value = pessoa.Nif });
                        cmd.Parameters.Add(new SqlParameter("@Nome", SqlDbType.VarChar, 100) { Value = pessoa.Nome });
                        cmd.Parameters.Add(new SqlParameter("@Sexo", SqlDbType.Char, 1) { Value = pessoa.Sexo });
                        cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 100) { Value = pessoa.Email });
                        cmd.Parameters.Add(new SqlParameter("@Telefone", SqlDbType.VarChar, 20) { Value = pessoa.Telefone });
                        cmd.Parameters.Add(new SqlParameter("@Rua", SqlDbType.VarChar, 100) { Value = pessoa.Rua });
                        cmd.Parameters.Add(new SqlParameter("@CodigoPostal", SqlDbType.VarChar, 10) { Value = pessoa.Codigo_Postal });
                        cmd.Parameters.Add(new SqlParameter("@Localidade", SqlDbType.VarChar, 100) { Value = pessoa.Localidade });
                        cmd.Parameters.Add(new SqlParameter("@Salario", SqlDbType.Decimal) { Value = pessoa.Salario });
                        cmd.Parameters.Add(new SqlParameter("@Loja", SqlDbType.Int) { Value = lojaTxtPessoa.Text });
                        cmd.Parameters.Add(new SqlParameter("@HorasSemanais", SqlDbType.Int) { Value = horasTxtPessoa.Text });

                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Erro ao adicionar esta pessoa| " + exc.Message);
                        cn.Close();
                        return false;
                    }
                }
            }
            else if (tipo == "Diretor")
            {
                using (SqlCommand cmd = new SqlCommand("AddDirector", cn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@Nif", SqlDbType.Decimal) { Value = pessoa.Nif });
                        cmd.Parameters.Add(new SqlParameter("@Nome", SqlDbType.VarChar, 100) { Value = pessoa.Nome });
                        cmd.Parameters.Add(new SqlParameter("@Sexo", SqlDbType.Char, 1) { Value = pessoa.Sexo });
                        cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 100) { Value = pessoa.Email });
                        cmd.Parameters.Add(new SqlParameter("@Telefone", SqlDbType.VarChar, 20) { Value = pessoa.Telefone });
                        cmd.Parameters.Add(new SqlParameter("@Rua", SqlDbType.VarChar, 100) { Value = pessoa.Rua });
                        cmd.Parameters.Add(new SqlParameter("@CodigoPostal", SqlDbType.VarChar, 10) { Value = pessoa.Codigo_Postal });
                        cmd.Parameters.Add(new SqlParameter("@Localidade", SqlDbType.VarChar, 100) { Value = pessoa.Localidade });
                        cmd.Parameters.Add(new SqlParameter("@Salario", SqlDbType.Decimal) { Value = pessoa.Salario });

                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Erro ao adicionar esta pessoa| " + exc.Message);
                        cn.Close();
                        return false;
                    }
                }
            }
            else if (tipo == "Efetivo")
            {
                using (SqlCommand cmd = new SqlCommand("AddEffectiveEmployee", cn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@Nif", SqlDbType.Decimal) { Value = pessoa.Nif });
                        cmd.Parameters.Add(new SqlParameter("@Nome", SqlDbType.VarChar, 100) { Value = pessoa.Nome });
                        cmd.Parameters.Add(new SqlParameter("@Sexo", SqlDbType.Char, 1) { Value = pessoa.Sexo });
                        cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 100) { Value = pessoa.Email });
                        cmd.Parameters.Add(new SqlParameter("@Telefone", SqlDbType.VarChar, 20) { Value = pessoa.Telefone });
                        cmd.Parameters.Add(new SqlParameter("@Rua", SqlDbType.VarChar, 100) { Value = pessoa.Rua });
                        cmd.Parameters.Add(new SqlParameter("@CodigoPostal", SqlDbType.VarChar, 10) { Value = pessoa.Codigo_Postal });
                        cmd.Parameters.Add(new SqlParameter("@Localidade", SqlDbType.VarChar, 100) { Value = pessoa.Localidade });
                        cmd.Parameters.Add(new SqlParameter("@Salario", SqlDbType.Decimal) { Value = pessoa.Salario });
                        cmd.Parameters.Add(new SqlParameter("@Loja", SqlDbType.Int) { Value = string.IsNullOrEmpty(lojaTxtPessoa.Text) ? (object)DBNull.Value : Convert.ToInt32(lojaTxtPessoa.Text) });
                        cmd.Parameters.Add(new SqlParameter("@InicioContrato", SqlDbType.Date) { Value = inicioContratoTxt.Text });
                        cmd.Parameters.Add(new SqlParameter("@FimContrato", SqlDbType.Date) { Value = fimContratoTxt.Text });

                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Erro ao adicionar esta pessoa| " + exc.Message);
                        cn.Close();
                        return false;
                    }
                }
            }
            MessageBox.Show("Pessoa adicionada com sucesso");
            cn.Close();
            return true;
        }

        private bool AddLoja(Loja loja)
        {
            if (!verifyConnection())
                return false;

            using (SqlCommand cmd = new SqlCommand("INSERT INTO Loja(telefone, rua, codigo_postal, localidade, subempresa, gerente) VALUES (@Telefone, @Rua, @CodigoPostal, @Localidade, @Subempresa, @Gerente)", cn))
            {
                try
                {
                    cmd.Parameters.Add(new SqlParameter("@Telefone", SqlDbType.VarChar, 20) { Value = loja.Telefone });
                    cmd.Parameters.Add(new SqlParameter("@Rua", SqlDbType.VarChar, 100) { Value = loja.Rua });
                    cmd.Parameters.Add(new SqlParameter("@CodigoPostal", SqlDbType.VarChar, 10) { Value = loja.Codigo_postal });
                    cmd.Parameters.Add(new SqlParameter("@Localidade", SqlDbType.VarChar, 100) { Value = loja.Localidade });
                    cmd.Parameters.Add(new SqlParameter("@Subempresa", SqlDbType.Int) { Value = loja.SubempresaID });

                    if (loja.Gerente == null)
                        cmd.Parameters.Add(new SqlParameter("@Gerente", SqlDbType.Decimal) { Value = DBNull.Value });
                    else
                        cmd.Parameters.Add(new SqlParameter("@Gerente", SqlDbType.Decimal) { Value = loja.Gerente });

                    cmd.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Erro ao adicionar esta loja| " + exc.Message);
                    cn.Close();
                    return false;
                }
            }
            String subempresaNome = "";
            using (SqlCommand cmd = new SqlCommand("SELECT nome FROM SubEmpresa WHERE id = @subempresaId", cn))
            {
                cmd.Parameters.Add(new SqlParameter("@subempresaId", SqlDbType.Int) { Value = loja.SubempresaID });
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    subempresaNome = reader["nome"].ToString();
                }
                else
                {
                    MessageBox.Show("Subempresa não existe");
                    cn.Close();
                    return false;
                }
            }
            loja.SubempresaNome = subempresaNome;
            MessageBox.Show("Loja adicionada com sucesso");
            cn.Close();
            return true;
        }

        private bool AddProduto(Produto produto)
        {
            if (!verifyConnection())
                return false;

            using (SqlCommand cmd = new SqlCommand("INSERT INTO Produto(preco, nome, marca) VALUES (@Preco, @Nome, @Marca)", cn))
            {
                try
                {
                    cmd.Parameters.Add(new SqlParameter("@Preco", SqlDbType.Decimal) { Value = produto.Preco });
                    cmd.Parameters.Add(new SqlParameter("@Nome", SqlDbType.VarChar, 100) { Value = produto.Nome });
                    cmd.Parameters.Add(new SqlParameter("@Marca", SqlDbType.Int) { Value = produto.MarcaId });

                    cmd.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Erro ao adicionar este produto| " + exc.Message);
                    cn.Close();
                    return false;
                }
            }
            MessageBox.Show("Produto adicionado com sucesso");
            cn.Close();
            return true;
        }

        private bool AddMarca(Marca marca)
        {
            if (!verifyConnection())
                return false;

            // Adicionar a marca na tabela
            using (SqlCommand cmd = new SqlCommand("AddMarca", cn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Nome", SqlDbType.VarChar, 100) { Value = marca.Nome });
                    cmd.Parameters.Add(new SqlParameter("@Data_registo", SqlDbType.Date) { Value = marca.Data_inicio });
                    cmd.Parameters.Add(new SqlParameter("@Data_vencimento", SqlDbType.Date) { Value = marca.Data_vencimento });

                    cmd.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Erro ao adicionar esta marca| " + exc.Message);
                    cn.Close();
                    return false;
                }
            }
            // Caso a lista de localidades não esteja vazia, inserir cada localidade na tabela Pat_Locs
            if (LocalidadesListMarca.Items.Count > 0)
            {
                foreach (String localidade in LocalidadesListMarca.Items)
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Pat_Locs(patente, Ploc) VALUES ((SELECT MAX(patente) FROM Marca), @localidade)", cn))
                    {
                        try
                        {
                            cmd.Parameters.Add(new SqlParameter("@localidade", SqlDbType.VarChar, 100) { Value = localidade });
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show("Erro ao adicionar esta localidade| " + exc.Message);
                            cn.Close();
                            return false;
                        }
                    }
                }
            }
            MessageBox.Show("Marca adicionada com sucesso");
            cn.Close();
            return true;
        }

        private bool AddFornecedor(Fornecedor fornecedor)
        {
            if (!verifyConnection())
                return false;

            using (SqlCommand cmd = new SqlCommand("INSERT INTO Fornecedor(telefone, rua, codigo_postal, localidade) VALUES (@Telefone, @Rua, @CodigoPostal, @Localidade)", cn))
            {
                try
                {
                    cmd.Parameters.Add(new SqlParameter("@Telefone", SqlDbType.VarChar, 20) { Value = fornecedor.Telefone });
                    cmd.Parameters.Add(new SqlParameter("@Rua", SqlDbType.VarChar, 100) { Value = fornecedor.Rua });
                    cmd.Parameters.Add(new SqlParameter("@CodigoPostal", SqlDbType.VarChar, 10) { Value = fornecedor.Codigo_Postal });
                    cmd.Parameters.Add(new SqlParameter("@Localidade", SqlDbType.VarChar, 100) { Value = fornecedor.Localidade });

                    cmd.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Erro ao adicionar este fornecedor| " + exc.Message);
                    cn.Close();
                    return false;
                }
            }
            MessageBox.Show("Fornecedor adicionado com sucesso");
            cn.Close();
            return true;
        }

        private bool UpdatePessoa(Pessoa pessoa, Pessoa anteriorPessoa)
        {
            if (!verifyConnection())
                return false;
        
            SqlCommand cmd = new SqlCommand("UPDATE Pessoa SET nif = @nif, nome = @nome, email = @email, sexo = @sexo, telefone = @telefone, rua = @rua, codigo_postal = @codigo_postal, localidade = @localidade, salario = @salario WHERE nif = @nifAnterior", cn);
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("@nif", SqlDbType.Decimal) { Precision = 9, Scale = 0, Value = pessoa.Nif });
            cmd.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar, 100) { Value = pessoa.Nome });
            cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 100) { Value = (object)pessoa.Email ?? DBNull.Value });
            cmd.Parameters.Add(new SqlParameter("@sexo", SqlDbType.Char, 1) { Value = pessoa.Sexo });
            cmd.Parameters.Add(new SqlParameter("@telefone", SqlDbType.VarChar, 20) { Value = (object)pessoa.Telefone ?? DBNull.Value });
            cmd.Parameters.Add(new SqlParameter("@rua", SqlDbType.VarChar, 100) { Value = (object)pessoa.Rua ?? DBNull.Value });
            cmd.Parameters.Add(new SqlParameter("@codigo_postal", SqlDbType.VarChar, 10) { Value = (object)pessoa.Codigo_Postal ?? DBNull.Value });
            cmd.Parameters.Add(new SqlParameter("@localidade", SqlDbType.VarChar, 100) { Value = (object)pessoa.Localidade ?? DBNull.Value });
            cmd.Parameters.Add(new SqlParameter("@salario", SqlDbType.Decimal) { Precision = 10, Scale = 2, Value = pessoa.Salario });
            cmd.Parameters.Add(new SqlParameter("@nifAnterior", SqlDbType.Decimal) { Precision = 9, Scale = 0, Value = anteriorPessoa.Nif });
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Erro ao atualizar pessoa na base de dados: " + exc.Message);
                cn.Close();
                return false;
            }
            if (anteriorPessoa.Tipo == "Part-Time")
            {
                cmd.CommandText = "UPDATE Part_Time SET horas_semanais = @horas_semanais WHERE nif = @nif";
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@horas_semanais", SqlDbType.Int) { Value = horasTxtPessoa.Text });
                cmd.Parameters.Add(new SqlParameter("@nif", SqlDbType.Decimal) { Precision = 9, Scale = 0, Value = pessoa.Nif });
            }
            else if (anteriorPessoa.Tipo == "Efetivo")
            {
                cmd.CommandText = "UPDATE Contrato SET data_inicio = @data_inicio, data_fim = @data_fim WHERE id_contrato = (SELECT contrato FROM Efetivo WHERE nif = @nif)";
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@data_inicio", SqlDbType.Date) { Value = inicioContratoTxt.Text });
                cmd.Parameters.Add(new SqlParameter("@data_fim", SqlDbType.Date) { Value = fimContratoTxt.Text });
                cmd.Parameters.Add(new SqlParameter("@nif", SqlDbType.Decimal) { Precision = 9, Scale = 0, Value = pessoa.Nif });
            }
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Erro ao atualizar pessoa na base de dados: " + exc.Message);
                cn.Close();
                return false;
            }
            if (anteriorPessoa.Tipo == "Part-Time" || anteriorPessoa.Tipo == "Efetivo")
            {
                cmd.CommandText = "UPDATE Funcionario SET loja = @loja WHERE nif = @nif";
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@loja", SqlDbType.Int) { Value = lojaTxtPessoa.Text });
                cmd.Parameters.Add(new SqlParameter("@nif", SqlDbType.Decimal) { Precision = 9, Scale = 0, Value = pessoa.Nif });
            }
            try 
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Erro ao atualizar pessoa na base de dados: " + exc.Message);
                cn.Close();
                return false;
            }
            MessageBox.Show("Pessoa atualizada com sucesso");
            cn.Close();
            return true;
        }

        private bool UpdateLoja(Loja loja, Loja currentLoja)
        {
            if (!verifyConnection())
                return false;

            using (SqlCommand cmd = new SqlCommand("UPDATE Loja SET telefone = @telefone, rua = @rua, codigo_postal = @codigo_postal, localidade = @localidade, subempresa = @subempresa, gerente = @gerente WHERE id_loja = @id_loja", cn))
            {
                try
                {
                    cmd.Parameters.Add(new SqlParameter("@telefone", SqlDbType.VarChar, 20) { Value = loja.Telefone });
                    cmd.Parameters.Add(new SqlParameter("@rua", SqlDbType.VarChar, 100) { Value = loja.Rua });
                    cmd.Parameters.Add(new SqlParameter("@codigo_postal", SqlDbType.VarChar, 10) { Value = loja.Codigo_postal });
                    cmd.Parameters.Add(new SqlParameter("@localidade", SqlDbType.VarChar, 100) { Value = loja.Localidade });
                    cmd.Parameters.Add(new SqlParameter("@subempresa", SqlDbType.Int) { Value = loja.SubempresaID });
                    cmd.Parameters.Add(new SqlParameter("@gerente", SqlDbType.Decimal) { Value = (object)loja.Gerente ?? DBNull.Value  });
                    cmd.Parameters.Add(new SqlParameter("@id_loja", SqlDbType.Int) { Value = currentLoja.ID });

                    cmd.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Erro ao atualizar loja na base de dados: " + exc.Message);
                    cn.Close();
                    return false;
                }
            }
            MessageBox.Show("Loja atualizada com sucesso");
            cn.Close();
            return true;
        }

        private bool UpdateProduto(Produto produto, Produto currentProduto)
        {
            if (!verifyConnection())
                return false;

            using (SqlCommand cmd = new SqlCommand("UPDATE Produto SET preco = @preco, nome = @nome, marca = @marca WHERE id_produto = @id_produto", cn))
            {
                try
                {
                    cmd.Parameters.Add(new SqlParameter("@preco", SqlDbType.Decimal) { Value = produto.Preco });
                    cmd.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar, 100) { Value = produto.Nome });
                    cmd.Parameters.Add(new SqlParameter("@marca", SqlDbType.Int) { Value = produto.MarcaId });
                    cmd.Parameters.Add(new SqlParameter("@id_produto", SqlDbType.Int) { Value = currentProduto.ID });

                    cmd.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Erro ao atualizar produto na base de dados: " + exc.Message);
                    cn.Close();
                    return false;
                }
            }
            MessageBox.Show("Produto atualizado com sucesso");
            cn.Close();
            return true;
        }

        private bool UpdateMarca(Marca marca, Marca currentMarca)
        {
            if (!verifyConnection())
                return false;
            
            // Primeiro dar update ás datas da patente
            using (SqlCommand cmd = new SqlCommand("UPDATE Patente SET data_registo = @data_registo, data_vencimento = @data_vencimento WHERE id_patente = @id", cn))
            {
                try
                {
                    cmd.Parameters.Add(new SqlParameter("@data_registo", SqlDbType.Date) { Value = marca.Data_inicio });
                    cmd.Parameters.Add(new SqlParameter("@data_vencimento", SqlDbType.Date) { Value = marca.Data_vencimento });
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = currentMarca.ID });

                    cmd.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Erro ao atualizar marca na base de dados: " + exc.Message);
                    cn.Close();
                    return false;
                }
            }

            // De seguida dar update ao nome da marca
            using (SqlCommand cmd = new SqlCommand("UPDATE Marca SET marcaNome = @nome WHERE patente = @id", cn))
            {
                try
                {
                    cmd.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar, 100) { Value = marca.Nome });
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = currentMarca.ID });

                    cmd.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Erro ao atualizar marca na base de dados: " + exc.Message);
                    cn.Close();
                    return false;
                }
            }

            // Adicionar as novas localidades
            if (addedLocalidadesMarca.Count > 0)
            {
                foreach (String localidade in addedLocalidadesMarca)
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Pat_Locs(patente, Ploc) VALUES (@patente, @localidade)", cn))
                    {
                        try
                        {
                            cmd.Parameters.Add(new SqlParameter("@patente", SqlDbType.Int) { Value = currentMarca.ID });
                            cmd.Parameters.Add(new SqlParameter("@localidade", SqlDbType.VarChar, 100) { Value = localidade });
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show("Erro ao atualizar marca na base de dados: " + exc.Message);
                            cn.Close();
                            return false;
                        }
                    }
                }
            }

            // De seguida remover as localidades que foram removidas
            if (deletedLocalidadesMarca.Count > 0)
            {
                foreach (String localidade in deletedLocalidadesMarca)
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Pat_Locs WHERE patente = @patente AND Ploc = @localidade", cn))
                    {
                        try
                        {
                            cmd.Parameters.Add(new SqlParameter("@patente", SqlDbType.Int) { Value = currentMarca.ID });
                            cmd.Parameters.Add(new SqlParameter("@localidade", SqlDbType.VarChar, 100) { Value = localidade });
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show("Erro ao atualizar marca na base de dados: " + exc.Message);
                            cn.Close();
                            return false;
                        }
                    }
                }
            }

            MessageBox.Show("Marca atualizada com sucesso");
            cn.Close();
            return true;
        }

        private bool UpdateFornecedor(Fornecedor fornecedor, Fornecedor currentFornecedor)
        {
            if (!verifyConnection())
                return false;

            using (SqlCommand cmd = new SqlCommand("UPDATE Fornecedor SET telefone = @telefone, rua = @rua, codigo_postal = @codigo_postal, localidade = @localidade WHERE id_fornecedor = @id_fornecedor", cn))
            {
                try
                {
                    cmd.Parameters.Add(new SqlParameter("@telefone", SqlDbType.VarChar, 20) { Value = fornecedor.Telefone });
                    cmd.Parameters.Add(new SqlParameter("@rua", SqlDbType.VarChar, 100) { Value = fornecedor.Rua });
                    cmd.Parameters.Add(new SqlParameter("@codigo_postal", SqlDbType.VarChar, 10) { Value = fornecedor.Codigo_Postal });
                    cmd.Parameters.Add(new SqlParameter("@localidade", SqlDbType.VarChar, 100) { Value = fornecedor.Localidade });
                    cmd.Parameters.Add(new SqlParameter("@id_fornecedor", SqlDbType.Int) { Value = currentFornecedor.ID });

                    cmd.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Erro ao atualizar fornecedor na base de dados: " + exc.Message);
                    cn.Close();
                    return false;
                }
            }
            MessageBox.Show("Fornecedor atualizado com sucesso");
            cn.Close();
            return true;
        }

        private bool RemovePessoa(Pessoa currentPessoa)
        {
            if (!verifyConnection())
                return false;

            using (SqlCommand cmd = new SqlCommand("DELETE FROM Pessoa WHERE nif = @Nif", cn))
            {
                try
                {
                    cmd.Parameters.Add(new SqlParameter("@Nif", SqlDbType.Decimal) { Value = currentPessoa.Nif });
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Erro ao eliminar esta pessoa| " + exc.Message);
                    cn.Close();
                    return false;
                }
            }
            MessageBox.Show("Pessoa eliminada com sucesso");
            cn.Close();
            return true;
        }

        private bool RemoveLoja(Loja currentLoja)
        {
            if (!verifyConnection())
                return false;
            
            using (SqlCommand cmd =  new SqlCommand("DELETE FROM Loja WHERE id_loja = @loja_id", cn))
            {
                try
                {
                    cmd.Parameters.Add(new SqlParameter("@loja_id", SqlDbType.Int) { Value = currentLoja.ID });
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Erro ao eliminar esta loja| " + exc.Message);
                    cn.Close();
                    return false;
                }
            }
            MessageBox.Show("Loja eliminada com sucesso");
            cn.Close();
            return true;
        }

        private bool RemoveProduto(Produto currentProduto)
        {
            if (!verifyConnection())
                return false;

            if (filterProdutoByLoja <= 0)
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Produto WHERE id_produto = @id_produto", cn))
                {
                    try
                    {
                        cmd.Parameters.Add(new SqlParameter("@id_produto", SqlDbType.Int) { Value = currentProduto.ID });
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Erro ao eliminar este produto| " + exc.Message);
                        cn.Close();
                        return false;
                    }
                }
            }
            else 
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Stock_Loja WHERE loja = @loja AND produto = @produto", cn))
                {

                    try
                    {
                        cmd.Parameters.Add(new SqlParameter("@loja", SqlDbType.Int) { Value = filterProdutoByLoja });
                        cmd.Parameters.Add(new SqlParameter("@produto", SqlDbType.Int) { Value = currentProduto.ID });
                        cmd.ExecuteNonQuery();
                    }

                    catch (Exception exc)
                    {
                        MessageBox.Show("Erro ao eliminar este produto desta loja| " + exc.Message);
                        cn.Close();
                        return false;
                    }
                }

            }
            MessageBox.Show("Produto eliminado com sucesso");
            cn.Close();
            return true;
        }

        private bool RemoveMarca(Marca currentMarca)
        {
            if (!verifyConnection())
                return false;

            using (SqlCommand cmd = new SqlCommand("DELETE FROM Patente WHERE id_patente = @patente", cn))
            {
                try
                {
                    cmd.Parameters.Add(new SqlParameter("@patente", SqlDbType.Int) { Value = currentMarca.ID });
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Erro ao eliminar esta marca| " + exc.Message);
                    cn.Close();
                    return false;
                }
            }
            MessageBox.Show("Marca eliminada com sucesso");
            cn.Close();
            return true;
        }

        private bool RemoveFornecedor(Fornecedor currentFornecedor)
        {
            if (!verifyConnection())
                return false;

            using (SqlCommand cmd = new SqlCommand("DELETE FROM Fornecedor WHERE id_fornecedor = @id_fornecedor", cn))
            {
                try
                {
                    cmd.Parameters.Add(new SqlParameter("@id_fornecedor", SqlDbType.Int) { Value = currentFornecedor.ID });
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Erro ao eliminar este fornecedor| " + exc.Message);
                    cn.Close();
                    return false;
                }
            }
            MessageBox.Show("Fornecedor eliminado com sucesso");
            cn.Close();
            return true;
        }

        private void showPartTimeSpecifics()
        {
            horasTxtPessoa.Enabled = true;
            horasTxtPessoa.Visible = true;
            horasLabelPessoa.Visible = true;
            horasLabelPessoa.Enabled = true;
            lojaTxtPessoa.Visible = true;
            lojaTxtPessoa.Enabled = true;
            lojaLabelPessoa.Visible = true;
            lojaLabelPessoa.Enabled = true;
        }

        private void showEfetivoSpecifics()
        {
            lojaTxtPessoa.Visible = true;
            lojaTxtPessoa.Enabled = true;
            lojaLabelPessoa.Visible = true;
            lojaLabelPessoa.Enabled = true;
            contratoLabelPessoa.Visible = true;
            contratoLabelPessoa.Enabled = true;
            inicioContratoLabel.Visible = true;
            inicioContratoLabel.Enabled = true;
            inicioContratoTxt.Visible = true;
            inicioContratoTxt.Enabled = true;
            fimContratoLabel.Visible = true;
            fimContratoLabel.Enabled = true;
            fimContratoTxt.Visible = true;
            fimContratoTxt.Enabled = true;

        }

        private void showDiretorSpecifics()
        {
            // Can't be done
        }
        private bool doesLojaExist(int lojaid)
        {
            if (!verifyConnection())
                return false;
            SqlCommand cmd = new SqlCommand("SELECT * FROM Loja WHERE id_loja = @lojaId", cn);
            cmd.Parameters.Add(new SqlParameter("@lojaId", SqlDbType.Int) { Value = lojaid });
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                MessageBox.Show("Loja não existe");
                cn.Close();
                return false;
            }
            cn.Close();
            return true;
        }

        private void loadPessoas(String filtro)
        {
            if (!verifyConnection())
                return;
            
            salariomedioPessoaDiretoresLabel.Text = "0";
            salariomedioPessoaEfetivosLabel.Text = "0";
            salariomedioPessoaPartTimesLabel.Text = "0";


            SqlCommand cmd = new SqlCommand("SearchPessoa", cn);

            cmd.CommandType = CommandType.StoredProcedure;
            // Adiciona os parametros das caixas de texto da pesquisa
            cmd.Parameters.Add(new SqlParameter("@nome_pessoa", SqlDbType.VarChar, 100) { Value = searchNomePessoaTxt.Text == "" ? DBNull.Value : (object)searchNomePessoaTxt.Text });

            cmd.Parameters.Add(new SqlParameter("@id_loja", SqlDbType.Int) { Value = searchLojaPessoaTxt.Text == "" ? DBNull.Value : (object)searchLojaPessoaTxt.Text });
            cmd.Parameters.Add(new SqlParameter("@tipo", SqlDbType.VarChar, 100) { Value = filtro == "" ? DBNull.Value : (object)filtro });

            if (searchLojaPessoaTxt.Text == "")
            {
                // Se não houver loja pode ser null
                cmd.Parameters.Add(new SqlParameter("@nome_subempresa", SqlDbType.VarChar, 100) { Value = searchSubempresaPessoaTxt.Text == ""? DBNull.Value : (object)searchSubempresaPessoaTxt.Text });

            }
            else
            {
                // Se houver loja é obrigatório ter ''
                cmd.Parameters.Add(new SqlParameter("@nome_subempresa", SqlDbType.VarChar, 100) { Value = (object)("")});
            }
        

            SqlDataReader reader = cmd.ExecuteReader();
            PessoasList.Items.Clear();

            while (reader.Read())
            {
                Pessoa pessoa = new Pessoa();
                pessoa.Nif = reader["nif"].ToString();
                pessoa.Nome = reader["nome"].ToString();
                pessoa.Email = reader["email"].ToString();
                pessoa.Sexo = reader["sexo"].ToString();
                pessoa.Telefone = reader["telefone"].ToString();
                pessoa.Rua = reader["rua"].ToString();
                pessoa.Codigo_Postal = reader["codigo_postal"].ToString();
                pessoa.Localidade = reader["localidade"].ToString();
                pessoa.Salario = reader["salario"].ToString();
                pessoa.Tipo = reader["tipo"].ToString();
                PessoasList.Items.Add(pessoa);
                double salarioMedioDiretores;
                if (double.TryParse(reader["Salario_Medio"].ToString(), out salarioMedioDiretores) && reader["tipo"].ToString() == "Diretor")
                {
                    salariomedioPessoaDiretoresLabel.Text = salarioMedioDiretores.ToString("0.00");
                }
                double salarioMedioEfetivos;
                if (double.TryParse(reader["Salario_Medio"].ToString(), out salarioMedioEfetivos) && reader["tipo"].ToString() == "Efetivo")
                {

                    salariomedioPessoaEfetivosLabel.Text = salarioMedioEfetivos.ToString("0.00");
                }
                double salarioMedioPartTimes;
                if (double.TryParse(reader["Salario_Medio"].ToString(), out salarioMedioPartTimes) && reader["tipo"].ToString() == "Part-Time")
                {
                    salariomedioPessoaPartTimesLabel.Text = salarioMedioPartTimes.ToString("0.00");
                }
            }


            cn.Close();
            // Se nao houverem items na lista
            if (PessoasList.Items.Count == 0)
            {
                MessageBox.Show("Não há pessoas resultado desta pesquisa");
                return;
            }
            currentPessoaIndex = 0;
            currentPessoa = (Pessoa)PessoasList.Items[currentPessoaIndex];
            ShowPessoa();
        }

        private void loadLojas(String subempresaName)
        {
            if (!verifyConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Loja JOIN SubEmpresa ON Loja.subempresa = SubEmpresa.id WHERE SubEmpresa.nome LIKE @subempresaName", cn);
            cmd.Parameters.Add(new SqlParameter("@subempresaName", SqlDbType.VarChar, 100) { Value = "%" + subempresaName + "%" });
            SqlDataReader reader = cmd.ExecuteReader();
            LojasList.Items.Clear();

            while (reader.Read())
            {
                Loja loja = new Loja();
                loja.ID = reader["id_loja"].ToString();
                loja.SubempresaNome = reader["nome"].ToString();
                loja.Telefone = reader["telefone"].ToString();
                loja.Rua = reader["rua"].ToString();
                loja.Codigo_postal = reader["codigo_postal"].ToString();
                loja.Localidade = reader["localidade"].ToString();
                loja.Gerente = reader["gerente"].ToString();
                loja.SubempresaID = reader["subempresa"].ToString();
                LojasList.Items.Add(loja);
            }
            cn.Close();
            // Se nao houverem items na lista
            if (LojasList.Items.Count == 0)
            {
                MessageBox.Show("Não há lojas resultado desta pesquisa");
                return;
            }

            currentLojaIndex = 0;
            currentLoja = (Loja)LojasList.Items[currentLojaIndex];
            ShowLoja();
        }

        public void loadProdutos(int lojaId)
        {
            if (!verifyConnection())
                return;
    
            SqlCommand cmd = new SqlCommand("SearchProduto", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id_loja", SqlDbType.Int) { Value = lojaId == 0 ? DBNull.Value : (object)lojaId });
            cmd.Parameters.Add(new SqlParameter("@marcaNome", SqlDbType.VarChar, 100) { Value = marcaSearchTxtProduto.Text == "" ? DBNull.Value : (object)marcaSearchTxtProduto.Text });
            cmd.Parameters.Add(new SqlParameter("@nomeProduto", SqlDbType.VarChar, 100) { Value = produtoNomeSearchTxt.Text == "" ? DBNull.Value :(object)produtoNomeSearchTxt.Text });
            cmd.Parameters.Add(new SqlParameter("@quantidadeMin", SqlDbType.Int) { Value = minStockProdutoSearchTxt.Text == "" ? 0 : Convert.ToInt32(minStockProdutoSearchTxt.Text)});
 
            SqlDataReader reader = cmd.ExecuteReader();
            ProdutosList.Items.Clear();

            // Ler os dados
            while (reader.Read())
            {
                Produto produto = new Produto();
                produto.ID = reader["id_produto"].ToString();
                produto.Nome = reader["nome"].ToString();
                produto.MarcaNome = reader["marcaNome"].ToString();
                produto.Preco = reader["preco"].ToString();

                if (lojaId > 0)
                {
                    produto.QuantidadeLoja = (int)reader["quantidade"];
                }
                produto.QuantidadeTotal = (int)reader["quantidade_total"];
                produto.MarcaId = reader["marca"].ToString();
                ProdutosList.Items.Add(produto);
            }
           
            cn.Close();
            // Se nao houverem items na lista
            if (ProdutosList.Items.Count == 0)
            {
                MessageBox.Show("Não há produtos resultado desta pesquisa");
                return;
            }
            currentProdutoIndex = 0;
            currentProduto = (Produto)ProdutosList.Items[currentProdutoIndex];
            ShowProduto();
        }

        public void loadMarcas()
        {
            if (!verifyConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM marca JOIN patente ON patente.id_patente = marca.patente", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            MarcasList.Items.Clear();
           

            while (reader.Read())
            {
                Marca marca = new Marca();
                marca.ID = reader["patente"].ToString();
                marca.Nome = reader["marcaNome"].ToString();
                marca.Data_inicio = reader.GetDateTime(reader.GetOrdinal("data_registo")).ToString();
                marca.Data_vencimento = reader.GetDateTime(reader.GetOrdinal("data_vencimento")).ToString();
                MarcasList.Items.Add(marca);
            }
            cn.Close();
            // Se nao houverem items na lista
            if (MarcasList.Items.Count == 0)
            {
                MessageBox.Show("Não há marcas na base de dados");
                return;
            }
            currentMarcaIndex = 0;
            currentMarca = (Marca)MarcasList.Items[currentMarcaIndex];
            ShowMarca();

        }

        public void loadFornecedores()
        {
            if (!verifyConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Fornecedor", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            FornecedoresList.Items.Clear();

            while (reader.Read())
            {
                Fornecedor fornecedor = new Fornecedor();
                fornecedor.ID = reader["id_fornecedor"].ToString();
                fornecedor.Telefone = reader["telefone"].ToString();
                fornecedor.Rua = reader["rua"].ToString();
                fornecedor.Codigo_Postal = reader["codigo_postal"].ToString();
                fornecedor.Localidade = reader["localidade"].ToString();
                FornecedoresList.Items.Add(fornecedor);
            }
            cn.Close();
            // Se nao houverem items na lista
            if (FornecedoresList.Items.Count == 0)
            {
                MessageBox.Show("Não há fornecedores na base de dados");
                return;
            }
            currentFornecedorIndex = 0;
            currentFornecedor = (Fornecedor)FornecedoresList.Items[currentFornecedorIndex];
            ShowFornecedor();
        }

        private void fimContratoTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void nomeTxtProduto_TextChanged(object sender, EventArgs e)
        {

        }

        private void NomeLabelProduto_Click(object sender, EventArgs e)
        {

        }

        private void marcastTab_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataRegistoTxtMarca_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataVencimentoTxtMarca_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
