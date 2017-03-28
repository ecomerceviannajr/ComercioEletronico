using NHibernateComercio.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;

namespace NHibernateComercio.DataBase.Repository
{
    public class ProdutoraRepository : RepositoryBase<Produtora>
    {
        public ProdutoraRepository(ISession session) : base(session)
        {
        }
        public Produtora FindById(int id)
        {
            return this.Session.Query<Produtora>().FirstOrDefault(f => f.Id == id);
        }
    }
}
