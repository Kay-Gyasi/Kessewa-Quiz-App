using System.Threading;
using System.Threading.Tasks;
using Kessewa.Quiz.Processors.Commands;
using Kessewa.Quiz.Processors.Processors;
using MediatR;

namespace Kessewa.Quiz.Application.Features.Faculties.Commands
{
    public class SaveFaculty
    {
        public class Command : IRequest<int>
        {
            public FacultyCommand FacultyCommand { get; }

            public Command(FacultyCommand command)
            {
                FacultyCommand = command;
            }
        }

        public class Handler : IRequestHandler<Command, int>
        {
            private readonly FacultyProcessor _facultyProcessor;

            public Handler(FacultyProcessor facultyProcessor)
            {
                _facultyProcessor = facultyProcessor;
            }
            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                return await _facultyProcessor.SaveAsync(request.FacultyCommand);
            }
        }
    }
}