namespace Amax.InsurancePro.Infrastructure.Dtos;
public class UserDto
{
    public int? ID { get; set; }
    public int UserID { get; set; }
    public string UserLoginID { get; set; }
    public string? UserName { get; set; }
    public string UserPassword { get; set; }
    public string UserEamil { get; set; }
    public string? Mobile { get; set; }
    public int DesgnationID { get; set; }
    public bool isAdmin { get; set; }
    public bool isAssigningAuthority { get; set; }
    public string? UserPhone { get; set; }
    public string? UserAddress { get; set; }
    public int AddBy { get; set; }
    public DateTime AddDate { get; set; }
    public int? EditBy { get; set; }
    public DateTime? EditDate { get; set; }
    public int OfferEmail { get; set; }
    public int ApplicationEmail { get; set; }
    public int OtherEmail { get; set; }
    public string? SyncBit { get; set; }
    public bool CanProcessApplications { get; set; }
    public bool AllowWebLogin { get; set; }
    public bool AllowWebEditing { get; set; }
    public bool Is_RBDMs { get; set; }
    public bool CanEditFee { get; set; }
    public bool CanTransferToSIMS { get; set; }
    public bool CanAssignRBDM { get; set; }
    public string Initials { get; set; }
    public bool CanAssignAgents { get; set; }
    public bool CanSendApplicantPassword { get; set; }
    public bool CanViewAgentPassword { get; set; }
    public bool IsActive { get; set; }
    public int DepartmentID { get; set; }
    public string? DefaultFolder { get; set; }
    public int EmployeeID { get; set; }
    public int PreferredRoleId { get; set; }
}