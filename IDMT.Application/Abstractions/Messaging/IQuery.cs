using IDMT.Domain.Abstractions;
using MediatR;

namespace IDMT.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
