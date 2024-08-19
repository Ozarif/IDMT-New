using IDMT.Domain.Abstractions;
using IDMT.Domain.IdentityAccounts.Events;
using IDMT.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Domain.IdentityAccounts
{
    public sealed class IdentityAccount : AuditableEntity
    {
        private IdentityAccount()
        {}
        internal IdentityAccount(Guid id,
                        Guid employeeId,
                        string loginName,
                        string domain,
                        string profile) : base(id)
        {
            EmployeeId = employeeId;
            LoginName = loginName;
            Domain = domain;
            Profile = profile;
        }

        public Guid EmployeeId { get; private set; }
        public string LoginName { get; private set; }
        public string Domain { get; private set; }
        public string Profile { get; private set; }
        public bool IsMain { get; private set; }
        public bool IsActive { get; private set; }

        public static IdentityAccount Create(Guid EmployeeId, string LoginName, string domain, string Profile)
        {
            var newIdentityAccount = new IdentityAccount(Guid.NewGuid(), EmployeeId, LoginName, domain, Profile);
            newIdentityAccount.Activate();
            newIdentityAccount.IsMain = false;
            newIdentityAccount.RaiseDomainEvent(new IdentityAccountCreatedDomainEvent(newIdentityAccount.Id));
            return newIdentityAccount;

        }
        internal Result SetAsMain()
        {
            IsMain = true;
            RaiseDomainEvent(new IdentityAccountMainChangedDomainEvent(Id));
            return Result.Success();
        }
        internal Result Activate()
        {
            IsActive = true;
            return Result.Success();
        }
        internal Result Deactivate()
        {
            IsActive = false;
            RaiseDomainEvent(new IdentityAccountDeactivatedDomainEvent(Id));
            return Result.Success();
        }
    }
}
