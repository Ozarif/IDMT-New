using IDMT.Domain.Abstractions;
using IDMT.Domain.ActiveDirectoryAccounts;
using IDMT.Domain.Employees.Events;
using IDMT.Domain.HrJobs;

namespace IDMT.Domain.Employees
{
	public sealed class Employee : Entity
	{
		private readonly HashSet<ActiveDirectoryAccount> _accounts = new();
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

		public IReadOnlyCollection<ActiveDirectoryAccount> Accounts => _accounts.ToList();

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

		public Result AddActiveDirectoryAccount(string LoginName, string Profile, bool SetAsMainAccount)
		{
			var newAccount = ActiveDirectoryAccount.Create(Id, LoginName, Profile);
			newAccount.SetAsMain(SetAsMainAccount);


			_accounts.Add(newAccount);
			return Result.Success();
		}

		public Result Terminate()
		{
			if (Status is not Status.TERMINATED)
			{
				Status = Status.TERMINATED;
				TerminationDate = UpdatedOn = DateTime.UtcNow;
				RaiseDomainEvent(new EmployeeTerminatedDomainEvent(Id));
			}
			return Result.Success();
		}
	}
}
