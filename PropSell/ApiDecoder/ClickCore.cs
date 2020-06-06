using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using PropSell.Models.Dto;
using PropSell.Models.Regular;

namespace PropSell.ApiDecoder
{
    public class ClickCore
    {
        private HttpClient _httpClient;

        public ClickCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/ClickCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a click to PropSell.TblClick
        /// </summary>
        /// <param name="click"></param>
        /// <returns></returns>
        public async Task<DtoTblClick> AddClick(TblClick click)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ClickCore/AddClick", click);
            DtoTblClick ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblClick>();
            return ans;
        }
        /// <summary>
        /// Deletes a click from PropSell.TblClick using its id
        /// </summary>
        /// <param name="click"></param>
        /// <returns></returns>
        public async Task<bool> DeleteClick(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ClickCore/DeleteClick?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a click at PropSell.TblClick
        /// </summary>
        /// <param name="click"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateClick(TblClick click, int logId)
        {
            List<object> clickAndLogId = new List<object>();
            clickAndLogId.Add(click);
            clickAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ClickCore/UpdateClick", clickAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all clicks from PropSell.TblClick
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblClick>> SelectAllClicks()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/ClickCore/SelectAllClicks");
            List<DtoTblClick> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblClick>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from PropSell.TblClick by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TblClick> SelectClickById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ClickCore/SelectClickById?id={id}", id);
            TblClick ans = await httpResponseMessage.Content.ReadAsAsync<TblClick>();
            return ans;
        }
        public async Task<List<DtoTblClick>> SelectClickByPropertyId(int propertyId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ClickCore/SelectClickByPropertyId?propertyId={propertyId}", propertyId);
            List<DtoTblClick> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblClick>>();
            return ans;
        }

    }
}