using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NHibernateComercio.DataBase.Models
{
    public class Usuario
    {
        public virtual int Id { get; set; }
        public virtual string Cpf { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Telefone { get; set; }
        public virtual string Email { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public virtual DateTime DataNasc { get; set; }
        public virtual string Identidade { get; set; }
        public virtual string Senha { get; set; }
        public virtual string Endereco { get; set; }
        public virtual IList<Endereco> Enderecos { get; set; }
        public Usuario()
        {
            this.Enderecos = new List<Endereco>();
        }

    }
    
    public class UsuarioMap : ClassMapping<Usuario>
    {
        public UsuarioMap()
        {
            Id<int>(x => x.Id,
                    m =>
                    {
                        m.Generator(Generators.Identity);
                    });
            Property<string>(x => x.Cpf);
            Property<string>(x => x.Nome);
            Property<string>(x => x.Telefone);
            Property<string>(x => x.Email);
            Property<DateTime>(x => x.DataNasc);
            Property<string>(x => x.Identidade);
            Property<string>(x => x.Senha);

            Bag<Endereco>(x => x.Enderecos,
                m =>
                {
                    m.Cascade(Cascade.Remove);
                    m.Inverse(true); // liga com a chave extrangeira de telefone
                    m.Lazy(CollectionLazy.NoLazy);
                    m.Key(k => k.Column("IdPessoa"));
                },
                o => o.OneToMany());
        }
    }


}