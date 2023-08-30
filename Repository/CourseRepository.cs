using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Xml.Linq;
using WebApplication1.Data;
using WebApplication1.Enitiy;
using Task = System.Threading.Tasks.Task;

namespace WebApplication1.Repository;
public class CourseRepository : ICourseRepository
{
    private readonly AppDbContext _context;

    public CourseRepository(AppDbContext context) => _context = context;


    [HttpGet]
    public async Task<List<Course?>> GetCourseAllAsync() => await _context.Course.ToListAsync();



    [HttpGet]
    public async Task<Course?> GetCourseByIdAsync(int id)
    {
        return await _context.Course.FirstOrDefaultAsync(i => (Equals(i.Id, id)));
    }


    [HttpPost]
    public async Task<Course> CreateCourseAsync(Course course)
    {
        var coursee = new Course();

        coursee.Id = course.Id;
        coursee.Name = course.Name;
        coursee.Url = course.Url;
        coursee.Price = course.Price;
        coursee.Description = course.Description;
        
          _context.Course.Add(coursee);
          await _context.SaveChangesAsync();
        return coursee;
    }


    [HttpPut]
    public async Task<Course> UpdateCourseAsync(Course course)
    {
        var coursee = await _context.Course.FindAsync(course.Id);
        if (coursee != null)
        {
            coursee.Name = course.Name;
            coursee.Url = course.Url;
            coursee.Price = course.Price;
            coursee.Description = course.Description;
            _context.Entry(coursee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        return coursee;
    }


    [HttpDelete]
    public async Task DeleteCourseAsync(int id)
    {
        var course = await _context.Course.FindAsync(id);
        if (course != null)
        {
            _context.Course.Remove(course);
            await _context.SaveChangesAsync();
        }
    }

}