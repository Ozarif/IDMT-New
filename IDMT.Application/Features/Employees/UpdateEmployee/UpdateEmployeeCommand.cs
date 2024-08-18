using IDMT.Application.Abstractions.Messaging;

namespace IDMT.Application.Features.Employees.GetListOfEmployees;
public sealed record UpdateEmployeeCommand(Guid Id,
	string HrId,
		string FirstName, 
		string FatherName, 
		string LastName, 
		string? SpouseName,
		Guid HrJobId) : ICommand;


