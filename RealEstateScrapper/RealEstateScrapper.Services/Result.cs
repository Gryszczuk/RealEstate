using System.Collections.Generic;

namespace RealEstateScrapper.Services
{
    public class Result
    {
        public bool Success { get; set; }

        public bool Failed => !Success;

        public IEnumerable<ErrorMessage> Errors { get; set; }

        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>()
            {
                Success = true,
                Value = value
            };
        }


        public static Result<T> Error<T>(string message)
        {
            return new Result<T>
            {
                Success = false,
                Errors = new List<ErrorMessage>()
                {
                    new ErrorMessage()
                    {
                        PropertyName = string.Empty,
                        Message = message
                    }
                }
            };
        }
    }

    public class ErrorMessage
    {
        public string PropertyName { get; set; }
        public string Message { get; set; }
    }

    public class Result<T> : Result
    {
        public T Value { get; set; }
    }
}
