using System.ComponentModel;

namespace TaskSystem.Enum
{
    public enum TaskStatus
    {
        [Description("To do")]
        ToDo = 1,
        [Description("Doing")]
        Doing = 2,
        [Description("Done")]
        Done = 3
    }
}
