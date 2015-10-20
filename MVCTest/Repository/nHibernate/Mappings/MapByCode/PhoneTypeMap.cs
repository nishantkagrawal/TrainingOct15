using MVCTest.Repository.Entities;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTest.Repository.nHibernate.Mappings
{
    public class PhoneTypeMap : ClassMapping<PhoneType>
    {
        public PhoneTypeMap()
        {
            Table("PhoneTypes");
            Id(x => x.Id);
            Property(x => x.Type);
            Bag<PhoneNumber>(x => x.PhoneNumbers, cp =>
            {
                //cp.Key(k => k.Column(typeof(PhoneNumber).Name));
                //cp.Table("PhoneNumbers");
            },

            cr => cr.OneToMany(c => c.Class(typeof(PhoneNumber)))

            );
        }
    }
}