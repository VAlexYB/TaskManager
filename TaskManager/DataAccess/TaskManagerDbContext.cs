using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.DataAccess
{
    public class TaskManagerDbContext : DbContext
    {
        public DbSet<SimpleTask> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) : base(options)
        {

        }
    }
}
