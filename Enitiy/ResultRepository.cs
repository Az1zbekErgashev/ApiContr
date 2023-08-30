﻿using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Repository;

namespace WebApplication1.Enitiy
{
    public class ResultRepository : IResultRepository
    {

        private readonly AppDbContext _context;
        public ResultRepository(AppDbContext context) { _context = context; }
        public async Task<Result> CreateResult(Result result)
        {
            var cur = new Result();
            cur.ID = result.ID;
            cur.Name = result.Name;
            cur.Url = result.Url;
            cur.Education = await _context.Education.FirstOrDefaultAsync(i => i.Id == result.ID) ?? throw new BadHttpRequestException("User not found");
            cur.User = await _context.User.FirstOrDefaultAsync(i => i.Id == result.ID) ?? throw new BadHttpRequestException("User not found");

            _context.Result.Add(cur);
            await _context.SaveChangesAsync();
            return cur;
        }

        public async System.Threading.Tasks.Task DeleteResultById(int id)
        {
            var cur = await _context.Result.FindAsync(id);
            if (cur != null)
            {
                _context.Result.Remove(cur);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Result>> GetAllResults() => await _context.Result.ToListAsync();

        public async Task<Result> GetResultById(int id)
        {
            return await _context.Result.FirstOrDefaultAsync(i =>(Equals(i.ID, id)));
        }

        public async System.Threading.Tasks.Task<Result> UpdateResult(Result result)
        {
            var cur = await _context.Result.FindAsync(result.ID);
            if(cur != null)
            {
                cur.Name = result.Name;
                cur.Url = result.Url;
                cur.Education = await _context.Education.FirstOrDefaultAsync(i => i.Id == result.ID) ?? throw new BadHttpRequestException("User not found");
                cur.User = await _context.User.FirstOrDefaultAsync(i => i.Id == result.ID) ?? throw new BadHttpRequestException("User not found");

                _context.Entry(cur).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return cur;
        }
    }
}
