using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Notespace.Web.Data;

namespace Notespace.Web.Models
{
    public class Repository : INotespaceRepository
    {
        private NotespaceDataContext context;

        public Repository (NotespaceDataContext context)
        {
            this.context = context;
        }

        public IQueryable<User> Users => context.User;

        public IQueryable<Notebook> Notebooks => context.Notebook;

        public IQueryable<Note> Notes => context.Note;
    }
}
