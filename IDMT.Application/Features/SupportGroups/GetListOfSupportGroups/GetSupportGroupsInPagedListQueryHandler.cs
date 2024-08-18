using IDMT.Application.Abstractions.Messaging;
using IDMT.Application.Features.SupportGroups.GetSupportGroup;
using IDMT.Application.Features.SupportGroups.Shared;
using IDMT.Domain.Abstractions;
using IDMT.Domain.SupportGroups;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.SupportGroups.GetListOfSupportGroups;
internal class GetSupportGroupsInPagedListQueryHandler : IQueryHandler<GetSupportGroupsInPagedListQuery, PagedList<SupportGroupResponse>>
{ 
	private readonly ISupportGroupRepository _supportGroupRepository;

	public GetSupportGroupsInPagedListQueryHandler(ISupportGroupRepository supportGroupRepository)
	{
		_supportGroupRepository = supportGroupRepository;
	}

	public async Task<Result<PagedList<SupportGroupResponse>>> Handle(GetSupportGroupsInPagedListQuery request, CancellationToken cancellationToken)
	{

		var supportGroupsList = await _supportGroupRepository.GetSupportGroupsAsync(request, cancellationToken);

	
		if (supportGroupsList is null)
		{
			return Result.Failure<PagedList<SupportGroupResponse>>(SupportGroupErrors.NotFound);

		}
		
		var supportGroupsPagedResponse = new PagedList<SupportGroupResponse>(supportGroupsList.Select(c => c.ToResponse()).ToList(),
																			supportGroupsList.TotalCount,
																			supportGroupsList.CurrentPage,
																			supportGroupsList.PageSize);


		return Result.Success(supportGroupsPagedResponse);

	}
}

