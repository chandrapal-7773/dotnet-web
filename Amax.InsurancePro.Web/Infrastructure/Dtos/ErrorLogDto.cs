namespace Amax.InsurancePro.Infrastructure.Dtos;

public class ErrorLogDto
{
    public long Id { get; set; }
    public string ErrorMessage { get; set; }
    public string StackTrace { get; set; }
    public string ControllerName { get; set; }
    public string ActionName { get; set; }
    public string Parameters { get; set; }
    public DateTime CreatedDate { get; set; }
}