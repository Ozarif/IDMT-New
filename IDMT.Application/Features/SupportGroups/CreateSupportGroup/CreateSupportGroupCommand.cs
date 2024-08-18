using IDMT.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.SupportGroups.CreateSupportGroup
{
    public sealed record CreateSupportGroupCommand(
        string Name,
        string Email) : ICommand<Guid>;
}
