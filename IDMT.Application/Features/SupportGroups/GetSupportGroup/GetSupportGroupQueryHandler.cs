using IDMT.Application.Abstractions.Messaging;
using IDMT.Application.Features.SupportGroups.Shared;
using IDMT.Domain.Abstractions;
using IDMT.Domain.SupportGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.SupportGroups.GetSupportGroup
{
    internal class GetSupportGroupQueryHandler : IQueryHandler<GetSupportGroupQuery, SupportGroupResponse>
    {
        private readonly ISupportGroupRepository _supportGroupRepository;

        public GetSupportGroupQueryHandler(ISupportGroupRepository supportGroupRepository)
        {
            _supportGroupRepository = supportGroupRepository;
        }

        public async Task<Result<SupportGroupResponse>> Handle(GetSupportGroupQuery request, CancellationToken cancellationToken)
        {
            var supportGroup = await _supportGroupRepository.GetByIdAsync(request.id, cancellationToken);

            if (supportGroup is null)// && !supportGroup.IsActive.Value)
            {
                return Result.Failure<SupportGroupResponse>(SupportGroupErrors.NotFound);
            }

            return supportGroup.ToResponse();
        }
    }
}
