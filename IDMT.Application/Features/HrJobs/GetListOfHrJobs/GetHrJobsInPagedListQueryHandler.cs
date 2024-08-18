using IDMT.Application.Abstractions.Messaging;
using IDMT.Application.Features.HrJobs.Shared;
using IDMT.Application.Features.SupportGroups.Shared;
using IDMT.Domain.Abstractions;
using IDMT.Domain.HrJobs;

namespace IDMT.Application.Features.HrJobs.GetListOfHrJobs;
internal class GetHrJobsInPagedListQueryHandler : IQueryHandler<GetHrJobsInPagedListQuery, PagedList<HrJobResponse>>
{ 
	private readonly IHrJobRepository _hrJobRepository;

	public GetHrJobsInPagedListQueryHandler(IHrJobRepository hrJobRepository)
	{
		_hrJobRepository = hrJobRepository;
	}

	public async Task<Result<PagedList<HrJobResponse>>> Handle(GetHrJobsInPagedListQuery request, CancellationToken cancellationToken)
	{

		var hrJobsList = await _hrJobRepository.GetHrJobsAsync(request, cancellationToken);

	
		if (hrJobsList is null)
		{
			return Result.Failure<PagedList<HrJobResponse>>(HrJobErrors.NotFound);

		}
		
		var hrJobsPagedResponse = new PagedList<HrJobResponse>(hrJobsList.Select(c => c.ToResponse()).ToList(),
																			hrJobsList.TotalCount,
																			hrJobsList.CurrentPage,
																			hrJobsList.PageSize);


		return Result.Success(hrJobsPagedResponse);

	}
}

