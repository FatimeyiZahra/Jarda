using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace Data.Repositories.Implementations
{
    public class NewsRepository : Repository<News>, INewsRepository
    {
        public NewsRepository(ApplicationDbContext context) : base(context) { }
        private ApplicationDbContext _context => Context as ApplicationDbContext;

        public async Task<IEnumerable<News>> GetAllNewWithCategories()
        {
            return await _context.News.Include("NewsCategories")
                  .Include("NewsCategories.Category")
                  .Where(n => n.Status)
                  .Include(p => p.NewsPhotos)
                  .ToListAsync();

        }
    }
}
