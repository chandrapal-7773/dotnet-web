namespace Amax.InsurancePro.Infrastructure.Dtos;
public class AuthenticateRequestDto
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? NewPassword { get; set; }
    public int LoginAttempts { get; set; } = 0;
}