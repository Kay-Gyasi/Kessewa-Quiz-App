using System.Threading;
using System.Threading.Tasks;
using Kessewa.Quiz.Processors.Dtos;
using Kessewa.Quiz.Processors.Processors;
using MediatR;

namespace Kessewa.Quiz.Application.Features.Questions.Queries
{
    public class GetQuestion
    {
        public class Query : IRequest<QuestionDto>
        {
            public int Id { get; }

            public Query(int id)
            {
                Id = id;
            }
        }

        public class Handler : IRequestHandler<Query, QuestionDto>
        {
            private readonly QuestionProcessor _processor;

            public Handler(QuestionProcessor processor)
            {
                _processor = processor;
            }
            public async Task<QuestionDto> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _processor.GetAsync(request.Id);
            }
        }

    }

}