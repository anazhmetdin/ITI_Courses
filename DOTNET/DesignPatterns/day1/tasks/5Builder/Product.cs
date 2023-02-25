using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4GameDecorator
{
    internal class Product
    {
        public string? Name { get; set; }
        public int Price { get; set; }
        public string? Category { get; set; }

        public override string ToString()
        {
            return $"{Name ?? "NA-name"}: {Price}, {Category??"NA-category"}";
        }
    }
}
