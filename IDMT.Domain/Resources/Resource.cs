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
	private readonly List<Position> _Positions = new();

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

	public IReadOnlyCollection<Position> Positions => _Positions.ToList();

	public static Resource Create(ResourceType resourceType, string name, SupportGroup supportGroup)
	{
		return new Resource(Guid.NewGuid(), resourceType, name,supportGroup.Id);
	}

	public Result AssignToPosition(Position position)
	{
	_Positions.Add(position);

		return Result.Success();
	}
	public Result RemoveFromPosition(Position position)
	{
		if (_Positions.Count > 0)
		{
			_Positions.Remove(position);
			return Result.Success();
		}
		return Result.Failure(ResourceErrors.NotFound);
	}
}
