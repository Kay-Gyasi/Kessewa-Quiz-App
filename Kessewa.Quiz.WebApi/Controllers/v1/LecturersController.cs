using Kessewa.Application.Shared.Domain.Models;
using Kessewa.Quiz.Application.Features.Lecturers.Commands;
using Kessewa.Quiz.Application.Features.Lecturers.Queries;
using Kessewa.Quiz.Processors.Commands;
using Kessewa.Quiz.Processors.Dtos;
using Kessewa.Quiz.Processors.Dtos.PageDtos;
using Kessewa.Quiz.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Kessewa.Quiz.WebApi.Controllers.v1;

public class LecturersController : BaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(IEnumerable<PaginatedList<LecturerPageDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<PaginatedList<LecturerPageDto>> GetLecturersPage([FromBody] PaginatedCommand command) =>
        await Mediator.Send(new GetLecturerPage.Query(command));

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<LecturerDto> GetLecturer(int id) =>
        await Mediator.Send(new GetLecturer.Query(id));

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<int> CreateOrUpdate([FromBody] LecturerCommand command) =>
        await Mediator.Send(new SaveLecturer.Command(command));

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task Delete(int id) =>
        await Mediator.Send(new DeleteLecturer.Command(id));
}