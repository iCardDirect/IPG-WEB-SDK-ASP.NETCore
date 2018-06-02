using System;
using System.Collections.Generic;
using System.Text;

namespace IPGGatewayAPILibrary
{
    /// <summary>
    /// This method is used by IPG to allow merchant to process subsequent recurring transaction. The IPG API will return an xml with the result.This method is intended to be utilized by the Merchant in his website back-end.Merchant is obliged to use this method in case of offering of subscription payments to clients- cardholders.
    /// </summary>
    public class IPGSubsequentRecurring : IPGGatewayAPIBackend
    {
        /// <summary>
        /// Currency ISO code
        /// </summary>
        public string CurrencyString
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
        /// Transaction currency
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
        /// Used to uniquely identify a transaction in IPG.Used as a parameter for subsequent recurring transaction in order to identify first recurring transaction of subscription.
        /// </summary>
        public string IPG_Trnref
        {
            get
            {
                if (_properties.ContainsKey("IPG_Trnref"))
                    return _properties["IPG_Trnref"];
                else
                    return null;
            }

            set
            {
                _properties["IPG_Trnref"] = value;
            }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public IPGSubsequentRecurring():base("IPGSubsequentRecurring")
        {
            CurrencyString = DefaultCurrencyCode;
        }
    }
}
