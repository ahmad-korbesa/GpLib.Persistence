using GpLib.Persistence.Repo;

namespace GpLib.Persistence.EFStorage.Test
{
    public interface IDummyRepository : IRepository<DummyModel>
    {
        void DoSomethingExtra();
    }
}
