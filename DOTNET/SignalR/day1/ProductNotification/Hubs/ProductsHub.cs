using Microsoft.AspNetCore.SignalR;
using ProductNotification.Data;
using static System.Net.Mime.MediaTypeNames;

namespace ProductNotification.Hubs
{
    public class ProductsHub: Hub
    {
        private readonly ProductsContext _context;

        public ProductsHub(ProductsContext context)
        {
            _context = context;
        }

        public void WriteComment(string name, string text, int productId)
        {
            try
            {
                _context.Comment.Add(new Models.Comment { ProductId = productId, Text = text, Username = name });

                if  (_context.SaveChanges() > 0)
                {
                    Clients.All.SendAsync("NotifyNewComment", name, text, productId);
                }
            }
            catch { }
        }

        public void Buy(int productId, int quantity)
        {
            try
            {
                var product = _context.Product.Find(productId);
                if (product == null || product.Quantity < quantity)
                {
                    return;
                }

                product.Quantity -= quantity;

                _context.SaveChanges();

                Clients.All.SendAsync("NotifyNewBuy", productId, product.Quantity);
            }
            catch { }
        }
    }
}
