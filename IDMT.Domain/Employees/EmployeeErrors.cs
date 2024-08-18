using IDMT.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Domain.Employees;

public static class EmployeeErrors
{
	public static readonly Error NotFound = new(
		"Employee.Found",
		"Employee with the specified identifier was not found");

	//public static readonly Error NotActivated = new(
	//	"Employee.NotActivated",
	//	"Employee is not deactivated");

	//public static readonly Error NotTerminated = new(
	//	"Employee.NotTerminated",
	//	"Employee is not active");

}
