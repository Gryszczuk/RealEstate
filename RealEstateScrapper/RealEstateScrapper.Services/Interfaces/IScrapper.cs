using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateScrapper.Services.Interfaces
{
    public interface IScrapper<T> where T : ITargetWebsite
    {
    }
}
