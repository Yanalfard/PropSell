using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using PropSell.Models.Dto;
using PropSell.Models.Regular;

namespace PropSell.ApiDecoder
{
    public class ProvinceCore
    {
        private HttpClient _httpClient;

        public ProvinceCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/ProvinceCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a province to PropSell.TblProvince
        /// </summary>
        /// <param name="province"></param>
        /// <returns></returns>
        public async Task<DtoTblProvince> AddProvince(TblProvince province)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ProvinceCore/AddProvince", province);
            DtoTblProvince ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblProvince>();
            return ans;
        }
        /// <summary>
        /// Deletes a province from PropSell.TblProvince using its id
        /// </summary>
        /// <param name="province"></param>
        /// <returns></returns>
        public async Task<bool> DeleteProvince(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProvinceCore/DeleteProvince?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a province at PropSell.TblProvince
        /// </summary>
        /// <param name="province"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateProvince(TblProvince province, int logId)
        {
            List<object> provinceAndLogId = new List<object>();
            provinceAndLogId.Add(province);
            provinceAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ProvinceCore/UpdateProvince", provinceAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all provinces from PropSell.TblProvince
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblProvince>> SelectAllProvinces()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/ProvinceCore/SelectAllProvinces");
            List<DtoTblProvince> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblProvince>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from PropSell.TblProvince by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TblProvince> SelectProvinceById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProvinceCore/SelectProvinceById?id={id}", id);
            TblProvince ans = await httpResponseMessage.Content.ReadAsAsync<TblProvince>();
            return ans;
        }
        public async Task<DtoTblProvince> SelectProvinceByName(string name)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProvinceCore/SelectProvinceByName?name={name}", name);
            DtoTblProvince ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblProvince>();
            return ans;
        }

    }
}