using IDMT.Application.Abstractions.Messaging;
using IDMT.Application.Features.Employees.Shared;
using IDMT.Application.Features.SupportGroups.GetSupportGroup;
using IDMT.Application.Features.SupportGroups.Shared;
using IDMT.Domain.Abstractions;
using IDMT.Domain.Employees;
using IDMT.Domain.SupportGroups;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.Employees.GetListOfEmployees;
internal class GetEmployeesInPagedListQueryHandler : IQueryHandler<GetEmployeesInPagedListQuery, PagedList<EmployeeResponse>>
{ 
	private readonly IEmployeeRepository _employeeRepository;

	public GetEmployeesInPagedListQueryHandler(IEmployeeRepository supportGroupRepository)
	{
		_employeeRepository = supportGroupRepository;
	}

	public async Task<Result<PagedList<EmployeeResponse>>> Handle(GetEmployeesInPagedListQuery request, CancellationToken cancellationToken)
	{

		var employeesList = await _employeeRepository.GetEmployeesAsync(request, cancellationToken);

	
		if (employeesList is null)
		{
			return Result.Failure<PagedList<EmployeeResponse>>(EmployeeErrors.NotFound);

		}
		
		var employeesPagedResponse = new PagedList<EmployeeResponse>(employeesList.Select(c => c.ToResponse()).ToList(),
																			employeesList.TotalCount,
																			employeesList.CurrentPage,
																			employeesList.PageSize);


		return Result.Success(employeesPagedResponse);

	}
}

