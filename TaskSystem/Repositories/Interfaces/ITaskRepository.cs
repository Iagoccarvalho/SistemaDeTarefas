using TaskSystem.Model;

namespace TaskSystem.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskSystem.Model.Task>> findAllTasks();
        Task<TaskSystem.Model.Task> findById(int id);
        Task<TaskSystem.Model.Task> add(TaskSystem.Model.Task task);
        Task<TaskSystem.Model.Task> update(TaskSystem.Model.Task task, int id);
        Task<bool> remove(int id);
    }
}
