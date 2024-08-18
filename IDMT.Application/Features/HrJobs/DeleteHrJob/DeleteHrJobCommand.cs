using IDMT.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.HrJobs.DeleteHrJob;
public sealed record DeleteHrJobCommand(Guid Id) : ICommand;

