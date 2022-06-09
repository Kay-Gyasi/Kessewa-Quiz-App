using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Kessewa.Quiz.Domain.Entities;
using Kessewa.Quiz.Processors.Dtos;
using Kessewa.Quiz.Processors.Processors;

namespace Kessewa.Quiz.Application.Features.Departments.Queries
{
    public class GetDepartment
    {
        public class Query : IRequest<DepartmentDto>
        {
            public int Id { get; }

            public Query(int id)
            {
                Id = id;
            }
        }

        public class Handler : IRequestHandler<Query, DepartmentDto>
        {
            private readonly DepartmentProcessor _processor;

            public Handler(DepartmentProcessor processor)
            {
                _processor = processor;
            }
            public async Task<DepartmentDto> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _processor.GetAsync(request.Id);
            }
        }
    }
}