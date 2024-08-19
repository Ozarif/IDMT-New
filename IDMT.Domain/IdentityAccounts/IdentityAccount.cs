using IDMT.Domain.Abstractions;
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
                        string profile) : base(id)
        {
            EmployeeId = employeeId;
            LoginName = loginName;
            Profile = profile;
        }

        public Guid EmployeeId { get; private set; }
        public string LoginName { get; private set; }
        public string Profile { get; private set; }
        public bool IsMain { get; private set; }
        public bool IsActive { get; private set; }

        public static IdentityAccount Create(Guid EmployeeId, string LoginName, string Profile)
        {
            var account = new IdentityAccount(Guid.NewGuid(), EmployeeId, LoginName, Profile);
            account.Activate();
            account.SetAsMain(false);

            return account;

        }
        internal Result SetAsMain(bool isMain)
        {
            IsMain = isMain;
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
            return Result.Success();
        }
    }
}
