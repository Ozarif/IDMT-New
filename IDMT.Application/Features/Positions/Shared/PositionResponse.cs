using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.Positions.Shared
{
    public sealed class PositionResponse
    {
        public Guid Id { get; init; }

        public string Name { get; init; }
    }
}
