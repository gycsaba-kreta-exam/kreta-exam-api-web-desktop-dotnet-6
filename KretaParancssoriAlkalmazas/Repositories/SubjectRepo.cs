﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Kreta.Repositories.Interfaces;
using Kreta.Repositories.BaseClass;
using Kreta.Models.Context;
using KretaParancssoriAlkalmazas.Models.EFClass;
using KretaParancssoriAlkalmazas.Models.Parameters;

namespace Kreta.Repositories
{
    public class SubjectRepo : RepositoryBase<EFSubject>, ISubjectRepo
    {
        public SubjectRepo(KretaContext kretaContext)
            : base(kretaContext)
        {
        }

        public IEnumerable<EFSubject> GetAllSubjects()
        {
            return GetAll()
                .OrderBy(subject => subject.SubjectName)
                .ToList();
        }

        public IEnumerable<EFSubject> SearchBySubjectName(SubjectNameSearchingParameters subjectNameSearchingParameters)
        {
            return GetAll()
                .Where(subject => subject.SubjectName.ToLower().Contains(subjectNameSearchingParameters.Name.Trim().ToLower()))
                .ToList();
        }


        public EFSubject? GetSubjectById(long subjectId)
        {
            return FindByCondition(subject => subject.Id.Equals(subjectId))
                .FirstOrDefault();
        }

        public void CreateSubject(EFSubject subject)
        {
            Insert(subject);
        }

        public void UpdateSubject(EFSubject subject)
        {
            Update(subject);
        }

        public void DeleteSubject(EFSubject subject)
        {
            Delete(subject);
        }
    }
}