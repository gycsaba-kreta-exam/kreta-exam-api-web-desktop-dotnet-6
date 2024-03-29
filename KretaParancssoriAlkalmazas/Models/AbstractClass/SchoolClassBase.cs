﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Models.AbstractClass
{
    public abstract class SchoolClassBase :ClassWithId
    {

        public SchoolClassBase(long id, int schoolYear, char classType, int teacherId)
            :base(id)
        {
            this.Id = id;
            this.SchoolYear = schoolYear;
            this.ClassType = classType;
            this.TeacherId = teacherId;
        }

        public SchoolClassBase()
            :base(-1)
        {
            this.Id = -1;
            this.SchoolYear = 9;
            this.ClassType = 'a';
            this.TeacherId = -1;
        }

        public virtual int SchoolYear { get; set; }

        public virtual char ClassType { get; set; }

        public virtual int TeacherId { get; set; }

        public virtual string SchoolYearClassType
        {
            get { return SchoolYear + ". " + ClassType; }
        }
    }
}
