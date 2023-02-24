using Microsoft.Extensions.DependencyInjection;
using ToDooo.Services.Interfaces;

namespace ToDooo.Services
{
    static class ServicesRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddTransient<ICompleteGoal, CompleteGoals>()
            ;
    }
}
