using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Enitiy;
using Task = System.Threading.Tasks.Task;


namespace WebApplication1.Repository;

public class ReviewRepository : IReviewRepository
{
    private readonly AppDbContext _context;
    public ReviewRepository(AppDbContext context) { _context = context; }
    public async Task<Review> CreateReview(Review review)
    {
        var Cur = new Review();

        Cur.Id = review.Id;
        Cur.Course_name = review.Course_name;
        Cur.Course_info= review.Course_info;
        Cur.comment = review.comment;
        Cur.Task = await _context.Task.FirstOrDefaultAsync(i => i.Id == review.Id) ?? throw new BadHttpRequestException("User not found");

        _context.Review.Add( Cur ); 
        await _context.SaveChangesAsync();
        return Cur;

    }

    public async Task DeleteReview(int id)
    {
        var Cur = await _context.Review.FindAsync(id);
        if( Cur != null)
        {
            _context.Review.Remove(Cur);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Review>> GetAllReviews() => await _context.Review.ToListAsync();

    public async Task<Review> GetReviewById(int id) => await _context.Review.FirstOrDefaultAsync(i => (Equals(i.Id, id)));

    public async Task<Review> UpdateReview(Review review)
    {
        var Cur = await _context.Review.FindAsync(review.Id);
        if (Cur != null)
        {
            Cur.Course_name = review.Course_name;
            Cur.Course_info = review.Course_info;
            Cur.comment = review.comment;
            Cur.Task = await _context.Task.FirstOrDefaultAsync(i => i.Id == review.Id) ?? throw new BadHttpRequestException("User not found");

            _context.Entry(Cur).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        return Cur;
    }
}
