using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyBrandManager
{
    [Serializable()]
    public class Funcionario : Pessoa
    {
        private String _tipo;
        private String _id_loja;
        private String _id_contrato;

        public String Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public String IdLoja
        {
            get { return _id_loja; }
            set { _id_loja = value; }
        }

        public String IdContrato
        {
            get { return _id_contrato; }
            set { _id_contrato = value; }
        }

        public Funcionario()
        {
            _tipo = "";
            _id_loja = "";
            _id_contrato = "";
        }

        public Funcionario(String nif, String nome, String email, String sexo, String telefone, String rua, String codigo_postal, String localidade, String salario, String tipo, String id_loja, String id_contrato)
        {
            Nif = nif;
            Nome = nome;
            Email = email;
            Sexo = sexo;
            Telefone = telefone;
            Rua = rua;
            Codigo_Postal = codigo_postal;
            Localidade = localidade;
            Salario = salario;
            Tipo = tipo;
            IdLoja = id_loja;
            IdContrato = id_contrato;
        }
    }
}
