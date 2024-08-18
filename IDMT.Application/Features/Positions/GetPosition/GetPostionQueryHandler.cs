using IDMT.Application.Abstractions.Messaging;
using IDMT.Application.Features.Positions.Shared;
using IDMT.Domain.Abstractions;
using IDMT.Domain.HrJobs;
using IDMT.Domain.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.Positions.GetPosition
{
    internal class GetPostionQueryHandler : IQueryHandler<GetPostionQuery, PositionResponse>
    {
        private readonly IPositionRepository _positionRepository;

        public GetPostionQueryHandler(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public async Task<Result<PositionResponse>> Handle(GetPostionQuery request, CancellationToken cancellationToken)
        {
            var position = await _positionRepository.GetByIdAsync(request.id, cancellationToken);

            if (position is null)
            {
                return Result.Failure<PositionResponse>(PositionErrors.NotFound);
            }

            return new PositionResponse() { Id = position.Id, Name = position.Name};
        }
    }
}
