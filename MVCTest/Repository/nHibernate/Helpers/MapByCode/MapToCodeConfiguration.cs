using MVCTest.Repository.nHibernate.Mappings;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTest.Repository.nHibernate.Helpers
{
    public static class MapToCodeConfiguration
    {
        private static HbmMapping CreateMapping()
        {

            var mapper = new ModelMapper();
            //Add the person mapping to the model mapper
            mapper.AddMappings(new List<System.Type> { typeof(PhoneTypeMap) });
            //Create and return a HbmMapping of the model mapping in code
            return mapper.CompileMappingForAllExplicitlyAddedEntities();
        }

        public static Configuration configuration;

        static MapToCodeConfiguration()
        {
            configuration = new Configuration();
            //Loads properties from hibernate.cfg.xml
            configuration.Configure();
            //Loads nhibernate mappings 
            configuration.AddDeserializedMapping(CreateMapping(), null);

            //return configuration;
        }
    }
}