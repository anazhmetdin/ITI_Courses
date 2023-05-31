using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping
{
    interface ICreditCard
    {
        void Charge();
    }

    public class VisaCard : ICreditCard
    {
        public void Charge()
        {
            Console.WriteLine("Charging using Visa Card........");
        }
    }

    public class MasterCard : ICreditCard
    {
        public void Charge()
        {
            Console.WriteLine("Charging using MasterCard........");
        }
    }

    public class Shopper
    {
        internal void Checkout(ICreditCard card)
        {
            // 1. code to handle check out process
            // 2. charging with card for checkout 
            card.Charge();
        }
    }
}
