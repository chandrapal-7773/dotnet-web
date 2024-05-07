namespace Amax.InsurancePro.Web.Models
{
	public class CompanyViewModel
	{
		public int CompanyID { get; set; }
		public string? CoName { get; set; }
		public string? CoAddressLine1 { get; set; }
		public string? CoAddressLine2 { get; set; }
		public string? CoAddressCity { get; set; }
		public string? CoAddressState { get; set; }
		public string? CoAddressZip { get; set; }
		public string? CoPhone1 { get; set; }
		public string? CoPhone2 { get; set; }
		public string? CoFax { get; set; }
		public string? CoContact { get; set; }
		public double? CommissionPercent { get; set; }
		public string? CompanyNote { get; set; }
		public short? CoDirectDebit { get; set; }
		public string? AgencyCode { get; set; }
		public string? CoType { get; set; }
		public int? CommColl { get; set; }
		public int? CommBase { get; set; }
		public int? CoPayMethod { get; set; }
		public string? Email { get; set; }
		public string? Web { get; set; }
		public string? CoEmail1 { get; set; }
		public string? CoWeb { get; set; }
		public string? AaCoID { get; set; }
		public short? MGA { get; set; }
		public string? Memo { get; set; }
		public bool CollectCommOnFees { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateModified { get; set; }
		public DateTime? DateDeleted { get; set; }
		public bool Deleted { get; set; }
		public int DeletedBy { get; set; }
		public long ABCompanyId { get; set; }
		public DateTime sysUTCDateCreated { get; set; }
		public DateTime sysUTCDateModified { get; set; }
		public int? CompFeeOptions { get; set; }
	}
}
