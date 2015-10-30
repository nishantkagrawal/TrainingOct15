using System.ComponentModel.DataAnnotations.Schema;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MVCTest.Repository.Entities;
using MVCTest.Repository.NHibernate.Helpers;
using MVCTest.Repository.NHibernate.Helpers.Fluent;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace MVCTest.Repository.NHibernate
{
    /// <summary>
    ///     The training context.
    /// </summary>
    public class TrainingContext
    {
        /// <summary>
        ///     The session factory.
        /// </summary>
        private static readonly ISessionFactory SessionFactory;

        /// <summary>
        ///     The transaction.
        /// </summary>
        private ITransaction transaction;

        /// <summary>
        ///     Initializes static members of the <see cref="TrainingContext" /> class.
        /// </summary>
        static TrainingContext()
        {
            SessionFactory = ConfigureSql();

            //SessionFactory = ConfigurePostGres();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="TrainingContext" /> class.
        /// </summary>
        public TrainingContext()
        {
            this.Session = SessionFactory.OpenSession();
        }

        /// <summary>
        ///     Gets or sets the Session object
        /// </summary>
        public ISession Session { get; set; }

        /// <summary>
        /// Gets or sets the transaction.
        /// </summary>
        public ITransaction Transaction
        {
            get { return this.transaction; }

            set { this.transaction = value; }
        }

        /// <summary>
        ///     The begin transaction.
        /// </summary>
        public void BeginTransaction()
        {
            this.transaction = this.Session.BeginTransaction();
        }

        /// <summary>
        ///     The configure post gres.
        /// </summary>
        /// <returns>
        ///     The <see cref="ISessionFactory" />.
        /// </returns>
        private static ISessionFactory ConfigurePostGres()
        {
            var sessionFactory =
                Fluently.Configure()
                    .Database(
                        PostgreSQLConfiguration.PostgreSQL82.ConnectionString(
                            x => x.FromConnectionStringWithKey("TrainingEntitiesPostGres")))

                    //The "none" will disable any operation regarding RDBMS KeyWords.
                    //And the Keywords is available for MsSQL, Oracle, Firebird, MsSqlCe, MySQL, SQLite, SybaseAnywhere.
                    //Since Postgress is not in the list it has to be set to None.
                    .Database(PostgreSQLConfiguration.PostgreSQL82.Raw("hbm2ddl.keywords", "none"))

                    //.Mappings(x => x.AutoMappings.Add(
                    //    AutoMap.AssemblyOf<Contact>(new AutomappingConfiguration()).UseOverridesFromAssemblyOf<ContactOverrides>()))
                    .Mappings(
                        x =>
                            x.AutoMappings.Add(
                                AutoMap.AssemblyOf<Contact>(new AutomappingConfiguration())
                                    .Conventions.AddFromAssemblyOf<PluralTableNameConvention>()
                                    .OverrideAll(p =>
                                    {
                                        p.SkipProperty(typeof(NotMappedAttribute));
                                    })))
                    .ExposeConfiguration(config => new SchemaUpdate(config).Execute(false, true))
                    .BuildSessionFactory();

            return sessionFactory;
        }

        /// <summary>
        ///     The configure sql.
        /// </summary>
        /// <returns>
        ///     The <see cref="ISessionFactory" />.
        /// </returns>
        private static ISessionFactory ConfigureSql()
        {
            //Gets all Mapping By code mappings
            var cfg = MapToCodeConfiguration.Configuration;

            var sessionFactory =
                Fluently.Configure(cfg)
                    .Database(
                        MsSqlConfiguration.MsSql2008.ConnectionString(
                            conString => conString.FromConnectionStringWithKey("TrainingEntities")).ShowSql())

                    //.Mappings(x => x.MergeMappings())

                    //The following code will map all classes that implement IEntity through
                    //AutoMap. No hand coding of mapping is required.
                    .Mappings(
                        x =>
                            x.AutoMappings.Add(
                                AutoMap.AssemblyOf<Contact>(new AutomappingConfiguration())
                                    .Conventions.AddFromAssemblyOf<PluralTableNameConvention>()
                                    .OverrideAll(p =>
                                    {
                                        p.SkipProperty(typeof(NotMappedAttribute));
                                    })))

                    //The following code will map all classes that are implementing ClassMap<T>
                    //Manual mapping of properties is required.
                    //See PhoneNumberMap.cs in Repository/Mappings folder
                    .Mappings(x => x.FluentMappings.AddFromAssemblyOf<Contact>())

                    //.UseOverridesFromAssemblyOf<ContactOverrides>()))
                    .ExposeConfiguration(config => new SchemaUpdate(config).Execute(false, false)).BuildSessionFactory();

            //.Mappings(m =>
            //          m.FluentMappings
            //              .AddFromAssemblyOf<Program>())
            //.ExposeConfiguration(cfg => new SchemaExport(cfg)
            //                                .Create(true, true))
            //.BuildSessionFactory();
            return sessionFactory;
        }
    }
}