namespace Amax.InsurancePro.Infrastructure.Dtos;

public class TableParameterDto
{
	public bool IsActiveOnly { get; set; }
	public int Start { get; set; }
	public int Length { get; set;}

	//Todo orderby, sorting, filter, search, global search?
}

