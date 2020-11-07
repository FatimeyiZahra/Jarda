using Data.Entities;
using Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories.Implementations
{
    public class SpecificationRepository : Repository<Specification>, ISpecificationRepository
    {
        public SpecificationRepository(ApplicationDbContext context) : base(context) { }
    }
    
}
