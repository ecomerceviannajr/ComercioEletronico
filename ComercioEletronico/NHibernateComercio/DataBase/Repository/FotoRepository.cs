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
    public class FotoRepository : RepositoryBase<Foto>
    {
        public FotoRepository(ISession session) : base(session)
        {
        }

        public Foto FindById(int id)
        {
            return this.Session.Query<Foto>().FirstOrDefault(f => f.Id == id);
        }
    }
}
