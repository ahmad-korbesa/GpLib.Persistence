using GpLib.Persistence.Repo;

namespace GpLib.Persistence.EFStorage.Test
{
    public class DummyRepository : RepositoryBase<DummyModel>, IDummyRepository
    {
        public DummyRepository(IStorage<DummyModel> storage) : base(storage)
        {
        }

        public void DoSomethingExtra()
        {
            //intentionally left blank
        }
    }
}