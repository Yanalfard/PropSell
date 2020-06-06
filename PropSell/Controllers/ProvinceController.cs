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
    [RoutePrefix("api/ProvinceCore")]
    public class ProvinceController : ApiController
    {
        [Route("AddProvince")]
        [HttpPost]
        public IHttpActionResult AddProvince(TblProvince province)
        {
            var task = Task.Run(() => new ProvinceService().AddProvince(province));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblProvince(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteProvince")]
        [HttpPost]
        public IHttpActionResult DeleteProvince(int id)
        {
            var task = Task.Run(() => new ProvinceService().DeleteProvince(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateProvince")]
        [HttpPost]
        public IHttpActionResult UpdateProvince(List<object> provinceLogId)
        {
            TblProvince province = JsonConvert.DeserializeObject<TblProvince>(provinceLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(provinceLogId[1].ToString());
            var task = Task.Run(() => new ProvinceService().UpdateProvince(province, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllProvinces")]
        [HttpGet]
        public IHttpActionResult SelectAllProvinces()
        {
            var task = Task.Run(() => new ProvinceService().SelectAllProvinces());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblProvince> dto = new List<DtoTblProvince>();
                    foreach (TblProvince obj in task.Result)
                        dto.Add(new DtoTblProvince(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectProvinceById")]
        [HttpPost]
        public IHttpActionResult SelectProvinceById(int id)
        {
            var task = Task.Run(() => new ProvinceService().SelectProvinceById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblProvince(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectProvinceByName")]
        [HttpPost]
        public IHttpActionResult SelectProvinceByName(string name)
        {
            var task = Task.Run(() => new ProvinceService().SelectProvinceByName(name));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblProvince(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
