using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RealEstateScrapper.Models.Helpers
{
   public class QueryArgs
    {

        [Range(0, int.MaxValue, ErrorMessage = "Page number must be greater than 0")]
        public int Page { get; set; } = 1;

        [Range(0, int.MaxValue, ErrorMessage = "Page size must be greater than 0")]
        public int PageSize { get; set; } = 10;

        [Range(0, int.MaxValue, ErrorMessage = "MinPrice must be greater than 0")]
        public int? MinPrice { get; set; } = 0;

        [Range(0, int.MaxValue, ErrorMessage = "MaxPrice must be greater than 0")]
        public int? MaxPrice { get; set; } = int.MaxValue; 
    }
}
