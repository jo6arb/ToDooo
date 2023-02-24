using Microsoft.EntityFrameworkCore;
using ToDooo.DAL.Entity;

namespace ToDooo.DAL.Context;

public class GoalDb : DbContext
{
    public GoalDb(DbContextOptions<GoalDb> options) : base(options) { }
    public DbSet<Goal> Goals => Set<Goal>();

}