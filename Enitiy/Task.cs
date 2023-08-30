

namespace WebApplication1.Enitiy
{
    public class Task
    {
        public int Id { get; set; }
        public int Title { get; set; }
        public DateTime Data { get; set; }
        public int Description { get; set; }
        public User user { get; set; }
        public Lessons Lessons { get; set; }
        public bool complete { get; set; }
    }
}
