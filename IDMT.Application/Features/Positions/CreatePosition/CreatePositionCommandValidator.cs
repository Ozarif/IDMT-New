using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.Positions.CreatePosition
{
    public class CreatePositionCommandValidator : AbstractValidator<CreatePositionCommand>
    {
        public CreatePositionCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}
