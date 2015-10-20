using FluentNHibernate.Mapping;
using MVCTest.Repository.Entities;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTest.Repository.nHibernate.Mappings
{
    public class PhoneNumberMap : ClassMap<PhoneNumber>
    {
        public PhoneNumberMap()
        {
            Id(x => x.Id);
            Map(x => x.Number);
            References(x => x.PhoneType).Column("PhoneTypeId");
            References(x => x.Contact).Column("ContactId");            

        }
    }
}