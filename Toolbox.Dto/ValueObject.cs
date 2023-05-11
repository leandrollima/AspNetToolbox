namespace Toolbox.Dto
{
    public class ValueObject<T>
    {
        public bool Success { get; set; } = true;
        public T Data { get; set; }
        public string Message { get; set; }
    }
}