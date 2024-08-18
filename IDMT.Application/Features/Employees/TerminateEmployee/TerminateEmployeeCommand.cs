using IDMT.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.Employees.TerminateEmployee;

public sealed record TerminateEmployeeCommand(Guid Id) : ICommand<Guid>;
