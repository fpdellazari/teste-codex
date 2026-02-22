using PessoasApi.Domain.Entities;

namespace PessoasApi.Domain.Repositories;

public interface IPersonRepository
{
    Task<IReadOnlyList<Person>> ListAsync(CancellationToken cancellationToken = default);
}
