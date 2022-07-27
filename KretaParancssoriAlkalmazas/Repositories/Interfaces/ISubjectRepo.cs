﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models;

namespace Kreta.Repositories.Interfaces
{
    public interface ISubjectRepo : IRepositoryBase<Subject>
    {
        IEnumerable<Subject> GetAllSubjects();
        Subject? GetSubjectById(int id);
        void CreateSubject(Subject subject);
    }
}
