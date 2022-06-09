using System.Threading;
using System.Threading.Tasks;
using Kessewa.Application.Shared.Domain.Models;
using Kessewa.Quiz.Processors.Dtos.PageDtos;
using Kessewa.Quiz.Processors.Processors;
using MediatR;

namespace Kessewa.Quiz.Application.Features.Questions.Queries
{
    public class GetQuestionPage
    {
        public class Query : IRequest<PaginatedList<QuestionPageDto>>
        {
            public PaginatedCommand Paginated { get; }

            public Query(PaginatedCommand paginated)
            {
                Paginated = paginated;
            }
        }

        public class Handler : IRequestHandler<Query, PaginatedList<QuestionPageDto>>
        {
            private readonly QuestionProcessor _processor;

            public Handler(QuestionProcessor processor)
            {
                _processor = processor;
            }
            public async Task<PaginatedList<QuestionPageDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _processor.GetPageAsync(request.Paginated);
            }
        }
    }
}