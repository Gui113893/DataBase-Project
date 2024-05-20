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

namespace CompanyBrandManager
{
    public partial class DistributeForm : Form
    {
        private Produto currentProduto;
        private SqlConnection cn;
        public DistributeForm(Produto currentProduto)
        {
            InitializeComponent();
            cn = getSqlConnection();
            this.currentProduto = currentProduto;
            this.Enabled = true;
        }

        private void DistributeForm_Load(object sender, EventArgs e)
        {
            cn = getSqlConnection();
            this.Enabled = true;
        }

        private SqlConnection getSqlConnection()
        {
            return new SqlConnection("Data Source = localhost; Initial Catalog = CompanyBrandManager; integrated security=true");
        }

        private bool verifyConnection()
        {
            if (cn == null)
                cn = getSqlConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!verifyConnection())
                return;
            // Se o campo da loja está vazio avisa
            if (lojaTxtDistribute.Text == "")
            {
                MessageBox.Show("Loja não pode estar vazia");
                return;
            }

            // Se o campo da quantidade está vazio avisa
            if (quantidadeDistributeTxt.Text == "")
            {
                MessageBox.Show("Quantidade não pode estar vazia");
                return;
            }

            // Se a loja não existe avisa
            if (!doesLojaExist(int.Parse(lojaTxtDistribute.Text)))
            {
                MessageBox.Show("Loja não existe");
                return;
            }

            // Se a quantidade não é um número
            if (!int.TryParse(quantidadeDistributeTxt.Text, out int n))
            {
                MessageBox.Show("Quantidade tem de ser um número");
                return;
            }

            int lojaId = int.Parse(lojaTxtDistribute.Text);
            int quantidade = int.Parse(quantidadeDistributeTxt.Text);
            String command = "";

            // Se a loja não tem o produto em stock
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Stock_Loja WHERE loja = @lojaId AND produto = @produtoId", cn))
            {
                cn.Open();
                cmd.Parameters.Add(new SqlParameter("@lojaId", SqlDbType.Int) { Value = lojaId });
                cmd.Parameters.Add(new SqlParameter("@produtoId", SqlDbType.Int) { Value = currentProduto.ID });
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    command = "INSERT INTO Stock_Loja (loja, produto, quantidade) VALUES (@lojaId, @produtoId, @quantidade);";
                }
                else
                {
                    command = "UPDATE Stock_Loja SET quantidade = quantidade + @quantidade WHERE loja = @lojaId AND produto = @produtoId;";
                }
                cn.Close();
            }

            using (SqlCommand cmd = new SqlCommand(command, cn))
            {
                // Tenta dar update á quantidade em Stock_Loja
                try
                {
                    cn.Open();
                    cmd.Parameters.Add(new SqlParameter("@quantidade", SqlDbType.Int) { Value = quantidade });
                    cmd.Parameters.Add(new SqlParameter("@lojaId", SqlDbType.Int) { Value = lojaId });
                    cmd.Parameters.Add(new SqlParameter("@produtoId", SqlDbType.Int) { Value = currentProduto.ID });
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao distribuir produto: " + ex.Message);
                    cn.Close();
                    return;
                }
            }
            MessageBox.Show("Distribuição feita com sucesso");
            cn.Close();
            this.Hide();
            this.Enabled = false;
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
    }
}
