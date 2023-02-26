using System.Linq;
using MathCore.ViewModels;
using ToDooo.DAL.Entity;
using ToDooo.Interfaces;
using ToDooo.Services.Interfaces;

namespace ToDooo.ViewModels;

public class MainWindowViewModel : ViewModel
{
    private readonly IRepository<Goal> _goals;
    private readonly ICompleteGoal _complete;
    public int CountGoals { get; set; }
    #region Title : string - Заголовок окна

    /// <summary>Заголовок окна</summary>
    private string _Title = "Заголовок программы";


    /// <summary>Заголовок окна</summary>
    public string Title { get => _Title; set => Set(ref _Title, value); }

    #endregion

    public MainWindowViewModel(IRepository<Goal> goals, ICompleteGoal complete)
    {
        _goals = goals;
        _complete = complete;

        var CountGoals = _complete.listGoal.Count();
    }
}