using Kessewa.Quiz.Processors.Dtos;
using Kessewa.Quiz.Processors.Processors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Kessewa.Quiz.Application.Features.Courses.Queries
{
    public class GetCourse
    {
        public class Query : IRequest<CourseDto>
        {
            public int Id { get; }

            public Query(int id)
            {
                Id = id;
            }
        }

        public class Handler : IRequestHandler<Query, CourseDto>
        {
            private readonly CourseProcessor _courseProcessor;

            public Handler(CourseProcessor courseProcessor)
            {
                _courseProcessor = courseProcessor;
            }
            public async Task<CourseDto> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _courseProcessor.GetAsync(request.Id);
            }
        }
    }
}