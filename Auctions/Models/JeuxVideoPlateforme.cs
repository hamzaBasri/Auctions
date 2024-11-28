using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Auctions.Models
{
    public class JeuxVideoPlateforme
    {
        
        public int JeuxVideoId { get; set; }
        public JeuxVideo JeuxVideo { get; set; }
        
        public int PlateformeId { get; set; }
        public Plateforme Plateforme { get; set; }
    }
}
