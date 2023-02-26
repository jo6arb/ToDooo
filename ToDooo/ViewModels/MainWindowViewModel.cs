using System.Linq;
using System.Windows.Input;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using ToDooo.DAL.Entity;
using ToDooo.Interfaces;
using ToDooo.Services.Interfaces;

namespace ToDooo.ViewModels;

public class MainWindowViewModel : ViewModel
{
    private readonly IRepository<Goal> _goals;
    private readonly ICompleteGoal _complete;

    #region Title : string - Заголовок окна

    /// <summary>Заголовок окна</summary>
    private string _Title = "Контроль задач и мероприятий";


    /// <summary>Заголовок окна</summary>
    public string Title { get => _Title; set => Set(ref _Title, value); }

    #endregion

    #region CurrentVodel : ViewModel - Текущая дочерняя модель-представление

    /// <summary>Текущая модель-представление</summary>
    private ViewModel _CurrentVodel;


    /// <summary>Текущая модель-представление</summary>
    public ViewModel CurrentVodel { get => _CurrentVodel; set => Set(ref _CurrentVodel, value); }

    #endregion

    #region Command ShowCurrentGoalCommand - Оторбразить представление текущих задач

    /// <summary>Оторбразить представление текущих задач</summary>
    private ICommand _ShowCurrentGoalCommand;

    /// <summary>Оторбразить представление текущих задач</summary>
    public ICommand ShowCurrentGoalCommand => _ShowCurrentGoalCommand
        ??= new LambdaCommand(OnShowCurrentGoalCommandExecuted, CanShowCurrentGoalCommandExecute);

    /// <summary>Проверка возможности выполнения - Оторбразить представление текущих задач</summary>
    private bool CanShowCurrentGoalCommandExecute() => true;

    /// <summary>Логика выполнения - Оторбразить представление текущих задач</summary>
    private void OnShowCurrentGoalCommandExecuted()
    {
        _CurrentVodel = new CurrentGoalsViewModel(_goals);
    }

    #endregion

    #region Command ShowCompletedGoalCommand - Оторбразить представление выполненных задач

    /// <summary>Оторбразить представление выполненных задач</summary>
    private ICommand _ShowCompletedGoalCommand;

    /// <summary>Оторбразить представление выполненных задач</summary>
    public ICommand ShowCompletedGoalCommand => _ShowCompletedGoalCommand
        ??= new LambdaCommand(OnShowCompletedGoalCommandExecuted, CanShowCompletedGoalCommandExecute);

    /// <summary>Проверка возможности выполнения - Оторбразить представление выполненных задач</summary>
    private bool CanShowCompletedGoalCommandExecute() => true;

    /// <summary>Логика выполнения - Оторбразить представление выполненных задач</summary>
    private void OnShowCompletedGoalCommandExecuted()
    {
        _CurrentVodel = new CompleteGoalsViewModel(_goals);
    }

    #endregion





    public MainWindowViewModel(IRepository<Goal> goals, ICompleteGoal complete)
    {
        _goals = goals;
        _complete = complete;
    }
}