using _4GameDecorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5Builder
{
    internal class ProductBuilder
    {
        private Product _product;

        public ProductBuilder()
        {
            _product = new Product();
        }

        public ProductBuilder WithName(string name)
        {
            _product.Name = name;
            return this;
        }

        public ProductBuilder WithPrice(int price)
        {
            _product.Price = price;
            return this;
        }

        public ProductBuilder WithCategory(string category)
        {
            _product.Category = category;
            return this;
        }

        public Product Build()
        {
            return _product;
        }
    }
}
