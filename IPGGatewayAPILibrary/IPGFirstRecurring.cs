using System;
using System.Collections.Generic;
using System.Text;

namespace IPGGatewayAPILibrary
{
    /// <summary>
    /// This is a method for processing a first transaction of subscription agreement.
    /// </summary>
    public class IPGFirstRecurring : IPGGatewayAPIFrontend
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
        /// IPGFirstRecurring constructor
        /// </summary>
        public IPGFirstRecurring() : base("IPGFirstRecurring")
        {

        }
    }
}
