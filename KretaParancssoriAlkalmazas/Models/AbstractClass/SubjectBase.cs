﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KretaParancssoriAlkalmazas.Models.AbstractClass
{
    public abstract class SubjectBase
    {

        public SubjectBase(long id, string subName)
        {
            this.Id = id;
            this.SubjectName = subName;
        }

        public SubjectBase()
        {
            this.Id = -1;
            this.SubjectName = String.Empty;
        }

        public virtual long Id { get; set; }

        public virtual string SubjectName { get; set; }

        public override string ToString()
        {
            return Id + ". " + SubjectName;
        }
    }
}