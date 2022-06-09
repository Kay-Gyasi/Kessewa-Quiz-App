using System.Threading;
using System.Threading.Tasks;
using Kessewa.Quiz.Processors.Dtos;
using Kessewa.Quiz.Processors.Processors;
using MediatR;

namespace Kessewa.Quiz.Application.Features.Lecturers.Queries
{
    public class GetLecturer
    {
        public class Query : IRequest<LecturerDto>
        {
            public int Id { get; }

            public Query(int id)
            {
                Id = id;
            }
        }

        public class Handler : IRequestHandler<Query, LecturerDto>
        {
            private readonly LecturerProcessor _processor;

            public Handler(LecturerProcessor processor)
            {
                _processor = processor;
            }
            public async Task<LecturerDto> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _processor.GetAsync(request.Id);
            }
        }
    }
}