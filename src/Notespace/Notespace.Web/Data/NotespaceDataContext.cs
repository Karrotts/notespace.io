using Microsoft.EntityFrameworkCore;
using Notespace.Web.Models;

namespace Notespace.Web.Data
{
    public class NotespaceDataContext : DbContext
    {
        public NotespaceDataContext (DbContextOptions<NotespaceDataContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Note> Note { get; set; }
        public DbSet<Notebook> Notebook { get; set; }
    }
}
