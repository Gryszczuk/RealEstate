using Microsoft.AspNetCore.Mvc;

namespace RealEstateScrapper.Services.Helpers
{
    public static class ResultExtenstions
    {
        public static IActionResult Process<T>(this Result<T> result)
        {
            if(result.Success == true)
            {
                return new OkObjectResult(result);
            }
            return new BadRequestObjectResult(result);
        }
        public static IActionResult Process(this Result result)
        {
            if (result.Success == true)
            {
                return new OkObjectResult(result);
            }
            return new BadRequestObjectResult(result);
        }
    }
}
