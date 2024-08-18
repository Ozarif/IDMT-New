using IDMT.Application.Abstractions.Messaging;
using IDMT.Domain.Abstractions;
using IDMT.Domain.SupportGroups;
using IDMT.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDMT.Domain.HrJobs;

namespace IDMT.Application.Features.HrJobs.UpdateHrJob
{
	internal sealed class UpdateHrJobCommandHandler : ICommandHandler<UpdateHrJobCommand>
	{
		private readonly IHrJobRepository _hrJobRepository;
		private readonly IUnitOfWork _unitOfWork;

		public UpdateHrJobCommandHandler(IHrJobRepository hrJobRepository, IUnitOfWork unitOfWork)
		{
			_hrJobRepository = hrJobRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<Result> Handle(UpdateHrJobCommand request, CancellationToken cancellationToken)
		{
			var hrJob = await _hrJobRepository.GetByIdAsync(request.Id);

			if (hrJob is null)
			{
				return Result.Failure(HrJobErrors.NotFound);
			}

			hrJob.Update(request.Name);

			await _hrJobRepository.UpdateAsync(hrJob);
			await _unitOfWork.SaveChangesAsync(cancellationToken);

			return Result.Success();
		}
	}
}
