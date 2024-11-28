using System.ComponentModel.DataAnnotations.Schema;

namespace Auctions.Models
{
    public class JeuxVideo
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }       
        public List<JeuxVideoPlateforme>? JeuxVideoPlateformes { get; set; }

        //public string Plateforme { get; set; }
        //public string Genre { get; set; }
        //public string Editeur { get; set; }
        //public string Developpeur { get; set; }
        //public string DateSortie { get; set; }
        //public string Classification { get; set; }
        //public string Prix { get; set; }
        //public int GenreId { get; set; }
        //public Genre Genre { get; set; }
    }
}
