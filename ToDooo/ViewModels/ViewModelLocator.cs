using Microsoft.Extensions.DependencyInjection;

namespace ToDooo.ViewModels;

public class ViewModelLocator
{
	public MainWindowViewModel MainWindowViewModel => App.Services.GetRequiredService<MainWindowViewModel>();
}