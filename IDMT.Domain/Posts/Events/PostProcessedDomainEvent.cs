using IDMT.Domain.Abstractions;

namespace IDMT.Domain.Posts.Events;

public sealed record PostProcessedDomainEvent(Guid EmployeeId) : IDomainEvent;
