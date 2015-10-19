using System;
using System.Collections.Generic;

namespace MVCTest.Repository.Entities
{
    public partial class PhoneNumber : IEntity
    {
        public virtual int Id { get; set; }
        public virtual int PhoneTypeId { get; set; }
        public virtual int ContactId { get; set; }
        public virtual string Number { get; set; }

        public virtual PhoneType PhoneType { get; set; }
        public virtual Contact Contact { get; set; }
    }
}
