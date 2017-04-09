using ComercioEletronico.DataBase.Repository;
using MySql.Data.MySqlClient;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Context;
using NHibernate.Mapping.ByCode;
using NHibernateComercio.DataBase.Models;
using NHibernateComercio.DataBase.Repository;
using System;
using System.Data;

using System.Reflection;

namespace NHibernateComercio.DataBase
{
    public class DBFactory
    {
        private static DBFactory _instance = null;
        private ISessionFactory _sessionFactory;

        public UsuarioRepository UsuarioRepository { get; set; }
        public EnderecoRepository EnderecoRepository { get; set; }
        public ProdutoraRepository ProdutoraRepository { get; set; }
        public ProdutoRepository ProdutoRepository { get; set; }
        public FotoRepository FotoRepository { get; set; }
        public InteressesRepository InteressesRepository { get; set; }

        private DBFactory()
        {
            this.Conectar();
            this.UsuarioRepository = new UsuarioRepository(this.Session);
            this.EnderecoRepository = new EnderecoRepository(this.Session);
            this.ProdutoraRepository = new ProdutoraRepository(this.Session);
            this.ProdutoRepository = new ProdutoRepository(this.Session);
            this.FotoRepository = new FotoRepository(this.Session);
            this.InteressesRepository = new InteressesRepository(this.Session);

        }

        public bool HttpContext { get; private set; }

        public static DBFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DBFactory();
                }
                return _instance;
            }
        }

        private void Conectar()
        {

            try
            {
                var stringConexao = "Persist Security Info=False;server=localhost;port=3306;database=comercioeletronico;uid=root;pwd=1234";
                var mySql = new MySqlConnection(stringConexao);
                try
                {
                    mySql.Open();
                }
                finally
                {
                    if (mySql.State == ConnectionState.Open)
                    {
                        mySql.Close();
                    }
                }
                this.ConfigNHibernate(stringConexao);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível Conectar ao Banco de Dados", ex);
            }

        }
        private void ConfigNHibernate(string stringConexao)
        {
            var config = new Configuration();
            try
            {
                config.DataBaseIntegration(c =>
                {
                    c.Dialect<NHibernate.Dialect.MySQLDialect>();
                    c.ConnectionString = stringConexao;
                    c.Driver<NHibernate.Driver.MySqlDataDriver>();
                    c.ConnectionProvider<NHibernate.Connection.DriverConnectionProvider>();
                    c.LogSqlInConsole = true;
                    c.LogFormattedSql = true;
                    c.SchemaAction = SchemaAutoAction.Update;
                });
                var maps = this.Mapeamento();
                config.AddMapping(maps);

                if (System.Web.HttpContext.Current == null)
                {
                    config.CurrentSessionContext<ThreadStaticSessionContext>();
                }
                else
                {
                    config.CurrentSessionContext<WebSessionContext>();
                }
                this._sessionFactory = config.BuildSessionFactory();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível config NHibernate", ex);
            }
        }
        private HbmMapping Mapeamento()
        {
            try
            {
                var mapper = new ModelMapper();
                mapper.AddMappings(Assembly.GetAssembly(typeof(UsuarioMap)).GetTypes());
                return mapper.CompileMappingForAllExplicitlyAddedEntities();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar o mapeamento do modelo", ex);
            }
        }

        private ISession Session
        {
            get
            {
                try
                {
                    if (CurrentSessionContext.HasBind(_sessionFactory))
                    {
                        return _sessionFactory.GetCurrentSession();
                    }

                    var session = _sessionFactory.OpenSession();
                    CurrentSessionContext.Bind(session);
                    return session;
                }
                catch (Exception ex)
                {

                    throw new Exception("Não foi possível criar a Sessão", ex);
                }
            }
        }
    }
}
