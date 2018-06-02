using System;
using System.Collections.Generic;
using System.Text;

namespace IPGGatewayAPILibrary
{
    /// <summary>
    /// Notify data
    /// </summary>
    public class IPGNotify
    {
        /// <summary>
        /// Merchant ID
        /// </summary>
        public string MID { get; set; }
        /// <summary>
        /// Amount of transaction
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// Currency ISO code
        /// </summary>
        public int Currency { get; set; }
        /// <summary>
        /// Customer IP
        /// </summary>
        public string CustomerIP { get; set; }
        /// <summary>
        /// Order ID
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// Aproval code
        /// </summary>
        public string Approval { get; set; }
        /// <summary>
        /// IPG transaction reference
        /// </summary>
        public string IPGTrnRef { get; set; }
        /// <summary>
        /// Request date time
        /// </summary>
        public DateTime RequestDateTime { get; set; }
        /// <summary>
        /// Request STAN
        /// </summary>
        public string RequestSTAN { get; set; }
        /// <summary>
        /// Signature
        /// </summary>
        public string Signature { get; set; }
        /// <summary>
        /// PAN
        /// </summary>
        public string PAN { get; set; }
    }
}
