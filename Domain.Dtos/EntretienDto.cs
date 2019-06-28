namespace Application.Dtos
{
    public class EntretienDto
    {
        public CreneauDto Creneau { get; set; }
        public EntretienStatusDto Status { get; set; }
        public CandidatDto Candidat { get; set; }
        public ConsultantRecruteurDto ConsultantRecruteur { get; set; }
    }

    public enum EntretienStatusDto
    {
        ToBeScheduled = 0,
        Scheduled = 1,
        Done = 2,
        Canceled = 3,
        NoScheduleAvailable = 4,
    }
}