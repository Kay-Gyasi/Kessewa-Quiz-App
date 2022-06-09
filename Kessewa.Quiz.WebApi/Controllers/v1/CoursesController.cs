using Kessewa.Application.Shared.Domain.Models;
using Kessewa.Quiz.Application.Features.Courses.Commands;
using Kessewa.Quiz.Application.Features.Courses.Queries;
using Kessewa.Quiz.Processors.Commands;
using Kessewa.Quiz.Processors.Dtos;
using Kessewa.Quiz.Processors.Dtos.PageDtos;
using Kessewa.Quiz.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Kessewa.Quiz.WebApi.Controllers.v1;

public class CoursesController : BaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(IEnumerable<PaginatedList<CoursePageDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<PaginatedList<CoursePageDto>> GetCoursesPage([FromBody] PaginatedCommand command) =>
        await Mediator.Send(new GetCoursePage.Query(command));

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<CourseDto> GetCourse(int id) =>
        await Mediator.Send(new GetCourse.Query(id));

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<int> CreateOrUpdate([FromBody] CourseCommand Course) =>
        await Mediator.Send(new SaveCourse.Command(Course));

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task Delete(int id) =>
        await Mediator.Send(new DeleteCourse.Command(id));
}