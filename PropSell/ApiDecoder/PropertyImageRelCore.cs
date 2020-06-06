using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using PropSell.Models.Dto;
using PropSell.Models.Regular;

namespace PropSell.ApiDecoder
{
    public class PropertyImageRelCore
    {
        private HttpClient _httpClient;

        public PropertyImageRelCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/PropertyImageRelCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a propertyImageRel to PropSell.TblPropertyImageRel
        /// </summary>
        /// <param name="propertyImageRel"></param>
        /// <returns></returns>
        public async Task<DtoTblPropertyImageRel> AddPropertyImageRel(TblPropertyImageRel propertyImageRel)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/PropertyImageRelCore/AddPropertyImageRel", propertyImageRel);
            DtoTblPropertyImageRel ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblPropertyImageRel>();
            return ans;
        }
        /// <summary>
        /// Deletes a propertyImageRel from PropSell.TblPropertyImageRel using its id
        /// </summary>
        /// <param name="propertyImageRel"></param>
        /// <returns></returns>
        public async Task<bool> DeletePropertyImageRel(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PropertyImageRelCore/DeletePropertyImageRel?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a propertyImageRel at PropSell.TblPropertyImageRel
        /// </summary>
        /// <param name="propertyImageRel"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdatePropertyImageRel(TblPropertyImageRel propertyImageRel, int logId)
        {
            List<object> propertyImageRelAndLogId = new List<object>();
            propertyImageRelAndLogId.Add(propertyImageRel);
            propertyImageRelAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/PropertyImageRelCore/UpdatePropertyImageRel", propertyImageRelAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all propertyImageRels from PropSell.TblPropertyImageRel
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblPropertyImageRel>> SelectAllPropertyImageRels()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/PropertyImageRelCore/SelectAllPropertyImageRels");
            List<DtoTblPropertyImageRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblPropertyImageRel>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from PropSell.TblPropertyImageRel by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TblPropertyImageRel> SelectPropertyImageRelById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PropertyImageRelCore/SelectPropertyImageRelById?id={id}", id);
            TblPropertyImageRel ans = await httpResponseMessage.Content.ReadAsAsync<TblPropertyImageRel>();
            return ans;
        }
        /// <summary>
        /// Select PropertyImageRels from PropSell.TblPropertyImageRel by propertyId
        /// </summary>
        /// <param name="propertyId"></param>
        /// <returns></returns>
        public async Task<List<DtoTblPropertyImageRel>> SelectPropertyImageRelByPropertyId(int propertyId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PropertyImageRelCore/SelectPropertyImageRelByPropertyId?propertyId={propertyId}", propertyId);
            List<DtoTblPropertyImageRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblPropertyImageRel>>();
            return ans;
        }
        /// <summary>
        /// Select PropertyImageRels from PropSell.TblPropertyImageRel by imageId
        /// </summary>
        /// <param name="imageId"></param>
        /// <returns></returns>
        public async Task<List<DtoTblPropertyImageRel>> SelectPropertyImageRelByImageId(int imageId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PropertyImageRelCore/SelectPropertyImageRelByImageId?imageId={imageId}", imageId);
            List<DtoTblPropertyImageRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblPropertyImageRel>>();
            return ans;
        }

    }
}