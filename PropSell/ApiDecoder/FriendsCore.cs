using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using PropSell.Models.Dto;
using PropSell.Models.Regular;

namespace PropSell.ApiDecoder
{
    public class FriendsCore
    {
        private HttpClient _httpClient;

        public FriendsCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/FriendsCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a friends to PropSell.TblFriends
        /// </summary>
        /// <param name="friends"></param>
        /// <returns></returns>
        public async Task<DtoTblFriends> AddFriends(TblFriends friends)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/FriendsCore/AddFriends", friends);
            DtoTblFriends ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblFriends>();
            return ans;
        }
        /// <summary>
        /// Deletes a friends from PropSell.TblFriends using its id
        /// </summary>
        /// <param name="friends"></param>
        /// <returns></returns>
        public async Task<bool> DeleteFriends(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/FriendsCore/DeleteFriends?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a friends at PropSell.TblFriends
        /// </summary>
        /// <param name="friends"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateFriends(TblFriends friends, int logId)
        {
            List<object> friendsAndLogId = new List<object>();
            friendsAndLogId.Add(friends);
            friendsAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/FriendsCore/UpdateFriends", friendsAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all friendss from PropSell.TblFriends
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblFriends>> SelectAllFriendss()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/FriendsCore/SelectAllFriendss");
            List<DtoTblFriends> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblFriends>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from PropSell.TblFriends by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TblFriends> SelectFriendsById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/FriendsCore/SelectFriendsById?id={id}", id);
            TblFriends ans = await httpResponseMessage.Content.ReadAsAsync<TblFriends>();
            return ans;
        }
        public async Task<List<DtoTblFriends>> SelectFriendsByMeId(int meId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/FriendsCore/SelectFriendsByMeId?meId={meId}", meId);
            List<DtoTblFriends> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblFriends>>();
            return ans;
        }
        public async Task<List<DtoTblFriends>> SelectFriendsByFriendId(int friendId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/FriendsCore/SelectFriendsByFriendId?friendId={friendId}", friendId);
            List<DtoTblFriends> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblFriends>>();
            return ans;
        }

    }
}