using System.Threading;
using System.Threading.Tasks;
using Kessewa.Application.Shared.Domain.Models;
using Kessewa.Quiz.Processors;
using Kessewa.Quiz.Processors.Dtos.PageDtos;
using MediatR;

namespace Kessewa.Quiz.Application.Features.Users.Queries
{
    public class GetUserPage
    {
        public class Query : IRequest<PaginatedList<UserPageDto>>
        {
            public PaginatedCommand Paginated { get; }

            public Query(PaginatedCommand paginated)
            {
                Paginated = paginated;
            }
        }

        public class Handler : IRequestHandler<Query, PaginatedList<UserPageDto>>
        {
            private readonly UserProcessor _processor;

            public Handler(UserProcessor processor)
            {
                _processor = processor;
            }
            public async Task<PaginatedList<UserPageDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _processor.GetPageAsync(request.Paginated);
            }
        }
    }
}