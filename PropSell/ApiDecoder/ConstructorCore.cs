using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using PropSell.Models.Dto;
using PropSell.Models.Regular;

namespace PropSell.ApiDecoder
{
    public class ConstructorCore
    {
        private HttpClient _httpClient;

        public ConstructorCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/ConstructorCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a constructor to PropSell.TblConstructor
        /// </summary>
        /// <param name="constructor"></param>
        /// <returns></returns>
        public async Task<DtoTblConstructor> AddConstructor(TblConstructor constructor)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ConstructorCore/AddConstructor", constructor);
            DtoTblConstructor ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblConstructor>();
            return ans;
        }
        /// <summary>
        /// Deletes a constructor from PropSell.TblConstructor using its id
        /// </summary>
        /// <param name="constructor"></param>
        /// <returns></returns>
        public async Task<bool> DeleteConstructor(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ConstructorCore/DeleteConstructor?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a constructor at PropSell.TblConstructor
        /// </summary>
        /// <param name="constructor"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateConstructor(TblConstructor constructor, int logId)
        {
            List<object> constructorAndLogId = new List<object>();
            constructorAndLogId.Add(constructor);
            constructorAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ConstructorCore/UpdateConstructor", constructorAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all constructors from PropSell.TblConstructor
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblConstructor>> SelectAllConstructors()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/ConstructorCore/SelectAllConstructors");
            List<DtoTblConstructor> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblConstructor>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from PropSell.TblConstructor by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TblConstructor> SelectConstructorById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ConstructorCore/SelectConstructorById?id={id}", id);
            TblConstructor ans = await httpResponseMessage.Content.ReadAsAsync<TblConstructor>();
            return ans;
        }
        public async Task<DtoTblConstructor> SelectConstructorByTellNo(string tellNo)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ConstructorCore/SelectConstructorByTellNo?tellNo={tellNo}", tellNo);
            DtoTblConstructor ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblConstructor>();
            return ans;
        }
        public async Task<List<DtoTblConstructor>> SelectConstructorByIdentification(int identification)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ConstructorCore/SelectConstructorByIdentification?identification={identification}", identification);
            List<DtoTblConstructor> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblConstructor>>();
            return ans;
        }

    }
}