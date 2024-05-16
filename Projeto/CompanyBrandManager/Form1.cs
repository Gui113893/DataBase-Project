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
    }
}
