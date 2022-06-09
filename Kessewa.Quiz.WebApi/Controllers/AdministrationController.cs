using Kessewa.Quiz.Application.Features;
using Kessewa.Quiz.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Kessewa.Quiz.WebApi.Controllers;

public class AdministrationController : BaseController
{

    [HttpGet]
    public async Task<IActionResult> Initialize()
    {
        await Mediator.Send(new InitializeDatabase.Command());
        return Ok();
    }
}