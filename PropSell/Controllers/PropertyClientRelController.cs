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
    [RoutePrefix("api/PropertyClientRelCore")]
    public class PropertyClientRelController : ApiController
    {
        [Route("AddPropertyClientRel")]
        [HttpPost]
        public IHttpActionResult AddPropertyClientRel(TblPropertyClientRel propertyClientRel)
        {
            var task = Task.Run(() => new PropertyClientRelService().AddPropertyClientRel(propertyClientRel));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblPropertyClientRel(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeletePropertyClientRel")]
        [HttpPost]
        public IHttpActionResult DeletePropertyClientRel(int id)
        {
            var task = Task.Run(() => new PropertyClientRelService().DeletePropertyClientRel(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdatePropertyClientRel")]
        [HttpPost]
        public IHttpActionResult UpdatePropertyClientRel(List<object> propertyClientRelLogId)
        {
            TblPropertyClientRel propertyClientRel = JsonConvert.DeserializeObject<TblPropertyClientRel>(propertyClientRelLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(propertyClientRelLogId[1].ToString());
            var task = Task.Run(() => new PropertyClientRelService().UpdatePropertyClientRel(propertyClientRel, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllPropertyClientRels")]
        [HttpGet]
        public IHttpActionResult SelectAllPropertyClientRels()
        {
            var task = Task.Run(() => new PropertyClientRelService().SelectAllPropertyClientRels());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPropertyClientRel> dto = new List<DtoTblPropertyClientRel>();
                    foreach (TblPropertyClientRel obj in task.Result)
                        dto.Add(new DtoTblPropertyClientRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPropertyClientRelById")]
        [HttpPost]
        public IHttpActionResult SelectPropertyClientRelById(int id)
        {
            var task = Task.Run(() => new PropertyClientRelService().SelectPropertyClientRelById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblPropertyClientRel(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPropertyClientRelByPropertyId")]
        [HttpPost]
        public IHttpActionResult SelectPropertyClientRelByPropertyId(int pertyId)
        {
            var task = Task.Run(() => new PropertyClientRelService().SelectPropertyClientRelByPropertyId(pertyId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPropertyClientRel> dto = new List<DtoTblPropertyClientRel>();
                    foreach (TblPropertyClientRel obj in task.Result)
                        dto.Add(new DtoTblPropertyClientRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPropertyClientRelByUserId")]
        [HttpPost]
        public IHttpActionResult SelectPropertyClientRelByUserId(int rId)
        {
            var task = Task.Run(() => new PropertyClientRelService().SelectPropertyClientRelByUserId(rId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPropertyClientRel> dto = new List<DtoTblPropertyClientRel>();
                    foreach (TblPropertyClientRel obj in task.Result)
                        dto.Add(new DtoTblPropertyClientRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPropertyClientRelByStatus")]
        [HttpPost]
        public IHttpActionResult SelectPropertyClientRelByStatus(int tus)
        {
            var task = Task.Run(() => new PropertyClientRelService().SelectPropertyClientRelByStatus(tus));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPropertyClientRel> dto = new List<DtoTblPropertyClientRel>();
                    foreach (TblPropertyClientRel obj in task.Result)
                        dto.Add(new DtoTblPropertyClientRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
