using System.Threading;
using System.Threading.Tasks;
using Kessewa.Quiz.Processors.Commands;
using Kessewa.Quiz.Processors.Processors;
using MediatR;

namespace Kessewa.Quiz.Application.Features.Departments.Commands
{
    public class SaveDepartment
    {
        public class Command : IRequest<int>
        {
            public DepartmentCommand DepartmentCommand { get; }

            public Command(DepartmentCommand departmentCommand)
            {
                DepartmentCommand = departmentCommand;
            }
        }

        public class Handler : IRequestHandler<Command, int>
        {
            private readonly DepartmentProcessor _processor;

            public Handler(DepartmentProcessor processor)
            {
                _processor = processor;
            }
            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                return await _processor.SaveAsync(request.DepartmentCommand);
            }
        }
    }
}