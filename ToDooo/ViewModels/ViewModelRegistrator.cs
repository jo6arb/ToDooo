using Microsoft.Extensions.DependencyInjection;

namespace ToDooo.ViewModels;

public static class ViewModelRegistrator
{
	public static IServiceCollection AddViewModels(this IServiceCollection services) =>
		services.AddSingleton<MainWindowViewModel>()
		;
}