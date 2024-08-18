using IDMT.Application.Features.HrJobs.Shared;
using IDMT.Domain.Employees;
using IDMT.Domain.HrJobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.Employees.Shared;

internal static class EmployeeMapping
{
	public static EmployeeResponse ToResponse(this Employee source)
	{
		return new()
		{
			Id = source.Id,
			HrId = source.HrId,
			FirstName = source.FirstName,
			FatherName = source.FatherName,
			LastName = source.LastName,
			SpouseName = source.SpouseName,
			HrJobId = source.HrJobId
		};
	}

	public static IQueryable<EmployeeResponse> ToIQueryableResponse(this IQueryable<Employee> source)
	{
		return source.Select(hj => new EmployeeResponse
		{
			Id = hj.Id,
			HrId = hj.HrId,
			FirstName = hj.FirstName,
			FatherName = hj.FatherName,
			LastName = hj.LastName,
			SpouseName = hj.SpouseName,
			HrJobId = hj.HrJobId
		});
	}
}


