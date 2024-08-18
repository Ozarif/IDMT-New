using IDMT.Application.Abstractions.Messaging;
using IDMT.Domain.Abstractions;
using IDMT.Domain.HrJobs;
using IDMT.Domain.Positions;
using IDMT.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.Positions.CreatePosition
{

    internal class CreatePositionCommandHandler : ICommandHandler<CreatePositionCommand, Guid>
    {
        public readonly IPositionRepository _positionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePositionCommandHandler(IPositionRepository positionRepository,
                                            IUnitOfWork unitOfWork)
        {
            _positionRepository = positionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
        {
            var position = Position.Create(request.Name);

            await _positionRepository.CreateAsync(position);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return position.Id;
        }
    }
}
