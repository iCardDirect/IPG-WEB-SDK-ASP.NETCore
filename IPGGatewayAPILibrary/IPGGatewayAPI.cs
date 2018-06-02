using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebApplication1.IPG.OpenSSL.OpenSSL.PrivateKeyDecoder;

namespace IPGGatewayAPILibrary
{
    /// <summary>
    /// IPG Gateway API abstraction
    /// </summary>
    public abstract class IPGGatewayAPI
    {
        /// <summary>
        /// IPG Gateway API Languages
        /// </summary>
        public enum Languages
        {
            /// <summary>
            /// English
            /// </summary>
            EN,
            /// <summary>
            /// Franch
            /// </summary>
            FR,
            /// <summary>
            /// German 
            /// </summary>
            DE,
            /// <summary>
            /// Bulgarian
            /// </summary>
            BG,
            /// <summary>
            /// Spanish
            /// </summary>
            ES,
            /// <summary>
            /// Romanian
            /// </summary>
            RO
        }
        /// <summary>
        /// IPG Gateway API Currencies
        /// </summary>
        public enum Currencies
        {
            /// <summary>
            /// AED
            /// </summary>
            AED = 784,
            /// <summary>
            /// AFN
            /// </summary>
            AFN = 971,
            /// <summary>
            /// ALL
            /// </summary>
            ALL = 008,
            /// <summary>
            /// AMD
            /// </summary>
            AMD = 051,
            /// <summary>
            /// ANG
            /// </summary>
            ANG = 532,
            /// <summary>
            /// AOA
            /// </summary>
            AOA = 973,
            /// <summary>
            /// ARS
            /// </summary>
            ARS = 032,
            /// <summary>
            /// AUD
            /// </summary>
            AUD = 036,
            /// <summary>
            /// AWG
            /// </summary>
            AWG = 533,
            /// <summary>
            /// AZN
            /// </summary>
            AZN = 944,
            /// <summary>
            /// BAM
            /// </summary>
            BAM = 977,
            /// <summary>
            /// BBD
            /// </summary>
            BBD = 052,
            /// <summary>
            /// BDT
            /// </summary>
            BDT = 050,
            /// <summary>
            /// BGN
            /// </summary>
            BGN = 975,
            /// <summary>
            /// BHD
            /// </summary>
            BHD = 048,
            /// <summary>
            /// BIF
            /// </summary>
            BIF = 108,
            /// <summary>
            /// BMD
            /// </summary>
            BMD = 060,
            /// <summary>
            /// BND
            /// </summary>
            BND = 096,
            /// <summary>
            /// BOB
            /// </summary>
            BOB = 068,
            /// <summary>
            /// BRL
            /// </summary>
            BRL = 986,
            /// <summary>
            /// BSD
            /// </summary>
            BSD = 044,
            /// <summary>
            /// BTN
            /// </summary>
            BTN = 064,
            /// <summary>
            /// BWP
            /// </summary>
            BWP = 072,
            /// <summary>
            /// BYN
            /// </summary>
            BYN = 933,
            /// <summary>
            /// BYR
            /// </summary>
            BYR = 974,
            /// <summary>
            /// BZD
            /// </summary>
            BZD = 084,
            /// <summary>
            /// CAD
            /// </summary>
            CAD = 124,
            /// <summary>
            /// CDF
            /// </summary>
            CDF = 976,
            /// <summary>
            /// CHF
            /// </summary>
            CHF = 756,
            /// <summary>
            /// CLP
            /// </summary>
            CLP = 152,
            /// <summary>
            /// CNH
            /// </summary>
            CNH = 157,
            /// <summary>
            /// CNX
            /// </summary>
            CNX = 158,
            /// <summary>
            /// CNY
            /// </summary>
            CNY = 156,
            /// <summary>
            /// COP
            /// </summary>
            COP = 170,
            /// <summary>
            /// CRC
            /// </summary>
            CRC = 188,
            /// <summary>
            /// CUP
            /// </summary>
            CUP = 192,
            /// <summary>
            /// CVE
            /// </summary>
            CVE = 132,
            /// <summary>
            /// CZK
            /// </summary>
            CZK = 203,
            /// <summary>
            /// DJF
            /// </summary>
            DJF = 262,
            /// <summary>
            /// DKK
            /// </summary>
            DKK = 208,
            /// <summary>
            /// DOP
            /// </summary>
            DOP = 214,
            /// <summary>
            /// DZD
            /// </summary>
            DZD = 012,
            /// <summary>
            /// EEK
            /// </summary>
            EEK = 233,
            /// <summary>
            /// EGP
            /// </summary>
            EGP = 818,
            /// <summary>
            /// ETB
            /// </summary>
            ETB = 230,
            /// <summary>
            /// EUR
            /// </summary>
            EUR = 978,
            /// <summary>
            /// FJD
            /// </summary>
            FJD = 242,
            /// <summary>
            /// FKP
            /// </summary>
            FKP = 238,
            /// <summary>
            /// GBP
            /// </summary>
            GBP = 826,
            /// <summary>
            /// GEL
            /// </summary>
            GEL = 981,
            /// <summary>
            /// GHS
            /// </summary>
            GHS = 936,
            /// <summary>
            /// GIP'
            /// </summary>
            GIP = 292,
            /// <summary>
            /// GMD
            /// </summary>
            GMD = 270,
            /// <summary>
            /// GNF
            /// </summary>
            GNF = 324,
            /// <summary>
            /// GTQ
            /// </summary>
            GTQ = 320,
            /// <summary>
            /// GYD
            /// </summary>
            GYD = 328,
            /// <summary>
            /// HKD
            /// </summary>
            HKD = 344,
            /// <summary>
            /// HNL
            /// </summary>
            HNL = 340,
            /// <summary>
            /// HRK
            /// </summary>
            HRK = 191,
            /// <summary>
            /// HTG
            /// </summary>
            HTG = 332,
            /// <summary>
            /// HUF
            /// </summary>
            HUF = 348,
            /// <summary>
            /// IDR
            /// </summary>
            IDR = 360,
            /// <summary>
            /// ILS
            /// </summary>
            ILS = 376,
            /// <summary>
            /// INR
            /// </summary>
            INR = 356,
            /// <summary>
            /// IQD
            /// </summary>
            IQD = 368,
            /// <summary>
            /// ISK
            /// </summary>
            ISK = 352,
            /// <summary>
            /// JMD
            /// </summary>
            JMD = 388,
            /// <summary>
            /// JMD
            /// </summary>
            JOD = 400,
            /// <summary>
            /// JOD
            /// </summary>
            JPY = 392,
            /// <summary>
            /// JPY
            /// </summary>
            KES = 404,
            /// <summary>
            /// KGS
            /// </summary>
            KGS = 417,
            /// <summary>
            /// KHR
            /// </summary>
            KHR = 116,
            /// <summary>
            /// KMF
            /// </summary>
            KMF = 174,
            /// <summary>
            /// KRW
            /// </summary>
            KRW = 410,
            /// <summary>
            /// KWD
            /// </summary>
            KWD = 414,
            /// <summary>
            /// KYD
            /// </summary>
            KYD = 136,
            /// <summary>
            /// KZT
            /// </summary>
            KZT = 398,
            /// <summary>
            /// LAK
            /// </summary>
            LAK = 418,
            /// <summary>
            /// LBP
            /// </summary>
            LBP = 422,
            /// <summary>
            /// LKR
            /// </summary>
            LKR = 144,
            /// <summary>
            /// LRD
            /// </summary>
            LRD = 430,
            /// <summary>
            /// LSL
            /// </summary>
            LSL = 426,
            /// <summary>
            /// LTL
            /// </summary>
            LTL = 440,
            /// <summary>
            /// LVL
            /// </summary>
            LVL = 428,
            /// <summary>
            /// LYD
            /// </summary>
            LYD = 434,
            /// <summary>
            /// MAD
            /// </summary>
            MAD = 504,
            /// <summary>
            /// MDL
            /// </summary>
            MDL = 498,
            /// <summary>
            /// MGA
            /// </summary>
            MGA = 969,
            /// <summary>
            /// MKD
            /// </summary>
            MKD = 807,
            /// <summary>
            /// MMK
            /// </summary>
            MMK = 104,
            /// <summary>
            /// MNT
            /// </summary>
            MNT = 496,
            /// <summary>
            /// MOP
            /// </summary>
            MOP = 446,
            /// <summary>
            /// MRO
            /// </summary>
            MRO = 478,
            /// <summary>
            /// MUR
            /// </summary>
            MUR = 480,
            /// <summary>
            /// MVR
            /// </summary>
            MVR = 462,
            /// <summary>
            /// MWK
            /// </summary>
            MWK = 454,
            /// <summary>
            /// MXM
            /// </summary>
            MXN = 484,
            /// <summary>
            /// MYR
            /// </summary>
            MYR = 458,
            /// <summary>
            /// MZM
            /// </summary>
            MZN = 943,
            /// <summary>
            /// NAD
            /// </summary>
            NAD = 516,
            /// <summary>
            /// NGN
            /// </summary>
            NGN = 566,
            /// <summary>
            /// NIO
            /// </summary>
            NIO = 558,
            /// <summary>
            /// NOK
            /// </summary>
            NOK = 578,
            /// <summary>
            /// NPR
            /// </summary>
            NPR = 524,
            /// <summary>
            /// NZD
            /// </summary>
            NZD = 554,
            /// <summary>
            /// OMR
            /// </summary>
            OMR = 512,
            /// <summary>
            /// PAB
            /// </summary>
            PAB = 590,
            /// <summary>
            /// PEN
            /// </summary>
            PEN = 604,
            /// <summary>
            /// PGK
            /// </summary>
            PGK = 598,
            /// <summary>
            /// PHP
            /// </summary>
            PHP = 608,
            /// <summary>
            /// PKR
            /// </summary>
            PKR = 586,
            /// <summary>
            /// PLN
            /// </summary>
            PLN = 985,
            /// <summary>
            /// PYG
            /// </summary>
            PYG = 600,
            /// <summary>
            /// QAR
            /// </summary>
            QAR = 634,
            /// <summary>
            /// RON
            /// </summary>
            RON = 946,
            /// <summary>
            /// RSD
            /// </summary>
            RSD = 941,
            /// <summary>
            /// RUB
            /// </summary>
            RUB = 643,
            /// <summary>
            /// RWF
            /// </summary>
            RWF = 646,
            /// <summary>
            /// SAR
            /// </summary>
            SAR = 682,
            /// <summary>
            /// SBD
            /// </summary>
            SBD = 090,
            /// <summary>
            /// SCR
            /// </summary>
            SCR = 690,
            /// <summary>
            /// SEK
            /// </summary>
            SEK = 752,
            /// <summary>
            /// SGD
            /// </summary>
            SGD = 702,
            /// <summary>
            /// SHP
            /// </summary>
            SHP = 654,
            /// <summary>
            /// SLL
            /// </summary>
            SLL = 694,
            /// <summary>
            /// SOS
            /// </summary>
            SOS = 706,
            /// <summary>
            /// SRD
            /// </summary>
            SRD = 968,
            /// <summary>
            /// SSP
            /// </summary>
            SSP = 728,
            /// <summary>
            /// STD
            /// </summary>
            STD = 678,
            /// <summary>
            /// SVC
            /// </summary>
            SVC = 222,
            /// <summary>
            /// SYP
            /// </summary>
            SYP = 760,
            /// <summary>
            /// SZL
            /// </summary>
            SZL = 748,
            /// <summary>
            /// THB
            /// </summary>
            THB = 764,
            /// <summary>
            /// TJS
            /// </summary>
            TJS = 972,
            /// <summary>
            /// TMT
            /// </summary>
            TMT = 934,
            /// <summary>
            /// TND
            /// </summary>
            TND = 788,
            /// <summary>
            /// TOP
            /// </summary>
            TOP = 776,
            /// <summary>
            /// TRY
            /// </summary>
            TRY = 949,
            /// <summary>
            /// TTD
            /// </summary>
            TTD = 780,
            /// <summary>
            /// TWD
            /// </summary>
            TWD = 901,
            /// <summary>
            /// TZS
            /// </summary>
            TZS = 834,
            /// <summary>
            /// UAH
            /// </summary>
            UAH = 980,
            /// <summary>
            /// UGX
            /// </summary>
            UGX = 800,
            /// <summary>
            /// USD
            /// </summary>
            USD = 840,
            /// <summary>
            /// UYU
            /// </summary>
            UYU = 858,
            /// <summary>
            /// UZS
            /// </summary>
            UZS = 860,
            /// <summary>
            /// VEF
            /// </summary>
            VEF = 937,
            /// <summary>
            /// VND
            /// </summary>
            VND = 704,
            /// <summary>
            /// VUV
            /// </summary>
            VUV = 548,
            /// <summary>
            /// WST
            /// </summary>
            WST = 882,
            /// <summary>
            /// XAF
            /// </summary>
            XAF = 950,
            /// <summary>
            /// XCD
            /// </summary>
            XCD = 951,
            /// <summary>
            /// XOF
            /// </summary>
            XOF = 952,
            /// <summary>
            /// XPF
            /// </summary>
            XPF = 953,
            /// <summary>
            /// YER
            /// </summary>
            YER = 886,
            /// <summary>
            /// ZAR
            /// </summary>
            ZAR = 710,
            /// <summary>
            /// zmk
            /// </summary>
            ZMK = 894,
            /// <summary>
            /// zmw
            /// </summary>
            ZMW = 967,
        }
        /// <summary>
        /// Properties container
        /// </summary>
        protected Dictionary<string, string> _properties;
        /// <summary>
        /// Private key container
        /// </summary>
        protected static string PrivateKeyPem { get; set; }
        /// <summary>
        /// Public key constructor
        /// </summary>
        protected static string PublicKeyPem { get; set; }
        /// <summary>
        /// Default MID
        /// </summary>
        protected static string DefaultMID { get; set; }
        /// <summary>
        /// Default merchant shop name
        /// </summary>
        protected static string DefaultShopName { get; set; }
        /// <summary>
        /// Default currency code
        /// </summary>
        protected static string DefaultCurrencyCode { get; set; } = "978";
        /// <summary>
        /// IPG version
        /// </summary>
        protected static string DefaultIPGVersion { get; set; } = "3.2";
        /// <summary>
        /// Default key index
        /// </summary>
        protected static int DefaultKeyIndex { get; set; } = 1;
        /// <summary>
        /// Default language
        /// </summary>
        protected static string DefaultLanguage { get; set; } = "EN";
        /// <summary>
        /// Defult ordinator
        /// </summary>
        protected static string DefaultOrdinator { get; set; }
        /// Deffault notify URL
        /// </summary>
        protected static string DefaultNotifyURL { get; set; }
        /// <summary>
        /// Default OK URL
        /// </summary>
        protected static string DefaultOKUrl { get; set; }
        /// <summary>
        /// Default cancel URL
        /// </summary>
        protected static string DefaultCancelURL { get; set; }
        /// <summary>
        /// Default action URL
        /// </summary>
        protected static string DefaultURL { get; set; }

