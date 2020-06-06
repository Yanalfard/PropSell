using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using PropSell.Models.Dto;
using PropSell.Models.Regular;

namespace PropSell.ApiDecoder
{
    public class PropertyClientRelCore
    {
        private HttpClient _httpClient;

        public PropertyClientRelCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/PropertyClientRelCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a propertyClientRel to PropSell.TblPropertyClientRel
        /// </summary>
        /// <param name="propertyClientRel"></param>
        /// <returns></returns>
        public async Task<DtoTblPropertyClientRel> AddPropertyClientRel(TblPropertyClientRel propertyClientRel)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/PropertyClientRelCore/AddPropertyClientRel", propertyClientRel);
            DtoTblPropertyClientRel ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblPropertyClientRel>();
            return ans;
        }
        /// <summary>
        /// Deletes a propertyClientRel from PropSell.TblPropertyClientRel using its id
        /// </summary>
        /// <param name="propertyClientRel"></param>
        /// <returns></returns>
        public async Task<bool> DeletePropertyClientRel(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PropertyClientRelCore/DeletePropertyClientRel?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a propertyClientRel at PropSell.TblPropertyClientRel
        /// </summary>
        /// <param name="propertyClientRel"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdatePropertyClientRel(TblPropertyClientRel propertyClientRel, int logId)
        {
            List<object> propertyClientRelAndLogId = new List<object>();
            propertyClientRelAndLogId.Add(propertyClientRel);
            propertyClientRelAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/PropertyClientRelCore/UpdatePropertyClientRel", propertyClientRelAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all propertyClientRels from PropSell.TblPropertyClientRel
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblPropertyClientRel>> SelectAllPropertyClientRels()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/PropertyClientRelCore/SelectAllPropertyClientRels");
            List<DtoTblPropertyClientRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblPropertyClientRel>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from PropSell.TblPropertyClientRel by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TblPropertyClientRel> SelectPropertyClientRelById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PropertyClientRelCore/SelectPropertyClientRelById?id={id}", id);
            TblPropertyClientRel ans = await httpResponseMessage.Content.ReadAsAsync<TblPropertyClientRel>();
            return ans;
        }
        /// <summary>
        /// Select PropertyClientRels from PropSell.TblPropertyClientRel by propertyId
        /// </summary>
        /// <param name="propertyId"></param>
        /// <returns></returns>
        public async Task<List<DtoTblPropertyClientRel>> SelectPropertyClientRelByPropertyId(int propertyId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PropertyClientRelCore/SelectPropertyClientRelByPropertyId?propertyId={propertyId}", propertyId);
            List<DtoTblPropertyClientRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblPropertyClientRel>>();
            return ans;
        }
        /// <summary>
        /// Select PropertyClientRels from PropSell.TblPropertyClientRel by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<DtoTblPropertyClientRel>> SelectPropertyClientRelByUserId(int userId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PropertyClientRelCore/SelectPropertyClientRelByUserId?userId={userId}", userId);
            List<DtoTblPropertyClientRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblPropertyClientRel>>();
            return ans;
        }
        /// <summary>
        /// Select PropertyClientRels from PropSell.TblPropertyClientRel by status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<List<DtoTblPropertyClientRel>> SelectPropertyClientRelByStatus(int status)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PropertyClientRelCore/SelectPropertyClientRelByStatus?status={status}", status);
            List<DtoTblPropertyClientRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblPropertyClientRel>>();
            return ans;
        }

    }
}