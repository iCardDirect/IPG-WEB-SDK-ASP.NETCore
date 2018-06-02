using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

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
            IPGGatewayAPILibrary.IPGGatewayAPI.SetDefaultCurrency(978);
            IPGGatewayAPILibrary.IPGGatewayAPI.SetDefaultOrdinator(33);
            IPGGatewayAPILibrary.IPGGatewayAPI.SetDefaultKeyIndex(1);
            IPGGatewayAPILibrary.IPGGatewayAPI.SetDefaultLanguage(IPGGatewayAPILibrary.IPGGatewayAPI.Languages.EN);
            IPGGatewayAPILibrary.IPGGatewayAPI.SetDefaultMID(112);
            IPGGatewayAPILibrary.IPGGatewayAPI.SetDefaultMIDShopName("This is my shop");
            IPGGatewayAPILibrary.IPGGatewayAPI.SetDefaultNotifyURL("http://10.64.4.177:5100/ipg/notify");
            IPGGatewayAPILibrary.IPGGatewayAPI.SetDefaultOKURL("http://10.64.4.177:5100/OK");
            IPGGatewayAPILibrary.IPGGatewayAPI.SetDefaultCancelURL("http://10.64.4.177:5100/Cancel");
            IPGGatewayAPILibrary.IPGGatewayAPI.SetDefaultURL("https://devs.icards.eu/ipgtest/");

            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            /*app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(new CultureInfo("en")),
                SupportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("en")
                },
                SupportedUICultures = new List<CultureInfo>
                {
                    new CultureInfo("en")
                }
            });*/

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
