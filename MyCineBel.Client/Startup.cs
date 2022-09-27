using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MyCineBel.Client.Data;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.Client
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
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            })
           .AddCookie()
           .AddOpenIdConnect("Auth0", options =>
           {
                //Set the authority to your Auth0 domain
                options.Authority = $"https://{Configuration["Auth0:Domain"]}";
                //Configure the auth0 Client ID and Client Secret
                options.ClientId = Configuration["Auth0:ClientId"];
               options.ClientSecret = Configuration["Auth0:ClientSecret"];
                //Set the reponse type to code
                options.ResponseType = OpenIdConnectResponseType.Code;
                //Configure the scope
                options.Scope.Clear();
               options.Scope.Add("openid");
               options.Scope.Add("profile");
               options.Scope.Add("read:comptes");
               options.Scope.Add("email");
            
                //options.Scope.Add("read:user_idp_tokens");
                options.CallbackPath = new PathString("/callback");
               options.ClaimsIssuer = "Auth0";
               options.SaveTokens = true;
               options.Events = new OpenIdConnectEvents
               {
                   OnRedirectToIdentityProviderForSignOut = (context) =>
                   {
                       var logoutUri = $"https://{Configuration["Auth0:Domain"]}/v2/logout?client_id={Configuration["Auth0:ClientId"]}";

                       var postLogoutUri = context.Properties.RedirectUri;
                       if (!string.IsNullOrEmpty(postLogoutUri))
                       {
                           if (postLogoutUri.StartsWith("/"))
                           {
                                // transform to absolute
                                var request = context.Request;
                               postLogoutUri = request.Scheme + "://" + request.Host + request.PathBase + postLogoutUri;
                           }
                           logoutUri += $"&returnTo={Uri.EscapeDataString(postLogoutUri)}";
                       }

                       context.Response.Redirect(logoutUri);
                       context.HandleResponse();

                       return Task.CompletedTask;
                   },
                   OnRedirectToIdentityProvider = context =>
                   {
                        //Set the audience query parameter to the API identifier to ensure the retrned Access Tokens can be used
                        // to call protected endpoints on the corresponding API.
                        context.ProtocolMessage.SetParameter("audience", Configuration["Auth0:Audience"]);
                       return Task.FromResult(0);
                   },

                   OnMessageReceived = context =>
                   {
                       if (context.ProtocolMessage.Error == "access_denied")
                       {
                           context.HandleResponse();
                           context.Response.Redirect("/Account/AccessDenied");
                       }
                       return Task.FromResult(0);
                   }

               };
           });

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(100);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddControllersWithViews();
            services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));

           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            StripeConfiguration.ApiKey = "sk_test_51LVduGAO0oCvAgsE8zZ4BpEHbH0xtZA35FPXOHqcIdtW2FuIz4uAwizQWXFZHO9iEmjtT8rHz7B5hjnBtIdEFvsX00l0iPPOpm";

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //if(env.IsDevelopment() || env.IsProduction())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            app.UseHttpsRedirection();
            app.UseCookiePolicy();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                     name: "areas",
                     pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
              );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
