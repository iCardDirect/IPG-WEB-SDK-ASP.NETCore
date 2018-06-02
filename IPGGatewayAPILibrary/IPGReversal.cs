using System;
using System.Collections.Generic;
using System.Text;

namespace IPGGatewayAPILibrary
{
    /// <summary>
    /// This method is used by Merchant to initiate a reversal of previously executed payment. The IPG API will return an xml with the result.This method is intended to be utilized by the Merchant in his website back-end.The Merchant could decide whether or not to use this method.
    /// </summary>
    public class IPGReversal : IPGGatewayAPIBackend
    {
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
        /// Output format of data. The property can be “xml” or “json”. If it is not specified in the request, the default value is “xml”.
        /// </summary>
        public IPGReversal() : base("IPGReversal")
        {

        }
    }
}
