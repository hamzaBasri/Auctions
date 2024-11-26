using Auctions.Models;

namespace Auctions.Data.Services
{
    public interface IActuService
    {
        IQueryable<Actu> GetAll();
        Task Add(Actu actu);
        Task<Actu> GetById(int id);
    }
}
