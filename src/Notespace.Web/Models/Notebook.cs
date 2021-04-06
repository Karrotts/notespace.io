using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notespace.Web.Models
{
    public class Notebook
    {
        public long NotebookID { get; set; }
        public string UserID { get; set; }
        public string Title { get; set; }
        public bool IsPublic { get; set; }
        public byte Color { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastModified { get; set; }
        public ICollection<Note> Notes { get; set; }
        public ApplicationUser User { get; set; }
    }
}
