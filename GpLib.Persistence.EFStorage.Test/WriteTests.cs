using FluentAssertions;
using GpLib.Persistence.Repo;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Entity;
using System.Linq;
using Xunit;

namespace GpLib.Persistence.EFStorage.Test
{
    public class WriteTests
    {
        private static ServiceProvider ConfigureServices() =>
            new ServiceCollection()
            .AddTransient<DbContext>(builder => new DummyDbContext(Effort.DbConnectionFactory.CreateTransient(), true))
            .AddTransient<IStorage<DummyModel>, EFStorage<DummyModel>>()
            .AddTransient<IDummyRepository, DummyRepository>()
            .BuildServiceProvider();

        [Fact]
        public void Should_WriteDummyModelToDatabase()
        {

            using var repo = ConfigureServices().GetService<IDummyRepository>();

            repo.Add(new DummyModel { IntValue = 1, TextValue = "test" });

            repo.SaveChanges();

            repo.GetAll().Should().NotBeEmpty();
            repo.GetAll().Should().HaveCount(1);
            repo.Filter(x => x.TextValue == "test").First().Should().NotBeNull();
            repo.Filter(x => x.TextValue == "test").First().IntValue.Should().Be(1);
        }
    }
}
