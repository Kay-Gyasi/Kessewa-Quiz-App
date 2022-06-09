using System.Threading;
using System.Threading.Tasks;
using Kessewa.Application.Shared.Domain.Models;
using Kessewa.Quiz.Processors.Dtos.PageDtos;
using Kessewa.Quiz.Processors.Processors;
using MediatR;

namespace Kessewa.Student.Application.Features.Students.Queries
{
    public class GetStudentPage
    {
        public class Query : IRequest<PaginatedList<StudentPageDto>>
        {
            public PaginatedCommand Paginated { get; }

            public Query(PaginatedCommand paginated)
            {
                Paginated = paginated;
            }
        }

        public class Handler : IRequestHandler<Query, PaginatedList<StudentPageDto>>
        {
            private readonly StudentProcessor _processor;

            public Handler(StudentProcessor processor)
            {
                _processor = processor;
            }
            public async Task<PaginatedList<StudentPageDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _processor.GetPageAsync(request.Paginated);
            }
        }
    }
}