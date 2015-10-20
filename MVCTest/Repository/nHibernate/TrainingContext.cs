using FluentNHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MVCTest.Repository.Entities;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json.Serialization;
using MVCTest.Repository.nHibernate.Helpers;
using MVCTest.Repository.nHibernate.Overrides;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using MVCTest.Repository.nHibernate.Mappings;
using NHibernate.Cfg;

namespace MVCTest.Repository.nHibernate
{
    public class TrainingContext
    {
        static TrainingContext()
        {
            SessionFactory = ConfigureSql();
            //SessionFactory = ConfigurePostGres();
        }

        static ISessionFactory ConfigureSql()
        {
            //Gets all Mapping By code mappings
            var cfg = MapToCodeConfiguration.configuration;            

            var sessionFactory = Fluently.Configure(cfg)
                .Database(MsSqlConfiguration.MsSql2008
                  .ConnectionString(conString => conString.FromConnectionStringWithKey("TrainingEntities"))
                  .ShowSql())
                  
                  //
                  //.Mappings(x => x.MergeMappings())

                  //The following code will map all classes that implement IEntity through
                  //AutoMap. No hand coding of mapping is required.
                  .Mappings(x => x.AutoMappings
                      .Add(AutoMap.AssemblyOf<Contact>(new AutomappingConfiguration())
                      .Conventions.AddFromAssemblyOf<PluralTableNameConvention>()
                      .OverrideAll(p => { p.SkipProperty(typeof(NotMappedAttribute)); })
                      ))

                  
                  //The following code will map all classes that are implementing ClassMap<T>
                  //Manual mapping of properties is required.
                  //See PhoneNumberMap.cs in Repository/Mappings folder
                  .Mappings(x => x.FluentMappings.AddFromAssemblyOf<Contact>())
                  
              //.UseOverridesFromAssemblyOf<ContactOverrides>()))

              .ExposeConfiguration(config => new SchemaUpdate(config).Execute(false, false))
              .BuildSessionFactory();

            //.Mappings(m =>
            //          m.FluentMappings
            //              .AddFromAssemblyOf<Program>())
            //.ExposeConfiguration(cfg => new SchemaExport(cfg)
            //                                .Create(true, true))
            //.BuildSessionFactory();

            return sessionFactory;
        }
        
        static ISessionFactory ConfigurePostGres()
        {
            var sessionFactory = Fluently.Configure()
             .Database(PostgreSQLConfiguration.PostgreSQL82.ConnectionString(x => x.FromConnectionStringWithKey("TrainingEntitiesPostGres")))
             //The "none" will disable any operation regarding RDBMS KeyWords.
             //And the Keywords is available for MsSQL, Oracle, Firebird, MsSqlCe, MySQL, SQLite, SybaseAnywhere.
             //Since Postgress is not in the list it has to be set to None.
             .Database(PostgreSQLConfiguration.PostgreSQL82.Raw("hbm2ddl.keywords", "none"))
              //.Mappings(x => x.AutoMappings.Add(
              //    AutoMap.AssemblyOf<Contact>(new AutomappingConfiguration()).UseOverridesFromAssemblyOf<ContactOverrides>()))
              .Mappings(x => x.AutoMappings
                      .Add(AutoMap.AssemblyOf<Contact>(new AutomappingConfiguration())
                      .Conventions.AddFromAssemblyOf<PluralTableNameConvention>()
                      .OverrideAll(p => { p.SkipProperty(typeof(NotMappedAttribute)); })
                      ))
             .ExposeConfiguration(config => new SchemaUpdate(config).Execute(false, true))
             .BuildSessionFactory();

            return sessionFactory;
        }

        public TrainingContext()
        {
            this.Session = SessionFactory.OpenSession();
        }


        public void BeginTransaction()
        {
            this.transaction = this.Session.BeginTransaction();
        }


        public ISession Session;

        private ITransaction transaction;

        private static readonly ISessionFactory SessionFactory;
    }
}