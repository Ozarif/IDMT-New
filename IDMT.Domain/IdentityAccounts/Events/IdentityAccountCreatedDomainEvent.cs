using IDMT.Domain.Abstractions;


namespace IDMT.Domain.IdentityAccounts.Events;

public sealed record IdentityAccountCreatedDomainEvent(Guid IdentityAccountId) : IDomainEvent;
