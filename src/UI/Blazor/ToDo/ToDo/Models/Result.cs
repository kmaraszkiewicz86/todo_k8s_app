namespace ToDo.Models
{
    public class Result<TModel>
    {
        public bool IsFailed { get; set; }
        public TModel Value { get; set; } = default!;
    }
}
