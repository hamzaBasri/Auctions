using Auctions.Models;

namespace Auctions.Data.Services
{
    public interface ICommentService
    {
        //Task<Comment> GetById(int id);
        //Task<IEnumerable<Comment>> GetAll();
        Task Add(Comment comment);
    }
}
