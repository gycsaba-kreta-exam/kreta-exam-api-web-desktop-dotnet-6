﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kreta.Models.AbstractClass
{
    public abstract class SubjectBaseWithAttributes : SubjectBase
    {

        [Column("name")]
        [Display(Name = "Subject name:")]
        [Required(ErrorMessage = "The name is required")]
        [StringLength(30, ErrorMessage = "The name cannot be longer than 30 characters")]
        [MinLength(3,ErrorMessage ="The name must be at least 3 characters long")]
        [RegularExpression(@"^[A-ZÁÉIÍOÓÖŐUÚÜŰ+][a-záéiíoóöőuúüű ]*$", ErrorMessage = "First letter must be uppercase, other lowercase or space")]
        public override string SubjectName { get; set; }

       public SubjectBaseWithAttributes(long id, string subName)
            : base(id, subName)
        {        
        }

        public SubjectBaseWithAttributes()
            : base()
        {
        }
    }
}
