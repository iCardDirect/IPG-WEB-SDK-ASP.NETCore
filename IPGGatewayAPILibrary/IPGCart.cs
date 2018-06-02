using System;
using System.Collections.Generic;
using System.Text;

namespace IPGGatewayAPILibrary
{
    /// <summary>
    /// Cart logical record
    /// </summary>
    public class IPGCart
    {
        /// <summary>
        /// Name of an article in the shopping cart.
        /// </summary>
        public string Article = string.Empty;
        /// <summary>
        /// How many pieces of an article.
        /// </summary>
        public int Quantity = 0;
        /// <summary>
        /// Price of a single unit.
        /// </summary>
        public decimal Price = 0;
        /// <summary>
        /// Quantity*Price for the article.
        /// </summary>
        public decimal Amount
        {
            get
            {
                return Price * Quantity;
            }
        }
        /// <summary>
        /// Cart constructor
        /// </summary>
        public IPGCart() { }
        /// <summary>
        /// Cart constructor
        /// </summary>
        /// <param name="article">Name of an article</param>
        public IPGCart(string article)
        {
            Article = article;
        }
    }
}
