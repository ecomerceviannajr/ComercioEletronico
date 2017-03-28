using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComercioEletronico.Models
{
    public class Produtora
    {
        public int Id { set; get; }
        public string Nome { set; get; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}