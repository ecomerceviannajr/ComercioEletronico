using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateComercio.DataBase.Models
{
    public class Carrinho
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public double ValorTotal { get; set; }
    }
}