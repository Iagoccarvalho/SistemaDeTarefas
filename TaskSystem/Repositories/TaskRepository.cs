using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Model;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskSystemDBContext _dbContext;

        public TaskRepository(TaskSystemDBContext taskSystemDBContext)
        {
            _dbContext = taskSystemDBContext;
        }
        public async Task<List<TaskSystem.Model.Task>> findAllTasks()
        {
            return await _dbContext.Tasks
                //Include usado para retornar o user relacionado com a task (HATEOAS)
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<TaskSystem.Model.Task> findById(int id)
        {
            return await _dbContext.Tasks
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TaskSystem.Model.Task> add(TaskSystem.Model.Task task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }

        public async Task<bool> remove(int id)
        {
            TaskSystem.Model.Task taskById = await findById(id);

            if (taskById == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não foi encontrado no banco de dados");
            }

            _dbContext.Tasks.Remove(taskById);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<TaskSystem.Model.Task> update(TaskSystem.Model.Task task, int id)
        {
            TaskSystem.Model.Task taskById = await findById(id);

            if (taskById == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados");
            }

            taskById.Name = task.Name;
            taskById.Description = task.Description;
            taskById.Status = task.Status;
            taskById.UserId = task.UserId;

            _dbContext.Tasks.Update(taskById);
            await _dbContext.SaveChangesAsync();

            return taskById;
        }
    }
}
