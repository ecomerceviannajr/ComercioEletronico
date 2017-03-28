using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComercioEletronico.Models
{
    public class Usuario
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataNasc { get; set; }
        public string Identidade { get; set; }
        public string Senha { get; set; }
        public List<Endereco> Enderecos { get; set; }
    }
}