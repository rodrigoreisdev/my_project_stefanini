using Example.Domain.ExampleAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Example.Infra.Data
{
    /// <summary>
    /// Referência de artigo para conseguir criar modelos de configuração
    /// https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-implementation-entity-framework-core
    /// Rererência de artigo para conseguir criar migration a partir de dominios
    /// https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/managing?tabs=dotnet-core-cli
    /// </summary>
    public class PersonContext : DbContext
    {
        public DbSet<Domain.ExampleAggregate.Person> Person { get; set; }
        public DbSet<Domain.ExampleAggregate.City> City { get; set; }
        public PersonContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new PersonEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CityEntityTypeConfiguration());
            modelBuilder.Entity<Domain.ExampleAggregate.Person>();
            modelBuilder.Entity<Domain.ExampleAggregate.City>();

        }
    }

    public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Domain.ExampleAggregate.Person>
    {
        public void Configure(EntityTypeBuilder<Domain.ExampleAggregate.Person> orderConfiguration)
        {
            orderConfiguration.ToTable("Person", "dbo");

            orderConfiguration.HasKey(o => o.id);
            orderConfiguration.Property(o => o.id).UseIdentityColumn();
            orderConfiguration.Property(o => o.name_person).IsRequired().HasMaxLength(300);
            orderConfiguration.Property(o => o.age).IsRequired().HasColumnType("int");
            orderConfiguration.Property(o => o.cpf).IsRequired().HasMaxLength(11);
        }
    }

    public class CityEntityTypeConfiguration : IEntityTypeConfiguration<Domain.ExampleAggregate.City>
    {
        public void Configure(EntityTypeBuilder<Domain.ExampleAggregate.City> orderConfiguration)
        {
            orderConfiguration.ToTable("City", "dbo");

            orderConfiguration.HasKey(o => o.id);
            orderConfiguration.Property(o => o.id).UseIdentityColumn();
            orderConfiguration.Property(o => o.name_city).IsRequired().HasMaxLength(200);
            orderConfiguration.Property(o => o.uf).IsRequired().HasMaxLength(2);
        }
    }
}
