using IDMT.Domain.Abstractions;
using IDMT.Domain.Employees;
using IDMT.Domain.Posts.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Domain.Posts;

public sealed class Post : AuditableEntity
{
	private readonly HashSet<PostResource> _postResources = new();
    private Post()
    {
        
    }
    private Post(Guid id,
				Guid employeeId,
				PostType type,
				Guid positionId
,				DateRange duration)
		: base(id)
	{
		EmployeeId = employeeId;
		Type = type;
		PositionId = positionId;
		Duration = duration;
	}
	public Guid EmployeeId { get; private set; }
	public PostType Type { get; private set; }
	public Guid PositionId { get; private set; }
	public DateRange Duration { get; private set; }
	public Guid UserId { get; private set; }
	public DateTime CreatedDate { get; private set; }
	public DateTime? CompletedDate { get; private set; }
	public bool IsSubmitted { get; private set; } 
	public DateTime? SubmittedDate { get; private set; }
	public DateTime? UpdatedDate { get; private set; }
	public PostStatus Status { get; private set; }
	public CurrentFlow CurrentFlow { get; private set; }
	public IReadOnlyCollection<PostResource> ResourcesSettings => _postResources.ToList();
	public Result Submit(DateTime utcNow)
	{
		if (Status != PostStatus.Pending)
		{
			return Result.Failure(PostErrors.NotSubmitted);
		}
		IsSubmitted = true;
		SubmittedDate = UpdatedDate = utcNow;
		Status = PostStatus.Active;

		RaiseDomainEvent(new PostSubmittedDomainEvent(Id));

		return Result.Success();
	}
	public Result Cancel(DateTime utcNow)
	{
		if (Status != PostStatus.Pending)
		{
			return Result.Failure(PostErrors.NotCancelled);
		}

		var currentDate = DateOnly.FromDateTime(utcNow);

		if (currentDate > Duration.Start)
		{
			return Result.Failure(PostErrors.AlreadyStarted);
		}

		UpdatedDate = utcNow;
		Status = PostStatus.Cancelled;

		RaiseDomainEvent(new PostCancelledDomainEvent(Id));

		return Result.Success();
	}
	public Result Complete(DateTime utcNow)
	{
		if (Status != PostStatus.Active)
		{
			return Result.Failure(PostErrors.NotCompleted);
		}

		UpdatedDate = CompletedDate = utcNow;
		Status = PostStatus.Completed;

		RaiseDomainEvent(new PostCompletedDomainEvent(Id));

		return Result.Success();
	}


	// Add new method applied by Support Group

	public void AddResourceSettings(Guid resourceId,Guid resourceProfileId,string? resourceLoginName = null, string? note = null)
	{
		var postResource = new PostResource(Guid.NewGuid(),Id, resourceId, resourceProfileId,resourceLoginName, note);
		_postResources.Add(postResource);
	}
	public static Post Create(Employee employee,
					PostType type,
					Guid positionId,
					DateRange duration,
					Guid userId, 
					DateTime utcNow)
	{
		var request = new Post(Guid.NewGuid(), employee.Id, type, positionId, duration);
		request.UserId = userId;
		request.CreatedDate = utcNow;
		request.CurrentFlow = CurrentFlow.ISBC;
		request.Status = PostStatus.Pending;
		request.IsSubmitted = false;
		request.UpdatedDate = utcNow;
		employee.LastPostDate = utcNow;
		request.RaiseDomainEvent(new PostCreatedDomainEvent(request.Id));

		return request;
	}
}
