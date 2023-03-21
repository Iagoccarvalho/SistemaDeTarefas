using TaskSystem.Enum;

namespace TaskSystem.Model
{
    public class Task
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public TaskSystem.Enum.TaskStatus Status { get; set; }

    }
}
