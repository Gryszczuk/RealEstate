using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RealEstateScrapper.Models.Helpers
{
   public class QueryArgs
    {
        public string SortTerm { get; set; }

        public bool SortAscending { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Page number must be greater than 0")]
        public int Page { get; set; } = 1;

        [Range(0, int.MaxValue, ErrorMessage = "Page size must be greater than 0")]
        public int PageSize { get; set; } = 10;

        [Range(0, int.MaxValue, ErrorMessage = "MinPrice must be greater than 0")]
        public int? MinPrice { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "MaxPrice must be greater than 0")]
        public int? MaxPrice { get; set; }
    }
}
