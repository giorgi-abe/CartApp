using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDtos
{
    public abstract class ProductDto
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public string Firm { get; set; }
    }
}
