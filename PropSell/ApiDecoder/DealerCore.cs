using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using PropSell.Models.Dto;
using PropSell.Models.Regular;

namespace PropSell.ApiDecoder
{
    public class DealerCore
    {
        private HttpClient _httpClient;

        public DealerCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/DealerCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a dealer to PropSell.TblDealer
        /// </summary>
        /// <param name="dealer"></param>
        /// <returns></returns>
        public async Task<DtoTblDealer> AddDealer(TblDealer dealer)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/DealerCore/AddDealer", dealer);
            DtoTblDealer ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblDealer>();
            return ans;
        }
        /// <summary>
        /// Deletes a dealer from PropSell.TblDealer using its id
        /// </summary>
        /// <param name="dealer"></param>
        /// <returns></returns>
        public async Task<bool> DeleteDealer(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DealerCore/DeleteDealer?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a dealer at PropSell.TblDealer
        /// </summary>
        /// <param name="dealer"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateDealer(TblDealer dealer, int logId)
        {
            List<object> dealerAndLogId = new List<object>();
            dealerAndLogId.Add(dealer);
            dealerAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/DealerCore/UpdateDealer", dealerAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all dealers from PropSell.TblDealer
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblDealer>> SelectAllDealers()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/DealerCore/SelectAllDealers");
            List<DtoTblDealer> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblDealer>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from PropSell.TblDealer by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TblDealer> SelectDealerById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DealerCore/SelectDealerById?id={id}", id);
            TblDealer ans = await httpResponseMessage.Content.ReadAsAsync<TblDealer>();
            return ans;
        }
        public async Task<DtoTblDealer> SelectDealerByTellNo(string tellNo)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DealerCore/SelectDealerByTellNo?tellNo={tellNo}", tellNo);
            DtoTblDealer ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblDealer>();
            return ans;
        }
        public async Task<List<DtoTblDealer>> SelectDealerByIdentification(int identification)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DealerCore/SelectDealerByIdentification?identification={identification}", identification);
            List<DtoTblDealer> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblDealer>>();
            return ans;
        }
        public async Task<DtoTblDealer> SelectDealerByName(string name)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DealerCore/SelectDealerByName?name={name}", name);
            DtoTblDealer ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblDealer>();
            return ans;
        }

    }
}