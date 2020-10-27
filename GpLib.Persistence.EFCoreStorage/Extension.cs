using GpLib.Persistence.Repo;
using Microsoft.Extensions.DependencyInjection;

namespace GpLib.Persistence.EFCoreStorage
{
    public static class Extension
    {
        public static IServiceCollection UseEFCoreStorage<T>(this IServiceCollection services) where T : class
            => services.AddTransient<IStorage<T>, EFCoreStorage<T>>();
    }
}
