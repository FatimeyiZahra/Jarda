using Data.Entities;
using Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories.Implementations
{
    public class ProductSpecificationRepository : Repository<Entities.ProductSpecification>, IProductSpecificationRepository
    {
        public ProductSpecificationRepository(ApplicationDbContext context) : base(context) { }
    }
    
}
