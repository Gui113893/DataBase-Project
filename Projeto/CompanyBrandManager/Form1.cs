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

        private Pessoa currentPessoa;
        private Loja currentLoja;
        private Produto currentProduto;
        private bool adding_pessoa;
        private bool adding_loja;
        private bool adding_produto;
        public Form1()
        {
            InitializeComponent();
            cn = getSqlConnection();
            loadPessoas("");
            loadLojas(0);
            loadProdutos(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cn = getSqlConnection();
        }

        private SqlConnection getSqlConnection()
        {
            return new SqlConnection("Data Source = localhost; Initial Catalog = CompanyBrandManager; uid=sa; password=sql123");
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
            loadPessoas("");
            loadLojas(0); 
            loadProdutos(0);  
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
                if (currentPessoaIndex == PessoasList.Items.Count)
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
                if (currentLojaIndex == LojasList.Items.Count)
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

        private void AddToolStripPessoa_Click(object sender, EventArgs e)
        {
            ClearPessoaFields();
            HideSpecifics();
        }

        private void AddToolStripLoja_Click(object sender, EventArgs e)
        {
            ClearLojaFields();
        }

        private void AddPartTime_Click(object sender, EventArgs e)
        {
            showPartTimeSpecifics();
        }

        private void AddEfetivo_Click(object sender, EventArgs e)
        {
            showEfetivoSpecifics();
        }

        private void PessoaFilterByDiretor_Click(object sender, EventArgs e)
        {
            loadPessoas("Diretor");
        }

        private void PessoaFilterByPartTime_Click(object sender, EventArgs e)
        {
            loadPessoas("Part-Time");
        }

        private void PessoaFilterByEfetivo_Click(object sender, EventArgs e)
        {
            loadPessoas("Efetivo");
        }

        private void PessoaRemoveFilter_Click(object sender, EventArgs e)
        {
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
                    loadLojas(0);
                }
                else
                return false;
            }
            else
            {
                if (AddLoja(loja))
                {
                    LojasList.Items.Add(loja);
                    loadLojas(0);
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
                        cmd.Parameters.Add(new SqlParameter("@Loja", SqlDbType.Int) { Value = lojaTxtPessoa.Text });
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
                    cmd.Parameters.Add(new SqlParameter("@gerente", SqlDbType.Decimal) { Value = loja.Gerente });
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

        private void loadPessoas(String filtro)
        {
            if (!verifyConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Pessoa", cn);
            if (filtro == "Diretor")
            {
                cmd = new SqlCommand("SELECT * FROM Pessoa JOIN Diretor ON pessoa.nif = diretor.nif", cn);
            }
            else if (filtro == "Part-Time")
            {
                cmd = new SqlCommand("SELECT * FROM Pessoa JOIN Part_Time ON pessoa.nif = part_time.nif", cn);
            }
            else if (filtro == "Efetivo")
            {
                cmd = new SqlCommand("SELECT * FROM Pessoa JOIN Efetivo ON pessoa.nif = efetivo.nif", cn);
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
            }
            cn.Close();
            currentPessoaIndex = 0;
            currentPessoa = (Pessoa)PessoasList.Items[currentPessoaIndex];
            ShowPessoa();
        }

        private void loadLojas(int subempresaId)
        {
            if (!verifyConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Loja JOIN SubEmpresa ON Loja.subempresa = Subempresa.id", cn);

            if (subempresaId > 0)
                cmd = new SqlCommand("SELECT * FROM Loja JOIN SubEmpresa ON Loja.subempresa = Subempresa.id WHERE subempresa = @subempresaId", cn);
                cmd.Parameters.Add(new SqlParameter("@subempresaId", SqlDbType.Int) { Value = subempresaId });

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
            currentLojaIndex = 0;
            currentLoja = (Loja)LojasList.Items[currentLojaIndex];
            ShowLoja();
        }

        private void loadProdutos(int lojaId)
        {
            if (!verifyConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Produto JOIN Marca ON Marca.patente = Produto.marca JOIN Stock_Fornecido ON Stock_Fornecido.produto = Produto.id_produto", cn);
            if (lojaId > 0)
            {
                cmd = new SqlCommand("SELECT * FROM Produto JOIN Stock_Loja ON Stock_Loja.produto = Produto.id_produto WHERE Stock_Loja.loja = @lojaId", cn);
                cmd.Parameters.Add(new SqlParameter("@lojaId", SqlDbType.Int) { Value = lojaId });
            }
            
            SqlDataReader reader = cmd.ExecuteReader();
            ProdutosList.Items.Clear();

            while (reader.Read())
            {
                Produto produto = new Produto();
                produto.ID = reader["id_produto"].ToString();
                produto.Nome = reader["nome"].ToString();
                produto.Preco = reader["preco"].ToString();
                produto.MarcaNome = reader["marcaNome"].ToString();
                produto.MarcaId = reader["marca"].ToString();   
                if (lojaId > 0)
                    produto.QuantidadeLoja = (int)reader["quantidade"];
                else
                    produto.QuantidadeTotal = (int)reader["quantidade"];

                ProdutosList.Items.Add(produto);
            }
            cn.Close();
            currentProdutoIndex = 0;
            currentProduto = (Produto)ProdutosList.Items[currentProdutoIndex];
            ShowProduto();
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
    }
}
