using Kessewa.Application.Shared.Domain.Models;
using Kessewa.Quiz.Processors.Commands;
using Kessewa.Quiz.Processors.Dtos;
using Kessewa.Quiz.Processors.Dtos.PageDtos;
using Kessewa.Quiz.WebApi.Controllers.Base;
using Kessewa.Student.Application.Features.Students.Commands;
using Kessewa.Student.Application.Features.Students.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Kessewa.Student.WebApi.Controllers.v1;

public class StudentsController : BaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(IEnumerable<PaginatedList<StudentPageDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<PaginatedList<StudentPageDto>> GetStudentsPage([FromBody] PaginatedCommand command) =>
        await Mediator.Send(new GetStudentPage.Query(command));

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<StudentDto> GetStudent(int id) =>
        await Mediator.Send(new GetStudent.Query(id));

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<int> CreateOrUpdate([FromBody] StudentCommand command) =>
        await Mediator.Send(new SaveStudent.Command(command));

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task Delete(int id) =>
        await Mediator.Send(new DeleteStudent.Command(id));
}