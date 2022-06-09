using System.Threading;
using System.Threading.Tasks;
using Kessewa.Quiz.Processors.Dtos;
using Kessewa.Quiz.Processors.Processors;
using MediatR;

namespace Kessewa.Quiz.Application.Features.Submissions.Queries
{
    public class GetSubmission
    {
        public class Query : IRequest<SubmissionDto>
        {
            public int Id { get; }

            public Query(int id)
            {
                Id = id;
            }
        }

        public class Handler : IRequestHandler<Query, SubmissionDto>
        {
            private readonly SubmissionProcessor _processor;

            public Handler(SubmissionProcessor processor)
            {
                _processor = processor;
            }
            public async Task<SubmissionDto> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _processor.GetAsync(request.Id);
            }
        }
    }
}