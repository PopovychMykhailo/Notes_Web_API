using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Notes.Identity
{

    public static class Configuration
    {
        // Scope (область) - те що клієнтский додаток може використовувати
        // (ідентифікатор для ресурсів. В IdentetiServer це identety і API ресурси).
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("NotesWebApi", "Web API")
            };


        // IdentityResources - дозволяю додатку переглядати інформацію (твердження, claim)
        // про користувача
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile() // Name, birthday
            };


        // ApiResources - доступ до всього захищеного ресурсу. Має окремі області дозволу, до яких
        // клієнт може запросити доступ.
        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("NotesWebApi", "Web API", new[] { JwtClaimTypes.Name })
                {
                    Scopes = { "NotesWebApi" }
                }
            };


        // Settings for clients
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "notes-web-api",
                    ClientName = "Notes Web",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,    // Usial SHA256 string
                    RequirePkce = true,
                    RedirectUris =
                    {
                        "http://.../signin-oidc" 
                    },
                    AllowedCorsOrigins = 
                    { 
                        "http://..." 
                    },
                    PostLogoutRedirectUris = 
                    { 
                        "http://.../signout-oidc" 
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "NotesWebAPI"
                    },
                    AllowAccessTokensViaBrowser = true
                }
            };
    }
}
