using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Notespace.Web.Data;

namespace Notespace.Web.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            NotespaceDataContext context = app.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<NotespaceDataContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.User.Any())
            {
                context.User.AddRange(
                    new User
                    {
                        Username = "johnsmith12",
                        Password = "aldkjflaksdjf",
                        Email = "jman@tacobell.com",
                        LastLogon = System.DateTime.Now
                    },
                    new User
                    {
                        Username = "janedoeiscool",
                        Password = "aldkjflaksdjf",
                        Email = "jellyfish@hotmail.com",
                        LastLogon = System.DateTime.Now
                    },
                    new User
                    {
                        Username = "wbmill96",
                        Password = "aldkjflaksdjf",
                        Email = "me@memememe.com",
                        LastLogon = System.DateTime.Now
                    },
                    new User
                    {
                        Username = "susancruzan",
                        Password = "aldkjflaksdjf",
                        Email = "miccheck@foreveralone.com",
                        LastLogon = System.DateTime.Now
                    },
                    new User
                    {
                        Username = "dogman",
                        Password = "aldkjflaksdjf",
                        Email = "woof@rurururu.dog",
                        LastLogon = System.DateTime.Now
                    }
                );
                context.SaveChanges();
            }

            if (!context.Notebook.Any())
            {
                context.Notebook.AddRange(
                    new Notebook
                    {
                        Title = "Science Stuff",
                        Color = 1,
                        IsPublic = false,
                        LastModified = System.DateTime.Now,
                        UserID = context.User.First().UserID
                    },
                    new Notebook
                    {
                        Title = "Math Stuff",
                        Color = 1,
                        IsPublic = false,
                        LastModified = System.DateTime.Now,
                        UserID = context.User.First().UserID
                    }
                );
                context.SaveChanges();
            }

            if (!context.Note.Any())
            {
                context.Note.AddRange(
                    new Note
                    {
                        Title = "Note Test 1",
                        Text = "## Hello World",
                        HTML = "<h2>Hello World</h2>",
                        IsPublic = false,
                        LastModified = System.DateTime.Now,
                        Order = 0,
                        UserID = context.User.First().UserID
                    },
                    new Note
                    {
                        Title = "Note Test 2",
                        Text = "# Hello From Notes",
                        HTML = "<h1>Hello World</h1>",
                        IsPublic = false,
                        LastModified = System.DateTime.Now,
                        Order = 0,
                        UserID = context.User.First().UserID,
                        NotebookID = context.Notebook.First().NotebookID
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
