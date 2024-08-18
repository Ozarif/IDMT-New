using IDMT.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Domain.Employees.Events;

public sealed record EmployeeCreatedDomainEvent(Guid EmployeeId) : IDomainEvent;
