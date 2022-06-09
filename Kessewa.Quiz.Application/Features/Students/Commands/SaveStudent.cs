using Kessewa.Quiz.Processors.Commands;
using Kessewa.Quiz.Processors.Processors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Kessewa.Student.Application.Features.Students.Commands
{
    public class SaveStudent
    {
        public class Command : IRequest<int>
        {
            public StudentCommand StudentCommand { get; }

            public Command(StudentCommand command)
            {
                StudentCommand = command;
            }
        }

        public class Handler : IRequestHandler<Command, int>
        {
            private readonly StudentProcessor _processor;

            public Handler(StudentProcessor processor)
            {
                _processor = processor;
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                return await _processor.SaveAsync(request.StudentCommand);
            }
        }
    }
}