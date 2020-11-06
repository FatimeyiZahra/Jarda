using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
   public class DiscountProduct
    {
        public int Id { get; set; }
        public int DiscountId { get; set; }
        public int ProductId { get; set; }
        public Discount Discount { get; set; }
        public Product Product { get; set; }
    }
}
