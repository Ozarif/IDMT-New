using IDMT.Application.Abstractions.Messaging;
using IDMT.Application.Features.HrJobs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.HrJobs.GetHrJob
{
    public sealed record GetHrJobQuery(Guid id) : IQuery<HrJobResponse>;
}
