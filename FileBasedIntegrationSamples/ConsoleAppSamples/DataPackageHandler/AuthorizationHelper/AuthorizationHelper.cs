using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationHelper
{
    public class AuthorizationHelper
    {
        const string aadTenant = "https://login.microsoftonline.com/968176fa-1eb8-4608-b9bd-36714706d7c6/oauth2/token";
        public const string aadResource = "https://a2c.sandbox.operations.dynamics.com";
        const string aadClientAppId = "ceef4f2b-c400-4bea-bd98-a13cea4ef474";        
        const string aadClientAppSecret = "zCdM6jvrG._Hyfh87wNG4ju~_fhxx4cK9m";

        /// <summary>
        /// Retrieves an authentication header from the service.
        /// </summary>
        /// <returns>The authentication header for the Web API call.</returns>
        public static string GetAuthenticationHeader()
        {
            AuthenticationContext authenticationContext = new AuthenticationContext(aadTenant);
            AuthenticationResult authenticationResult;
            
            var creadential = new ClientCredential(aadClientAppId, aadClientAppSecret);
            authenticationResult = authenticationContext.AcquireTokenAsync(aadResource, creadential).Result;
            
            // Create and get JWT token
            return authenticationResult.CreateAuthorizationHeader();
        }
    }
}

