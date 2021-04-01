using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notespace.Web.Models
{
    public class Note
    {
        public long NoteID { get; set; }
        [ForeignKey("NotebookID")]
        public long NotebookID { get; set; }
        [ForeignKey("UserID")]
        public long UserID { get; set; }
        public string Title { get; set; }
        public bool IsPublic { get; set; }
        public string Text { get; set; }
        public string HTML { get; set; }
        public int Order { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastModified { get; set; }
    }
}
