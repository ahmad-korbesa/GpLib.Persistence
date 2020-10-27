using GpLib.Persistence.Repo;
using Microsoft.Extensions.DependencyInjection;

namespace GpLib.Persistence.EFStorage
{
    public static class Extension
    {
        public static IServiceCollection UseEFStorage<T>(this IServiceCollection services) where T : class
            => services.AddTransient<IStorage<T>, EFStorage<T>>();
    }
}
