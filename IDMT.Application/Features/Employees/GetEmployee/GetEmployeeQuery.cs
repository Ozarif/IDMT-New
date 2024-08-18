using IDMT.Application.Abstractions.Messaging;
using IDMT.Application.Features.Employees.Shared;
using IDMT.Application.Features.HrJobs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.Employees.GetEmployee
{
    public sealed record GetEmployeeQuery(Guid id) : IQuery<EmployeeResponse>;
}
