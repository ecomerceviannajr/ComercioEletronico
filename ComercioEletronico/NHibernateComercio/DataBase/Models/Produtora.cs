using System;
using System.Collections.Generic;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace NHibernateComercio.DataBase.Models
{
    public class Produtora
    {
        public virtual int Id { set; get; }
        public virtual string Nome { set; get; }
        public virtual string Telefone { get; set; }
        public virtual string Email { get; set; }
        public virtual string Produto { get; set; }
        public virtual IList<Produto> Produtos { get; set; }
        public Produtora()
        {
            this.Produtos = new List<Produto>();
        }

    }

    public class ProdutoraMap : ClassMapping<Produtora>
    {
        public ProdutoraMap()
        {
            Id<int>(x => x.Id,
                   m =>
                   {
                       m.Generator(Generators.Identity);
                   });
            
            Property<string>(x => x.Nome);
            Property<string>(x => x.Telefone);
            Property<string>(x => x.Email);
            
            Bag<Produto>(x => x.Produtos,
                m =>
                {
                    m.Cascade(Cascade.Remove);
                    m.Inverse(true); // liga com a chave extrangeira de telefone
                    m.Lazy(CollectionLazy.NoLazy);
                    m.Key(k => k.Column("IdProdutora"));
                },
                o => o.OneToMany());
        }
    }
}