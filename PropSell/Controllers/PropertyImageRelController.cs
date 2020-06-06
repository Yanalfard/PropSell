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
    [RoutePrefix("api/PropertyImageRelCore")]
    public class PropertyImageRelController : ApiController
    {
        [Route("AddPropertyImageRel")]
        [HttpPost]
        public IHttpActionResult AddPropertyImageRel(TblPropertyImageRel propertyImageRel)
        {
            var task = Task.Run(() => new PropertyImageRelService().AddPropertyImageRel(propertyImageRel));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblPropertyImageRel(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeletePropertyImageRel")]
        [HttpPost]
        public IHttpActionResult DeletePropertyImageRel(int id)
        {
            var task = Task.Run(() => new PropertyImageRelService().DeletePropertyImageRel(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdatePropertyImageRel")]
        [HttpPost]
        public IHttpActionResult UpdatePropertyImageRel(List<object> propertyImageRelLogId)
        {
            TblPropertyImageRel propertyImageRel = JsonConvert.DeserializeObject<TblPropertyImageRel>(propertyImageRelLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(propertyImageRelLogId[1].ToString());
            var task = Task.Run(() => new PropertyImageRelService().UpdatePropertyImageRel(propertyImageRel, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllPropertyImageRels")]
        [HttpGet]
        public IHttpActionResult SelectAllPropertyImageRels()
        {
            var task = Task.Run(() => new PropertyImageRelService().SelectAllPropertyImageRels());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPropertyImageRel> dto = new List<DtoTblPropertyImageRel>();
                    foreach (TblPropertyImageRel obj in task.Result)
                        dto.Add(new DtoTblPropertyImageRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPropertyImageRelById")]
        [HttpPost]
        public IHttpActionResult SelectPropertyImageRelById(int id)
        {
            var task = Task.Run(() => new PropertyImageRelService().SelectPropertyImageRelById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblPropertyImageRel(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPropertyImageRelByPropertyId")]
        [HttpPost]
        public IHttpActionResult SelectPropertyImageRelByPropertyId(int pertyId)
        {
            var task = Task.Run(() => new PropertyImageRelService().SelectPropertyImageRelByPropertyId(pertyId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPropertyImageRel> dto = new List<DtoTblPropertyImageRel>();
                    foreach (TblPropertyImageRel obj in task.Result)
                        dto.Add(new DtoTblPropertyImageRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPropertyImageRelByImageId")]
        [HttpPost]
        public IHttpActionResult SelectPropertyImageRelByImageId(int geId)
        {
            var task = Task.Run(() => new PropertyImageRelService().SelectPropertyImageRelByImageId(geId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPropertyImageRel> dto = new List<DtoTblPropertyImageRel>();
                    foreach (TblPropertyImageRel obj in task.Result)
                        dto.Add(new DtoTblPropertyImageRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
