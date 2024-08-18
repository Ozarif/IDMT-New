using IDMT.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.Employees.CreateEmployee;

public sealed record CreateEmployeeCommand(
	Guid Id,
	string HrId,
	string FirstName,
	string FatherName,
	string LastName,
	string? SpouseName,
	Guid HrJobId) : ICommand<Guid>;
