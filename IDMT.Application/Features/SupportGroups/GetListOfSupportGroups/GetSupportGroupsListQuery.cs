using IDMT.Application.Abstractions.Messaging;
using IDMT.Application.Features.SupportGroups.Shared;
using IDMT.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.SupportGroups.GetListOfSupportGroups;

public sealed record GetSupportGroupsListQuery(bool? isActive) : IQuery<IReadOnlyList<SupportGroupResponse>>;

