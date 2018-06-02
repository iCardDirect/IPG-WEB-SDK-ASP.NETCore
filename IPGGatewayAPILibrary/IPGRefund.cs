using System;
using System.Collections.Generic;
using System.Text;

namespace IPGGatewayAPILibrary
{
    /// <summary>
    /// Create refund transaction
    /// </summary>
    public class IPGRefund : IPGGatewayAPIBackend
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
        /// Currency of transaction
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
        /// Used to uniquely identify a transaction in IPG.Used as a parameter for subsequent refund of reversal if needed.
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
        /// The amount of the requested.
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
        /// Constructor
        /// </summary>
        public IPGRefund() : base("IPGRefund")
        {
            CurrencyString = DefaultCurrencyCode;
        }
    }
}
