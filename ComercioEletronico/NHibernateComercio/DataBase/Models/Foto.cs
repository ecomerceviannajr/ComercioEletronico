using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateComercio.DataBase.Models
{
    public class Foto
    {
        public virtual int Id { get; set; }
        public virtual int IdProduto { get; set; }
        public virtual string FileName { get; set; }
        public virtual Produto Produto { get; set; }
    }

    public class FotoMap : ClassMapping<Foto>
    {
        public FotoMap()
        {
            Property<int>(x => x.Id);
            Property<int>(x => x.IdProduto);
            Property<string>(x => x.FileName);
            ManyToOne(x => x.Produto, m => {
                m.Column("idProduto");
                m.Lazy(LazyRelation.NoLazy);
            });
        }
    }
}
