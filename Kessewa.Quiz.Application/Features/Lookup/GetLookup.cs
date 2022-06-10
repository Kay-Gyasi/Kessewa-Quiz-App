using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kessewa.Quiz.Processors.Processors;
using MediatR;

namespace Kessewa.Quiz.Application.Features.Lookup
{
    public class GetLookup
    {
        public class Query : IRequest<List<Domain.ViewModels.Lookup>>
        {
            public LookupType Type { get; }
            public Query(LookupType lookupType)
            {
                Type = lookupType;
            }
        }

        public class Handler : IRequestHandler<Query, List<Domain.ViewModels.Lookup>>
        {
            private readonly LookupProcessor _processor;

            public Handler(LookupProcessor processor)
            {
                _processor = processor;
            }
            public async Task<List<Domain.ViewModels.Lookup>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _processor.GetLookup(request.Type);
            }
        }
    }
}