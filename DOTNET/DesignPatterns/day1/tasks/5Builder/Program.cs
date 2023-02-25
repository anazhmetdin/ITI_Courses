using _4GameDecorator;

namespace _5Builder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product = new ProductBuilder()
                .WithName("Test Product1")
                .WithPrice(100)
                .WithCategory("Test Category")
                .Build();

            Console.WriteLine(product.ToString());

            Console.WriteLine("-----------");

            Console.WriteLine(ProductDirector.CreateProduct().ToString());
        }
    }
}