using IDMT.Application.Abstractions.Messaging;
using IDMT.Application.Features.Employees.Shared;
using IDMT.Application.Features.SupportGroups.Shared;
using IDMT.Domain.Abstractions;
using IDMT.Domain.Employees;
using IDMT.Domain.SupportGroups;

namespace IDMT.Application.Features.Employees.GetListOfEmployees;

public sealed record GetEmployeesInPagedListQuery : EmployeePaginationParam, IQuery<PagedList<EmployeeResponse>>;

