namespace Amax.InsurancePro.Infrastructure.Dtos;

public class LoginInfoDto
{
    public int UserId { get; set; }
    public string UserLoginId { get; set; }
    public string UserName { get; set; }
    public string UserEmail { get; set; }
    public string Mobile { get; set; }
    public int PreferredRoleId { get; set; }
    public int OTPRemainingAttempts { get; set; }
    public bool OTPVerified { get; set; }
    public string OTP { get; set; }
    public bool Disabled { get; set; }
    public bool Active { get; set; }
    public bool IsAdmin { get; set; }
    public DateTime PasswordUpdatedDate { get; set; }
    public AgentRightsDto AgentRights { get; set; }
    public LoginInfoDto()
    {
        OTPRemainingAttempts = 1;
        OTPVerified = true;
        OTP = string.Empty;
        AgentRights = new AgentRightsDto();
    }
}