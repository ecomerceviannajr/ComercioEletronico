using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComercioEletronico.Models
{
    public class ProdutoCarrinho
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public double ValorParcial { get; set; }
        public Carrinho Carrinho { get; set; }
    }
}