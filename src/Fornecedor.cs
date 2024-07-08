using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyBrandManager
{
    [Serializable()]
    public class Fornecedor
    {
        private String _id;
        private String _telefone;
        private String _rua;
        private String _codigo_postal;
        private String _localidade;

        public String ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public String Telefone
        {
            get { return _telefone; }
            set 
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Campo Telefone não pode estar vazio");
                    return;
                }
                _telefone = value;
            }
        }

        public String Rua
        {
            get { return _rua; }
            set 
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Campo Rua não pode estar vazio");
                    return;
                }
                _rua = value;
            }
        }

        public String Codigo_Postal
        {
            get { return _codigo_postal; }
            set 
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Campo Código Postal não pode estar vazio");
                    return;
                }
                _codigo_postal = value;
            }
        }

        public String Localidade
        {
            get { return _localidade; }
            set 
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Campo Localidade não pode estar vazio");
                    return;
                }
                _localidade = value;
            }
        }

        public Fornecedor() : base()
        {
        }

        public override string ToString()
        {
            return _id + " - " + _telefone + " - " + _localidade;
        }
    }
}
