﻿using KretaParancssoriAlkalmazas.Models.HTEOS;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KretaParancssoriAlkalmazas.Models.Helpers
{
    public interface IDataShaper<T>
    {
        // IEnumerable<ExpandoObject> ??
        IEnumerable<ExpandoObject> ShapeData(IEnumerable<T> entities, string fieldsString);
        ExpandoObject ShapeData(T entity, string fieldsString);
    }
}
