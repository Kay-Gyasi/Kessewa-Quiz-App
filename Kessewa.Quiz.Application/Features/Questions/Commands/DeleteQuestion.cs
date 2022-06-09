using System.Threading;
using System.Threading.Tasks;
using Kessewa.Quiz.Processors.Processors;
using MediatR;

namespace Kessewa.Quiz.Application.Features.Questions.Commands
{
    public class DeleteQuestion
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
            private readonly QuestionProcessor _questionProcessor;
            public Handler(QuestionProcessor questionProcessor)
            {
                _questionProcessor = questionProcessor;
            }
            
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _questionProcessor.DeleteAsync(request.Id);
                return Unit.Value;
            }
        }
    }
}