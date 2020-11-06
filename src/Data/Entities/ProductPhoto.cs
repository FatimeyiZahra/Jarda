using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
   public class ProductPhoto :BaseEntity
    {
        public int ProductId { get; set; }
        public string Photo { get; set; }

        public Product Product { get; set; }
    }
}
