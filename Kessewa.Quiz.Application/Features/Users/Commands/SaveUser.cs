using System.Threading;
using System.Threading.Tasks;
using Kessewa.Quiz.Processors.Commands;
using Kessewa.Quiz.Processors.Processors;
using MediatR;

namespace Kessewa.Quiz.Application.Features.Users.Commands
{
    public class SaveUser
    {
        public class Command : IRequest<int>
        {
            public UserCommand UserCommand { get; }

            public Command(UserCommand command)
            {
                UserCommand = command;
            }
        }

        public class Handler : IRequestHandler<Command, int>
        {
            private readonly UserProcessor _processor;

            public Handler(UserProcessor processor)
            {
                _processor = processor;
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                return await _processor.SaveAsync(request.UserCommand);
            }

        }
    }
}