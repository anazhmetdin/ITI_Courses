using Shopping;
using StructureMap;

namespace IOC
{
    internal class StructureMapProgram
    {
        static void Main1(string[] args)
        {
            // Container Creation
            var container = new Container(builder =>
            {
                // Registration

                // LifeStyle (Singelton)
                builder.For<Shopper>().Use<Shopper>().Singleton();

                // LifeStyle (Transient - default)
                builder.For<ICreditCard>().Use<MasterCard>().Named("master");

                // LifeStyle (Scoped)
                builder.For<ICreditCard>().Use<VisaCard>().Named("visa").ContainerScoped();
            });

            // Resolution
            var shopper = container.GetInstance<Shopper>();
            var masterCard = container.GetInstance<ICreditCard>("master");
            var visa = container.GetInstance<ICreditCard>("visa");

            shopper.Checkout(masterCard);
            shopper.Checkout(visa);
        }
    }
}