using Auctions.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Auctions.Data.Services
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _context;
        public CommentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }



        //public Task<Comment> GetById(int id)
        //{
        //    // Implementation here
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<Comment>> GetAll()
        //{
        //    // Implementation here
        //    throw new NotImplementedException();
        //}


    }
}
