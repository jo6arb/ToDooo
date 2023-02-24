using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDooo.DAL.Context;
using ToDooo.DAL.Repositories;

namespace ToDooo.Data
{
    static class DbRegistrator
    {
        public static IServiceCollection AddDataBase(this IServiceCollection services) => services
            .AddDbContext<GoalDb>(
                opt => opt.UseSqlite($"Data Source={{_appEnv.ApplicationBasePath}}GoalDb.db")
                )
            .AddTransient<DbInitializer>()
            .AddRepositoriesInDb()
            ;

    }
}
