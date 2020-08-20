using RealEstateScrapper.Models;
using RealEstateScrapper.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateScrapper.DataAccess.Repositories
{
   public class StatisticsRepository : Repository<StatisticsSnapshot>, IStatisticsRepository
    {
        public StatisticsRepository(RealEstateContext context) : base(context) { }
    }
}
