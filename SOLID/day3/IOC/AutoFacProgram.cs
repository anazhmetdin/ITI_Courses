using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;
using Shopping;

namespace IOC
{
    internal class AutoFacProgram
    {
        static void Main(string[] args)
        {
            // Container Creation
            var builder = new ContainerBuilder();

            #region CodeRegisteration
            /*// Registration
            // LifeStyle (Singelton)
            builder.RegisterType<Shopper>()
                   .SingleInstance();

            // Registration
            // LifeStyle (default is transient)
            // Named instance
            builder.RegisterType<MasterCard>()
                .Named<ICreditCard>("master");

            // Registration
            // LifeStyle (scoped)
            // Named instance
            builder.RegisterType<VisaCard>()
                .InstancePerLifetimeScope()
                .Named<ICreditCard>("visa");
             
            // Resolution
            var shopper = container.Resolve<Shopper>();
            var masterCard = container.ResolveNamed<ICreditCard>("master");
            var visa = container.ResolveNamed<ICreditCard>("visa");

            shopper.Checkout(masterCard);
            shopper.Checkout(visa);*/
            #endregion

            #region ConfigRegistration
            // Add the configuration to the ConfigurationBuilder.
            var config = new ConfigurationBuilder();
            config.AddJsonFile("autofac.json");

            // Register the ConfigurationModule with Autofac.
            var module = new ConfigurationModule(config.Build());
            builder.RegisterModule(module);
            var container = builder.Build();

            // Resolution
            var shopper = container.Resolve<Shopper>();
            var card = container.Resolve<ICreditCard>();
            #endregion

            shopper.Checkout(card);
        }
    }
}