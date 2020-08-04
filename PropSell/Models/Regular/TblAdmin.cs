using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropSell.Models.Regular
{
    public class TblAdmin
    {
        public int id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public TblAdmin()
        {
        }

        public TblAdmin(int id, string username, string password)
        {
            this.id = id;
            Username = username;
            Password = password;
        }

        public TblAdmin(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public TblAdmin(int id)
        {
            this.id = id;
        }
    }
}