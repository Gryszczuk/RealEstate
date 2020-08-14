using Microsoft.EntityFrameworkCore;
using RealEstateScrapper.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RealEstateScrapper.DataAccess
{
   public class RealEstateContext : DbContext
    {
        public RealEstateContext(DbContextOptions<RealEstateContext> options) 
            : base(options)
        {
        }
        public DbSet<Offer> Offers { get; set; }
    }
}
