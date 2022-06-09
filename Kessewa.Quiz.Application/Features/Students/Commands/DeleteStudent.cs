using System.Threading;
using System.Threading.Tasks;
using Kessewa.Quiz.Processors.Processors;
using MediatR;

namespace Kessewa.Student.Application.Features.Students.Commands
{
    public class DeleteStudent
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
            private readonly StudentProcessor _processor;

            public Handler(StudentProcessor processor)
            {
                _processor = processor;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _processor.DeleteAsync(request.Id);
                return Unit.Value;
            }
        }
    }
}