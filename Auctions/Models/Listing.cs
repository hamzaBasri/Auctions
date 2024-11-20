using Microsoft.AspNetCore.Identity;

namespace Auctions.Models
{
    public class Listing
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }
        public bool IsSold { get; set; }
        public int IdentityUserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
