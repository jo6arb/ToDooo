using Microsoft.Extensions.DependencyInjection;
using ToDooo.DAL.Entity;
using ToDooo.Interfaces;

namespace ToDooo.DAL.Repositories
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoriesInDb(this IServiceCollection services) => services
            .AddTransient<IRepository<Goal>, DbRepository<Goal>>();
    }
}
