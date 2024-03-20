namespace Voitures.Shared.Entity
{
    public class Voiture
    {
        public int Id { get; set; }
        public string? Marque { get; set; }
        public string? Modele { get; set; }
        public string? Immatriculation { get; set; }
        public int Annee { get; set; }
        public int Kilometrage { get; set; }
        public string? Energie { get; set; }

        public List<Entretien> Entretiens { get; set; }
    }
}
