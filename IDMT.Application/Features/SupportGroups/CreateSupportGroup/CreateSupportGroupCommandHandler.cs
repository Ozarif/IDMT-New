using IDMT.Application.Abstractions.Messaging;
using IDMT.Domain.Abstractions;
using IDMT.Domain.Positions;
using IDMT.Domain.Shared;
using IDMT.Domain.SupportGroups;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.SupportGroups.CreateSupportGroup
{
    internal sealed class CreateSupportGroupCommandHandler : ICommandHandler<CreateSupportGroupCommand, Guid>
    {
        private readonly ISupportGroupRepository _supportGroupRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateSupportGroupCommandHandler(ISupportGroupRepository supportGroupRepository, IUnitOfWork unitOfWork)
        {
            _supportGroupRepository = supportGroupRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreateSupportGroupCommand request, CancellationToken cancellationToken)
        {
 
                var supportGroup = SupportGroup.Create(
                                                    request.Name,
                                                    request.Email);

                if (await _supportGroupRepository.AnyAsync(sg => sg.Name.ToLower() == request.Name.ToLower()))
                {
                   return Result.Failure<Guid>(SupportGroupErrors.AlreadyExists);
                }

                await _supportGroupRepository.CreateAsync(supportGroup);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
				return supportGroup.Id;

        }
    }
}
