namespace Amax.InsurancePro.Infrastructure.Dtos;
public class AgentRightsDto
{
    #region Properties
    public bool HasAccessToMail { get; set; }

    public bool IsAdmin { get; set; }

    public bool HasAccessToReports { get; set; }

    public bool HasAccessToDeletePayments { get; set; }

    public bool HasAccessToDailyReports { get; set; }

    public bool HasAccessToSetupAgency { get; set; }

    public bool HasAccessToReconcile { get; set; }

    public bool HasAccessToWriteCheck { get; set; }

    public bool HasAccessToSetupAgentsCompanies { get; set; }

    public bool HasAccessToDeleteClients { get; set; }

    public bool HasAccessToEODReport { get; set; }

    #endregion

}
