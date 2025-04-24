using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Brand Brand { get; set; }
        public Category CategoryDescription { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }

    }
}
