# iCard.Direct-SDK-ASP.NETCore


1.Create ASP.NET Core 2.0 Web Application

2.Make reference to IPGGatewayAPILibrary 

3.Open Startup.cs and add configuration of api (function ConfigureServices)

3.1.Set private key:
For testing environment you can take them from https://devs.icards.eu/ipgtest/test_keys/
For production env must be given from iCard AD

Example:
```aspx
IPGGatewayAPILibrary.IPGGatewayAPI.SetPrivateKey(@"-----BEGIN RSA PRIVATE KEY-----
MIICXgIBAAKBgQC+NIHevraPmAvx5//z38qjcqlCeyiLwXI5CRNZoL+Ms+/itElM
ITVpaILCBF5+Uwp+A0pPYy/Gn9S+1gz/LL/mBDbWpTuMhHvEgJilX6CsVIah9/c/
Bn8U3gT724aBhyIJeKVLO54pILKlkrKId4w76KDaouaFxyCECBMLaXQZoQIDAQAB
AoGBAI0zVaYSVlzLNzLiU/Srkjc8i8K6wyLc/Pqybhb/arP9cHwP8sn9bTVPTKLT
s4J8CzH5J1VAANunE7yIEyXsBphnr4lfC0ZPVHavPPBfFR/v9QVI1HByhnjihmG9
uPZBuUAm/+s20rPOERepEMBmjpHnA7vTefMbtBXhRKbwszYxAkEA3Nl6ZmAIe50y
yyK3IyCDYitqqQIpMDDTBs8Pn3L+Cen7+a5UXt2+mP87uJSid7m6qK6tQrdKBXgI
TCMf9DZmBwJBANx6a9liZtQBM+GD0vAMZ3kTcBBKQe/c63pPpDBRSbiIgdhKJzcD
lfJoGL6wl2QI2NHhXc9eaH6gVGOsBQYD2RcCQQCVYp4Cpa7XPqve7+qE3jdArjGF
hKqrqDr1/hWJO1VPC3CfoSX8zW1hPDP/VLrY1U7HTvBvkl+Fd33VUmUI4cr9AkAR
PBSgKpwFKI7oqwhbMW0JPua8r0FWQbu6lO0txbzwiuMziCBmoYYgK9j7VwyOik6A
oZBWvHeIpnnSTMkbvkNDAkEAvYoCwTJWAGYUDSSLSN+nP1nmrbyJVSSJMNNQ5974
bBzRvEz9OIgvFL2LslY3kBdwE5JIFacyvDXBVUVqv7MdlQ==
-----END RSA PRIVATE KEY-----");
```
3.2.Set default ordinator:
* For testing use value "33" or check our lastest documentation
* For production - unique identifier for merchant company that has signed a contract with iCard AD.

Example:
```aspx
IPGGatewayAPILibrary.IPGGatewayAPI.SetDefaultOrdinator(33);
```

3.3.Set default currency:
Default API currency is EUR with code 978.
Example:
```aspx
IPGGatewayAPILibrary.IPGGatewayAPI.SetDefaultCurrency(978);
```

3.4.Set default key index (default API key index is 1)
Example:
```aspx
IPGGatewayAPILibrary.IPGGatewayAPI.SetDefaultKeyIndex(1);
```

3.5.Set default language (default API language is EN)
Example:
```aspx
IPGGatewayAPILibrary.IPGGatewayAPI.SetDefaultLanguage(IPGGatewayAPILibrary.IPGGatewayAPI.Languages.EN);
```
3.6.Set default MID
Example:
```aspx
IPGGatewayAPILibrary.IPGGatewayAPI.SetDefaultMID(112);
```
3.7.Set default shop name
Example:
```aspx
IPGGatewayAPILibrary.IPGGatewayAPI.SetDefaultMIDShopName("This is my shop");
```
3.8.Set default notify URL, OK and Cancel URLs (Example for OK, Cancel and notify pages you can find in step 4)

Example:
```aspx
IPGGatewayAPILibrary.IPGGatewayAPI.SetDefaultNotifyURL("http://10.64.4.177:5100/ipg/notify");
IPGGatewayAPILibrary.IPGGatewayAPI.SetDefaultOKURL("http://10.64.4.177:5100/OK");
IPGGatewayAPILibrary.IPGGatewayAPI.SetDefaultCancelURL("http://10.64.4.177:5100/Cancel");
```
3.9.Set form action URL

Development mode:
https://devs.icards.eu/ipgtest/
Production mode:
https://ipg.icard.com/

Example:
```aspx
IPGGatewayAPILibrary.IPGGatewayAPI.SetDefaultURL("https://devs.icards.eu/ipgtest/");
```

3.10.If you have problems with loading you maj need ignore antiforgery token attribute to MVC service

Example:
```aspx

services.AddMvc().AddRazorPagesOptions(options =>
{
    options.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
});
```

4.Create pages

4.1.Create OK and Cancel pages

4.1.1.Add new Razor Page

4.1.2.Set page names

4.1.3.Set layout (/just for example)

4.2.Create controler for notify url

4.2.1.Create folder with name "Controlers"

4.2.2.Add controler with router and custom action 

Example:
```aspx
[Route("ipg")]
public class IPGController : Controller
{
    [HttpPost("notify")]
    [Consumes("application/x-www-form-urlencoded")]
    public string Notify(IPGNotify data)
    {
        if (ModelState.IsValid)
            return "OK";
        else
            return "NotOK";
    }
}
```

Note: If you use localization with format diferent from "en-US" for decimal numbers, you may need to add this code in ASP.NET Core pipeline:

```aspx
app.UseRouter(routes =>
{
    routes.MapMiddlewareRoute("ipg/notify", subApp =>
    {
        var supportedCultures = new[]
        {
            new CultureInfo("en"),
        };
        var localizationOptions = new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture("en"),
            SupportedCultures = supportedCultures,
            SupportedUICultures = supportedCultures
        };
        var requestProvider = new RouteDataRequestCultureProvider();
        localizationOptions.RequestCultureProviders.Insert(0, requestProvider);
        subApp.UseRequestLocalization(localizationOptions);
        subApp.UseMvcWithDefaultRoute();
    });
});
```

5.Create purchase page:

5.1. Create Razor Page

5.2. In model create IPGPurchase object and add cart


Example:

```aspx
IPGPurchase Purchase = new IPGPurchase();

IPGCart cart = new IPGCart("Test Product");
cart.Price = 25.00m;
cart.Quantity = 1;

Purchase.AddCart(cart);
Purchase.Email = "ivelin.ksotov@icard.com";
Purchase.CustomerIP = "10.64.4.177";

data = Purchase.GeneratePage();
```

5.3. Replace contecnt with generated source from object

Example:
```aspx
@page
@model WebApplication1.Pages.PayModel
@{
    Layout = null;
}

@Html.Raw(Model.data)
```