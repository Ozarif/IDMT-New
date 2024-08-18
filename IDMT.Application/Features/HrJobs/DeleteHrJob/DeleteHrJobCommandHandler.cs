using IDMT.Application.Abstractions.Messaging;
using IDMT.Application.Features.SupportGroups.UpdateSupportGroup;
using IDMT.Domain.Abstractions;
using IDMT.Domain.HrJobs;
using IDMT.Domain.Shared;
using IDMT.Domain.SupportGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.HrJobs.DeleteHrJob
{
	internal sealed class DeleteHrJobCommandHandler : ICommandHandler<DeleteHrJobCommand>
	{
		private readonly IHrJobRepository _hrJobRepository;
		//private readonly IEmployeeRepository _employeeRepository;
		private readonly IUnitOfWork _unitOfWork;

		public DeleteHrJobCommandHandler(IHrJobRepository hrJobRepository, IUnitOfWork unitOfWork)
		{
			_hrJobRepository = hrJobRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<Result> Handle(DeleteHrJobCommand request, CancellationToken cancellationToken)
		{
			var hrJob = await _hrJobRepository.GetByIdAsync(request.Id);

            if (hrJob is null)
            {
				return Result.Failure(HrJobErrors.NotFound);
			}

			// check if it's already assigned to any employee

			if (hrJob is null)
			{
				return Result.Failure(HrJobErrors.AlreadyAssigned);
			}

			await _hrJobRepository.RemoveAsync(hrJob);
			await _unitOfWork.SaveChangesAsync(cancellationToken);

			return Result.Success();
		}
	}
}
