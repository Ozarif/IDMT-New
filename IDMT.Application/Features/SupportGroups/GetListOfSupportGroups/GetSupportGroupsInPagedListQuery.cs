using IDMT.Application.Abstractions.Messaging;
using IDMT.Application.Features.SupportGroups.Shared;
using IDMT.Domain.Abstractions;
using IDMT.Domain.SupportGroups;

namespace IDMT.Application.Features.SupportGroups.GetListOfSupportGroups;

public sealed record GetSupportGroupsInPagedListQuery : SupportGroupPaginationParam, IQuery<PagedList<SupportGroupResponse>>;

