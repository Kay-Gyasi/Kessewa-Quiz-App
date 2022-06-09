using System.Threading;
using System.Threading.Tasks;
using Kessewa.Quiz.Processors.Commands;
using Kessewa.Quiz.Processors.Processors;
using MediatR;

namespace Kessewa.Quiz.Application.Features.Quizzes.Commands
{
    public class SaveQuiz
    {
        public class Command : IRequest<int>
        {
            public QuizCommand QuizCommand { get; }

            public Command(QuizCommand command)
            {
                QuizCommand = command;
            }
        }

        public class Handler : IRequestHandler<Command, int>
        {
            private readonly QuizProcessor _processor;

            public Handler(QuizProcessor processor)
            {
                _processor = processor;
            }
            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                return await _processor.SaveAsync(request.QuizCommand);
            }
        }
    }
}