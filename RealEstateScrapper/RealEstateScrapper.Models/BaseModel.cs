using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateScrapper.Models
{
   public class BaseModel
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
