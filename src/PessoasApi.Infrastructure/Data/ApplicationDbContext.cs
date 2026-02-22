using Microsoft.EntityFrameworkCore;
using PessoasApi.Domain.Entities;

namespace PessoasApi.Infrastructure.Data;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Person> People => Set<Person>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var personBuilder = modelBuilder.Entity<Person>();

        personBuilder.ToTable("people");
        personBuilder.HasKey(person => person.Id);
        personBuilder.Property(person => person.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();
        personBuilder.Property(person => person.Name)
            .HasColumnName("name")
            .HasMaxLength(120)
            .IsRequired();

        personBuilder.HasData(
            new Person(Guid.Parse("d9764e0c-355c-4f72-bdd8-3bd307af5afe"), "Ana Carolina"),
            new Person(Guid.Parse("3845f42e-ac17-43fd-8173-37ce3493409d"), "Bruno Henrique"),
            new Person(Guid.Parse("8f87b95e-5d95-4f4c-a22d-86f369f2d5d2"), "Camila Souza"),
            new Person(Guid.Parse("6b040f5d-1f28-4600-a7ab-f5381c24430b"), "Diego Almeida"),
            new Person(Guid.Parse("4fc962ef-44f5-4123-9f36-4e14df9fce73"), "Fernanda Lima"),
            new Person(Guid.Parse("4dcf0330-1889-402c-8f30-245741efd95f"), "João Pedro"),
            new Person(Guid.Parse("09b87714-c7c5-4eec-b45d-94c661f313f0"), "Larissa Martins"),
            new Person(Guid.Parse("b0a63952-19cd-4d14-91c9-a7132e470f0c"), "Rafael Costa")
        );
    }
}
