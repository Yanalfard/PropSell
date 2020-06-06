using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using PropSell.Models.Dto;
using PropSell.Models.Regular;

namespace PropSell.ApiDecoder
{
    public class ClientCore
    {
        private HttpClient _httpClient;

        public ClientCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/ClientCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a client to PropSell.TblClient
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public async Task<DtoTblClient> AddClient(TblClient client)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ClientCore/AddClient", client);
            DtoTblClient ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblClient>();
            return ans;
        }
        /// <summary>
        /// Deletes a client from PropSell.TblClient using its id
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public async Task<bool> DeleteClient(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ClientCore/DeleteClient?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a client at PropSell.TblClient
        /// </summary>
        /// <param name="client"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateClient(TblClient client, int logId)
        {
            List<object> clientAndLogId = new List<object>();
            clientAndLogId.Add(client);
            clientAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ClientCore/UpdateClient", clientAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all clients from PropSell.TblClient
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblClient>> SelectAllClients()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/ClientCore/SelectAllClients");
            List<DtoTblClient> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblClient>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from PropSell.TblClient by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TblClient> SelectClientById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ClientCore/SelectClientById?id={id}", id);
            TblClient ans = await httpResponseMessage.Content.ReadAsAsync<TblClient>();
            return ans;
        }
        public async Task<DtoTblClient> SelectClientByTellNo(string tellNo)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ClientCore/SelectClientByTellNo?tellNo={tellNo}", tellNo);
            DtoTblClient ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblClient>();
            return ans;
        }
        public async Task<List<DtoTblClient>> SelectClientByIdentification(int identification)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ClientCore/SelectClientByIdentification?identification={identification}", identification);
            List<DtoTblClient> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblClient>>();
            return ans;
        }

    }
}