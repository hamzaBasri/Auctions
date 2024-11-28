using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auctions.Models
{
    public class JeuxVideoVM
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
