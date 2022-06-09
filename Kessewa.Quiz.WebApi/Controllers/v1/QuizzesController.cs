using Kessewa.Application.Shared.Domain.Models;
using Kessewa.Quiz.Application.Features.Quizzes.Commands;
using Kessewa.Quiz.Application.Features.Quizzes.Queries;
using Kessewa.Quiz.Processors.Commands;
using Kessewa.Quiz.Processors.Dtos;
using Kessewa.Quiz.Processors.Dtos.PageDtos;
using Kessewa.Quiz.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Kessewa.Quiz.WebApi.Controllers.v1;

public class QuizzesController : BaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(IEnumerable<PaginatedList<QuizPageDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<PaginatedList<QuizPageDto>> GetQuizzesPage([FromBody] PaginatedCommand command) =>
        await Mediator.Send(new GetQuizPage.Query(command));

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<QuizDto> GetQuiz(int id) =>
        await Mediator.Send(new GetQuiz.Query(id));

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<int> CreateOrUpdate([FromBody] QuizCommand command) =>
        await Mediator.Send(new SaveQuiz.Command(command));

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task Delete(int id) =>
        await Mediator.Send(new DeleteQuiz.Command(id));
}