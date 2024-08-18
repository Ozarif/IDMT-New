using IDMT.Application.Abstractions.Messaging;
using IDMT.Application.Features.HrJobs.Shared;
using IDMT.Domain.Abstractions;
using IDMT.Domain.Employees;
using IDMT.Domain.HrJobs;
using IDMT.Domain.Shared;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.Employees.CreateEmployee;

    internal class CreateEmployeeCommandHandler : ICommandHandler<CreateEmployeeCommand, Guid>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IHrJobRepository _hrJobRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork, IHrJobRepository hrJobRepository)
    {
        _employeeRepository = employeeRepository;
        _unitOfWork = unitOfWork;
        _hrJobRepository = hrJobRepository;
    }

    public async Task<Result<Guid>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var hrJob = await _hrJobRepository.GetByIdAsync(request.HrJobId,cancellationToken);

        if(hrJob is null)
			return Result.Failure<Guid>(HrJobErrors.NotFound);

		var employee = Employee.Create( request.HrId, 
                                        request.FirstName, 
                                        request.FatherName, 
                                        request.LastName, 
                                        request.SpouseName, 
                                        hrJob);

        await _employeeRepository.CreateAsync(employee);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return employee.Id;
    }
}
