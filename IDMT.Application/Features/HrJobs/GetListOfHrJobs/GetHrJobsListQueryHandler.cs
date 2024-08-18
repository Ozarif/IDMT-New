namespace IDMT.Application.Features.HrJobs.GetListOfHrJobs;

//internal class GetHrJobsListQueryHandler : IQueryHandler<GetHrJobsListQuery, IReadOnlyList<HrJobResponse>>
//{
//	private readonly IHrJobRepository _employeeRepository;

//	public GetHrJobsListQueryHandler(IHrJobRepository hrJobRepository)
//	{
//		_employeeRepository = hrJobRepository;
//	}

//	public async Task<Result<IReadOnlyList<HrJobResponse>>> Handle(GetHrJobsListQuery request, CancellationToken cancellationToken)
//	{
//		var hrJob = await _employeeRepository.GetByIdAsync();





//		if (hrJob is null)
//		{
//			return Result.Failure<PagedList<HrJobResponse>>(SupportGroupErrors.NotFound);

//		}
//	}
//}
