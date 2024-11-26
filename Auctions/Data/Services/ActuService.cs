using Auctions.Models;
using Microsoft.EntityFrameworkCore;

namespace Auctions.Data.Services
{
    public class ActuService : IActuService
    {
        private readonly ApplicationDbContext _context;
        public ActuService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(Actu actu)
        {
            _context.Actus.Add(actu);
            await _context.SaveChangesAsync();
        }
        public IQueryable<Actu> GetAll()
        {
            var applicationDbContext = _context.Actus.Include(l => l.User);
            return applicationDbContext;
        }
        public async Task<Actu> GetById(int id)
        {
            var actu = await _context.Actus
                .Include(l => l.User)
                .Include(l => l.Comments)
                .FirstOrDefaultAsync(l => l.Id == id);
            return actu;
        }
        
    }
}
