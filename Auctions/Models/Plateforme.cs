namespace Auctions.Models
{
    public class Plateforme
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public List<JeuxVideoPlateforme>? JeuxVideoPlateformes { get; set; }
    }
}
