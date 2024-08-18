using IDMT.Application.Abstractions.Messaging;
using IDMT.Domain.Abstractions;
using IDMT.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.Employees.TerminateEmployee
{
	internal class TerminateEmployeeCommandHandler : ICommandHandler<TerminateEmployeeCommand, Guid>
	{
		private readonly IEmployeeRepository _employeeRepository;
		//private readonly IPos
		private readonly IUnitOfWork _unitOfWork;
		public TerminateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}

		public Task<Result<Guid>> Handle(TerminateEmployeeCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
