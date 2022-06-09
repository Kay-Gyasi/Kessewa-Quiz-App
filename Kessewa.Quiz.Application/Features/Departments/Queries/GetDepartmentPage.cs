using System.Threading;
using System.Threading.Tasks;
using Kessewa.Application.Shared.Domain.Models;
using Kessewa.Quiz.Processors.Dtos.PageDtos;
using Kessewa.Quiz.Processors.Processors;
using MediatR;

namespace Kessewa.Quiz.Application.Features.Departments.Queries
{
    public class GetDepartmentPage
    {
        public class Query : IRequest<PaginatedList<DepartmentPageDto>>
        {
            public PaginatedCommand Paginated { get; }

            public Query(PaginatedCommand paginated)
            {
                Paginated = paginated;
            }
        }

        public class Handler : IRequestHandler<Query, PaginatedList<DepartmentPageDto>>
        {
            private readonly DepartmentProcessor _processor;

            public Handler(DepartmentProcessor processor)
            {
                _processor = processor;
            }
            public async Task<PaginatedList<DepartmentPageDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _processor.GetPageAsync(request.Paginated);
            }
        }
    }
}