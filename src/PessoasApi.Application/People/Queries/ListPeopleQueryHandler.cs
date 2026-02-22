using PessoasApi.Application.Abstractions;

namespace PessoasApi.Application.People.Queries;

public sealed class ListPeopleQueryHandler : IQueryHandler<ListPeopleQuery, PersonResponse>
{
    private readonly Random _random = Random.Shared;

    public Task<PersonResponse> HandleAsync(
        ListPeopleQuery query,
        CancellationToken cancellationToken = default)
    {
        var normalizedGender = query.Gender.Trim().ToLowerInvariant();

        var names = normalizedGender switch
        {
            "m" => MedievalNamesCatalog.MaleNames,
            "f" => MedievalNamesCatalog.FemaleNames,
            _ => throw new ArgumentException("O parâmetro de gênero deve ser 'm' ou 'f'.", nameof(query))
        };

        var selectedName = names[_random.Next(names.Count)];

        return Task.FromResult(new PersonResponse(Guid.NewGuid(), selectedName));
    }
}
