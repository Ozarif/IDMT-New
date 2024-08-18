using FluentValidation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.Employees.GetListOfEmployees;

internal class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
        public UpdateEmployeeCommandValidator()
        {
		RuleFor(c => c.Id).NotEmpty();
		RuleFor(c => c.HrId).NotEmpty();
		RuleFor(c => c.FirstName).NotEmpty();
		RuleFor(c => c.FatherName).NotEmpty();
		RuleFor(c => c.LastName).NotEmpty();
		RuleFor(c => c.HrJobId).NotEmpty();
	}
}
