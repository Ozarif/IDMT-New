using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Domain.Resources
{
	public interface IResourceRepository
	{
		Task<Resource?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
		Task CreateAsync(Resource resource);
	}
}
