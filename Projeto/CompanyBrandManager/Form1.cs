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
        private int currentPessoa;
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
                PessoasList.Items.Add(pessoa);
            }
            cn.Close();
            currentPessoa = 0;
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
            if (PessoasList.SelectedIndex > 0)
            {
                currentPessoa = PessoasList.SelectedIndex;
                ShowPessoa();
            }
        }

        private void EditButtonPessoa_Click(object sender, EventArgs e)
        {
            currentPessoa = PessoasList.SelectedIndex;
            if (currentPessoa < 0)
            {
                MessageBox.Show("Seleciona um contacto para editar");
                return;
            }
            adding = false;
            PessoasList.Enabled = false;
            SavePessoa(adding);
            PessoasList.Enabled = true;
        }


        // Aux Funcs
        public void ShowPessoa()
        {
            if (PessoasList.Items.Count == 0 | currentPessoa < 0)
                return;
            Pessoa pessoa = new Pessoa();
            pessoa = (Pessoa)PessoasList.Items[currentPessoa];
            nifTxtPessoa.Text = pessoa.Nif;
            nomeTxtPessoa.Text = pessoa.Nome;
            emailTxtPessoa.Text = pessoa.Email;
            sexoTxtPessoa.Text = pessoa.Sexo;
            telefoneTxtPessoa.Text = pessoa.Telefone;
            ruaTxtPessoa.Text = pessoa.Rua;
            codpostalTxtPessoa.Text = pessoa.Codigo_Postal;
            localidadeTxtPessoa.Text = pessoa.Localidade;
            salarioTxtPessoa.Text = pessoa.Salario;
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
        }

        private bool SavePessoa(bool adding)
        {
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
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return false;
            }
            if (!adding)
            {
                UpdatePessoa(pessoa);
                PessoasList.Items[currentPessoa] = pessoa;
            }
            // else
            // {
            //     PessoasList.Items.Add(pessoa);
            //     currentPessoa = PessoasList.Items.Count - 1;
            //     PessoasList.SelectedIndex = currentPessoa;
            // }
            return true;
        }

        private void UpdatePessoa(Pessoa pessoa)
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
    }
}
