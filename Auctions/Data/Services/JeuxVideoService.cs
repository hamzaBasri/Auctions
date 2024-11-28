using Auctions.Models;
using Microsoft.EntityFrameworkCore;

namespace Auctions.Data.Services
{
    public class JeuxVideoService : IJeuxVideoService
    {
        private readonly ApplicationDbContext _context;
        public JeuxVideoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<JeuxVideo> GetAll()
        {
            return _context.JeuxVideos;
        }

        public async Task Add(JeuxVideo jeuxVideo)
        {
            await _context.JeuxVideos.AddAsync(jeuxVideo);
            await _context.SaveChangesAsync();
        }
    }
}
