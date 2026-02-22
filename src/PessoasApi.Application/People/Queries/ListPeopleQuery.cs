using PessoasApi.Application.Abstractions;

namespace PessoasApi.Application.People.Queries;

public sealed record ListPeopleQuery(string Gender) : IQuery<PersonResponse>;
