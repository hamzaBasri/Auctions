using Auctions.Models;

namespace Auctions.Data.Services
{
    public interface IBidsService
    {
        Task Add(Bid bid);
        Task<Actu> GetById(int id);
        IQueryable<Bid> GetAll();
    }
}
