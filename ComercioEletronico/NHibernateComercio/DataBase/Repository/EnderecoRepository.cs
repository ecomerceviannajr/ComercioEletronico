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
    public class EnderecoRepository : RepositoryBase<Endereco>
    {
        public EnderecoRepository(ISession session) : base(session)
        {
        }
        public Endereco FindById(int id)
        {
            return this.Session.Query<Endereco>().FirstOrDefault(f => f.Id == id);
        }
    }
}
