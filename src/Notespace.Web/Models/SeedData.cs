using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Notespace.Web.Data;
using Microsoft.AspNetCore.Identity;

namespace Notespace.Web.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationIdentityContext context = app.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<ApplicationIdentityContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Notebooks.Any())
            {
                context.Notebooks.AddRange(
                    new Notebook
                    {
                        Title = "Science Stuff",
                        Color = 1,
                        IsPublic = false,
                        LastModified = System.DateTime.Now,
                    },
                    new Notebook
                    {
                        Title = "Math Stuff",
                        Color = 1,
                        IsPublic = false,
                        LastModified = System.DateTime.Now,
                    }
                );
                context.SaveChanges();
            }

            if (!context.Notes.Any())
            {
                context.Notes.AddRange(
                    new Note
                    {
                        Title = "Note Test 1",
                        Text = "## Hello World",
                        HTML = "<h2>Hello World</h2>",
                        IsPublic = false,
                        LastModified = System.DateTime.Now,
                        Order = 0,
                    },
                    new Note
                    {
                        Title = "Note Test 2",
                        Text = "# Hello From Notes",
                        HTML = "<h1>Hello World</h1>",
                        IsPublic = false,
                        LastModified = System.DateTime.Now,
                        Order = 0,
                        NotebookID = context.Notebooks.First().NotebookID
                    }
                );
                context.SaveChanges();
            }
        }
    }

    public class SeedUser
    {
        private const string adminPassword = "Secret123$";
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationIdentityContext context = app.ApplicationServices
            .CreateScope().ServiceProvider
            .GetRequiredService<ApplicationIdentityContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            UserManager<ApplicationUser> userManager = app.ApplicationServices
            .CreateScope().ServiceProvider
            .GetRequiredService<UserManager<ApplicationUser>>();
            ApplicationUser user = await userManager.FindByIdAsync("Karrotts");
            if (user == null)
            {
                user = new ApplicationUser();
                user.UserName = "Karrotts";
                user.Email = "admin@example.com";
                user.PhoneNumber = "555-1234";
                await userManager.CreateAsync(user, adminPassword);
            }
        }
    }
}
