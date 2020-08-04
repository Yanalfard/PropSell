using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using PropSell.Models.Dto;
using PropSell.Services.Impl;
using PropSell.Utilities;

namespace PropSell.Controllers
{
    [RoutePrefix("api/AdminCore")]
    public class AdminController : ApiController
    {
        [Route("SelectAdminByUsername")]
        [HttpPost]
        public IHttpActionResult SelectAdminByUsername(string username)
        {
            var task = Task.Run(() => new MainProvider().SelectAdminByUsername(username));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblAdmin(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
