using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace IPGGatewayAPILibrary
{
    /// <summary>
    /// This is the standard method for checkout at web shop.
    /// </summary>
    public class IPGPurchase : IPGGatewayAPIFrontend
    {
        /// <summary>
        /// This is the cardholder’s email.
        /// </summary>
        public string Email
        {
            get
            {
                if (_properties.ContainsKey("Email"))
                    return _properties["Email"];
                else
                    return null;
            }

            set
            {
                _properties["Email"] = value;
            }
        }
        /// <summary>
        /// Cart
        /// </summary>
        protected List<IPGCart> _cart;
        /// <summary>
        /// Cart
        /// </summary>
        public List<IPGCart> Cart
        {
            get
            {
                return _cart;
            }
        }
        /// <summary>
        /// Purchase constructor
        /// </summary>
        public IPGPurchase() : base("IPGPurchase")
        {
            _cart = new List<IPGCart>();
        }
        /// <summary>
        /// Add item to cart
        /// </summary>
        /// <param name="cart">Add cart</param>
        /// <param name="recalculateAmount">If true will recalculate purchase amount automatic, else it will not be changed.</param>
        public void AddCart(IPGCart cart, bool recalculateAmount = true)
        {
            _cart.Add(cart);
            if (recalculateAmount)
                CalculateAmount();
        }
        /// <summary>
        /// Reset cart
        /// </summary>
        public void ResetCart() => _cart.Clear();
        /// <summary>
        /// Calculate amount of cart
        /// </summary>
        public void CalculateAmount()
        {
            if(_cart.Count == 0)
            {
                _properties["Amount"] = "0";
            }
            else
            {
                _properties["Amount"] = _cart.Sum(x => x.Amount).ToString();
            }
        }
        /// <summary>
        /// Custom aditional values of purchase
        /// </summary>
        /// <returns></returns>
        protected override string AddAdditionalValues()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(_cart.Count);
            foreach(IPGCart cart in _cart)
            {
                sb.Append(cart.Article);
                sb.Append(cart.Quantity);
                sb.Append(cart.Price);
                sb.Append(FormatValue("Amount",cart.Amount.ToString()));
                sb.Append(CurrencyString);
            }
            return sb.ToString();
        }
        /// <summary>
        /// Custom aditional
        /// </summary>
        /// <returns></returns>
        protected override List<KeyValuePair<string, string>> AddAdditionalFields()
        {
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();

            data.Add(new KeyValuePair<string, string>("CartItems", _cart.Count.ToString()));
            for (int i = 0; i < _cart.Count; i++)
            {
                data.Add(new KeyValuePair<string, string>("Article_" + (i + 1), _cart[0].Article));
                data.Add(new KeyValuePair<string, string>("Quantity_" + (i + 1), _cart[0].Quantity.ToString()));
                data.Add(new KeyValuePair<string, string>("Price_" + (i + 1), _cart[0].Price.ToString()));
                data.Add(new KeyValuePair<string, string>("Amount_" + (i + 1), _cart[0].Amount.ToString()));
                data.Add(new KeyValuePair<string, string>("Currency_" + (i + 1), CurrencyString));
            }

            return data;
        }
    }
}
