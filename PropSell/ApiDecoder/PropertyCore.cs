using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using PropSell.Models.Dto;
using PropSell.Models.Regular;

namespace PropSell.ApiDecoder
{
    public class PropertyCore
    {
        private HttpClient _httpClient;

        public PropertyCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/PropertyCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a property to PropSell.TblProperty
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public async Task<DtoTblProperty> AddProperty(TblProperty property)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/PropertyCore/AddProperty", property);
            DtoTblProperty ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblProperty>();
            return ans;
        }
        /// <summary>
        /// Deletes a property from PropSell.TblProperty using its id
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public async Task<bool> DeleteProperty(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PropertyCore/DeleteProperty?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a property at PropSell.TblProperty
        /// </summary>
        /// <param name="property"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateProperty(TblProperty property, int logId)
        {
            List<object> propertyAndLogId = new List<object>();
            propertyAndLogId.Add(property);
            propertyAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/PropertyCore/UpdateProperty", propertyAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all propertys from PropSell.TblProperty
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblProperty>> SelectAllPropertys()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/PropertyCore/SelectAllPropertys");
            List<DtoTblProperty> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblProperty>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from PropSell.TblProperty by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TblProperty> SelectPropertyById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PropertyCore/SelectPropertyById?id={id}", id);
            TblProperty ans = await httpResponseMessage.Content.ReadAsAsync<TblProperty>();
            return ans;
        }
        public async Task<List<DtoTblProperty>> SelectPropertyByTitle(string title)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PropertyCore/SelectPropertyByTitle?title={title}", title);
            List<DtoTblProperty> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblProperty>>();
            return ans;
        }
        public async Task<List<DtoTblProperty>> SelectPropertyByValid(bool valid)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PropertyCore/SelectPropertyByValid?valid={valid}", valid);
            List<DtoTblProperty> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblProperty>>();
            return ans;
        }
        public async Task<List<DtoTblProperty>> SelectPropertyByShowToFriends(bool showToFriends)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PropertyCore/SelectPropertyByShowToFriends?showToFriends={showToFriends}", showToFriends);
            List<DtoTblProperty> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblProperty>>();
            return ans;
        }
        public async Task<List<DtoTblProperty>> SelectPropertyByUserId(int userId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PropertyCore/SelectPropertyByUserId?userId={userId}", userId);
            List<DtoTblProperty> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblProperty>>();
            return ans;
        }
        public async Task<List<DtoTblProperty>> SelectPropertyByCityId(int cityId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PropertyCore/SelectPropertyByCityId?cityId={cityId}", cityId);
            List<DtoTblProperty> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblProperty>>();
            return ans;
        }
        public async Task<List<DtoTblImage>> SelectImageByPropertyId(int propertyId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PropertyCore/SelectImageByPropertyId?propertyId={propertyId}", propertyId);
            List<DtoTblImage> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblImage>>();
            return ans;
        }
        public async Task<List<DtoTblClient>> SelectClientByPropertyId(int propertyId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PropertyCore/SelectClientByPropertyId?propertyId={propertyId}", propertyId);
            List<DtoTblClient> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblClient>>();
            return ans;
        }

    }
}