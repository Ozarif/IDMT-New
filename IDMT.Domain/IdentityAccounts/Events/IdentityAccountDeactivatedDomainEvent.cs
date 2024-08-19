
using IDMT.Domain.Abstractions;

namespace IDMT.Domain.IdentityAccounts.Events;

public sealed record IdentityAccountDeactivatedDomainEvent(Guid IdentityAccountId) : IDomainEvent;