        /// <summary>
        /// Identifier of the private key used for signature
        /// </summary>
        public string KeyIndex
        {
            get
            {
                if (_properties.ContainsKey("KeyIndex"))
                    return _properties["KeyIndex"];
                else
                    return null;
            }

            set
            {
                _properties["KeyIndex"] = value;
            }
        }

        /// <summary>
        /// Version of protocol used for transition
        /// </summary>
        public string Version
        {
            get
            {
                return DefaultIPGVersion;
            }
        }

        /// <summary>
        /// ISO 2-character code for the desired language on the payment page. If IPG cannot fulfill the requested language, it will set the English language as defaults.
        /// </summary>
        public string Language
        {
            get
            {
                if (_properties.ContainsKey("Language"))
                    return _properties["Language"];
                else
                    return null;
            }

            set
            {
                _properties["Language"] = value;
            }
        }

        /// <summary>
        /// Value that uniquely identifies the merchant company that has signed a contract with Intercard Finance AD.
        /// </summary>
        public string Originator
        {
            get
            {
                if (_properties.ContainsKey("Originator"))
                    return _properties["Originator"];
                else
                    return null;
            }

            set
            {
                _properties["Originator"] = value;
            }
        }

        /// <summary>
        /// Identifier of the virtual terminal used for the purchase.
        /// </summary>
        public string MID
        {
            get
            {
                if (_properties.ContainsKey("MID"))
                    return _properties["MID"];
                else
                    return null;
            }

            set
            {
                _properties["MID"] = value;
            }
        }

