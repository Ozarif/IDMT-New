using IDMT.Domain.Abstractions;

namespace IDMT.Domain.Posts.Events;

public sealed record PostSubmittedDomainEvent(Guid EmployeeId) : IDomainEvent;
