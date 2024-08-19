using IDMT.Domain.Abstractions;


namespace IDMT.Domain.IdentityAccounts.Events;

public sealed record IdentityAccountMainChangedDomainEvent(Guid IdentityAccountId) : IDomainEvent;

