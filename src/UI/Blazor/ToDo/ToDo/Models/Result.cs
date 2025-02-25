namespace ToDo.Models
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public bool IsFailed { get; set; }
        public List<Reason> Reasons { get; set; } = default!;
        public IEnumerable<Reason> Errors { get; set; } = default!;
        public IEnumerable<Reason> Successes { get; set; } = default!;

        public static Result Ok()
        {
            return new Result { IsSuccess = true };
        }

        public static Result Fail(string errorMessage)
        {
            var result = new Result { IsSuccess = false };
            result.Reasons.Add(new Reason { Message = errorMessage });
            return result;
        }

        public Result WithError(string errorMessage)
        {
            Reasons.Add(new Reason { Message = errorMessage });
            return this;
        }

        public Result WithSuccess(string successMessage)
        {
            Reasons.Add(new Reason { Message = successMessage });
            return this;
        }
    }

    public class Result<T> : Result
    {

        public T Value { get; set; } = default!;

        public static Result<T> Ok(T value)
        {
            return new Result<T> { IsSuccess = true, Value = value };
        }

        public static Result<T> Fail(string errorMessage)
        {
            var result = new Result<T> { IsSuccess = false };
            result.Reasons.Add(new Reason { Message = errorMessage });
            return result;
        }
    }
}
