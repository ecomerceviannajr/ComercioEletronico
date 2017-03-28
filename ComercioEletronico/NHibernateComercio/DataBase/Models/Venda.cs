
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateComercio.DataBase.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public Carrinho Carrinho { get; set; }
        public DateTime Data { get; set; }
        public FormasPagamento Forma_Pagamento { get; set; }
        public string Numero_Cartao { get; set; }
        public string Nome_Cartao { get; set; }
        public string Tipo_Cartao { get; set; }
        public string Num_Cartao { get; set; }
        public string Vencimento_Cartao { get; set; }
        public string Status { get; set; }
    }
}