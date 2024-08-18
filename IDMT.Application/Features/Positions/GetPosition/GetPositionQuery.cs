using IDMT.Application.Abstractions.Messaging;
using IDMT.Application.Features.Positions.Shared;

namespace IDMT.Application.Features.Positions.GetPosition;

public sealed record GetPostionQuery(Guid id) : IQuery<PositionResponse>;
