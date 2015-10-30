using System;
using System.Collections.Generic;
using MVCTest.Repository.NHibernate.Mappings;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;

namespace MVCTest.Repository.NHibernate.Helpers
{
    /// <summary>
    ///     The map to code Configuration.
    /// </summary>
    public static class MapToCodeConfiguration
    {
        /// <summary>
        ///     Initializes static members of the <see cref="MapToCodeConfiguration" /> class.
        /// </summary>
        static MapToCodeConfiguration()
        {
            Configuration = new Configuration();

            //Loads properties from hibernate.cfg.xml
            Configuration.Configure();

            //Loads nhibernate mappings
            Configuration.AddDeserializedMapping(CreateMapping(), null);

            //return Configuration;
        }

        /// <summary>
        ///     Gets The Configuration.
        /// </summary>
        public static Configuration Configuration { get; private set; }

        /// <summary>
        ///     The create mapping.
        /// </summary>
        /// <returns>
        ///     The <see cref="HbmMapping" />.
        /// </returns>
        private static HbmMapping CreateMapping()
        {
            var mapper = new ModelMapper();

            //Add the person mapping to the model mapper
            mapper.AddMappings(new List<Type> { typeof(PhoneTypeMap) });

            //Create and return a HbmMapping of the model mapping in code
            return mapper.CompileMappingForAllExplicitlyAddedEntities();
        }
    }
}