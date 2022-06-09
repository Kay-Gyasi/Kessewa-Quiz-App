using System.Threading;
using System.Threading.Tasks;
using Kessewa.Quiz.Processors;
using MediatR;

namespace Kessewa.Quiz.Application.Features.Users.Commands
{
    public class DeleteUser
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
            private readonly UserProcessor _processor;

            public Handler(UserProcessor processor)
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