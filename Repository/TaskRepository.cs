using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApplication1.Data;
using WebApplication1.Enitiy;

namespace WebApplication1.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;
        public TaskRepository(AppDbContext context) => _context = context;

        public async Task <Enitiy.Task>  CreateTask(Enitiy.Task task)
        {
            Enitiy.Task CurTask = new Enitiy.Task();

            CurTask.Id = task.Id;
            CurTask.Title = task.Title;
            CurTask.Data = task.Data;
            CurTask.Description = task.Description;
            CurTask.user = await _context.User.FirstOrDefaultAsync(i => i.Id == task.Id) ?? throw new BadHttpRequestException("User not found");
            CurTask.Lessons = await _context.Lessons.FirstOrDefaultAsync(i => i.Id ==  task.Id) ?? throw new BadHttpRequestException("User not found");
            CurTask.complete = task.complete;

            _context.Task.Add(CurTask);
            await _context.SaveChangesAsync();
            return CurTask;


        }

        public async System.Threading.Tasks.Task DeleteTask(int id)
        {
            var cur = await _context.Task.FindAsync(id);
            if(cur != null)
            {
                _context.Task.Remove(cur);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Enitiy.Task>> GetAllTasks() => await _context.Task.ToListAsync();

        public async Task <Enitiy.Task> GetTasksById(int id)
        {
            return await _context.Task.FirstOrDefaultAsync(i => Equals(i.Id, id));
        }

        public async System.Threading.Tasks.Task<Enitiy.Task> UpdateTask(Enitiy.Task task)
        {
            var Cur = await _context.Task.FindAsync(task.Id);
            if( Cur == null)
            {
                Cur.Title = task.Title;
                Cur.Data = task.Data;
                Cur.Description = task.Description;
                Cur.user = await _context.User.FirstOrDefaultAsync(i => i.Id == task.Id) ?? throw new BadHttpRequestException("User not found");
                Cur.Lessons = await _context.Lessons.FirstOrDefaultAsync(i => i.Id == task.Id) ?? throw new BadHttpRequestException("User not found");
                Cur.complete = task.complete;

                _context.Entry(Cur).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return Cur;



        }
    }
}
