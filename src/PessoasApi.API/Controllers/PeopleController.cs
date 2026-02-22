using Microsoft.AspNetCore.Mvc;
using PessoasApi.Application.Abstractions;
using PessoasApi.Application.People.Queries;

namespace PessoasApi.API.Controllers;

[ApiController]
[Route("api/pessoas")]
public sealed class PeopleController : ControllerBase
{
    private readonly IQueryHandler<ListPeopleQuery, PersonResponse> _listPeopleQueryHandler;

    public PeopleController(IQueryHandler<ListPeopleQuery, PersonResponse> listPeopleQueryHandler)
    {
        _listPeopleQueryHandler = listPeopleQueryHandler;
    }

    [HttpGet]
    [ProducesResponseType(typeof(PersonResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonResponse>> GetAsync([FromQuery] string gender, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(gender))
        {
            return BadRequest("O parâmetro 'gender' é obrigatório e deve ser 'm' ou 'f'.");
        }

        try
        {
            var person = await _listPeopleQueryHandler.HandleAsync(new ListPeopleQuery(gender), cancellationToken);
            return Ok(person);
        }
        catch (ArgumentException)
        {
            return BadRequest("O parâmetro 'gender' deve ser 'm' ou 'f'.");
        }
    }
}
