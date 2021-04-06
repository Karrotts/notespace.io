using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notespace.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        [DataType(DataType.Date)]
        public DateTime LastLogon { get; set; }
        ICollection<Note> Notes { get; set; }
        ICollection<Notebook> Notebooks { get; set; }
    }
}
