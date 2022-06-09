using System.Threading;
using System.Threading.Tasks;
using Kessewa.Quiz.Processors.Commands;
using Kessewa.Quiz.Processors.Processors;
using MediatR;

namespace Kessewa.Quiz.Application.Features.Lecturers.Commands
{
    public class SaveLecturer
    {
        public class Command : IRequest<int>
        {
            public LecturerCommand LecturerCommand { get; }

            public Command(LecturerCommand command)
            {
                LecturerCommand = command;
            }
        }

        public class Handler : IRequestHandler<Command, int>
        {
            private readonly LecturerProcessor _processor;

            public Handler(LecturerProcessor processor)
            {
                _processor = processor;
            }
            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                return await _processor.SaveAsync(request.LecturerCommand);
            }
        }
    }
}