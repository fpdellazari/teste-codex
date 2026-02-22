namespace PessoasApi.Domain.Entities;

public sealed class Person
{
    public Person(Guid id, string name)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id não pode ser vazio.", nameof(id));
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Nome é obrigatório.", nameof(name));
        }

        Id = id;
        Name = name.Trim();
    }

    public Guid Id { get; }

    public string Name { get; }
}
