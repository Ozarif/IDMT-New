using FluentValidation;
using IDMT.Application.Features.HrJobs.CreateHrJob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.HrJobs.GetListOfHrJobs
{
	internal class GetHrJobsInPagedListQueryValidator : AbstractValidator<GetHrJobsInPagedListQuery>
	{
        public GetHrJobsInPagedListQueryValidator()
        {
            RuleFor(c => c.PageNumber).NotNull();
			RuleFor(c => c.PageSize).NotNull();
        }
    }
}
