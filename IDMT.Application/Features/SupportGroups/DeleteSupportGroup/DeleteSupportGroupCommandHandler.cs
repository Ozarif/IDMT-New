using IDMT.Application.Abstractions.Messaging;
using IDMT.Application.Features.SupportGroups.UpdateSupportGroup;
using IDMT.Domain.Abstractions;
using IDMT.Domain.Shared;
using IDMT.Domain.SupportGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.SupportGroups.DeleteSupportGroup
{
	internal sealed class DeleteSupportGroupCommandHandler : ICommandHandler<DeleteSupportGroupCommand>
	{
		private readonly ISupportGroupRepository _supportGroupRepository;
		private readonly IUnitOfWork _unitOfWork;

		public DeleteSupportGroupCommandHandler(ISupportGroupRepository supportGroupRepository, IUnitOfWork unitOfWork)
		{
			_supportGroupRepository = supportGroupRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<Result> Handle(DeleteSupportGroupCommand request, CancellationToken cancellationToken)
		{
			var supportGroup = await _supportGroupRepository.GetByIdAsync(request.Id);

            if (supportGroup is null)
            {
				return Result.Failure(SupportGroupErrors.NotFound);
			}

			supportGroup.Delete();

			await _supportGroupRepository.UpdateAsync(supportGroup);
			await _unitOfWork.SaveChangesAsync(cancellationToken);

			return Result.Success();
		}
	}
}
