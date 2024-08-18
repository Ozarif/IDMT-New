using IDMT.Domain.Abstractions;
using IDMT.Domain.Positions;
using IDMT.Domain.PositionsResources;
using IDMT.Domain.Shared;
using IDMT.Domain.SupportGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Domain.Resources;

public sealed class Resource : Entity
{
	private readonly List<PositionResource> _positionResources = new();

	private Resource() { }
	private Resource(Guid id, ResourceType resourceType, string name, Guid supportGroupId) : base(id)
	{
		ResourceType = resourceType;
		Name = name;
		SupportGroupId = supportGroupId;
	}

	public string Name { get; private set; }
	public ResourceType ResourceType { get; private set; }

	public Guid SupportGroupId { get; private set; }

	public IReadOnlyCollection<PositionResource> ResourcePositions => _positionResources.ToList();

	public static Resource Create(ResourceType resourceType, string name, SupportGroup supportGroup)
	{
		return new Resource(Guid.NewGuid(), resourceType, name,supportGroup.Id);
	}

	public Result AssignToPosition(Position position)
	{
		if (_positionResources.Any(pa => pa.PositionId == position.Id))
		{
			return Result.Failure(PositionErrors.AlreadyAssigned);
		}

		var positionResource = new PositionResource(position.Id, Id);
		_positionResources.Add(positionResource);

		return Result.Success();
	}
	public Result RemoveFromPosition(Position position)
	{
		var positionResource = _positionResources.FirstOrDefault(pa => pa.ResourceId == Id && pa.PositionId == position.Id);
		if (positionResource != null)
		{
			_positionResources.Remove(positionResource);
			return Result.Success();
		}
		return Result.Failure(ResourceErrors.NotFound);
	}
}
