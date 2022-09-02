﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KretaParancssoriAlkalmazas.Models.Helpers
{
    public class PagedList<T> : List<T> where T : class
    {
        public int CurrentPage { get; private set; }
        public int NumberOfPage { get; private set; }
        public int PageSize { get; private set; }
        public int NumberOfRows { get; private set; }

        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < NumberOfPage;

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            NumberOfRows = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;

            NumberOfPage = (int) Math.Ceiling(count / (double)pageSize);

            AddRange(items);
        }

        public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
