namespace Amax.InsurancePro.Infrastructure.Dtos.Request;
public class BaseRequestDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long RoleId { get; set; }
    public string UserLoginId { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public bool? Active { get; set; }

    public BaseRequestDto()
    {
        this.PageNumber = 1;
        this.PageSize = 10;
    }
}