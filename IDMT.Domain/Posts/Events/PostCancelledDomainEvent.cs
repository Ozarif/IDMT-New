using IDMT.Domain.Abstractions;

namespace IDMT.Domain.Posts.Events;

public sealed record PostCancelledDomainEvent(Guid EmployeeId) : IDomainEvent;
