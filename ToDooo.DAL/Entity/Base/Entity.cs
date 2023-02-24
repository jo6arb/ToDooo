using System.Security.Principal;

namespace ToDooo.DAL.Entity.Base;

public abstract class Entity : IEntity
{
	public int Id { get; set; } = default;
}