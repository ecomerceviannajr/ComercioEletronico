using NHibernate;
using NHibernate.Linq;
using NHibernateComercio.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateComercio.DataBase.Repository
{
    public class ProdutoRepository : RepositoryBase<Produto>
    {
        public ProdutoRepository(ISession session) : base(session)
        {
        }

        public Produto FindById(int id)
        {
            return this.Session.Query<Produto>().FirstOrDefault(p => p.Id == id);
        }

        public IList<Produto> FindByNome(string nome)
        {
            return this.Session.Query<Produto>().Where(p => p.Nome.Contains(nome)).ToList();
        }
        public IList<Produto> FindByIdProdutora(int idprodutora)
        {
            return this.Session.Query<Produto>().Where(p => p.Produtora.Id == idprodutora).ToList();
        }
    }
}
