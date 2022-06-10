using Kessewa.Quiz.Application.Features.Lookup;
using Kessewa.Quiz.Domain.ViewModels;
using Kessewa.Quiz.Processors.Processors;
using Kessewa.Quiz.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Kessewa.Quiz.WebApi.Controllers.v1;

public class LookupController : BaseController
{
    [HttpGet("{type}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<List<Lookup>> GetLookup(LookupType type) => await Mediator.Send(new GetLookup.Query(type));
}