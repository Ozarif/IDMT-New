using FluentValidation;
using IDMT.Application.Features.HrJobs.CreateHrJob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.HrJobs.DeleteHrJob;

internal class DeleteHrJobCommandValidator : AbstractValidator<DeleteHrJobCommand>
{
    public DeleteHrJobCommandValidator()
    {
           RuleFor(c => c.Id).NotEmpty();
    }
}
