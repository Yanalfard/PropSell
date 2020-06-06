using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using PropSell.Models.Dto;
using PropSell.Models.Regular;

namespace PropSell.ApiDecoder
{
    public class CityCore
    {
        private HttpClient _httpClient;

        public CityCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/CityCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a city to PropSell.TblCity
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public async Task<DtoTblCity> AddCity(TblCity city)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/CityCore/AddCity", city);
            DtoTblCity ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblCity>();
            return ans;
        }
        /// <summary>
        /// Deletes a city from PropSell.TblCity using its id
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public async Task<bool> DeleteCity(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/CityCore/DeleteCity?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a city at PropSell.TblCity
        /// </summary>
        /// <param name="city"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateCity(TblCity city, int logId)
        {
            List<object> cityAndLogId = new List<object>();
            cityAndLogId.Add(city);
            cityAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/CityCore/UpdateCity", cityAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all citys from PropSell.TblCity
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblCity>> SelectAllCitys()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/CityCore/SelectAllCitys");
            List<DtoTblCity> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblCity>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from PropSell.TblCity by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TblCity> SelectCityById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/CityCore/SelectCityById?id={id}", id);
            TblCity ans = await httpResponseMessage.Content.ReadAsAsync<TblCity>();
            return ans;
        }
        public async Task<DtoTblCity> SelectCityByName(string name)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/CityCore/SelectCityByName?name={name}", name);
            DtoTblCity ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblCity>();
            return ans;
        }
        public async Task<List<DtoTblCity>> SelectCityByProvinceId(int provinceId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/CityCore/SelectCityByProvinceId?provinceId={provinceId}", provinceId);
            List<DtoTblCity> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblCity>>();
            return ans;
        }

    }
}