using System.Threading;
using System.Threading.Tasks;
using Kessewa.Quiz.Processors.Commands;
using Kessewa.Quiz.Processors.Processors;
using MediatR;

namespace Kessewa.Quiz.Application.Features.Submissions.Commands
{
    public class SaveSubmission
    {
        public class Command : IRequest<int>
        {
            public SubmissionCommand SubmissionCommand { get; }

            public Command(SubmissionCommand command)
            {
                SubmissionCommand = command;
            }
        }

        public class Handler : IRequestHandler<Command, int>
        {
            private readonly SubmissionProcessor _processor;

            public Handler(SubmissionProcessor processor)
            {
                _processor = processor;
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                return await _processor.SaveAsync(request.SubmissionCommand);
            }

        }
    }
}