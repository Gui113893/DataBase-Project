using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyBrandManager
{
    [Serializable()]
    public class Loja
    {
        private String _id;
        private String _telefone;
        private String _rua;
        private String _codigo_postal;
        private String _localidade;
        private String _subempresaID;
        private String _subempresaNome;
        private String _gerente;

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

        public String Codigo_postal
        {
            get { return _codigo_postal; }
            set 
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Campo Codigo Postal não pode estar vazio");
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

        public String SubempresaID
        {
            get { return _subempresaID; }
            set 
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Campo SubempresaID não pode estar vazio");
                    return;
                }
                _subempresaID = value;
            }
        }

        public String SubempresaNome
        {
            get { return _subempresaNome; }
            set { _subempresaNome = value; }
        }

        public String Gerente
        {
            get { return _gerente; }
            set { _gerente = value; }
        }

        public Loja() : base()
        {
        }

        public override string ToString()
        {
            return ID + " - " + SubempresaNome + " ( " + SubempresaID + " ) - " + Telefone + " - " + Localidade;
        } 


    }
}
