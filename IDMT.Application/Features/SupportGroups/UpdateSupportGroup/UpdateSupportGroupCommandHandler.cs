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

namespace IDMT.Application.Features.SupportGroups.UpdateSupportGroup
{
	internal sealed class UpdateSupportGroupCommandHandler : ICommandHandler<UpdateSupportGroupCommand>
	{
		private readonly ISupportGroupRepository _supportGroupRepository;
		private readonly IUnitOfWork _unitOfWork;

		public UpdateSupportGroupCommandHandler(ISupportGroupRepository supportGroupRepository, IUnitOfWork unitOfWork)
		{
			_supportGroupRepository = supportGroupRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<Result> Handle(UpdateSupportGroupCommand request, CancellationToken cancellationToken)
		{
			var supportGroup = await _supportGroupRepository.GetByIdAsync(request.Id);

			if (supportGroup is null)
			{
				return Result.Failure(SupportGroupErrors.NotFound);
			}

			supportGroup.Update(request.Name, request.Email);

			await _supportGroupRepository.UpdateAsync(supportGroup);
			await _unitOfWork.SaveChangesAsync(cancellationToken);

			return Result.Success();
		}
	}
}
