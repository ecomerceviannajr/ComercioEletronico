using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateComercio.DataBase.Models
{
    public class Interesses
    {
        public virtual int Id { get; set; }
        public virtual string Interesse { get; set; }
        public virtual Usuario Usuario { get; set; }
    }

    public class InteressesMap : ClassMapping<Interesses>
    {
        public InteressesMap()
        {

            Id<int>(x => x.Id,
                     m =>
                     {
                         m.Generator(Generators.Identity);
                     });
            Property<string>(x => x.Interesse);
            ManyToOne(x => x.Usuario, m =>
            {
                m.Column("idUsuario");
                m.Lazy(LazyRelation.NoLazy);
            });
        }
    }
}
