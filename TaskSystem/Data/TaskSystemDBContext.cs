using Microsoft.EntityFrameworkCore;
using TaskSystem.Data.Map;
using TaskSystem.Model;

namespace TaskSystem.Data
{
    public class TaskSystemDBContext : DbContext
    {
        public TaskSystemDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set;}

        public DbSet<TaskSystem.Model.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
