using System.Threading;
using System.Threading.Tasks;
using Kessewa.Quiz.Processors.Commands;
using Kessewa.Quiz.Processors.Processors;
using MediatR;

namespace Kessewa.Quiz.Application.Features.Courses.Commands
{
    public class SaveCourse
    {
        public class Command : IRequest<int>
        {
            public CourseCommand CourseCommand { get; }

            public Command(CourseCommand courseCommand)
            {
                CourseCommand = courseCommand;
            }
        }

        public class Handler : IRequestHandler<Command, int>
        {
            private readonly CourseProcessor _courseProcessor;

            public Handler(CourseProcessor courseProcessor)
            {
                _courseProcessor = courseProcessor;
            }
            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                return await _courseProcessor.SaveAsync(request.CourseCommand);
            }
        }
    }
}