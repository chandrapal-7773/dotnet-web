using Amax.InsurancePro.Infrastructure.Dtos;

namespace Amax.InsurancePro.Infrastructure.Dtos.Response;
public class BaseResponseDto
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public string Result { get; set; }
    public int TotalRecordCount { get; set; }
    public List<dynamic> Errors { get; set; }
    public int Code { get; set; }
    public object Data { get; set; }
    public BaseResponseDto()
    {
        Message = "Success";
        Success = true;
        Code = 200;
    }
    public BaseResponseDto(string message, bool success)
    {
        Message = message == "" ? !success ? "Error" : "Success" : message;
        Success = success;
        Code = !success ? 400 : 200;
    }
    public BaseResponseDto(string message, bool success, int code)
    {
        Message = message == "" ? !success ? "Error" : "Success" : message;
        Success = success;
        Code = code;
    }
    public BaseResponseDto(string message, bool success, object data)
    {
        Message = message == "" ? !success ? "Error" : "Success" : message;
        Success = success;
        Data = data;
        Code = !success ? 400 : 200;
    }
}