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

        private Pessoa currentPessoa;
        private bool adding;
        public Form1()
        {
            InitializeComponent();
            cn = getSqlConnection();
            if (!verifyConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Pessoa", cn);
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

        // Event Funcs
        private void PessoasList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PessoasList.SelectedIndex >= 0)
            {
                currentPessoaIndex = PessoasList.SelectedIndex;
                currentPessoa = (Pessoa)PessoasList.Items[currentPessoaIndex];
                ShowPessoa();
            }
        }

        private void EditButtonPessoa_Click(object sender, EventArgs e)
        {
            currentPessoaIndex = PessoasList.SelectedIndex;
            if (currentPessoaIndex < 0)
            {
                MessageBox.Show("Seleciona um contacto para editar");
                return;
            } 
            adding = false;
            PessoasList.Enabled = false;
            SavePessoa(adding, currentPessoa, "");
            PessoasList.Enabled = true;
        }

        private void AddButtonPessoa_Click(object sender, EventArgs e)
        {
            adding = true;
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
            SavePessoa(adding, currentPessoa, tipo);
            PessoasList.Enabled = true;

        }

        private void AddToolStripPessoa_Click(object sender, EventArgs e)
        {
            ClearPessoaFields();
            HideSpecifics();
        }

        private void AddPartTime_Click(object sender, EventArgs e)
        {
            showPartTimeSpecifics();
        }

        private void AddEfetivo_Click(object sender, EventArgs e)
        {
            showEfetivoSpecifics();
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

        private bool SavePessoa(bool adding, Pessoa currentPessoa, String tipo)
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
            if (!adding)
            {
                UpdatePessoa(pessoa, currentPessoa);
                PessoasList.Items[currentPessoaIndex] = pessoa;
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

        private void UpdatePessoa(Pessoa pessoa, Pessoa anteriorPessoa)
        {
            if (!verifyConnection())
                return;
            
            int rows = 0;

            SqlCommand cmd = new SqlCommand("UPDATE Pessoa SET nif = @nif, nome = @nome, email = @email, sexo = @sexo, telefone = @telefone, rua = @rua, codigo_postal = @codigo_postal, localidade = @localidade, salario = @salario WHERE nif = @nif", cn);
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
            cmd.Connection = cn;

            try
            {
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                throw new Exception("Erro ao atualizar pessoa na base de dados: " + exc.Message);
            }
            finally
            {
                if (rows == 1)
                    MessageBox.Show("Pessoa atualizada com sucesso");
                else
                    MessageBox.Show("Erro ao atualizar pessoa");
                cn.Close();
            }
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
    }
}
