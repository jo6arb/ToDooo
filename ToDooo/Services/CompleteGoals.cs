using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using ToDooo.DAL.Entity;
using ToDooo.Interfaces;
using ToDooo.Services.Interfaces;

namespace ToDooo.Services
{
    public class CompleteGoals : ICompleteGoal
    {
        private readonly IRepository<Goal> _goals;
        public IEnumerable<Goal> listGoal => _goals.Items;

        public CompleteGoals(IRepository<Goal> goals)
        {
            _goals = goals;
        }

        public async void CompleteGoalAsync(string nameGoal, DateTime completeGoal, CancellationToken cancel = default)
        {
            var goal = await _goals.Items.FirstOrDefaultAsync(g => g.Name == nameGoal, cancel);
            goal.DateSuccessGoal = completeGoal;
            _goals.UpdateAsync(goal, cancel);
        }


    }
}
