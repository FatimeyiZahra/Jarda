using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
   public class Specification : BaseEntity
    {
        public string Name { get; set; }

        public List<ProductSpecification> ProductSpecifications { get; set; }
    }
}
