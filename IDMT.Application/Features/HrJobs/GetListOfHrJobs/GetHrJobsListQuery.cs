using IDMT.Application.Abstractions.Messaging;
using IDMT.Application.Features.HrJobs.Shared;

namespace IDMT.Application.Features.HrJobs.GetListOfHrJobs;

public sealed record GetHrJobsListQuery() : IQuery<IReadOnlyList<HrJobResponse>>;

