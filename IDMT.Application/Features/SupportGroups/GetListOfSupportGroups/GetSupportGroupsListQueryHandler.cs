using IDMT.Application.Abstractions.Messaging;
using IDMT.Application.Features.SupportGroups.Shared;
using IDMT.Domain.Abstractions;
using IDMT.Domain.SupportGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.SupportGroups.GetListOfSupportGroups;

//internal class GetSupportGroupsListQueryHandler : IQueryHandler<GetSupportGroupsListQuery, IReadOnlyList<SupportGroupResponse>>
//{
//	private readonly ISupportGroupRepository _employeeRepository;

//	public GetSupportGroupsListQueryHandler(ISupportGroupRepository supportGroupRepository)
//	{
//		_employeeRepository = supportGroupRepository;
//	}

//	public async Task<Result<IReadOnlyList<SupportGroupResponse>>> Handle(GetSupportGroupsListQuery request, CancellationToken cancellationToken)
//	{
//		IReadOnlyList<SupportGroup> supportGroups;

//		if (request.isActive.HasValue)
//			supportGroups = await _employeeRepository.GetSupportGroupsAsync(c => c.IsActive.Value == request.isActive.Value, cancellationToken);
//		else
//			supportGroups = await _employeeRepository.GetSupportGroupsAsync();




//		if (supportGroup is null)
//		{
//			return Result.Failure<PagedList<SupportGroupResponse>>(SupportGroupErrors.NotFound);

//		}


//	}
//}
