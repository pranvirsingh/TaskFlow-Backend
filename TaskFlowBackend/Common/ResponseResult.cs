using System.Text.Json.Serialization;

namespace TaskFlowBackend.Common
{
    public class ResponseResult<T>
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        //public int? TotalRecords { get; set; }

        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        //public int? PageNumber { get; set; }

        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        //public int? PageSize { get; set; }

        public ResponseResult(int status, string message, T data)
        {
            Status = status;
            Message = message;
            Data = data;
        }

        //public ResponseResult(int status, string message, T data,
        //           int? totalRecords = null, int? pageNumber = null, int? pageSize = null)
        //{
        //    Status = status;
        //    Message = message;
        //    Data = data;
        //    TotalRecords = totalRecords;
        //    PageNumber = pageNumber;
        //    PageSize = pageSize;
        //}
    }
}
