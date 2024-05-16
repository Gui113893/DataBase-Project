using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyBrandManager
{
    [Serializable()]
    public class Pessoa
    {
        private String _nif;
        private String _nome;
        private String _email;
        private String _sexo;
        private String _telefone;
        private String _rua;
        private String _codigo_postal;
        private String _localidade;
        private String _salario;

        public String Nif
        {
            get { return _nif; }
            set 
            { 
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Campo NIF não pode estar vazio");
                    return;
                }
                _nif = value;
            }
        }

        public String Nome
        {
            get { return _nome; }
            set 
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Campo Nome não pode estar vazio");
                    return;
                }    
                _nome = value;
            }
        }

        public String Email
        {
            get { return _email; }
            set { _email = value; }
        }


        public String Sexo
        {
            get { return _sexo; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Campo Sexo não pode estar vazio");
                    return;
                }
                _sexo = value;
                
            }
        }

        public String Telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }

        public String Rua
        {
            get { return _rua; }
            set { _rua = value; }
        }

        public String Codigo_Postal
        {
            get { return _codigo_postal; }
            set { _codigo_postal = value; }
        }

        public String Localidade
        {
            get { return _localidade; }
            set { _localidade = value; }
        }

        public String Salario
        {
            get { return _salario; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Campo Salário não pode estar vazio");
                    return;
                }
                _salario = value;
            }
        }

        public Pessoa(String nif, String nome, String email, String sexo, String telefone, String rua, String codigo_postal, String localidade, String _salario) : base()
        {
            Nif = nif;
            Nome = nome;
            Email = email;
            Sexo = sexo;
            Telefone = telefone;
            Rua = rua;
            Codigo_Postal = codigo_postal;
            Localidade = localidade;
            Salario = _salario;
        }

        public Pessoa() : base()
        {
        }

        public override string ToString()
        {
            string result = "NIF: " + Nif;
            result += (Nif != null ? " " : "");
            result += "Nome: " + Nome;
            result += (Nome != null ? " " : "");
            result += "Email: " + Email;
            result += (Email != null ? " " : "");
            result += "Sexo: " + Sexo;
            result += (Sexo != null ? " " : "");
            result += "Telefone: " + Telefone;
            result += (Telefone != null ? " " : "");
            result += "Rua: " + Rua;
            result += (Rua != null ? " " : "");
            result += "Codigo Postal: " + Codigo_Postal;
            result += (Codigo_Postal != null ? " " : "");
            result += "\nLocalidade: " + Localidade;
            result += (Localidade != null ? " " : "");
            result += "\nSalário: " + Salario;
            return result;
        }
    }
}
