namespace Definitions.Entities.ConnectWise
{
    public class CwRestClientResult
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public object Raw { get; set; } 
    }

    public class CwRestClientResult<T> : CwRestClientResult
    {
        public T Data { get; set; }
    }
}