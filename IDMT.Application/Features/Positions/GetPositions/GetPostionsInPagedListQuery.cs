using IDMT.Application.Abstractions.Messaging;
using IDMT.Application.Features.Positions.Shared;
using IDMT.Domain.Abstractions;

namespace IDMT.Application.Features.Positions.GetPositions;

public sealed record GetPostionsInPagedListQuery(PaginationParam param) : IQuery<PagedList<PositionResponse>>;
