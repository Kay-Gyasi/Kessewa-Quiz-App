using Kessewa.Quiz.Processors.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Kessewa.Quiz.Processors.Processors;

namespace Kessewa.Quiz.Application.Features.Faculties.Queries
{
    public class GetFaculty
    {
        public class Query : IRequest<FacultyDto>
        {
            public int FacultyId { get; }

            public Query(int facultyId)
            {
                FacultyId = facultyId;
            }
        }

        public class Handler : IRequestHandler<Query, FacultyDto>
        {
            private readonly FacultyProcessor _facultyProcessor;

            public Handler(FacultyProcessor facultyProcessor)
            {
                _facultyProcessor = facultyProcessor;
            }
            public async Task<FacultyDto> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _facultyProcessor.GetAsync(request.FacultyId);
            }
        }
    }
}