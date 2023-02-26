using MathCore.WPF.ViewModels;
using ToDooo.DAL.Entity;
using ToDooo.Interfaces;

namespace ToDooo.ViewModels
{
    class CompleteGoalsViewModel : ViewModel
    {
        public CompleteGoalsViewModel(IRepository<Goal> goals) { }
    }
}
