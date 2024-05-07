
namespace Amax.InsurancePro.Infrastructure.Dtos;
public class AgencyDto: BaseDto
{
	public int AgencyId { get; set; }

	public string? AgencyName { get; set; }

	public string? AgencyAddressLine1 { get; set; }

	public string? AgencyAddressLine2 { get; set; }

	public string? AgencyAddressCity { get; set; }

	public string? AgencyAddressState { get; set; }

	public string? AgencyAddressZip { get; set; }

	public string? AgencyPhone1 { get; set; }

	public string? AgencyPhone2 { get; set; }

	public string? AgencyFax { get; set; }

	public int? CurrentCheckNum { get; set; }

	public short? First { get; set; }

	public string? StartBalance { get; set; }

	public string? EndBalance { get; set; }

	public DateTime? StartDate { get; set; }

	public int? Count { get; set; }

	public string? Logo { get; set; }

	public short? LogonRequired { get; set; }

	public DateTime? ExpDate { get; set; }

	public short? Registered { get; set; }

	public string? CodeName { get; set; }

	public string? AaLocId { get; set; }

	public short? Demo { get; set; }

	public short? Online { get; set; }

	public DateTime DateCreated { get; set; }

	public DateTime DateModified { get; set; }

	public DateTime? DateDeleted { get; set; }

	public bool Deleted { get; set; }

	public int DeletedBy { get; set; }

	public Guid? BatchId { get; set; }

	public int DefaultBankAccountId { get; set; }

	public long AgencyBuzzLocationId { get; set; }

	public DateTime SysUtcdateCreated { get; set; }

	public DateTime SysUtcdateModified { get; set; }

	public string? CustomMsg { get; set; }
}
