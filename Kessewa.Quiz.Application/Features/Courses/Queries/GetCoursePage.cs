using System.Threading;
using System.Threading.Tasks;
using Kessewa.Application.Shared.Domain.Models;
using Kessewa.Quiz.Processors.Dtos.PageDtos;
using Kessewa.Quiz.Processors.Processors;
using MediatR;

namespace Kessewa.Quiz.Application.Features.Courses.Queries
{
    public class GetCoursePage
    {
        public class Query : IRequest<PaginatedList<CoursePageDto>>
        {
            public PaginatedCommand Paginated { get; }

            public Query(PaginatedCommand paginated)
            {
                Paginated = paginated;
            }
        }

        public class Handler : IRequestHandler<Query, PaginatedList<CoursePageDto>>
        {
            private readonly CourseProcessor _courseProcessor;

            public Handler(CourseProcessor courseProcessor)
            {
                _courseProcessor = courseProcessor;
            }
            public async Task<PaginatedList<CoursePageDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _courseProcessor.GetPage(request.Paginated);
            }
        }
    }
}