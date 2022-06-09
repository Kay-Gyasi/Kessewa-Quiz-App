using System.Threading;
using System.Threading.Tasks;
using Kessewa.Quiz.Processors.Processors.Administration;
using MediatR;

namespace Kessewa.Quiz.Application.Features
{
    public class InitializeDatabase
    {
        public class Command : IRequest
        {
            public Command()
            {
                
            }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly InitializeDbProcessor _processor;

            public Handler(InitializeDbProcessor processor)
            {
                _processor = processor;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _processor.InitializeDatabase();
                return Unit.Value;
            }
        }
    }
}