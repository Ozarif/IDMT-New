using IDMT.Domain.Abstractions;
using IDMT.Domain.Resources;


namespace IDMT.Domain.Positions
{
    public sealed class Position : Entity
	{
		private readonly HashSet<Resource> _resources = new();
        private Position(Guid id, string name) : base(id)
		{
			Name = name;
		}
		private Position() { }

		public string Name { get; private set; }
		public bool IsActive { get; private set; }
		public IReadOnlyCollection<Resource> Resources => _resources.ToList();

		public static Position Create(string name)
		{
			var position = new Position(Guid.NewGuid(), name);
			position.Activate();
			return position;
		}

		public Result Activate(){
			IsActive = true;
			return Result.Success();
		}

		public Result Deactivate()
		{
			IsActive = false;
			return Result.Success();
		}
		public Result AddResource(Resource resource)
		{
			_resources.Add(resource);
			return Result.Success();
		}
		public Result RemoveApplication(Resource resource)
		{			
			if (_resources.Count > 0)
			{
				_resources.Remove(resource);			
			}
			return Result.Success();
		}
	}
}
