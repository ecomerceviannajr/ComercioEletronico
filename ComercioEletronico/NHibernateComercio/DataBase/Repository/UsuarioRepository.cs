using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Linq;
using NHibernateComercio.DataBase.Repository;
using NHibernateComercio.DataBase.Models;

namespace ComercioEletronico.DataBase.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>
    {
        public UsuarioRepository(ISession session) : base(session)
        {

        }
        public Usuario FindByEmailSenha(string Email, string Senha)
        {
            return this.Session.Query<Usuario>().FirstOrDefault(f => f.Email == Email && f.Senha == Senha);
        }
        public Usuario FindById(int id)
        {
            return this.Session.Query<Usuario>().FirstOrDefault(f => f.Id == id);
        }

    }
}