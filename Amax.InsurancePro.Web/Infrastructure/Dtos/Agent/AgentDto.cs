
namespace Amax.InsurancePro.Infrastructure.Dtos;

public class AgentDto : BaseDto
{
	public int AgentId { get; set; }

	public string? AgentName { get; set; }

	public string? AgentAddressLine1 { get; set; }

	public string? AgentAddressLine2 { get; set; }

	public string? AgentAddressCity { get; set; }

	public string? AgentAddressState { get; set; }

	public string? AgentAddressZip { get; set; }

	public string? AgentPhone1 { get; set; }

	public string? AgentPhone2 { get; set; }

	public string? AgentNotes { get; set; }

	public string? AgentPayType { get; set; }

	public int? AgentRate { get; set; }

	public double? AgentCommPercent { get; set; }

	public short? AgentActive { get; set; }

	public string? UserId { get; set; }

	public string? Password { get; set; }

	public bool AdminAccess { get; set; }

	public bool AccessReport { get; set; }

	public bool AccessDeletePay { get; set; }

	public bool AccessDaily { get; set; }

	public bool AccessSetupAgency { get; set; }

	public bool AccessReconcile { get; set; }

	public bool AccessWriteCheck { get; set; }

	public string? AaAgentId { get; set; }

	public int? AgencyId { get; set; }

	public bool AccessPost { get; set; }

	public short? Logged { get; set; }

	public string? SignPic { get; set; }

	public bool Prefill { get; set; }

	public decimal? AgentFlatFee { get; set; }

	public bool BLocked { get; set; }

	public DateTime DateCreated { get; set; }

	public DateTime DateModified { get; set; }

	public DateTime? DateDeleted { get; set; }

	public int DeletedBy { get; set; }

	public string? EzlynxId { get; set; } //todo = null!;

	public string? TurboRaterId { get; set; } // = null!;

	public int AgencyBuzzId { get; set; }

	public Guid? BatchId { get; set; }

	public int DefaultBankAccountId { get; set; }

	public DateTime SysUtcdateCreated { get; set; }

	public DateTime SysUtcdateModified { get; set; }

	public string? Email { get; set; }

	public string? Title { get; set; }

	public bool AccessDelPayClients { get; set; }

	public bool AccesEodreports { get; set; }

	public bool AccessAgencyFees { get; set; }

	public string? Password_Enc { get; set; }

	public DateTime PasswordUpdatedDate { get; set; }

	public bool ResetPassword { get; set; }

	public List<int>? SelectedLocations { get; set; }
	public List<AgencyDto>? Agencies { get; set; }
}