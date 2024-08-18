using IDMT.Application.Features.SupportGroups.Shared;
using IDMT.Domain.HrJobs;
using IDMT.Domain.SupportGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.HrJobs.Shared
{
    internal static class HrJobMapping
    {
        public static HrJobResponse ToResponse(this HrJob hrJob)
        {
            return new()
            {
                Id = hrJob.Id,
                Name = hrJob.Name
            };
        }

        public static IQueryable<HrJobResponse> ToIQueryableResponse(this IQueryable<HrJob> source)
        {
            return source.Select(hj => new HrJobResponse
            {
                Id = hj.Id,
                Name = hj.Name
            });
        }
    }
}
