namespace Amax.InsurancePro.Web.Models
{
	public class DatatableRequest
	{
		public int draw { get; set; } = 0;
		public int start { get; set; } = 0;
		public int length { get; set; }
		public bool IsActiveOnly { get; set; }
	}
}
