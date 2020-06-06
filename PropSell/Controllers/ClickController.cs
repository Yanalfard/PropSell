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
    [RoutePrefix("api/ClickCore")]
    public class ClickController : ApiController
    {
        [Route("AddClick")]
        [HttpPost]
        public IHttpActionResult AddClick(TblClick click)
        {
            var task = Task.Run(() => new ClickService().AddClick(click));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblClick(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteClick")]
        [HttpPost]
        public IHttpActionResult DeleteClick(int id)
        {
            var task = Task.Run(() => new ClickService().DeleteClick(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateClick")]
        [HttpPost]
        public IHttpActionResult UpdateClick(List<object> clickLogId)
        {
            TblClick click = JsonConvert.DeserializeObject<TblClick>(clickLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(clickLogId[1].ToString());
            var task = Task.Run(() => new ClickService().UpdateClick(click, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllClicks")]
        [HttpGet]
        public IHttpActionResult SelectAllClicks()
        {
            var task = Task.Run(() => new ClickService().SelectAllClicks());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblClick> dto = new List<DtoTblClick>();
                    foreach (TblClick obj in task.Result)
                        dto.Add(new DtoTblClick(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectClickById")]
        [HttpPost]
        public IHttpActionResult SelectClickById(int id)
        {
            var task = Task.Run(() => new ClickService().SelectClickById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblClick(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectClickByPropertyId")]
        [HttpPost]
        public IHttpActionResult SelectClickByPropertyId(int propertyId)
        {
            var task = Task.Run(() => new ClickService().SelectClickByPropertyId(propertyId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblClick> dto = new List<DtoTblClick>();
                    foreach (TblClick obj in task.Result)
                        dto.Add(new DtoTblClick(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
