using Kessewa.Application.Shared.Domain.Models;
using Kessewa.Quiz.Application.Features.Faculties.Commands;
using Kessewa.Quiz.Application.Features.Faculties.Queries;
using Kessewa.Quiz.Processors.Commands;
using Kessewa.Quiz.Processors.Dtos;
using Kessewa.Quiz.Processors.Dtos.PageDtos;
using Kessewa.Quiz.WebApi.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kessewa.Quiz.WebApi.Controllers
{
    
    public class FacultiesController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<PaginatedList<FacultyPageDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<PaginatedList<FacultyPageDto>> GetFacultiesPage([FromBody] PaginatedCommand command) =>
            await Mediator.Send(new GetFacultyPage.Query(command));

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<FacultyDto> GetFaculty(int id) =>
            await Mediator.Send(new GetFaculty.Query(id));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<int> CreateOrUpdate([FromBody] FacultyCommand faculty) =>
            await Mediator.Send(new SaveFaculty.Command(faculty));

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task Delete(int id) =>
            await Mediator.Send(new DeleteFaculty.Command(id));
    }
}
