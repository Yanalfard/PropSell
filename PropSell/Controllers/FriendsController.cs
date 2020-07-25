using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using PropSell.Models.Dto;
using PropSell.Models.Regular;
using PropSell.Services.Impl;

namespace PropSell.Controllers
{
    [RoutePrefix("api/FriendsCore")]
    public class FriendsController : ApiController
    {
        [Route("AddFriends")]
        [HttpPost]
        public IHttpActionResult AddFriends(TblFriends friends)
        {
            var task = Task.Run(() => new FriendsService().AddFriends(friends));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblFriends(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteFriends")]
        [HttpPost]
        public IHttpActionResult DeleteFriends(int id)
        {
            var task = Task.Run(() => new FriendsService().DeleteFriends(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateFriends")]
        [HttpPost]
        public IHttpActionResult UpdateFriends(List<object> friendsLogId)
        {
            TblFriends friends = JsonConvert.DeserializeObject<TblFriends>(friendsLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(friendsLogId[1].ToString());
            var task = Task.Run(() => new FriendsService().UpdateFriends(friends, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllFriendss")]
        [HttpGet]
        public IHttpActionResult SelectAllFriendss()
        {
            var task = Task.Run(() => new FriendsService().SelectAllFriendss());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblFriends> dto = new List<DtoTblFriends>();
                    foreach (TblFriends obj in task.Result)
                        dto.Add(new DtoTblFriends(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectFriendsById")]
        [HttpPost]
        public IHttpActionResult SelectFriendsById(int id)
        {
            var task = Task.Run(() => new FriendsService().SelectFriendsById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblFriends(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectFriendsByMeId")]
        [HttpPost]
        public IHttpActionResult SelectFriendsByMeId(int meId)
        {
            var task = Task.Run(() => new FriendsService().SelectFriendsByMeId(meId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblFriends> dto = new List<DtoTblFriends>();
                    foreach (TblFriends obj in task.Result)
                        dto.Add(new DtoTblFriends(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectFriendsByFriendId")]
        [HttpPost]
        public IHttpActionResult SelectFriendsByFriendId(int friendId)
        {
            var task = Task.Run(() => new FriendsService().SelectFriendsByFriendId(friendId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblFriends> dto = new List<DtoTblFriends>();
                    foreach (TblFriends obj in task.Result)
                        dto.Add(new DtoTblFriends(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

        [Route("SelectFriendsByFriendIdAndMeId")]
        [HttpPost]
        public IHttpActionResult SelectFriendsByFriendIdAndMeId(List<object> friendIdMeId)
        {
            int friendId = JsonConvert.DeserializeObject<int>(friendIdMeId[0].ToString());
            int meId = JsonConvert.DeserializeObject<int>(friendIdMeId[1].ToString());
            var task = Task.Run(() => new FriendsService().SelectFriendsByFriendIdAndMeId(friendId, meId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblFriends> dto = new List<DtoTblFriends>();
                    foreach (TblFriends obj in task.Result)
                        dto.Add(new DtoTblFriends(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
    }
}
