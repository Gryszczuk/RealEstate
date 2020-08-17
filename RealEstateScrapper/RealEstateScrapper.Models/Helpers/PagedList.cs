using System;
using System.Collections.Generic;
using System.Linq;

namespace RealEstateScrapper.Models.Helpers
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }

        public bool HasPrevious
        {
            get { return (CurrentPage > 1); }
        }
        public bool HasNext
        {
            get { return (CurrentPage < TotalPages); }
        }

        public int? NextPage
        {
            get
            {
                if (HasNext) return CurrentPage + 1;
                else return null;
            }
        }

        public int? PreviousPage
        {
            get
            {
                if (HasPrevious) return CurrentPage - 1;
                else return null;
            }
        }
        private PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            if (pageSize <= 0)
            {
                PageSize = 10;
            }
            else
            {
                PageSize = pageSize;
            }
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public static PagedList<T> Create(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
