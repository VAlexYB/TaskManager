using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.DataAccess.Repositories
{
    public class TasksRepository
    {
        private readonly TaskManagerDbContext _context;
        public TasksRepository(TaskManagerDbContext context)
        {
            _context = context;
        }


        public async Task<List<SimpleTask>> GetAll()
        {
            var tasks = await _context.Tasks
                .AsNoTracking()
                .ToListAsync();

            return tasks;
        }

        public async Task<int> Create(SimpleTask task)
        {

            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task.Id;
        }

        public async Task<int> Update(SimpleTask task)
        {
            await _context.Tasks
                .Where(t => t.Id == task.Id)
                .ExecuteUpdateAsync(t => t
                        .SetProperty(t => t.Name, t => task.Name)
                        .SetProperty(t => t.Description, t => task.Description));

            return task.Id;
        }

        public async Task<SimpleTask> GetById(int id)
        {
            var task = await _context.Tasks
                .FirstOrDefaultAsync(t => t.Id == id);

            return task;
        }

        public async Task<bool> IsAny(int id)
        {
            var result = await _context.Tasks
                .AnyAsync(t => t.Id == id);
            return result;
        }

        public async Task<int> Delete(int id)
        {
            await _context.Tasks
                .Where(t => t.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
