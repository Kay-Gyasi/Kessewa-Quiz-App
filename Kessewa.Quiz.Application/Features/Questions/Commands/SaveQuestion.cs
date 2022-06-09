using System.Threading;
using System.Threading.Tasks;
using Kessewa.Quiz.Processors.Commands;
using Kessewa.Quiz.Processors.Processors;
using MediatR;

namespace Kessewa.Quiz.Application.Features.Questions.Commands
{
    public class SaveQuestion
    {
        public class Command : IRequest<int>
        {
            public QuestionCommand QuestionCommand { get; }

            public Command(QuestionCommand command)
            {
                QuestionCommand = command;
            }
        }

        public class Handler : IRequestHandler<Command, int>
        {
            private readonly QuestionProcessor _processor;

            public Handler(QuestionProcessor processor)
            {
                _processor = processor;
            }
            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                return await _processor.SaveAsync(request.QuestionCommand);
            }
        }
    }
}