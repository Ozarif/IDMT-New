using IDMT.Application.Abstractions.Messaging;
using IDMT.Application.Features.HrJobs.Shared;
using IDMT.Domain.Abstractions;
using IDMT.Domain.HrJobs;

namespace IDMT.Application.Features.HrJobs.GetHrJob
{
	internal class HrJobGroupQueryHandler : IQueryHandler<GetHrJobQuery, HrJobResponse>
    {
        private readonly IHrJobRepository _hrJobRepository;

        public HrJobGroupQueryHandler(IHrJobRepository hrJobRepository)
        {
            _hrJobRepository = hrJobRepository;
        }

        public async Task<Result<HrJobResponse>> Handle(GetHrJobQuery request, CancellationToken cancellationToken)
        {
            var hrJob = await _hrJobRepository.GetByIdAsync(request.id, cancellationToken);

            if (hrJob is null)
            {
                return Result.Failure<HrJobResponse>(HrJobErrors.NotFound);
            }

            return hrJob.ToResponse();
        }
    }
}
