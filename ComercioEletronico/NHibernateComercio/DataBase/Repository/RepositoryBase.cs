using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateComercio.DataBase.Repository
{
    public abstract class RepositoryBase<T> where T : class
    {
        public ISession Session = null;

        protected RepositoryBase(ISession session)
        {
            this.Session = session;
        }

        //buscar todos
        public virtual IList<T> FindAll()
        {
            return this.Session.CreateCriteria(typeof(T)).List<T>();
        }

        //busca o primeiro
        public virtual T FirstOrDefault()
        {
            return this.Session.Query<T>().FirstOrDefault();
        }

        //deletar
        public void Delete(T entity)
        {
            try
            {
                var transaction = this.Session.BeginTransaction();

                this.Session.Delete(entity);

                transaction.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível excluir " + typeof(T) + "\nErro: " + ex.Message);
            }
        }

        

        //Inserir e alterar
        public virtual T Save(T entity)
        {
            try
            {
                this.Session.Clear();

                var transacao = this.Session.BeginTransaction();
                this.Session.SaveOrUpdate(entity);
                transacao.Commit();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível gravar " + typeof(T) + "\nErro: " + ex.Message);
            }
        }

    }
}