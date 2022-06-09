using Kessewa.Application.Shared.Domain.Models;
using Kessewa.Quiz.Application.Features.Users.Commands;
using Kessewa.Quiz.Application.Features.Users.Queries;
using Kessewa.Quiz.Processors.Commands;
using Kessewa.Quiz.Processors.Dtos;
using Kessewa.Quiz.Processors.Dtos.PageDtos;
using Kessewa.Quiz.WebApi.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kessewa.Quiz.WebApi.Controllers.v1;

public class UsersController : BaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(IEnumerable<PaginatedList<UserPageDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<PaginatedList<UserPageDto>> GetUsersPage([FromBody] PaginatedCommand command) =>
        await Mediator.Send(new GetUserPage.Query(command));

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<UserDto> GetUser(int id) =>
        await Mediator.Send(new GetUser.Query(id));

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<int> CreateOrUpdate([FromBody] UserCommand command) =>
        await Mediator.Send(new SaveUser.Command(command));

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task Delete(int id) =>
        await Mediator.Send(new DeleteUser.Command(id));
}