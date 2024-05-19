using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyBrandManager
{
    [Serializable()]
    public class Produto
    {
        private String _id;
        private String _preco;
        private String _nome;
        private String _marcaId;
        private String _marcaNome;
        private int _quantidadeTotal;
        private int _quantidadeLoja;

        public String ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public String Preco
        {
            get { return _preco; }
            set 
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Campo Preço não pode estar vazio");
                    return;
                }
                _preco = value;
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

        public String MarcaId
        {
            get { return _marcaId; }
            set 
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Campo Marca não pode estar vazio");
                    return;
                }
                _marcaId = value;
            }
        }

        public String MarcaNome
        {
            get { return _marcaNome; }
            set { _marcaNome = value; }
        }

        public int QuantidadeTotal
        {
            get { return _quantidadeTotal; }
            set { _quantidadeTotal = value; }
        }

        public int QuantidadeLoja
        {
            get { return _quantidadeLoja; }
            set { _quantidadeLoja = value; }
        }

        public Produto() : base()
        {
        }
        
        public override string ToString()
        {
            return ID + " - " + Nome + " - " + MarcaNome + " - " + Preco + "€";
        }
    }
}
