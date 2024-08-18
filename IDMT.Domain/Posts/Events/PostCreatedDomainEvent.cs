using IDMT.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Domain.Posts.Events;

public sealed record PostCreatedDomainEvent(Guid EmployeeId) : IDomainEvent;
