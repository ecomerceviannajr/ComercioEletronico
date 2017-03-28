using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateComercio.DataBase.Models
{
    public class Endereco
    {
        public virtual int Id { get; set; }
        public virtual string Logradouro { get; set; }
        public virtual string Complemento { get; set; }
        public virtual string Bairro { get; set; }
        public virtual string Cidade { get; set; }
        public virtual string Estado { get; set; }
        public virtual string Cep { get; set; }
        public virtual Usuario Usuario{ get; set; }
    }

    public class EnderecoMap : ClassMapping<Endereco>
    {
        public EnderecoMap()
        {
            Id<int>(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);
            });

            Property<string>(x => x.Logradouro);
            Property<string>(x => x.Complemento);
            Property<string>(x => x.Bairro);
            Property<string>(x => x.Cidade);
            Property<string>(x => x.Estado);
            Property<string>(x => x.Cep);

            ManyToOne(x => x.Usuario, m =>
            {
                m.Column("idPessoa");
                m.Lazy(LazyRelation.NoLazy);
            });
        }
    }
}