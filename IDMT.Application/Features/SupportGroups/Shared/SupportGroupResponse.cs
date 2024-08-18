using IDMT.Domain.SupportGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.SupportGroups.Shared
{
    public sealed class SupportGroupResponse
    {
        public Guid Id { get; init; }

        public string Name { get; init; }
        public string Email { get; init; }
		public bool IsActive { get; init; }
	}

    public static class SupportGroupExtensions
    {
        public static IQueryable<SupportGroupResponse> ToResponse(this IQueryable<SupportGroup> source)
        {
            return source.Select(sg => new SupportGroupResponse 
            { Id = sg.Id, 
                Name = sg.Name,
                Email = sg.Email,
                IsActive = sg.IsActive
            });
        }
    }
}
