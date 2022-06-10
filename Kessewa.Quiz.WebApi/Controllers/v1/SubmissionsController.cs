using Kessewa.Application.Shared.Domain.Models;
using Kessewa.Quiz.Application.Features.Submissions.Commands;
using Kessewa.Quiz.Application.Features.Submissions.Queries;
using Kessewa.Quiz.Processors.Commands;
using Kessewa.Quiz.Processors.Dtos;
using Kessewa.Quiz.Processors.Dtos.PageDtos;
using Kessewa.Quiz.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Kessewa.Quiz.WebApi.Controllers.v1;

public class SubmissionsController : BaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(IEnumerable<PaginatedList<SubmissionPageDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<PaginatedList<SubmissionPageDto>> GetSubmissionsPage([FromBody] PaginatedCommand command) =>
        await Mediator.Send(new GetSubmissionPage.Query(command));

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<SubmissionDto> GetSubmission(int id) =>
        await Mediator.Send(new GetSubmission.Query(id));

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<int> CreateOrUpdate([FromBody] SubmissionCommand command) =>
        await Mediator.Send(new SaveSubmission.Command(command));

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task Delete(int id) =>
        await Mediator.Send(new DeleteSubmission.Command(id));
}