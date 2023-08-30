namespace WebApplication1.Enitiy
{
    public class HomeWork
    {
          public int Id { get; set; }
          public string Img { get; set; }
          public string Title { get; set; }
          public string Name { get; set; }
          public Lessons Lessons { get; set; }
          public Enitiy.Task Task { get; set; }
    }
}