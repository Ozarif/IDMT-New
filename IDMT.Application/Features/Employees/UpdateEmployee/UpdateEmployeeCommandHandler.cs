using IDMT.Application.Abstractions.Messaging;
using IDMT.Domain.Abstractions;
using IDMT.Domain.Employees;
using IDMT.Domain.HrJobs;

namespace IDMT.Application.Features.Employees.GetListOfEmployees;

internal sealed class UpdateEmployeeCommandHandler : ICommandHandler<UpdateEmployeeCommand>
{
	private readonly IEmployeeRepository _employeeRepository;
	private readonly IHrJobRepository _hrJobRepository;
	private readonly IUnitOfWork _unitOfWork;

	public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository, 
										IUnitOfWork unitOfWork, 
										IHrJobRepository hrJobRepository)
	{
		_employeeRepository = employeeRepository;
		_unitOfWork = unitOfWork;
		_hrJobRepository = hrJobRepository;
	}

	public async Task<Result> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
	{
		var hrJob = await _hrJobRepository.GetByIdAsync(request.HrJobId, cancellationToken);

		if (hrJob is null)
			return Result.Failure<Guid>(HrJobErrors.NotFound);

		var employee = await _employeeRepository.GetByIdAsync(request.Id);

		if (employee is null)
		{
			return Result.Failure(EmployeeErrors.NotFound);
		}

		employee.Update(request.HrId,
										request.FirstName,
										request.FatherName,
										request.LastName,
										request.SpouseName,
										hrJob);

		await _employeeRepository.UpdateAsync(employee);
		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}
