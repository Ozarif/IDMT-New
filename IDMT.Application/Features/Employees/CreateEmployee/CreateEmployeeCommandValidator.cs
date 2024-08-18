using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.Employees.CreateEmployee;

internal class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(h => h.HrId).NotEmpty();
            RuleFor(h => h.FirstName).NotEmpty();
		    RuleFor(h => h.FatherName).NotEmpty();
		    RuleFor(h => h.LastName).NotEmpty();
		    RuleFor(h => h.HrJobId).NotEmpty();

	}
}

