using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using PropSell.Models.Regular;

namespace PropSell.Models.Dto
{
    public class DtoTblAdmin
    {
        public int id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public HttpStatusCode StatusEffect { get; set; }

        public DtoTblAdmin(TblAdmin admin, HttpStatusCode statusEffect)
        {
            id = admin.id;
            Username = admin.Username;
            Password = admin.Password;

            StatusEffect = statusEffect;
        }

        public DtoTblAdmin()
        {
            
        }
    }
}