using IDMT.Application.Abstractions.Messaging;
using IDMT.Application.Features.Positions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.Positions.GetPositions;

public sealed record GetPostionsQuery() : IQuery<IReadOnlyCollection<PositionResponse>>;
