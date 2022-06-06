using System.Threading;
using System.Threading.Tasks;
using Kessewa.Application.Shared.Domain.Models;
using Kessewa.Quiz.Processors.Dtos.PageDtos;
using Kessewa.Quiz.Processors.Processors;
using MediatR;

namespace Kessewa.Quiz.Application.Features.Faculties.Queries
{
    public class GetFacultyPage
    {
        public class Query : IRequest<PaginatedList<FacultyPageDto>>
        {
            public PaginatedCommand Paginated { get; }

            public Query(PaginatedCommand paginated)
            {
                Paginated = paginated;
            }
        }

        public class Handler : IRequestHandler<Query, PaginatedList<FacultyPageDto>>
        {
            private readonly FacultyProcessor _facultyProcessor;

            public Handler(FacultyProcessor facultyProcessor)
            {
                _facultyProcessor = facultyProcessor;
            }
            public async Task<PaginatedList<FacultyPageDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _facultyProcessor.GetPage(request.Paginated);
            }
        }
    }
}