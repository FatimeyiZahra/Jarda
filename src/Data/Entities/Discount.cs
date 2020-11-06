using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Discount : BaseEntity
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float Percentage { get; set; }
        public ICollection<DiscountProduct> Products { get; set; }
    }
}
