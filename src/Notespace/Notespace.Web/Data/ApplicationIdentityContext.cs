using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Notespace.Web.Models;

namespace Notespace.Web.Data
{
    public class ApplicationIdentityContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationIdentityContext(DbContextOptions<ApplicationIdentityContext> options) : base(options) { }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Notebook> Notebooks { get; set; }
    }
}
