using IDMT.Application.Abstractions.Messaging;
using IDMT.Application.Features.Employees.Shared;
using IDMT.Application.Features.HrJobs.Shared;
using IDMT.Domain.Abstractions;
using IDMT.Domain.Employees;
using IDMT.Domain.HrJobs;
using IDMT.Domain.SupportGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.Employees.GetEmployee
{
    internal class GetEmployeeQueryHandler : IQueryHandler<GetEmployeeQuery, EmployeeResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Result<EmployeeResponse>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.id, cancellationToken);

            if (employee is null)
            {
                return Result.Failure<EmployeeResponse>(HrJobErrors.NotFound);
            }

            return employee.ToResponse();
        }
    }
}
