
using Amax.InsurancePro.Infrastructure.Dtos;
using Amax.InsurancePro.Infrastructure.Dtos.Request;

namespace Amax.InsurancePro.Application.DTO.Request;
public class ErrorLogRequestDto : BaseRequestDto
{
    public Exception Exception { get; set; }
    public ErrorLogDto ErrorLog { get; set; }
    public bool IsDBLog { get; set; }
}