using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyBrandManager
{
    [Serializable()]
    public class Marca
    {
        private String _id;
        private String _nome;
        private String _data_inicio;
        private String _data_vencimento;

        public String ID
        {
            get { return _id; }
            set { _id = value; }
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

        public String Data_inicio
        {
            get { return _data_inicio; }
            set 
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Campo Data de Início não pode estar vazio");
                    return;
                }
                _data_inicio = value;
            }
        }

        public String Data_vencimento
        {
            get { return _data_vencimento; }
            set 
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Campo Data de Vencimento não pode estar vazio");
                    return;
                }
                _data_vencimento = value;
            }
        }

        public Marca() : base()
        {
        }

        public override string ToString()
        {
            return ID + " - " + Nome;
        }
    }
}
