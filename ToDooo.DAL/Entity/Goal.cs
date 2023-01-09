using ToDooo.DAL.Entity.Base;

namespace ToDooo.DAL.Entity;

public class Goal : NameEntity
{
	public DateTime DateAddGoal { get; set; } = DateTime.MinValue;
	public DateTime DateControlGoal { get; set; } = DateTime.MinValue;
	public DateTime DateSuccessGoal { get; set; } = DateTime.MinValue;

	public byte Priority { get; set; } = Byte.MinValue;

	public string Note { get; set; } = string.Empty;
}