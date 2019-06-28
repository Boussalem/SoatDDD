namespace Application.model
{
    public class Entretien
    {
        public Creneau Creneau { get; set; }
        public EntretienStatus Status { get; set; }
        public Candidat Candidat { get; set; }
        public ConsultantRecruteur ConsultantRecruteur { get; set; }
        public Salle Salle { get; set; }
    }

    public enum EntretienStatus
    {
        ToBeScheduled = 0,
        Scheduled = 1,
        Done = 2,
        Canceled = 3,
    }
}
