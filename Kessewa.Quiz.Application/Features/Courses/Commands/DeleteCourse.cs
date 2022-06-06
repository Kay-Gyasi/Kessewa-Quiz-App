using Kessewa.Quiz.Processors.Processors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Kessewa.Quiz.Application.Features.Courses.Commands
{
    public class DeleteCourse
    {
        public class Command : IRequest
        {
            public int Id { get; }

            public Command(int id)
            {
                Id = id;
            }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly CourseProcessor _courseProcessor;

            public Handler(CourseProcessor courseProcessor)
            {
                _courseProcessor = courseProcessor;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _courseProcessor.DeleteAsync(request.Id);
                return Unit.Value;
            }
        }
    }
}