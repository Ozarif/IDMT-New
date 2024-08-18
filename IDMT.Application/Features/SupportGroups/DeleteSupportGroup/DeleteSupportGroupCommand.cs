using IDMT.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.SupportGroups.DeleteSupportGroup;
public sealed record DeleteSupportGroupCommand(Guid Id) : ICommand;

