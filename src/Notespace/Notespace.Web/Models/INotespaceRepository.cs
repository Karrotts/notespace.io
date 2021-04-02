using System.Linq;

namespace Notespace.Web.Models
{
    public interface INotespaceRepository
    {
        IQueryable<User> Users { get; }
        IQueryable<Notebook> Notebooks { get; }
        IQueryable<Note> Notes { get; }
    }
}
