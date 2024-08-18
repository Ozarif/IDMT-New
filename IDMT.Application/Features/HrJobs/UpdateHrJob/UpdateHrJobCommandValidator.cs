using FluentValidation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.HrJobs.UpdateHrJob
{
	internal class UpdateHrJobCommandValidator : AbstractValidator<UpdateHrJobCommand>
	{
        public UpdateHrJobCommandValidator()
        {
			RuleFor(c => c.Id).NotEmpty();
			RuleFor(c => c.Name).NotEmpty();
		}
    }
}
