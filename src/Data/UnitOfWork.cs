using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Repositories.Implementations;
using Data.Repositories.Interfaces;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        private CategoryRepository _categoryRepository;
        private DiscountProductRepository _discountProductRepository;
        private DiscountRepository _discountRepository;
        private NewsCategoryRepository _newsCategoryRepository;
        private NewsPhotoRepository _newsPhotoRepository;
        private NewsRepository _newsRepository;
        private ProductPhotoRepository _productPhotoRepository;
        private ProductRepository _productRepository;
        private ProductTagRepository _productTagRepository;
        private StockRepository _stockRepository;
        private TagRepository _tagRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }

        public ICategoryRepository Category => _categoryRepository ??= new CategoryRepository(_context);

        public IDiscountProductRepository DiscountProduct => _discountProductRepository ??= new DiscountProductRepository(_context);

        public IDiscountRepository Discount => _discountRepository ??= new DiscountRepository(_context);

        public INewsCategoryRepository NewsCategory => _newsCategoryRepository ??= new NewsCategoryRepository(_context);

        public INewsPhotoRepository NewsPhoto => _newsPhotoRepository ??= new NewsPhotoRepository(_context);

        public INewsRepository News => _newsRepository ??= new NewsRepository(_context);

        public IProductPhotoRepository ProductPhoto => _productPhotoRepository ??= new ProductPhotoRepository(_context);

        public IProductRepository Product => _productRepository ??= new ProductRepository(_context);

        public IProductTagRepository ProductTag => _productTagRepository ??= new ProductTagRepository(_context);

        public IStockRepository Stock => _stockRepository ??= new StockRepository(_context);

        public ITagRepository Tag => _tagRepository ??= new TagRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
