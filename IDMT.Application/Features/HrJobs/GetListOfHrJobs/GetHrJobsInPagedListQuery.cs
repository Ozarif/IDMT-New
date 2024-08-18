using IDMT.Application.Abstractions.Messaging;
using IDMT.Application.Features.HrJobs.Shared;
using IDMT.Domain.Abstractions;
using IDMT.Domain.HrJobs;

namespace IDMT.Application.Features.HrJobs.GetListOfHrJobs;

public sealed record GetHrJobsInPagedListQuery : HrJobPaginationParam, IQuery<PagedList<HrJobResponse>>;

