using IDMT.Domain.Abstractions;
using IDMT.Domain.SupportGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Domain.Employees
{
	public interface IEmployeeRepository
	{
		Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
		Task<bool> AnyAsync(Expression<Func<Employee, bool>> filter, CancellationToken cancellationToken = default);
		Task<PagedList<Employee>> GetEmployeesAsync(EmployeePaginationParam employeeParams, CancellationToken cancellationToken = default);
		Task<IReadOnlyList<Employee>> GetEmployeesAsync(Expression<Func<Employee, bool>> filter, CancellationToken cancellationToken = default);
		Task CreateAsync(Employee employee);
		Task UpdateAsync(Employee employee);
	}

}
