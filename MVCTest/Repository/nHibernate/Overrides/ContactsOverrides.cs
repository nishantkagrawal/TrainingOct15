using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MVCTest.Models;
using MVCTest.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTest.Repository.nHibernate.Overrides
{
    public class ContactOverrides : IAutoMappingOverride<Contact>
    {
        public void Override(AutoMapping<Contact> mapping)
        {
            //mapping.IgnoreProperty(p => p.HomePhone);
            //mapping.IgnoreProperty(p => p.CellPhone);
            //mapping.IgnoreProperty(p => p.WorkPhone);
            ////mapping(p => p.PhoneCollectionToFlatObject);

        }
    }
}