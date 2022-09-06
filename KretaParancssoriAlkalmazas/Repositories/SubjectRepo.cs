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
using KretaParancssoriAlkalmazas.Models.Helpers;
using KretaParancssoriAlkalmazas.Models.HTEOS;
using System.Dynamic;
using KretaParancssoriAlkalmazas.Models.DataModel;

namespace Kreta.Repositories
{
    public class SubjectRepo : RepositoryBase<EFSubject>, ISubjectRepo
    {
        private ISortHelper<EFSubject> sortHelper;
        private IDataShaper<EFSubject> dataShaper;

        public SubjectRepo(KretaContext kretaContext, ISortHelper<EFSubject> sortHelper, IDataShaper<EFSubject> dataShaper)
            : base(kretaContext)
        {
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        public PagedList<ExpandoObject> GetAllSubjects(SubjectParameters subjectParameters)
        {
            var subjects = SearchBySubjectName(subjectParameters.Filter);

            var sortedSubject = sortHelper.ApplySort((IQueryable<EFSubject>) subjects, subjectParameters.OrderBy);
            var sortedAndShapedSubject = dataShaper.ShapeData(sortedSubject, subjectParameters.Fields);

            return PagedList<ExpandoObject>.ToPagedList(sortedAndShapedSubject, subjectParameters.CurrentPage, subjectParameters.PageSize);

         
        }

        public IEnumerable<EFSubject> SearchBySubjectName(string subjectParameters)
        {
            if(subjectParameters!=string.Empty)
                return GetAll()
                    .Where(subject => subject.SubjectName.ToLower().Contains(subjectParameters.Trim().ToLower()))
                    .ToList();
            else
                return GetAll();
        }

        public EFSubject? GetSubjectById(long subjectId)
        {
            return FindByCondition(subject => subject.Id.Equals(subjectId))
                   .FirstOrDefault();
   
        }

        public ExpandoObject? GetSubjectById(long subjectId,string fields)
        {
            var subjects=FindByCondition(subject => subject.Id.Equals(subjectId))
                .FirstOrDefault();
            return dataShaper.ShapeData(subjects, fields);
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
