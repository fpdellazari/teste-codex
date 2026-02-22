using PessoasApi.Application.Abstractions;
using PessoasApi.Domain.Repositories;

namespace PessoasApi.Application.People.Queries;

public sealed class ListPeopleQueryHandler : IQueryHandler<ListPeopleQuery, IReadOnlyList<PersonResponse>>
{
    private readonly IPersonRepository _personRepository;

    public ListPeopleQueryHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<IReadOnlyList<PersonResponse>> HandleAsync(
        ListPeopleQuery query,
        CancellationToken cancellationToken = default)
    {
        var people = await _personRepository.ListAsync(cancellationToken);

        return people
            .OrderBy(person => person.Name)
            .Select(person => new PersonResponse(person.Id, person.Name))
            .ToList();
    }
}
