using System.Threading;
using System.Threading.Tasks;
using Kessewa.Application.Shared.Domain.Models;
using Kessewa.Quiz.Processors.Dtos.PageDtos;
using Kessewa.Quiz.Processors.Processors;
using MediatR;

namespace Kessewa.Quiz.Application.Features.Lecturers.Queries
{
    public class GetLecturerPage
    {
        public class Query : IRequest<PaginatedList<LecturerPageDto>>
        {
            public PaginatedCommand Paginated { get; }

            public Query(PaginatedCommand paginated)
            {
                Paginated = paginated;
            }
        }

        public class Handler : IRequestHandler<Query, PaginatedList<LecturerPageDto>>
        {
            private readonly LecturerProcessor _processor;

            public Handler(LecturerProcessor processor)
            {
                _processor = processor;
            }
            public async Task<PaginatedList<LecturerPageDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _processor.GetPageAsync(request.Paginated);
            }
        }
    }
}