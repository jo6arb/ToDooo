using Microsoft.EntityFrameworkCore;
using ToDooo.DAL.Entity;

namespace ToDooo.DAL.Context;

public class GoalDb : DbContext
{
	public DbSet<Goal> Goals => Set<Goal>();

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
		optionsBuilder.UseSqlite("DataSource=GoalDb.db");
}