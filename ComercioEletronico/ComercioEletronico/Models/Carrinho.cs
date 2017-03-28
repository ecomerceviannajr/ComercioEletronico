using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComercioEletronico.Models
{
    public class Carrinho
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public double ValorTotal { get; set; }
    }
}