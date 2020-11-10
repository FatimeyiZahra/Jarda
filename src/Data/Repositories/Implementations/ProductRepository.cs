using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace Data.Repositories.Implementations
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) { }
        private ApplicationDbContext _context => Context as ApplicationDbContext;

        public async Task<IEnumerable<Product>> GetIsComingProduct()
        {
            return await _context.Products
                                             .Include(p => p.Category)
                                             .Include(p => p.Stocks)
                                             .Include(p => p.Photos)
                                             .Include(n => n.ProductTags).ThenInclude(n => n.Tag)
                                             .Include(s => s.ProductSpecifications).ThenInclude(s => s.Specification)
                                             .Where(p => p.Status && p.IsComing)
                                             .Where(p => p.Stocks.Any(s => s.Quantity > 0))
                                             .Include(p => p.Discounts).ThenInclude(p => p.Discount)
                                             .IncludeFilter(p => p.Discounts.FirstOrDefault(d => d.Discount.Status && d.Discount.StartDate <= DateTime.Now && d.Discount.EndDate >= DateTime.Now))
                                             .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetIsFreeProduct()
        {
            return await _context.Products
                                 .Include(p => p.Category)
                                 .Include(p => p.Stocks)
                                 .Include(p => p.Photos)
                                 .Include(n => n.ProductTags).ThenInclude(n => n.Tag)
                                 .Include(s => s.ProductSpecifications).ThenInclude(s => s.Specification)
                                 .Where(p => p.Status && p.IsFree)
                                 .Where(p => p.Stocks.Any(s => s.Quantity > 0))
                                 .Include(p => p.Discounts).ThenInclude(p => p.Discount)
                                 .IncludeFilter(p => p.Discounts.FirstOrDefault(d => d.Discount.Status && d.Discount.StartDate <= DateTime.Now && d.Discount.EndDate >= DateTime.Now))
                                 .ToListAsync();

        }

        public async Task<IEnumerable<Product>> GetIsNewProduct()
        {
            return await _context.Products
                                           .Include(p => p.Category)
                                           .Include(p => p.Stocks)
                                           .Include(p => p.Photos)
                                           .Include(n => n.ProductTags).ThenInclude(n => n.Tag)
                                           .Include(s => s.ProductSpecifications).ThenInclude(s => s.Specification)
                                           .Where(p => p.Status && p.IsNew)
                                           .Where(p => p.Stocks.Any(s => s.Quantity > 0))
                                           .Include(p => p.Discounts).ThenInclude(p => p.Discount)
                                           .IncludeFilter(p => p.Discounts.FirstOrDefault(d => d.Discount.Status && d.Discount.StartDate <= DateTime.Now && d.Discount.EndDate >= DateTime.Now))
                                           .ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products
                                .Include(p => p.Photos)
                                .Include(n => n.ProductTags).ThenInclude(n => n.Tag)
                                .Include(s => s.ProductSpecifications).ThenInclude(s => s.Specification)
                                .Include(p => p.Discounts).ThenInclude(p => p.Discount)
                                .IncludeFilter(p => p.Discounts.FirstOrDefault(d => d.Discount.Status && d.Discount.StartDate <= DateTime.Now && d.Discount.EndDate >= DateTime.Now))
                                .Where(p => p.Status && p.Id == id)
                                .Where(p => p.Stocks.Any(s => s.Quantity > 0))
                                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId, int page)
        {
            return await _context.Products
                                                      .Include(p => p.Category)
                                                      .Include(p => p.Stocks)
                                                      .Include(p => p.Photos)
                                                      .Include(n => n.ProductTags).ThenInclude(n => n.Tag)
                                                      .Include(s => s.ProductSpecifications).ThenInclude(s => s.Specification)
                                                      .Where(p => p.Status && p.CategoryId == categoryId)
                                                      .Where(p => p.Stocks.Any(s => s.Quantity > 0))
                                                      .Include(p => p.Discounts).ThenInclude(p => p.Discount)
                                                      .IncludeFilter(p => p.Discounts.FirstOrDefault(d => d.Discount.Status && d.Discount.StartDate <= DateTime.Now && d.Discount.EndDate >= DateTime.Now))
                                                      .OrderByDescending(p => p.AddedDate)
                                                      .Skip((page - 1) * 12)
                                                      .Take(12)
                                                      .ToListAsync();
        }

        public async Task<int> GetProductsCountByCategoryId(int categoryId)
        {
            return await _context.Products
                                           .Include(p => p.Stocks)
                                           .Where(p => p.Status && p.CategoryId == categoryId)
                                           .Where(p => p.Stocks.Any(s => s.Quantity > 0))
                                           .CountAsync();
            
        }
    }
}
