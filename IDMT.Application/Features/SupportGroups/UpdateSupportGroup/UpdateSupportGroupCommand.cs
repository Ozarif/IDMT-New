using IDMT.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.SupportGroups.UpdateSupportGroup;
public sealed record UpdateSupportGroupCommand(Guid Id,
		string Name,
		string Email) : ICommand;


