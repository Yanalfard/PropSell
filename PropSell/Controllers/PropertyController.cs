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
    [RoutePrefix("api/PropertyCore")]
    public class PropertyController : ApiController
    {
        [Route("AddProperty")]
        [HttpPost]
        public IHttpActionResult AddProperty(TblProperty property)
        {
            var task = Task.Run(() => new PropertyService().AddProperty(property));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblProperty(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteProperty")]
        [HttpPost]
        public IHttpActionResult DeleteProperty(int id)
        {
            var task = Task.Run(() => new PropertyService().DeleteProperty(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateProperty")]
        [HttpPost]
        public IHttpActionResult UpdateProperty(List<object> propertyLogId)
        {
            TblProperty property = JsonConvert.DeserializeObject<TblProperty>(propertyLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(propertyLogId[1].ToString());
            var task = Task.Run(() => new PropertyService().UpdateProperty(property, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllPropertys")]
        [HttpGet]
        public IHttpActionResult SelectAllPropertys()
        {
            var task = Task.Run(() => new PropertyService().SelectAllPropertys());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblProperty> dto = new List<DtoTblProperty>();
                    foreach (TblProperty obj in task.Result)
                        dto.Add(new DtoTblProperty(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPropertyById")]
        [HttpPost]
        public IHttpActionResult SelectPropertyById(int id)
        {
            var task = Task.Run(() => new PropertyService().SelectPropertyById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblProperty(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPropertyByTitle")]
        [HttpPost]
        public IHttpActionResult SelectPropertyByTitle(string title)
        {
            var task = Task.Run(() => new PropertyService().SelectPropertyByTitle(title));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblProperty> dto = new List<DtoTblProperty>();
                    foreach (TblProperty obj in task.Result)
                        dto.Add(new DtoTblProperty(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPropertyByValid")]
        [HttpPost]
        public IHttpActionResult SelectPropertyByValid(bool valid)
        {
            var task = Task.Run(() => new PropertyService().SelectPropertyByValid(valid));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblProperty> dto = new List<DtoTblProperty>();
                    foreach (TblProperty obj in task.Result)
                        dto.Add(new DtoTblProperty(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPropertyByShowToFriends")]
        [HttpPost]
        public IHttpActionResult SelectPropertyByShowToFriends(bool showToFriends)
        {
            var task = Task.Run(() => new PropertyService().SelectPropertyByShowToFriends(showToFriends));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblProperty> dto = new List<DtoTblProperty>();
                    foreach (TblProperty obj in task.Result)
                        dto.Add(new DtoTblProperty(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPropertyByUserId")]
        [HttpPost]
        public IHttpActionResult SelectPropertyByUserId(int userId)
        {
            var task = Task.Run(() => new PropertyService().SelectPropertyByUserId(userId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblProperty> dto = new List<DtoTblProperty>();
                    foreach (TblProperty obj in task.Result)
                        dto.Add(new DtoTblProperty(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPropertyByCityId")]
        [HttpPost]
        public IHttpActionResult SelectPropertyByCityId(int cityId)
        {
            var task = Task.Run(() => new PropertyService().SelectPropertyByCityId(cityId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblProperty> dto = new List<DtoTblProperty>();
                    foreach (TblProperty obj in task.Result)
                        dto.Add(new DtoTblProperty(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectImageByPropertyId")]
        [HttpPost]
        public IHttpActionResult SelectImageByPropertyId(int propertyId)
        {
            var task = Task.Run(() => new PropertyService().SelectImagesByPropertyId(propertyId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblImage> dto = new List<DtoTblImage>();
                    foreach (TblImage obj in task.Result)
                        dto.Add(new DtoTblImage(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectClientByPropertyId")]
        [HttpPost]
        public IHttpActionResult SelectClientByPropertyId(int propertyId)
        {
            var task = Task.Run(() => new PropertyService().SelectClientsByPropertyId(propertyId));
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
        }        [Route("SelectLatestProperties")]
        [HttpPost]
        public IHttpActionResult SelectLatestProperties(int count)
        {
            var task = Task.Run(() => new PropertyService().SelectLatestProperties(count));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblProperty> dto = new List<DtoTblProperty>();
                    foreach (TblProperty obj in task.Result)
                        dto.Add(new DtoTblProperty(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
    }
}
