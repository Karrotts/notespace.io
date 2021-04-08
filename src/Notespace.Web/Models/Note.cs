using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notespace.Web.Models
{
    public class Note
    {
        public long NoteID { get; set; }
        public long? NotebookID { get; set; }
        public string UserID { get; set; }
        public string Title { get; set; }
        public bool IsPublic { get; set; }
        public string Text { get; set; }
        public string HTML { get; set; }
        public int Order { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastModified { get; set; }
        public Notebook Notebook { get; set; }
        public ApplicationUser User { get; set; }
    }
}
