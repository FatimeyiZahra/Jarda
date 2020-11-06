using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Rating { get; set; }
        public string Desc { get; set; }
        public string Video { get; set; }

        public int CategoryId { get; set; }
        public bool IsFree { get; set; }
        public bool IsNew { get; set; }
        public bool IsComing { get; set; }
        public bool IsTopSeller { get; set; }


        public Category Category { get; set; }
        public ICollection<ProductPhoto> Photos { get; set; }
        public ICollection<DiscountProduct> Discounts { get; set; }
        public ICollection<Stock> Stocks { get; set; }
        public List<ProductTag> ProductTags { get; set; }
    }
}
