using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class ProductSpecification
    {

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SpecificationId { get; set; }
        public string OS { get; set; }
        public string CPU { get; set; }
        public string Memory { get; set; }
        public string GPU { get; set; }
        public string CPUrecommended { get; set; }
        public string Memoryrecommended { get; set; }
        public Product Product { get; set; }
        public Specification Specification { get; set; }
    }
}
