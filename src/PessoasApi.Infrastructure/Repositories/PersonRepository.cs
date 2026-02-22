using Microsoft.EntityFrameworkCore;
using PessoasApi.Domain.Entities;
using PessoasApi.Domain.Repositories;
using PessoasApi.Infrastructure.Data;

namespace PessoasApi.Infrastructure.Repositories;

public sealed class PersonRepository : IPersonRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PersonRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<Person>> ListAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.People
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}
