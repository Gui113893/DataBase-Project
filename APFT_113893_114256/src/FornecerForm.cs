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
    public partial class FornecerForm : Form
    {
        private Fornecedor currentFornecedor;
        private SqlConnection cn;
        public FornecerForm(Fornecedor currentFornecedor)
        {
            InitializeComponent();
            cn = getSqlConnection();
            this.currentFornecedor = currentFornecedor;
        }

        private void FornecerForm_Load(object sender, EventArgs e)
        {
            cn = getSqlConnection();
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!verifyConnection())
                return;
            // Se o campo da produto está vazio avisa
            if (produtoTxtFornecer.Text == "")
            {
                MessageBox.Show("Produto não pode estar vazio");
                return;
            }

            // Se o campo da quantidade está vazio avisa
            if (quantidadeFornecerTxt.Text == "")
            {
                MessageBox.Show("Quantidade não pode estar vazia");
                return;
            }

            // Se o produto não existe avisa
            if (!doesProdutoExist(int.Parse(produtoTxtFornecer.Text)))
            {
                MessageBox.Show("Produto não existe");
                return;
            }
            cn.Close();

            // Se a quantidade é negativa avisa
            if (int.Parse(quantidadeFornecerTxt.Text) < 0)
            {
                MessageBox.Show("Quantidade não pode ser negativa");
                return;
            }

            // Se a quantidade não é um número avisa
            if (!int.TryParse(quantidadeFornecerTxt.Text, out _))
            {
                MessageBox.Show("Quantidade tem de ser um número");
                return;
            }

            int produtoId = int.Parse(produtoTxtFornecer.Text);
            int quantidade = int.Parse(quantidadeFornecerTxt.Text);

            String command = "";
            cn.Open();
            // Ver se existe o par produto-fornecedor em Stock_Fornecido
            if (!doesProdutoFornecedorExist(produtoId, currentFornecedor.ID))
            {
                command = "INSERT INTO Stock_Fornecido VALUES (@fornecedorId, @produtoId, @quantidade)";
            }
            else
            {
                command = "UPDATE Stock_Fornecido SET quantidade = quantidade + @quantidade WHERE produto = @produtoId AND fornecedor = @fornecedorId";
            }
            cn.Close();

            // Executa o comando
            using (SqlCommand cmd = new SqlCommand(command, cn))
            {
                // Tenta inserir quantidade
                try
                {
                    cn.Open();
                    cmd.Parameters.AddWithValue("@produtoId", produtoId);
                    cmd.Parameters.AddWithValue("@fornecedorId", currentFornecedor.ID);
                    cmd.Parameters.AddWithValue("@quantidade", quantidade);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao inserir quantidade: " + ex.Message);
                    return;
                }
            }
            MessageBox.Show("Quantidade fornecida com sucesso");
            cn.Close();
            this.Hide();
        }

        private bool doesProdutoExist(int id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Produto WHERE id_produto = @id", cn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader.HasRows;
        }

        private bool doesProdutoFornecedorExist(int produtoId, String fornecedorId)
        {
            SqlCommand cmd2 = new SqlCommand("SELECT * FROM Stock_Fornecido WHERE produto = @produtoId AND fornecedor = @fornecedorId", cn);
            cmd2.Parameters.AddWithValue("@produtoId", produtoId);
            cmd2.Parameters.AddWithValue("@fornecedorId", fornecedorId);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            return reader2.HasRows;
        }
    }
}
