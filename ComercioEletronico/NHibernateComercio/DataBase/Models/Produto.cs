using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateComercio.DataBase.Models
{
    public class Produto
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual double Preco { get; set; }
        public virtual int DataLancamento { get; set; }
        public virtual string Categoria { get; set; }
        public virtual double Peso { get; set; }
        public virtual string Descricao { get; set; }
        public virtual Produtora Produtora { get; set; }
       
    }
    public class ProdutoMap : ClassMapping<Produto>
    {
        public ProdutoMap()
        {

            Id<int>(x => x.Id,
                     m =>
                     {
                         m.Generator(Generators.Identity);
                     });
            Property<string>(x => x.Nome);
            Property<double>(x => x.Preco);
            Property<int>(x => x.DataLancamento);
            Property<string>(x => x.Categoria);
            Property<double>(x => x.Peso);
            Property<string>(x => x.Descricao);
            Property<string>(x => x.Descricao);
            ManyToOne(x => x.Produtora, m =>
            {
                m.Column("IdProdutora");
                m.Lazy(LazyRelation.NoLazy);
            });
        }
    }
}