﻿using Kreta.Models.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Models.AbstractClass
{
    public abstract class ClassWithId : IEntityIdentify
    {
        public ClassWithId(long id)
        {
            this.Id = id;     
        }

        public long Id { get; set; }
    }
    
}
