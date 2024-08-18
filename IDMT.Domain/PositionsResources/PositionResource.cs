using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Domain.PositionsResources;

public sealed class PositionResource
{
    internal PositionResource(Guid positionId, Guid resourceId)
    {
        PositionId = positionId;
        ResourceId = resourceId;
    }
    private PositionResource()
    {
        
    }
    public Guid PositionId { get; private set; }
	public Guid ResourceId { get; private set; }
}
