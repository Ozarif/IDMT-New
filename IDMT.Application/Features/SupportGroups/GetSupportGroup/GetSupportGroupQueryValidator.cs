using FluentValidation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.SupportGroups.GetSupportGroup
{
	internal class GetSupportGroupQueryValidator : AbstractValidator<GetSupportGroupQuery>
	{
        public GetSupportGroupQueryValidator()
        {
            RuleFor(c => c.id).NotEmpty();
        }
    }
}
