using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auctions.Models
{
    public class Actu
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Contenu { get; set; }
        //public DateTime DatePublication { get; set; }
        public string Auteur { get; set; }
        public string ImagePath { get; set; }
        //public string VideoUrl { get; set; }
        [Required]
        public string? IdentityUserId { get; set; }
        [ForeignKey("IdentityUserId")]
        public IdentityUser? User { get; set; }
        public List<Comment>? Comments { get; set; }

    }
}
