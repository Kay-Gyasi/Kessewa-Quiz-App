using System.Threading;
using System.Threading.Tasks;
using Kessewa.Quiz.Processors.Dtos;
using Kessewa.Quiz.Processors.Processors;
using MediatR;

namespace Kessewa.Quiz.Application.Features.Quizzes.Queries
{
    public class GetQuiz
    {
        public class Query : IRequest<QuizDto>
        {
            public int Id { get; }

            public Query(int id)
            {
                Id = id;
            }
        }

        public class Handler : IRequestHandler<Query, QuizDto>
        {
            private readonly QuizProcessor _processor;

            public Handler(QuizProcessor processor)
            {
                _processor = processor;
            }
            public async Task<QuizDto> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _processor.GetAsync(request.Id);
            }
        }
    }
}