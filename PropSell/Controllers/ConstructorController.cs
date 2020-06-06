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
    [RoutePrefix("api/ConstructorCore")]
    public class ConstructorController : ApiController
    {
        [Route("AddConstructor")]
        [HttpPost]
        public IHttpActionResult AddConstructor(TblConstructor constructor)
        {
            var task = Task.Run(() => new ConstructorService().AddConstructor(constructor));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblConstructor(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteConstructor")]
        [HttpPost]
        public IHttpActionResult DeleteConstructor(int id)
        {
            var task = Task.Run(() => new ConstructorService().DeleteConstructor(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateConstructor")]
        [HttpPost]
        public IHttpActionResult UpdateConstructor(List<object> constructorLogId)
        {
            TblConstructor constructor = JsonConvert.DeserializeObject<TblConstructor>(constructorLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(constructorLogId[1].ToString());
            var task = Task.Run(() => new ConstructorService().UpdateConstructor(constructor, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllConstructors")]
        [HttpGet]
        public IHttpActionResult SelectAllConstructors()
        {
            var task = Task.Run(() => new ConstructorService().SelectAllConstructors());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblConstructor> dto = new List<DtoTblConstructor>();
                    foreach (TblConstructor obj in task.Result)
                        dto.Add(new DtoTblConstructor(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectConstructorById")]
        [HttpPost]
        public IHttpActionResult SelectConstructorById(int id)
        {
            var task = Task.Run(() => new ConstructorService().SelectConstructorById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblConstructor(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectConstructorByTellNo")]
        [HttpPost]
        public IHttpActionResult SelectConstructorByTellNo(string tellNo)
        {
            var task = Task.Run(() => new ConstructorService().SelectConstructorByTellNo(tellNo));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblConstructor(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectConstructorByIdentification")]
        [HttpPost]
        public IHttpActionResult SelectConstructorByIdentification(int identification)
        {
            var task = Task.Run(() => new ConstructorService().SelectConstructorByIdentification(identification));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblConstructor> dto = new List<DtoTblConstructor>();
                    foreach (TblConstructor obj in task.Result)
                        dto.Add(new DtoTblConstructor(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
