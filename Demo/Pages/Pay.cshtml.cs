using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPGGatewayAPILibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class PayModel : PageModel
    {
        public string data;
        public void OnGet()
        {
            IPGPurchase Purchase = new IPGPurchase();

            IPGCart cart = new IPGCart("Test Product");
            cart.Price = 25.00m;
            cart.Quantity = 1;

            Purchase.AddCart(cart);
            Purchase.Email = "ivelin.ksotov@icard.com";
            Purchase.CustomerIP = "10.64.4.177";

            data = Purchase.GeneratePage();
        }
    }
}