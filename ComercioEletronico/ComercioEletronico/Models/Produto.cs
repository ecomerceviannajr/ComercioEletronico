using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComercioEletronico.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public DateTime DataLancamento { get; set; }
        public string Categoria { get; set; }
        public int IdProdutora { get; set; }
    }
}