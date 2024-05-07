

namespace Amax.InsurancePro.Web.Models
{
	public class AgentLocationsViewModel
	{
		public int id { get; set; }

		public int AgentId { get; set; }

		public int LocationId { get; set; }

		public bool Deleted { get; set; }

		public bool defaultLocation { get; set; }
	}
}
