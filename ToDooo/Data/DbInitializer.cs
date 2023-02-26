using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ToDooo.DAL.Context;
using ToDooo.DAL.Entity;

namespace ToDooo.Data
{
    class DbInitializer
    {
        private readonly GoalDb _db;
        private readonly ILogger<DbInitializer> _logger;

        public DbInitializer(GoalDb db, ILogger<DbInitializer> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task InitializeAsync()
        {
            var timer = Stopwatch.StartNew();
            _logger.LogInformation("Инициализация БД....");

            _logger.LogInformation("Удаление существующей БД....");
            await _db.Database.EnsureDeletedAsync().ConfigureAwait(false);
            _logger.LogInformation("Удаление существующей БД выполнено за {0} мс", timer.ElapsedMilliseconds);


            _logger.LogInformation("Миграция БД....");
            await _db.Database.MigrateAsync();
            _logger.LogInformation("Миграция БД выполнена за {0} мс", timer.ElapsedMilliseconds);

            if (await _db.Goals.AnyAsync()) return;

            await InitializeGoalAsync();
          
            _logger.LogInformation("Инициализация БД выполнено за {0} мс", timer.Elapsed.TotalSeconds);
        }

        private const int __GoalCount = 10;
        private Goal[] _Goals;

        private async Task InitializeGoalAsync()
        {

            var timer = Stopwatch.StartNew();
            _logger.LogInformation("Инициализация задач....");

            _Goals = new Goal[__GoalCount];
            for (var i = 0; i < __GoalCount; i++)
                _Goals[i] = new Goal 
                {
                    Name = $"Задача {i + 1}",
                    DateAddGoal = DateTime.Now,
                    DateControlGoal = DateTime.Now,
                    DateSuccessGoal = DateTime.Now,
                    Priority = (byte)(new Random()).Next(0, __GoalCount),
                    Note = $"Заметка {i + 1}"
                };
            await _db.AddRangeAsync(_Goals);
            await _db.SaveChangesAsync();
            
            _logger.LogInformation("Инициализация Задач выполнено за {0} мс", timer.Elapsed.TotalSeconds);
        }
    }
}
