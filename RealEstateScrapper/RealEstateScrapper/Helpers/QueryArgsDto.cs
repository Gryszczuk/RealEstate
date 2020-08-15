using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateScrapper.Helpers
{
    public class QueryArgsDto
    {
        [BindProperty(Name = "sort")]
        public string SortTerm { get; set; }

        [BindProperty(Name = "asc")]
        public bool SortAscending { get; set; }

        [BindProperty(Name = "page")]
        public int Page { get; set; } = 1;

        [BindProperty(Name = "size")]
        public int PageSize { get; set; } = 10;
    }
}
