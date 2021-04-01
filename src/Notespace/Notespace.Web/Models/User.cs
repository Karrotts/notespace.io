using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notespace.Web.Models
{
    public class User
    {
        public long UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastLogon { get; set; }
    }
}
