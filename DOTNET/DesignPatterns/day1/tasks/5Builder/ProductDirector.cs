using _4GameDecorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5Builder
{
    internal class ProductDirector
    {
        public static Product CreateProduct()
        {
            return new ProductBuilder().WithName("Test Product2")
                                        .WithPrice(100)
                                        .WithCategory("Test Category")
                                        .Build();
        }
    }
}
