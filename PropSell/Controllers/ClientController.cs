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
    [RoutePrefix("api/ClientCore")]
    public class ClientController : ApiController
    {
        [Route("AddClient")]
        [HttpPost]
        public IHttpActionResult AddClient(TblClient client)
        {
            var task = Task.Run(() => new ClientService().AddClient(client));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblClient(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteClient")]
        [HttpPost]
        public IHttpActionResult DeleteClient(int id)
        {
            var task = Task.Run(() => new ClientService().DeleteClient(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateClient")]
        [HttpPost]
        public IHttpActionResult UpdateClient(List<object> clientLogId)
        {
            TblClient client = JsonConvert.DeserializeObject<TblClient>(clientLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(clientLogId[1].ToString());
            var task = Task.Run(() => new ClientService().UpdateClient(client, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllClients")]
        [HttpGet]
        public IHttpActionResult SelectAllClients()
        {
            var task = Task.Run(() => new ClientService().SelectAllClients());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblClient> dto = new List<DtoTblClient>();
                    foreach (TblClient obj in task.Result)
                        dto.Add(new DtoTblClient(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectClientById")]
        [HttpPost]
        public IHttpActionResult SelectClientById(int id)
        {
            var task = Task.Run(() => new ClientService().SelectClientById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblClient(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectClientByTellNo")]
        [HttpPost]
        public IHttpActionResult SelectClientByTellNo(string tellNo)
        {
            var task = Task.Run(() => new ClientService().SelectClientByTellNo(tellNo));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblClient(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectClientByIdentification")]
        [HttpPost]
        public IHttpActionResult SelectClientByIdentification(int identification)
        {
            var task = Task.Run(() => new ClientService().SelectClientByIdentification(identification));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblClient> dto = new List<DtoTblClient>();
                    foreach (TblClient obj in task.Result)
                        dto.Add(new DtoTblClient(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
