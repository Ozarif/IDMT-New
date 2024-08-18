using FluentValidation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.SupportGroups.UpdateSupportGroup
{
	internal class UpdateSupportGroupCommandValidator : AbstractValidator<UpdateSupportGroupCommand>
	{
        public UpdateSupportGroupCommandValidator()
        {
			RuleFor(c => c.Id).NotEmpty();
			RuleFor(c => c.Name).NotEmpty();
			RuleFor(c => c.Email).NotEmpty();
		}
    }
}