        /// <summary>
        /// User friendly name of the merchant web shop.The cardholder will see this name on some notices in the payment page.
        /// </summary>
        public string MIDName
        {
            get
            {
                if (_properties.ContainsKey("MIDName"))
                    return _properties["MIDName"];
                else
                    return null;
            }

            set
            {
                _properties["MIDName"] = value;
            }
        }

        /// <summary>
        /// User friendly name of the merchant web shop.The cardholder will see this name on some notices in the payment page.
        /// </summary>
        public string OrderID
        {
            get
            {
                if (_properties.ContainsKey("OrderID"))
                    return _properties["OrderID"];
                else
                    return null;
            }

            set
            {
                _properties["OrderID"] = value;
            }
        }

        /// <summary>
        /// Name of the method requested for execution from IPG.
        /// </summary>
        public string IPGmethod
        {
            get
            {
                if (_properties.ContainsKey("IPGmethod"))
                    return _properties["IPGmethod"];
                else
                    return null;
            }
        }
        
        /// <summary>
        /// URL of IPG payment page
        /// </summary>
        public string ActionURL
        {
            get
            {
                return DefaultURL;
            }

            set
            {
                DefaultURL = value;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public IPGGatewayAPI()
        {
            _properties = new Dictionary<string, string>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="method">Name of method</param>
        /// <param name="setDefault">If true set default propertie values</param>
        public IPGGatewayAPI(string method, bool setDefault = true)
        {
            _properties = new Dictionary<string, string>();
            _properties["IPGmethod"] = method;
            if(setDefault)
                SetDefaultProperies();
        }

        /// <summary>
        /// Default properties
        /// </summary>
        protected void SetDefaultProperies()
        {
            _properties["KeyIndex"] = DefaultKeyIndex.ToString();
            _properties["IPGVersion"] = DefaultIPGVersion;
            _properties["Language"] = DefaultLanguage;
            _properties["Originator"] = DefaultOrdinator;
            _properties["MID"] = DefaultMID;
            _properties["MIDName"] = DefaultShopName;
            _properties["OrderID"] = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Preformat value (Invariant culture will create problems)
        /// </summary>
        /// <param name="key">Name of parameter</param>
        /// <param name="value">Value</param>
        /// <returns></returns>
        protected static string FormatValue(string key, string value)
        {
            if (key.Contains("Amount"))
                return value.Replace(",", ".");
            else return value;
        }

        #region Default values
        /// <summary>
        /// Set private key
        /// </summary>
        /// <param name="key">Private key string(PEM)</param>
        public static void SetPrivateKey(string key) => PrivateKeyPem = key;
        /// <summary>
        /// Get private key
        /// </summary>
        /// <returns></returns>
        public static string GetPrivateKey() => PrivateKeyPem;
        /// <summary>
        /// Set public key
        /// </summary>
        /// <param name="key"></param>
        public static void SetPublicKey(string key) => PublicKeyPem = key;
        /// <summary>
        /// Get publick Key
        /// </summary>
        /// <returns></returns>
        public static string GetPublicKey() => PublicKeyPem;
        /// <summary>
        /// Set default currency
        /// </summary>
        /// <param name="code">ISO code of currency</param>
        public static void SetDefaultCurrency(string code) => DefaultCurrencyCode = code;
        /// <summary>
        /// Set default currency
        /// </summary>
        /// <param name="code"></param>
        public static void SetDefaultCurrency(int code) => SetDefaultCurrency(code.ToString());
        /// <summary>
        /// Set default currency
        /// </summary>
        /// <param name="currency"></param>
        public static void SetDefaultCurrency(Currencies currency) => SetDefaultCurrency((int)currency);
        /// <summary>
        /// Get currency code
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultCurrencyCode() => DefaultCurrencyCode;
        /// <summary>
        /// Get IPG version
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultIPGVersion() => DefaultIPGVersion;
        /// <summary>
        /// Set default key index
        /// </summary>
        /// <param name="index"></param>
        public static void SetDefaultKeyIndex(int index) => DefaultKeyIndex = index;
        /// <summary>
        /// Get default key index
        /// </summary>
        /// <returns></returns>
        public static int GetDefaultKeyIndex() => DefaultKeyIndex;
        /// <summary>
        /// Set default language
        /// </summary>
        /// <param name="lang"></param>
        public static void SetDefaultLanguage(string lang) => DefaultLanguage = lang;
        /// <summary>
        /// Set default language
        /// </summary>
        /// <param name="lang"></param>
        public static void SetDefaultLanguage(Languages lang) => SetDefaultLanguage(lang.ToString());
        /// <summary>
        /// Get default language
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultLanguage() => DefaultLanguage;
        /// <summary>
        /// Set default ordinator
        /// </summary>
        /// <param name="ordinator"></param>
        public static void SetDefaultOrdinator(string ordinator) => DefaultOrdinator = ordinator;
        /// <summary>
        /// Set default ordinator
        /// </summary>
        /// <param name="ordinator"></param>
        public static void SetDefaultOrdinator(int ordinator) => SetDefaultOrdinator(ordinator.ToString());
        /// <summary>
        /// Get default ordinator
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultOrdinator() => DefaultOrdinator;
        /// <summary>
        /// Set default merchant ID
        /// </summary>
        /// <param name="mid">MID</param>
        public static void SetDefaultMID(string mid) => DefaultMID = mid;
        /// <summary>
        /// Set default merchant ID
        /// </summary>
        /// <param name="mid">MID</param>
        public static void SetDefaultMID(int mid) => DefaultMID = mid.ToString();
        /// <summary>
        /// Get default MID
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultMID() => DefaultMID;
        /// <summary>
        /// Set shop name
        /// </summary>
        /// <param name="shopName">Shop name</param>
        /// <returns></returns>
        public static void SetDefaultMIDShopName(string shopName) => DefaultShopName = shopName;
        /// <summary>
        /// Get default shop name
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultMIDShopName() => DefaultShopName;
        /// <summary>
        /// Set default Notify URL
        /// </summary>
        /// <param name="url"></param>
        public static void SetDefaultNotifyURL(string url) => DefaultNotifyURL = url;
        /// <summary>
        /// Get default notify URL
        /// </summary>
        /// <returns>URL</returns>
        public static string GetDefaultNotifyURL() => DefaultNotifyURL;
        /// <summary>
        /// Set default OK URL
        /// </summary>
        /// <param name="url">URL</param>
        public static void SetDefaultOKURL(string url) => DefaultOKUrl = url;
        /// <summary>
        /// Get defaut OK URL
        /// </summary>
        /// <returns>URL</returns>
        public static string GetDefaultOKURL() => DefaultOKUrl;
        /// <summary>
        /// Set default Cancel URL
        /// </summary>
        /// <param name="url">URL</param>
        public static void SetDefaultCancelURL(string url) => DefaultCancelURL = url;
        /// <summary>
        /// Get default Cancel URL
        /// </summary>
        /// <returns>URL</returns>
        public static string GetDefaultCancelURL() => DefaultCancelURL;
        /// <summary>
        /// Set default URL of form action
        /// </summary>
        /// <param name="url"></param>
        public static void SetDefaultURL(string url) => DefaultURL = url;
        /// <summary>
        /// Get default URL of form action
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultURL() => DefaultURL;

        #endregion

        #region Crypto
        /// <summary>
        /// Get hash
        /// </summary>
        /// <returns></returns>
        protected string GetHash()
        {
            var a = GetMethodValues();
            SHA1 sha = new SHA1CryptoServiceProvider();
            var hash = Encoding.ASCII.GetBytes(a);
            byte[] data = sha.ComputeHash(hash);
            return ByteArrayToString(data);
        }
        /// <summary>
        /// Get metod values
        /// </summary>
        /// <returns></returns>
        protected string GetMethodValues()
        {
            StringBuilder data = new StringBuilder();
            foreach (KeyValuePair<string,string> temp in _properties)
            {
                data.Append(FormatValue(temp.Key, temp.Value));
            }
            data.Append(AddAdditionalValues());
            var a = data.ToString();
            var b = Helper.StripSlashes(a);
            var c = HttpUtility.UrlEncode(b);
            var d = UpperCaseUrlEncode(c);
            return d;
        }
        /// <summary>
        /// Add aditional values
        /// </summary>
        /// <returns></returns>
        protected virtual string AddAdditionalValues()
        {
            return string.Empty;
        }
        /// <summary>
        /// Additional fields
        /// </summary>
        /// <returns></returns>
        protected virtual List<KeyValuePair<string,string>> AddAdditionalFields()
        {
            return new List<KeyValuePair<string, string>>();
        }
        /// <summary>
        /// Sign data
        /// </summary>
        /// <param name="sign"></param>
        /// <returns></returns>
        protected byte[] Sign(string sign = null)
        {
            if(sign == null)
            {
                sign = GetHash();
            }
            byte[] indata = Encoding.UTF8.GetBytes(sign);
            IOpenSSLPrivateKeyDecoder decoder = new OpenSSLPrivateKeyDecoder();
            RSAParameters parameters = decoder.DecodeParameters(PrivateKeyPem);
            RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();
            RSAalg.ImportParameters(parameters);
            var data = RSAalg.SignData(indata, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
            return data;
        }

        /// <summary>
        /// Make encioding with upper key
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        protected static string UpperCaseUrlEncode(string s)
        {
            char[] temp = s.ToCharArray();
            for (int i = 0; i < temp.Length - 2; i++)
            {
                if (temp[i] == '%')
                {
                    temp[i + 1] = char.ToUpper(temp[i + 1]);
                    temp[i + 2] = char.ToUpper(temp[i + 2]);
                }
            }
            return new string(temp);
        }
        /// <summary>
        /// Convert byte array to string
        /// </summary>
        /// <param name="ba"></param>
        /// <returns></returns>
        protected static string ByteArrayToString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "").ToLower();
        }
        #endregion
        /// <summary>
        /// Clear all internal data
        /// </summary>
        [Obsolete("Dont use this method in production. It will broke evrythink!!!",false)]
        public void CleanAll()
        {
            _properties.Clear();
        }

    }
}
