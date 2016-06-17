using Microsoft.BusinessStore.Extensions;
using Microsoft.BusinessStore.Internal;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microsoft.BusinessStore
{
    public class StoreServiceClient
    {
        private const string resource = "https://onestore.microsoft.com";
        private const string baseUri = "https://bspmts.mp.microsoft.com/V1";
        private HttpClient client;


        public StoreServiceClient(string authority, string clientid, string clientSecret)
        {
            var context = new AuthenticationContext(authority);
            var credential = new ClientCredential(clientid, clientSecret);
            var handler = new HttpAuthenticationHandler(resource, context, credential);
            client = new HttpClient(handler);
        }

        public async Task<List<InventoryEntryDetails>> GetInventory(
            DateTime? modifiedSince = null,
            List<LicenseType> licenseTypes = null,
            int maxResults = 25)
        {
            var results = new List<InventoryEntryDetails>();
            Func<string, Task<InventoryResultSet>> function = async (token) =>
            {
                var query = QueryString.Create();
                query.AddParameter("continuationToken", token);
                query.AddParameter("modifiedSince", modifiedSince);
                query.AddParameter("maxResults", maxResults);
                query.AddParameters("licenseTypes", licenseTypes);
                var url = $"{baseUri}/Inventory?{query.ToString()}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsAsync<InventoryResultSet>();
                return result;
            };
            string continuationtoken = null;
            do
            {
                var output = await Task.Run(() => function(continuationtoken));
                results.AddRange(output.InventoryEntries);
                continuationtoken = output.ContinuationToken;
            } while (continuationtoken != null);
            return results;
        }

        public async Task<ProductDetails> GetProductDetails(
            ProductKey productKey)
        {
            var url = $"{baseUri}/Products/{productKey.ProductId}/{productKey.SkuId}";
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<ProductDetails>();
            return result;
        }

        public async Task<LocalizedProductDetail> GetLocalizedProductDetails(
            ProductKey productKey, string language)
        {
            var url = $"{baseUri}/Products/{productKey.ProductId}/{productKey.SkuId}/LocalizedDetails/{language}";
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<LocalizedProductDetail>();
            return result;
        }

        public async Task<ProductPackageSet> GetProductPackages(
            ProductKey productKey)
        {
            var url = $"{baseUri}/Products/{productKey.ProductId}/{productKey.SkuId}/Packages";
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<ProductPackageSet>();
            return result;
        }

        public async Task<ProductPackageDetails> GetProductPackage(
            ProductKey productKey, string packageId)
        {
            var url = $"{baseUri}/Products/{productKey.ProductId}/{productKey.SkuId}/Packages/{packageId}";
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<ProductPackageDetails>();
            return result;
        }

        public async Task<List<SeatDetails>> GetSeats(
            ProductKey productKey,
            int maxResults = 25)
        {
            var results = new List<SeatDetails>();
            Func<string, Task<SeatDetailsResultSet>> function = async (token) =>
            {
                var query = QueryString.Create();
                query.AddParameter("continuationToken", token);
                query.AddParameter("maxResults", maxResults);
                var url = $"{baseUri}/Inventory/{productKey.ProductId}/{productKey.SkuId}/Seats?{query.ToString()}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsAsync<SeatDetailsResultSet>();
                return result;
            };
            string continuationtoken = null;
            do
            {
                var output = await Task.Run(() => function(continuationtoken));
                results.AddRange(output.Seats);
                continuationtoken = output.ContinuationToken;
            } while (continuationtoken != null);
            return results;
        }

        public async Task<SeatDetails> GetSeat(
            ProductKey productKey,
            string username)
        {
            var url = $"{baseUri}/Inventory/{productKey.ProductId}/{productKey.SkuId}/Seats/{username}";
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<SeatDetails>();
            return result;
        }

        public async Task<List<SeatDetails>> GetSeats(
            string username,
            int maxResults = 25)
        {
            var results = new List<SeatDetails>();
            Func<string, Task<SeatDetailsResultSet>> function = async (token) =>
            {
                var query = QueryString.Create();
                query.AddParameter("continuationToken", token);
                query.AddParameter("maxResults", maxResults);
                var url = $"{baseUri}/Users/{username}/Seats?{query.ToString()}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsAsync<SeatDetailsResultSet>();
                return result;
            };
            string continuationtoken = null;
            do
            {
                var output = await Task.Run(() => function(continuationtoken));
                results.AddRange(output.Seats);
                continuationtoken = output.ContinuationToken;
            } while (continuationtoken != null);
            return results;
        }

        public async Task<BulkSeatOperationResultSet> ChangeSeats(
            ProductKey productKey,
            SeatAction action,
            params string[] userNames
            )
        {
            var url = $"{baseUri}/Inventory/{productKey.ProductId}/{productKey.SkuId}/Seats";
            var json = new
            {
                UserNames = userNames,
                seatAction = action
            };
            var response = await client.PostAsJsonAsync(url, json);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<BulkSeatOperationResultSet>();
            return result;
        }
    }
}
