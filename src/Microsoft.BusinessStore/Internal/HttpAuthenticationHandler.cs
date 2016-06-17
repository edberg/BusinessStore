using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http.Headers;

namespace Microsoft.BusinessStore.Internal
{
    internal class HttpAuthenticationHandler : DelegatingHandler
    {
        private const string AuthScheme = "bearer";
        private readonly string resource;
        private readonly AuthenticationContext context;
        private readonly ClientCredential credential;

        public HttpAuthenticationHandler(string resource, AuthenticationContext context, ClientCredential credential)
        {
            this.resource = resource;
            this.context = context;
            this.credential = credential;
            this.InnerHandler = new HttpClientHandler();
        }

        private async Task<string> GetToken()
        {
            var token = await context.AcquireTokenAsync(resource, credential);
            return token.AccessToken;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await GetToken();
            request.Headers.Authorization = new AuthenticationHeaderValue(AuthScheme, token);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}