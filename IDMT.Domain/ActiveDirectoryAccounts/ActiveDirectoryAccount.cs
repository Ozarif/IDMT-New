using IDMT.Domain.Abstractions;
using IDMT.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Domain.ActiveDirectoryAccounts
{
    public sealed class ActiveDirectoryAccount : AuditableEntity
    {
        private ActiveDirectoryAccount()
        {

        }
        internal ActiveDirectoryAccount(Guid id,
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

        public static ActiveDirectoryAccount Create(Guid EmployeeId, string LoginName, string Profile)
        {
            var account = new ActiveDirectoryAccount(Guid.NewGuid(), EmployeeId, LoginName, Profile);
            account.IsActive = true;
            account.SetAsMain(false);

            return account;

        }
        public void SetAsMain(bool isMain)
        {
            IsMain = isMain;
        }
    }
}
