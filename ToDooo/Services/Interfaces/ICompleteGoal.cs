using System.Collections.Generic;
using ToDooo.DAL.Entity;

namespace ToDooo.Services.Interfaces
{
    public interface ICompleteGoal
    {
        IEnumerable<Goal> listGoal { get; }
    }
}
