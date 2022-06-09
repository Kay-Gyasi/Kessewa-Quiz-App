using Kessewa.Application.Shared.Domain.Models;
using Kessewa.Quiz.Application.Features.Departments.Commands;
using Kessewa.Quiz.Application.Features.Departments.Queries;
using Kessewa.Quiz.Processors.Commands;
using Kessewa.Quiz.Processors.Dtos;
using Kessewa.Quiz.Processors.Dtos.PageDtos;
using Kessewa.Quiz.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Kessewa.Quiz.WebApi.Controllers.v1;

public class DepartmentsController : BaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(IEnumerable<PaginatedList<DepartmentPageDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<PaginatedList<DepartmentPageDto>> GetDepartmentsPage([FromBody] PaginatedCommand command) =>
        await Mediator.Send(new GetDepartmentPage.Query(command));

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<DepartmentDto> GetDepartment(int id) =>
        await Mediator.Send(new GetDepartment.Query(id));

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<int> CreateOrUpdate([FromBody] DepartmentCommand command) =>
        await Mediator.Send(new SaveDepartment.Command(command));

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task Delete(int id) =>
        await Mediator.Send(new DeleteDepartment.Command(id));
}