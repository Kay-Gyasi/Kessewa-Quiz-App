using System.Threading;
using System.Threading.Tasks;
using Kessewa.Application.Shared.Domain.Models;
using Kessewa.Quiz.Processors.Dtos.PageDtos;
using Kessewa.Quiz.Processors.Processors;
using MediatR;

namespace Kessewa.Quiz.Application.Features.Submissions.Queries
{
    public class GetSubmissionPage
    {
        public class Query : IRequest<PaginatedList<SubmissionPageDto>>
        {
            public PaginatedCommand Paginated { get; }

            public Query(PaginatedCommand paginated)
            {
                Paginated = paginated;
            }
        }

        public class Handler : IRequestHandler<Query, PaginatedList<SubmissionPageDto>>
        {
            private readonly SubmissionProcessor _processor;

            public Handler(SubmissionProcessor processor)
            {
                _processor = processor;
            }
            public async Task<PaginatedList<SubmissionPageDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _processor.GetPageAsync(request.Paginated);
            }
        }
    }
}