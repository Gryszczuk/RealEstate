using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateScrapper.Models
{
    public class StatisticsSnapshot : BaseModel
    {
        public City City { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public int Count { get; set; }
        public decimal AveragePrice { get; set; }
    }
}
