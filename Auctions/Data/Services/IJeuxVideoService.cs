using Auctions.Models;

namespace Auctions.Data.Services
{
    public interface IJeuxVideoService
    {
        IQueryable<JeuxVideo> GetAll();
        Task Add(JeuxVideo jeuxVideo);
    }
}
