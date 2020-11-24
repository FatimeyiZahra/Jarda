using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Resources
{
    public class ProductResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Rating { get; set; }
        public string Desc { get; set; }
        public string Video { get; set; }
        public decimal Price { get; set; }
        //public string OS { get; set; }
        //public string CPU { get; set; }
        //public string Memory { get; set; }
        //public string GPU { get; set; }
        //public string CPUrecommended { get; set; }
        //public string Memoryrecommended { get; set; }
        public DateTime AddedDate { get; set; }

        public DiscountResource Discount { get; set; }
        public string[] Photos { get; set; }
        public List<string> ProductTags { get; set; }
        public List<string> ProductSpecifications { get; set; }

        public CategoryResource Category { get; set; }


    }
}
