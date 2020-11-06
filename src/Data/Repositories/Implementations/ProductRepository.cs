﻿using Data.Entities;
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


        public async Task<IEnumerable<Product>> GetIsFreeProduct()
        {
            return await _context.Products
                .Include(p=> p.Category)
                                 .Include(p => p.Stocks)
                                 .Include(p => p.Photos)
                                 .Include(n=>n.ProductTags)
                                 .Where(p => p.Status && p.IsFree)
                                 .Where(p => p.Stocks.Any(s => s.Quantity > 0))
                                 .Include(p => p.Discounts).ThenInclude(p => p.Discount)
                                 .IncludeFilter(p => p.Discounts.FirstOrDefault(d => d.Discount.Status && d.Discount.StartDate <= DateTime.Now && d.Discount.EndDate >= DateTime.Now))
                                 .ToListAsync();

        }
    }
}