using IDMT.Domain.Abstractions;
using IDMT.Domain.Employees.Events;
using IDMT.Domain.Shared;
using IDMT.Domain.SupportGroups.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Domain.SupportGroups
{
    public sealed class SupportGroup : Entity
	{

		private SupportGroup(Guid id, string name, string email) : base(id)
		{
			Name = name;
			Email = email;
		}
        private SupportGroup()
        {          
        }
	
        public string Name { get; private set; }
		public string Email { get; private set; }

		public void Update(string newName,string newEmail)
		{
			Name = newName;
			Email = newEmail;
			RaiseDomainEvent(new SupportGroupUpdatedDomainEvent(Id));
		}

		public void Delete()
		{
			IsActive = false;
			RaiseDomainEvent(new SupportGroupDeletedDomainEvent(Id));
		}
		public void Activate()
		{
			IsActive = true;
		}
		public bool IsActive { get; private set; }

		public static SupportGroup Create(string name, string email)
		{
			var supportGroup = new SupportGroup(Guid.NewGuid(), name, email);
			supportGroup.Activate();

			supportGroup.RaiseDomainEvent(new SupportGroupCreatedDomainEvent(supportGroup.Id));
			return supportGroup;
		}
	}
}
