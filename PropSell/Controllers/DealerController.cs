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
    [RoutePrefix("api/DealerCore")]
    public class DealerController : ApiController
    {
        [Route("AddDealer")]
        [HttpPost]
        public IHttpActionResult AddDealer(TblDealer dealer)
        {
            var task = Task.Run(() => new DealerService().AddDealer(dealer));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblDealer(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteDealer")]
        [HttpPost]
        public IHttpActionResult DeleteDealer(int id)
        {
            var task = Task.Run(() => new DealerService().DeleteDealer(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateDealer")]
        [HttpPost]
        public IHttpActionResult UpdateDealer(List<object> dealerLogId)
        {
            TblDealer dealer = JsonConvert.DeserializeObject<TblDealer>(dealerLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(dealerLogId[1].ToString());
            var task = Task.Run(() => new DealerService().UpdateDealer(dealer, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllDealers")]
        [HttpGet]
        public IHttpActionResult SelectAllDealers()
        {
            var task = Task.Run(() => new DealerService().SelectAllDealers());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblDealer> dto = new List<DtoTblDealer>();
                    foreach (TblDealer obj in task.Result)
                        dto.Add(new DtoTblDealer(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectDealerById")]
        [HttpPost]
        public IHttpActionResult SelectDealerById(int id)
        {
            var task = Task.Run(() => new DealerService().SelectDealerById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblDealer(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectDealerByTellNo")]
        [HttpPost]
        public IHttpActionResult SelectDealerByTellNo(string tellNo)
        {
            var task = Task.Run(() => new DealerService().SelectDealerByTellNo(tellNo));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblDealer(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectDealerByIdentification")]
        [HttpPost]
        public IHttpActionResult SelectDealerByIdentification(int identification)
        {
            var task = Task.Run(() => new DealerService().SelectDealerByIdentification(identification));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblDealer> dto = new List<DtoTblDealer>();
                    foreach (TblDealer obj in task.Result)
                        dto.Add(new DtoTblDealer(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectDealerByName")]
        [HttpPost]
        public IHttpActionResult SelectDealerByName(string name)
        {
            var task = Task.Run(() => new DealerService().SelectDealerByName(name));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblDealer(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }


        [Route("SelectDealerByTellNoLike")]
        [HttpPost]
        public IHttpActionResult SelectDealerByTellNoLike(string tellNo)
        {
            var task = Task.Run(() => new DealerService().SelectDealerByTellNoLike(tellNo));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblDealer> dto = new List<DtoTblDealer>();
                    foreach (TblDealer obj in task.Result)
                        dto.Add(new DtoTblDealer(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
    }
}
