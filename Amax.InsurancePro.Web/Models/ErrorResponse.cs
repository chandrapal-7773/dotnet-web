
namespace Amax.InsurancePro.Web.Models
{
	public class ErrorResponse
	{
		public int Code { get; set; }
		public string Message { get; set; }

		public List<ValidationError> ValidationErrors { get; set; } = new List<ValidationError>();
	}
}
