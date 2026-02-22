using PessoasApi.Application.Abstractions;

namespace PessoasApi.Application.People.Queries;

public sealed record ListPeopleQuery : IQuery<IReadOnlyList<PersonResponse>>;
