using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }

        public List<ProductTag> ProductTags { get; set; }

    }
}
