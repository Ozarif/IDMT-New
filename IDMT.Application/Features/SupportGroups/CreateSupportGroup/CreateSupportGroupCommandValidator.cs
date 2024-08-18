using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.SupportGroups.CreateSupportGroup
{
    internal class CreateSupportGroupCommandValidator : AbstractValidator<CreateSupportGroupCommand>
    {
        public CreateSupportGroupCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Email).NotEmpty();
        }
    }
}
