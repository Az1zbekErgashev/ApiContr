namespace WebApplication1.Repository
{
    public interface ITaskRepository
    {
        Task<List<Enitiy.Task>> GetAllTasks();
        Task<Enitiy.Task> GetTasksById(int id);
        Task<Enitiy.Task> CreateTask(Enitiy.Task task);
        Task<Enitiy.Task> UpdateTask(Enitiy.Task task);
        Task DeleteTask(int id);
    }
}
