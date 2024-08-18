using IDMT.Application.Abstractions.Messaging;
using IDMT.Application.Features.SupportGroups.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.SupportGroups.GetSupportGroup
{
    public sealed record GetSupportGroupQuery(Guid id) : IQuery<SupportGroupResponse>;

}
