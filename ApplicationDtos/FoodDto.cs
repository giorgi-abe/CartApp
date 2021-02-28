using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDtos
{
    public class FoodDto : ProductDto
    {
        public int Calories { get; set; }
        public DateTime Date { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
