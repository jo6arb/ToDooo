using MathCore.ViewModels;

namespace ToDooo.ViewModels;

public class MainWindowViewModel : ViewModel
{
	#region Title : string - Заголовок окна

	/// <summary>Заголовок окна</summary>
	private string _Title = "Заголовок программы";

	/// <summary>Заголовок окна</summary>
	public string Title { get => _Title; set => Set(ref _Title, value); }

	#endregion
}