using IDMT.Domain.Abstractions;

namespace IDMT.Domain.Posts.Events;

public sealed record PostCompletedDomainEvent(Guid EmployeeId) : IDomainEvent;
