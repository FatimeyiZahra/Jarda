using Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IDiscountProductRepository DiscountProduct { get; }
        IDiscountRepository Discount { get; }
        INewsCategoryRepository NewsCategory { get; }
        INewsPhotoRepository NewsPhoto { get; }
        INewsRepository News { get; }
        IProductPhotoRepository ProductPhoto { get; }
        IProductRepository Product { get; }
        IProductTagRepository ProductTag { get; }
        IStockRepository Stock { get; }
        ITagRepository Tag { get; }
        IProductSpecificationRepository ProductSpecification { get; }
        ISpecificationRepository Specification { get; }
        Task<int> CommitAsync();
    }
}
