using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Notespace.Web.Data;

namespace Notespace.Web.Models
{
    public class Repository : INotespaceRepository
    {
        private ApplicationIdentityContext context;

        public Repository (ApplicationIdentityContext context)
        {
            this.context = context;
        }

        public IQueryable<Notebook> Notebooks => context.Notebooks;

        public IQueryable<Note> Notes => context.Notes;

        public IQueryable<ApplicationUser> Users => context.Users;
    }
}
