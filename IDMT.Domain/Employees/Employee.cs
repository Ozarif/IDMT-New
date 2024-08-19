using IDMT.Domain.Abstractions;
using IDMT.Domain.Employees.Events;
using IDMT.Domain.HrJobs;
using IDMT.Domain.IdentityAccounts;

namespace IDMT.Domain.Employees
{
	public sealed class Employee : Entity
	{
		private readonly HashSet<IdentityAccount> _identityAccounts = new();
		private Employee(Guid Id, 
						string hrId, 
						string firstName, 
						string fatherName, 
						string lastName, 
						string? spouseName,
						Guid hrJobId) : base (Id) { 
			HrId = hrId;
			FirstName = firstName;
			FatherName = fatherName;
			LastName = lastName;
			SpouseName = spouseName;
			HrJobId = hrJobId;
		
		}
        public string HrId { get; private set; }
		public string FirstName { get; private set; }
		public string FatherName { get; private set; }
		public string LastName { get; private set; }
		public string? SpouseName { get; private set; }
		public Guid HrJobId {  get; private set; }
		public Status Status { get; private set; }
		public DateTime? CreatedOn { get; private set; }
		public DateTime? UpdatedOn { get; private set; }
		public DateTime? TerminationDate { get; private set; }
		public DateTime? LastPostDate { get; internal set; }
		public string FullName => new($"{FirstName} {FatherName} {LastName}");

		public IReadOnlyCollection<IdentityAccount> IdentityAccounts => _identityAccounts.ToList();

		public static Employee Create(string hrId,
						string firstName,
						string fatherName,
						string lastName,
						string? spouseName,
						HrJob hrJob)
		{
			var employee =  new Employee(Guid.NewGuid(),hrId,firstName,fatherName,lastName, spouseName, hrJob.Id);
			employee.CreatedOn = employee.UpdatedOn = DateTime.UtcNow;
			employee.Status = Status.ACTIVE;
			employee.RaiseDomainEvent(new EmployeeCreatedDomainEvent(employee.Id));
			return employee;
			
		}

		public Result Update(string hrId,
						string firstName,
						string fatherName,
						string lastName,
						string? spouseName,
						HrJob hrJob)
		{
			HrId = hrId;
			FirstName = firstName;
			LastName = lastName;
			FatherName = fatherName;
			SpouseName = spouseName;
			HrJobId = hrJob.Id;

			return Result.Success();
		}

		public Result AddIdentityAccount(string LoginName, string Profile, bool SetAsMainAccount)
		{
			var newIdentityAccount = IdentityAccount.Create(Id, LoginName, Profile);
			newIdentityAccount.SetAsMain(SetAsMainAccount);


			_identityAccounts.Add(newIdentityAccount);
			return Result.Success();
		}

		public Result Terminate()
		{
			if (Status is not Status.TERMINATED)
			{
				Status = Status.TERMINATED;
				TerminationDate = UpdatedOn = DateTime.UtcNow;

				foreach(var identityAccount in _identityAccounts){
					identityAccount.Deactivate();
				}

				RaiseDomainEvent(new EmployeeTerminatedDomainEvent(Id));
			}
			return Result.Success();
		}
	}
}
