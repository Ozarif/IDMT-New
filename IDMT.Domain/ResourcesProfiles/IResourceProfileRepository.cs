using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Domain.ResourcesProfiles
{
	public interface IResourceProfileRepository
	{
		Task<ResourceProfile?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
		void Add(ResourceProfile resourceProfile);
	}
}
