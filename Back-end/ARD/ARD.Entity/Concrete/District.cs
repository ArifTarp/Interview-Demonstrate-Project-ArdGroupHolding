﻿using ARD.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ARD.Entity.Concrete
{
    public class District : IEntity
    {
        public District()
        {
            Addresses = new List<Address>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}
