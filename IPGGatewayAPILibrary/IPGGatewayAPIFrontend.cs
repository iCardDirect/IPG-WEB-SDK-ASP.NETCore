using System;
using System.Collections.Generic;
using System.Text;

namespace IPGGatewayAPILibrary
{
    /// <summary>
    /// Abstraction of all frontend transactions
    /// </summary>
    public abstract class IPGGatewayAPIFrontend : IPGGatewayAPI
    {
        /// <summary>
        /// The page where the cardholder should be redirected when Cancel is pressed on the payment page.
        /// </summary>
        public string UrlOk
        {
            get
            {
                if (_properties.ContainsKey("URL_OK"))
                    return _properties["URL_OK"];
                else
                    return null;
            }

            set
            {
                _properties["URL_OK"] = value;
            }
        }
        /// <summary>
        /// The page where the cardholder should be redirected when Cancel is pressed on the payment page.
        /// </summary>
        public string UrlCancel
        {
            get
            {
                if (_properties.ContainsKey("URL_Cancel"))
                    return _properties["URL_Cancel"];
                else
                    return null;
            }

            set
            {
                _properties["URL_Cancel"] = value;
            }
        }
        /// <summary>
        /// Address supplied by the partner, where the IPGPurchaseNotify API call will send the parameters for the successful payment.
        /// </summary>
        public string UrlNotify
        {
            get
            {
                if (_properties.ContainsKey("URL_Notify"))
                    return _properties["URL_Notify"];
                else
                    return null;
            }

            set
            {
                _properties["URL_Notify"] = value;
            }
        }
        /// <summary>
        /// Index specified in IPG for every banner provided by the Merchant.The Merchant may choose to select a proper banner for every payment. The banner is displayed on the payment page.
        /// </summary>
        public string BannerIndex
        {
            get
            {
                if (_properties.ContainsKey("BannerIndex"))
                    return _properties["BannerIndex"];
                else
                    return null;
            }

            set
            {
                _properties["BannerIndex"] = value;
            }
        }
        /// <summary>
        /// ISO numeric currency code. The currency for the payment must be equal to the currency of the MID.
        /// </summary>
        protected string CurrencyString
        {
            get
            {
                if (_properties.ContainsKey("Currency"))
                    return _properties["Currency"];
                else
                    return null;
            }

            set
            {
                _properties["Currency"] = value;
            }
        }
        /// <summary>
        /// ISO numeric currency code. The currency for the payment must be equal to the currency of the MID.
        /// </summary>
        public IPGGatewayAPI.Currencies Currency
        {
            get
            {
                return (Currencies)(int.Parse(_properties["Currency"]));
            }

            set
            {
                _properties["Currency"] = ((int)value).ToString();
            }
        }
        /// <summary>
        /// The amount of the payment requested.
        /// </summary>
        public string Amount
        {
            get
            {
                if (_properties.ContainsKey("Amount"))
                    return _properties["Amount"];
                else
                    return null;
            }

            set
            {
                _properties["Amount"] = value;
            }
        }
        /// <summary>
        /// Text associated with the purchase.
        /// </summary>
        public string Note
        {
            get
            {
                if (_properties.ContainsKey("Note"))
                    return _properties["Note"];
                else
                    return null;
            }

            set
            {
                _properties["Note"] = value;
            }
        }
        /// <summary>
        /// Dotted-decimal string, that holds the customer IP address as reported at merchant web shop.
        /// </summary>
        public string CustomerIP
        {
            get
            {
                if (_properties.ContainsKey("CustomerIP"))
                    return _properties["CustomerIP"];
                else
                    return null;
            }

            set
            {
                _properties["CustomerIP"] = value;
            }
        }
        /// <summary>
        /// The link of the page with the order from the merchant web shop.
        /// </summary>
        public string OrderLink
        {
            get
            {
                if (_properties.ContainsKey("OrderLink"))
                    return _properties["OrderLink"];
                else
                    return null;
            }

            set
            {
                _properties["OrderLink"] = value;
            }
        }
        /// <summary>
        /// Abstract constructor of Frontend transaction
        /// </summary>
        /// <param name="data">Methid name</param>
        public IPGGatewayAPIFrontend(string data) : base(data)
        {
            BannerIndex = "1";
            CurrencyString = DefaultCurrencyCode;
            SetDefaultURLs();
        }
        /// <summary>
        /// Set default URLs
        /// </summary>
        protected void SetDefaultURLs()
        {
            _properties["URL_OK"] = DefaultOKUrl;
            _properties["URL_Cancel"] = DefaultCancelURL;
            _properties["URL_Notify"] = DefaultNotifyURL;
        }
        /// <summary>
        /// Generate html with all transaction parameters
        /// </summary>
        /// <returns>Page HTML</returns>
        public string GeneratePage()
        {
            StringBuilder data = new StringBuilder();

            data.Append(@"<html><head><title>IPG</title></head><body onload=""document.getElementById('ipg').submit();""><form id=""ipg"" method=""POST"" action=""");
            data.Append(DefaultURL);
            data.Append(@""">");

            foreach (KeyValuePair<string, string> temp in _properties)
            {
                data.AppendFormat("<input name=\"{0}\" type=\"hidden\" value=\"{1}\" />", temp.Key, FormatValue(temp.Key,temp.Value));
            }
            foreach (KeyValuePair<string, string> temp in AddAdditionalFields())
            {
                data.AppendFormat("<input name=\"{0}\" type=\"hidden\" value=\"{1}\" />", temp.Key, FormatValue(temp.Key, temp.Value));
            }
            data.AppendFormat("<input name=\"{0}\" type=\"hidden\" value=\"{1}\" />", "Signature", Convert.ToBase64String(Sign()));
            data.Append("</form></body></html>");
            Console.WriteLine(data.ToString());
            return data.ToString();
        }
    }
}
