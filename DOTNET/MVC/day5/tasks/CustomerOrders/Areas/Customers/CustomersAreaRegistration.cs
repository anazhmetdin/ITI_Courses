using System.Web.Mvc;

namespace CustomerOrders.Areas.Customers
{
    public class CustomersAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Customers";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Customers_Orders",
                "Customer/{cid}/Orders/{action}/{id}",
                new { action = "Index", controller = "Orders", id = UrlParameter.Optional }
            );

            /*context.MapRoute(
                "Customers_default",
                "Customers/{action}/{id}",
                new { action = "Index", controller = "Customers", id = UrlParameter.Optional }
            );*/
        }
    }
}