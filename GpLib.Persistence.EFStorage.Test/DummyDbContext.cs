using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace GpLib.Persistence.EFStorage.Test
{
    public class DummyDbContext : DbContext
    {

        private class DummyTypeConfiguration : EntityTypeConfiguration<DummyModel>
        {
            public DummyTypeConfiguration()
            {
                HasKey(x => x.DummyModelId);
                Property(x => x.DummyModelId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            }
        }

        public DummyDbContext()
        {

        }

        public DummyDbContext(string connectionString) : base(connectionString)
        {

        }

        public DummyDbContext(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection)
        {

        }

        public DbSet<DummyModel> DummyModels { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DummyTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}
