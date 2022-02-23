using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleProducts
{
    public class Config
    {
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                // interactive ASP.NET Core MVC client
                new Client
                {
                    ClientId = "xpo-transport-google-products",
                    ClientSecrets = { new Secret("ZmjiEbj1Wh0nbJzU7iCnkR8LeIYubzJ5ceq9Mt9iEFn4DAcWjLOBqv15AETFPvZ4".Sha256()) },

                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,

                    // where to redirect to after login
                    RedirectUris = { "https://googleproducts20220201151501.azurewebsites.net/signin-oidc" },

                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "https://googleproducts20220201151501.azurewebsites.net/signout-callback-oidc" },

                    AllowedScopes = new List<string>{"openid" , "name"},
                }
            };

        //public static IEnumerable<ApiScope> ApiScopes =>
        //        new List<ApiScope>() { new ApiScope("openid"), 
        //                               new ApiScope("name")};

        //public static IEnumerable<IdentityResource> IdentityResources =>
        //        new List<IdentityResource>() { new IdentityResource( };
    }
}
