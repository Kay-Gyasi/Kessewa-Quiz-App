using System.Threading;
using System.Threading.Tasks;
using Kessewa.Quiz.Processors;
using Kessewa.Quiz.Processors.Dtos;
using MediatR;

namespace Kessewa.Quiz.Application.Features.Users.Queries
{
    public class GetUser
    {
        public class Query : IRequest<UserDto>
        {
            public int Id { get; }

            public Query(int id)
            {
                Id = id;
            }
        }

        public class Handler : IRequestHandler<Query, UserDto>
        {
            private readonly UserProcessor _processor;

            public Handler(UserProcessor processor)
            {
                _processor = processor;
            }
            public async Task<UserDto> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _processor.GetAsync(request.Id);
            }
        }
    }
}