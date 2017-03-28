using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateComercio.DataBase.Models
{
    public class NotaFiscal
    {
        public int Id { get; set; }
        public Venda Venda { get; set; }
        public int Quantidade { get; set; }
        public double Valor_Unitario { get; set; }
        public double Total { get; set; }
    }
}