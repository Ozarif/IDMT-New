using IDMT.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.HrJobs.UpdateHrJob;
public sealed record UpdateHrJobCommand(Guid Id,
		string Name) : ICommand;


