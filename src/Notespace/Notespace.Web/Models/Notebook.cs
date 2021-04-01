using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notespace.Web.Models
{
    public class Notebook
    {
        public long NotebookID { get; set; }
        [ForeignKey("UserID")]
        public long UserID { get; set; }
        public bool IsPublic { get; set; }
        public byte Color { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastModified { get; set; }
    }
}
