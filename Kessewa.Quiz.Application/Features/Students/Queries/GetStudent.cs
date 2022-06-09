using System.Threading;
using System.Threading.Tasks;
using Kessewa.Quiz.Processors.Dtos;
using Kessewa.Quiz.Processors.Processors;
using MediatR;

namespace Kessewa.Student.Application.Features.Students.Queries
{
    public class GetStudent
    {
        public class Query : IRequest<StudentDto>
        {
            public int Id { get; }

            public Query(int id)
            {
                Id = id;
            }
        }

        public class Handler : IRequestHandler<Query, StudentDto>
        {
            private readonly StudentProcessor _processor;

            public Handler(StudentProcessor processor)
            {
                _processor = processor;
            }
            public async Task<StudentDto> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _processor.GetAsync(request.Id);
            }
        }
    }
}