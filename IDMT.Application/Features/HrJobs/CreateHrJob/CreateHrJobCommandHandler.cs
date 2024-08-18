using IDMT.Application.Abstractions.Messaging;
using IDMT.Domain.Abstractions;
using IDMT.Domain.HrJobs;
using IDMT.Domain.Shared;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.HrJobs.CreateHrJob
{
    internal class CreateHrJobCommandHandler : ICommandHandler<CreateHrJobCommand, Guid>
    {
        private readonly IHrJobRepository _hrJobRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateHrJobCommandHandler(IHrJobRepository hrJobRepository, IUnitOfWork unitOfWork)
        {
            _hrJobRepository = hrJobRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreateHrJobCommand request, CancellationToken cancellationToken)
        {

            if(await _hrJobRepository.AnyAsync(r => r.Name.ToLower() == request.Name.ToLower(), cancellationToken)){
                return Result.Failure<Guid>(HrJobErrors.AlreadyExists);
            }

            var hrJob = HrJob.Create(request.Name);

            await _hrJobRepository.CreateAsync(hrJob);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return hrJob.Id;
        }
    }
}
