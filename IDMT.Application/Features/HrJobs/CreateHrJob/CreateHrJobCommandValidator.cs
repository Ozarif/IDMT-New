using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.HrJobs.CreateHrJob
{
    internal class CreateHrJobCommandValidator : AbstractValidator<CreateHrJobCommand>
    {
        public CreateHrJobCommandValidator()
        {
            RuleFor(h => h.Name).NotEmpty();
        }
    }
}
