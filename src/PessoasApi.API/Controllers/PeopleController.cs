using Microsoft.AspNetCore.Mvc;
using PessoasApi.Application.Abstractions;
using PessoasApi.Application.People.Queries;

namespace PessoasApi.API.Controllers;

[ApiController]
[Route("api/pessoas")]
public sealed class PeopleController : ControllerBase
{
    private readonly IQueryHandler<ListPeopleQuery, IReadOnlyList<PersonResponse>> _listPeopleQueryHandler;

    public PeopleController(IQueryHandler<ListPeopleQuery, IReadOnlyList<PersonResponse>> listPeopleQueryHandler)
    {
        _listPeopleQueryHandler = listPeopleQueryHandler;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<PersonResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<PersonResponse>>> GetAsync(CancellationToken cancellationToken)
    {
        var people = await _listPeopleQueryHandler.HandleAsync(new ListPeopleQuery(), cancellationToken);

        return Ok(people);
    }
}
