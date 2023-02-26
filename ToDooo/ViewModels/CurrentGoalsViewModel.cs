using MathCore.WPF.ViewModels;
using ToDooo.DAL.Entity;
using ToDooo.Interfaces;

namespace ToDooo.ViewModels
{
    class CurrentGoalsViewModel : ViewModel
    {
        public CurrentGoalsViewModel(IRepository<Goal> Goals) {  }
    }
}
