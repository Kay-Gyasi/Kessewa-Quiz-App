using System.Threading;
using System.Threading.Tasks;
using Kessewa.Quiz.Processors.Processors;
using MediatR;

namespace Kessewa.Quiz.Application.Features.Faculties.Commands
{
    public class DeleteFaculty
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
            private readonly FacultyProcessor _facultyProcessor;

            public Handler(FacultyProcessor facultyProcessor)
            {
                _facultyProcessor = facultyProcessor;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _facultyProcessor.DeleteAsync(request.Id);
                return Unit.Value;
            }
        }
    }
}