using System.Threading;
using System.Threading.Tasks;
using Kessewa.Application.Shared.Domain.Models;
using Kessewa.Quiz.Processors.Dtos.PageDtos;
using Kessewa.Quiz.Processors.Processors;
using MediatR;

namespace Kessewa.Quiz.Application.Features.Quizzes.Queries
{
    public class GetQuizPage
    {
        public class Query : IRequest<PaginatedList<QuizPageDto>>
        {
            public PaginatedCommand Paginated { get; }

            public Query(PaginatedCommand paginated)
            {
                Paginated = paginated;
            }
        }

        public class Handler : IRequestHandler<Query, PaginatedList<QuizPageDto>>
        {
            private readonly QuizProcessor _processor;

            public Handler(QuizProcessor processor)
            {
                _processor = processor;
            }
            public async Task<PaginatedList<QuizPageDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _processor.GetPageAsync(request.Paginated);
            }
        }
    }
}