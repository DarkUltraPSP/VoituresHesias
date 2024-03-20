namespace Voitures.Shared.Entity
{
    public class Entretien
    {
        public int Id { get; set; }
        public int Kilometrage { get; set; }
        public string? DescritionEntretien { get; set; }

        public int VoitureId { get; set; }
        public Voiture Voiture { get; set; }
    }
}
